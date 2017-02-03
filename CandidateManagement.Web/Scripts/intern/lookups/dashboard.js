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
    var signupRate = 0.00;
    var contractStats = [];
    var repeatRatio = 0.00;
    var repeatValue = 0;

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
                    { name: 'JobSeekers', type: 'int' },
                    { name: 'ConversionRate', type: 'double' },
                    { name: 'YTDInterviews', type: 'double' },
                    { name: 'RepeatContractors', type: 'double' },
                    { name: 'RepeatRatio', type: 'double' },
                    { name: 'OutOfContract', type: 'double' }
                ],
                url: '../Report/GetDashboard',
                id: 'Id'
            };

    var dataAdapter;
    
    
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
                $('#interviewValue').text(Math.round(e.args.value) + ' Interviews');
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
            
            $('#successRate').jqxGauge({
                labels: labels,
                ranges: [{ startValue: 0, endValue: 25, style: { fill: '#e02629', stroke: '#e02629' }, endWidth: 5, startWidth: 5 },
                         { startValue: 25, endValue: 50, style: { fill: '#fbd109', stroke: '#fbd109' }, endWidth: 5, startWidth: 5 },
                         { startValue: 50, endValue: 100, style: { fill: '#4bb648', stroke: '#4bb648' }, endWidth: 5, startWidth: 5 }],
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
            
            $('#repeatRatio').jqxGauge({
                ranges: [{ startValue: 0, endValue: 25, style: { fill: '#e02629', stroke: '#e02629' }, endWidth: 5, startWidth: 5 },
                         { startValue: 25, endValue: 50, style: { fill: '#fbd109', stroke: '#fbd109' }, endWidth: 5, startWidth: 5 },
                         { startValue: 50, endValue: 100, style: { fill: '#4bb648', stroke: '#4bb648' }, endWidth: 5, startWidth: 5 }],
                ticksMinor: minorTicks,
                ticksMajor: majorTicks,
                value: repeatRatio,
                min: 0,
                labels: labels,
                max: 100,
                colorScheme: 'scheme05',
                animationDuration: 1200,
                height: 200
            });
            $('#repeatRatio').on('valueChanging', function (e) {
                $('#repeatratioValue').text(Math.round(e.args.value) + '% Repeat Ratio');
            });

            $('#workingKnob').jqxBarGauge();
        };

        return {
            config: {
                dragArea: null
            },
            init: function () {
                dataAdapter.dataBind();
                _createElements();
            }
        };
    }());
    $(document).ready(function () {
        dataAdapter = new $.jqx.dataAdapter(source, {
            loadComplete: function (records) {
                var records = dataAdapter.records;
                var length = records.length;

                for (var i = 0; i < length; i++) {
                    var record = records[i];
                    averageinterviews = record.Average;
                    interviews = record.Interviews;
                    signups = record.SignUps;
                    ending = record.EndingSoon;
                    oncontract = record.OnContract;
                    outofcontract = record.OutOfContract;
                    successrate = record.SuccessRate;
                    daystojob = record.DaysToJob;
                    signupRate = record.ConversionRate;
                    repeatRatio = record.RepeatRatio;
                    repeatValue = record.RepeatContractors;

                    $('#interviewGauge').jqxGauge('value', interviews);
                    $('#signupGauge').jqxGauge('value', signupRate);
                    $('#successRate').jqxGauge('value', successrate);
                    $('#repeatRatio').jqxGauge('value', repeatRatio);

                    $("#interviews").text(interviews + ' Interviews');
                    $("#signups").text(signups + ' Sign Ups');
                    $("#oncontract").text(oncontract + ' On Contract');
                    $("#endingsoon").text(ending + ' Contracts Ending');
                    $("#outofcontract").text(outofcontract + ' Out of Contract');
                    $("#daystojob").text(daystojob + ' Days to Placement');
                    $("#repeatcontractors").text(repeatValue + ' Repeat Contractors');

                    $('#workingKnob').jqxBarGauge({
                        colorScheme: 'rgb',
                        customColorScheme: {
                            name: 'rgb',
                            colors: ['#e21818', '#fcf535', '#47db30']
                        },
                        height: 350,
                        values: [outofcontract, ending, oncontract], max: oncontract,
                        title: {
                            text: 'Contractor Status',
                            font: {
                                size: 15
                            },
                            verticalAlignment: 'center',
                            margin: 15
                        },
                        tooltip: {
                            visible: true,
                            formatFunction: function (value, index) {
                                var stat;
                                switch (index)
                                {
                                    case 2:
                                        stat = "On Contract";
                                        break;
                                    case 1:
                                        stat = "Ending Soon";
                                        break;
                                    case 0:
                                        stat = "OUT OF CONTRACT";
                                        break;
                                }
                                return (stat + ' ' + value);
                            },
                        }
                    });
                    $('#workingKnob').jqxBarGauge('render');
                }
            },
            loadError: function (jqXHR, status, error) {
            },
            beforeLoadComplete: function (records) {
            }
        });

        

        basicDemo.init();
        
    });
});