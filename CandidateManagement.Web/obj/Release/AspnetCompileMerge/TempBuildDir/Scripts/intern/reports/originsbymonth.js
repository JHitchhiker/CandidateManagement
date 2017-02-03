$(function () {
    var idx = 0;
    var id = 0;
    var delName = "";
    var source =
            {
                datatype: "json",
                datafields: [
					 { name: 'Origin', type: 'string' },
					 { name: 'Apr', type: 'int' },
					 { name: 'May', type: 'int' },
                     { name: 'Jun', type: 'int' },
					 { name: 'Jul', type: 'int' },
                     { name: 'Aug', type: 'int' },
					 { name: 'Sep', type: 'int' },
                     { name: 'Oct', type: 'int' },
					 { name: 'Nov', type: 'int' },
                     { name: 'Dec', type: 'int' },
					 { name: 'Jan', type: 'int' },
                     { name: 'Feb', type: 'int' },
					 { name: 'Mar', type: 'int' },
                     { name: 'Total', type: 'int' },
                ],
                url: '../Report/GetOriginByMonth',
                id: 'Id'
            };
    var dataAdapter = new $.jqx.dataAdapter(source);
    
    var chartsource =
           {
               datatype: "json",
               datafields: [
                    { name: 'Origin', type: 'string' },
                    { name: 'Apr', type: 'int' },
                    { name: 'May', type: 'int' },
                    { name: 'Jun', type: 'int' },
                    { name: 'Jul', type: 'int' },
                    { name: 'Aug', type: 'int' },
                    { name: 'Sep', type: 'int' },
                    { name: 'Oct', type: 'int' },
                    { name: 'Nov', type: 'int' },
                    { name: 'Dec', type: 'int' },
                    { name: 'Jan', type: 'int' },
                    { name: 'Feb', type: 'int' },
                    { name: 'Mar', type: 'int' },
                    { name: 'Total', type: 'int' },
               ],
               url: '../Report/GetOriginByMonthChart',
               id: 'Id'
           };
    var chartdataAdapter = new $.jqx.dataAdapter(chartsource);

    var basicDemo = (function () {
        //Creating all page elements which are jqxWidgets
        function _createElements() {
            var settings = {
                title: "YTD Interviews Ups By Source",
                description: "",
                enableAnimations: true,
                showLegend: true,
                showBorderLine: true,
                legendLayout: { left: 750, top: 160, width: 300, height: 200, flow: 'vertical' },
                padding: { left: 5, top: 5, right: 5, bottom: 5 },
                titlePadding: { left: 0, top: 0, right: 0, bottom: 10 },
                source: chartdataAdapter,
                colorScheme: 'scheme02',
                seriesGroups:
                    [
                        {
                            type: 'pie',
                            showLabels: true,
                            series:
                                [
                                    {
                                        dataField: 'Total',
                                        displayText: 'Origin',
                                        labelRadius: 240,
                                        initialAngle: 15,
                                        radius: 220,
                                        centerOffset: 0,
                                        offsetX:350,
                                        formatFunction: function (value) {
                                            if (isNaN(value))
                                                return value;
                                            return parseFloat(value);
                                        },
                                    }
                                ]
                        }
                    ]
            };
            // setup the chart
            $('#chartContainer').jqxChart(settings);

            $("#grid").jqxGrid(
            {
                width: '100%',  
                theme: 'metro',
                height: 600,
                source: dataAdapter,
                pageSize: 20,
                pageable: true,

                columns: [
                            { text: 'Origin', datafield: 'Origin', align: 'center', cellsalign: 'left' },
                            { text: 'Apr', datafield: 'Apr', align: 'center', cellsalign: 'right' },
                            { text: 'May', datafield: 'May', align: 'center', cellsalign: 'right' },
                            { text: 'Jun', datafield: 'Jun', align: 'center', cellsalign: 'right' },
                            { text: 'Jul', datafield: 'Jul', align: 'center', cellsalign: 'right' },
                            { text: 'Aug', datafield: 'Aug', align: 'center', cellsalign: 'right' },
                            { text: 'Sep', datafield: 'Sep', align: 'center', cellsalign: 'right' },
                            { text: 'Oct', datafield: 'Oct', align: 'center', cellsalign: 'right'},
                            { text: 'Nov', datafield: 'Nov', align: 'center', cellsalign: 'right' },
                            { text: 'Dec', datafield: 'Dec', align: 'center', cellsalign: 'right' },
                            { text: 'Jan', datafield: 'Jan', align: 'center', cellsalign: 'right' },
                            { text: 'Feb', datafield: 'Feb', align: 'center', cellsalign: 'right' },
                            { text: 'Mar', datafield: 'Mar', align: 'center', cellsalign: 'right' },
                            { text: 'Total', datafield: 'Total', align: 'center', cellsalign: 'right' }
                ],
                showtoolbar: true,
                rendertoolbar: function (toolbar) {
                    var gridTitle = "<div style='width: 100%; height: 100%; text-align: center;'><b>ALL OUTCOMES BY SOURCE</b></div>";
                    toolbar.append(gridTitle);
                }
            });
        };
        
        return {
            config: {
                dragArea: null
            },
            init: function () {
                _createElements();
            }
        };
    }());
    $(document).ready(function () {
        //Initializing the demo
        basicDemo.init();
    });
});