$(function () {
    var averageinterviews = 125.00;
    var interviews = 11;
    var signups = 11;
    var ending = 12;
    var oncontract = 1;
    var outofcontract = 5;
    var labels = { visible: false };
    var successrate = 65.00;
    var daystojob = 1;

    var majorTicks = { size: '10%', interval: 10, visible: false },
        minorTicks = { size: '5%', interval: 2.5, style: { 'stroke-width': 1, stroke: '#aaaaaa' }, visible: false },
        labels = { visible: false };

    var source =
            {
                datatype: "json",
                datafields: [
                    { name: 'Average', type: 'double' },
                    { name: 'Interviews', type: 'int' },
                    { name: 'SignUps', type: 'int' },
                    { name: 'OnContract', type: 'int' },
                    { name: 'NewContracts', type: 'int' },
                    { name: 'EndingSoon', type: 'int' },
                    { name: 'DaysToJob', type: 'double' },
                    { name: 'SuccessRate', type: 'double' },
                    { name: 'JobSeekers', type: 'int' }
                ],
                url: '../Report/GetDashboard',
                id: 'Id'
            };

    var dataAdapter = new $.jqx.dataAdapter(source, {
        loadComplete: function (records) {
            // get data records.
            var records = dataAdapter.records;
            // get the length of the records array.
            var length = records.length;
            // loop through the records and display them in a table.
            for (var i = 0; i < length; i++) {
                var record = records[i];
                averageinterviews = record.Average;
                interviews = record.Interviews;
                signups = record.SignUps;
                ending = record.EndingSoon;
                oncontract = record.OnContract;
                //outofcontract = record.outofcontract;
                successrate = record.SuccessRate;
                daystojob = record.DaysToJob;


                $('#interviewGauge').jqxGauge('value', interviews);
                if (signups == 0)
                {
                    $('#signupGauge').jqxGauge('value', 0);
                }
                else
                {
                    $('#signupGauge').jqxGauge('value', signups / interviews * 100);
                }
                
                $('#successRate').jqxGauge('value', successrate);

                $("#interviews").text(interviews + ' Interviews');
                $("#signups").text(signups + ' Sign Ups');
                $("#oncontract").text(oncontract + ' On Contract');
                $("#endingsoon").text(ending + ' Contracts Ending');
                $("#outofcontract").text(outofcontract + ' Out of Contract');
                $("#daystojob").text(daystojob + ' Days to Placement');
                
                //create an array variable and populate with the 3 stats and pass to knob...
                $('#workingKnob').jqxBarGauge({
                    
                    values: [outofcontract, ending, oncontract], max: oncontract, tooltip: {
                        visible: true, formatFunction: function (value) {
                            var realVal = parseInt(value);
                            return ('Year: 2016<br/>Price Index:' + realVal);
                        },
                    }
                });
            }
        },
        loadError: function (jqXHR, status, error) {
        },
        beforeLoadComplete: function (records) {
        }
    });
    

    var basicDemo = (function () {
        //Creating all page elements which are jqxWidgets
        function _createElements() {

            $("#interviewNav, #statsNav").jqxNavBar({
                height: 40, selectedItem: -1, theme: 'bite'
            });

            $('#interviewGauge').jqxGauge({
                ranges: [{ startValue: 0, endValue: averageinterviews / 3, style: { fill: '#e02629', stroke: '#e02629' }, endWidth: 5, startWidth: 5 },
                         { startValue: averageinterviews / 3, endValue: averageinterviews, style: { fill: '#fbd109', stroke: '#fbd109' }, endWidth: 5, startWidth: 5 },
                         { startValue: averageinterviews, endValue: averageinterviews * 2, style: { fill: '#4bb648', stroke: '#4bb648' }, endWidth: 5, startWidth: 5 }],
                ticksMinor: minorTicks,
                ticksMajor: majorTicks,
                value: interviews,
                min: 0,
                labels: labels,
                max: averageinterviews * 2,
                colorScheme: 'scheme05',
                animationDuration: 1200,
                height: 200
            });
            $('#interviewGauge').on('valueChanging', function (e) {
                $('#interviewValue').text('Interview Performance');
            });
            
            $('#signupGauge').jqxGauge({
                ranges: [{ startValue: '0%', endValue: '12%', style: { fill: '#e02629', stroke: '#e02629' }, endWidth: 5, startWidth: 5 },
                         { startValue: '12.1%', endValue: '32.9%', style: { fill: '#fbd109', stroke: '#fbd109' }, endWidth: 5, startWidth: 5 },
                         { startValue: '33%', endValue: '100%', style: { fill: '#4bb648', stroke: '#4bb648' }, endWidth: 5, startWidth: 5 }],
                ticksMinor: minorTicks,
                ticksMajor: majorTicks,
                value: signups / interviews * 100,
                min: 0,
                labels: labels,
                max: 100,
                colorScheme: 'scheme05',
                animationDuration: 1200,
                height: 200
            });
            $('#signupGauge').on('valueChanging', function (e) {
                $('#signupValue').text(Math.round(e.args.value) + '% Sign Up Rate');
            });
            
            $('#workingKnob').jqxBarGauge({
                colorScheme: "scheme02", height: 350,
                values: [outofcontract, ending, oncontract], max: oncontract, tooltip: {
                    visible: true, formatFunction: function (value) {
                        var realVal = parseInt(value);
                        return ('Year: 2016<br/>Price Index:' + realVal);
                    },
                }
            });

            $('#successRate').jqxGauge({
                labels: labels,
                ticksMinor: minorTicks,
                ticksMajor: majorTicks,
                value: successrate,
                min: 0,
                max: 100,
                colorScheme: 'scheme05',
                animationDuration: 1200,
                height: 200
            });
            $('#successRate').on('valueChanging', function (e) {
                $('#successValue').text(Math.round(e.args.value) + '% Successful Placings');
            });
            
        };

        return {
            config: {
                dragArea: null
            },
            init: function () {
                dataAdapter.dataBind();
                var records = dataAdapter.records;
                // get the length of the records array.
                var length = records.length;
                // loop through the records and display them in a table.
                //for (var i = 0; i < length; i++) {
                //    var record = records[i];
                //    averageinterviews = record.Average;
                //    interviews = record.Interviews;
                //    signups = record.SignUps;
                //    ending = record.EndingSoon;
                //    oncontract = record.OnContract;
                //    outofcontract = record.outofcontract;
                //    successrate = record.SuccessRate;
                //    daystojob = record.DaysToJob;
                //}
                //Creating all jqxWindgets except the window
                _createElements();
            }
        };
    }());
    $(document).ready(function () {
        //Initializing the demo
        dataAdapter.dataBind();
        basicDemo.init();
    });
});