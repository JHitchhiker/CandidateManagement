$(function () {
    var idx = 0;
    var id = 0;
    var delName = "";
    var source =
            {
                datatype: "json",
                datafields: [
					 { name: 'WeekEnding', type: 'date' },
					 { name: 'JobSeekers', type: 'int' },
					 { name: 'Working', type: 'int' },
                     { name: 'Leavers', type: 'int' },
                     { name: 'ContractsEnding', type: 'int' },
                     { name: 'NewContracts', type: 'int' },
                     { name: 'ContractsExtending', type: 'int' },
                ],
                url: '../Report/GetWorkingByWeek',
                id: 'Id'
            };
    var dataAdapter = new $.jqx.dataAdapter(source);
    
    var basicDemo = (function () {
        //Creating all page elements which are jqxWidgets
        function _createElements() {
            $("#grid").jqxDataTable(
            {
                width: '100%',
                theme: 'metro',
                source: dataAdapter,
                pageSize: 52,
                sortable: true,
                pageable: true,
                columns: [
                            { text: 'Week Ending', datafield: 'WeekEnding', cellsformat: 'dd-MM-yyyy', align: 'center', cellsalign: 'center', width:'14.3%' },
                            { text: 'Job Seekers', datafield: 'JobSeekers', align: 'center', cellsalign: 'right', width: '14.3%' },
                            { text: 'Working', datafield: 'Working', align: 'center', cellsalign: 'right', width: '14.3%' },
                            { text: 'Leavers', datafield: 'Leavers', align: 'center', cellsalign: 'right', width: '14.3%' },
                            { text: 'Contracts Ending', datafield: 'ContractsEnding', align: 'center', cellsalign: 'right', width: '14.3%' },
                            { text: 'New Contracts', datafield: 'NewContracts', align: 'center', cellsalign: 'right', width: '14.3%' },
                            { text: 'Contract Extensions', datafield: 'ContractsExtending', align: 'center', cellsalign: 'right', width: '14.3%' }
                ],
                showtoolbar: true,
                rendertoolbar: function (toolbar) {
                    var gridTitle = "<div style='width: 100%; height: 100%; text-align: center;'><b>WORKING WEEKLY TOTALS</b></div>";
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