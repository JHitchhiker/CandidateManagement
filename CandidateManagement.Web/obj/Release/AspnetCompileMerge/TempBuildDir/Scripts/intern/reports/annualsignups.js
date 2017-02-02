$(function () {
    var idx = 0;
    var id = 0;
    var delName = "";
    var source =
            {
                datatype: "json",
                datafields: [
					 { name: 'FinYear', type: 'string' },
					 { name: 'Apr', type: 'int' },
					 { name: 'May', type: 'int' },
                     { name: 'Jun', type: 'int' },
                     { name: 'Jul', type: 'int' },
                     { name: 'Aug', type: 'int' },
                     { name: 'Sep', type: 'int' },
                     { name: 'HalfYear', type: 'int' },
                     { name: 'Oct', type: 'int' },
					 { name: 'Nov', type: 'int' },
                     { name: 'Dec', type: 'int' },
                     { name: 'Jan', type: 'int' },
                     { name: 'Feb', type: 'int' },
                     { name: 'Mar', type: 'int' },
                     { name: 'Total', type: 'int' },
                     { name: 'Percentage', type: 'decimal' }
                ],
                url: '../Report/GetAnnualSignups',
                id: 'Id'
            };
    var dataAdapter = new $.jqx.dataAdapter(source);
    
    var basicDemo = (function () {
        //Creating all page elements which are jqxWidgets
        function _createElements() {
            $("#grid").jqxDataTable(
            {
                width: '100%',
                altRows: true,
                theme: 'metro',
                source: dataAdapter,
                pageSize: 52,
                pageable: true,
                columns: [
                             { text: '', datafield: 'FinYear', width: 150, align: 'center', cellsalign: 'center' },
					         { text: 'APR', datafield: 'Apr', width: 60, align: 'center', cellsalign: 'right' },
					         { text: 'MAY', datafield: 'May', width: 60, align: 'center', cellsalign: 'right' },
                             { text: 'JUN', datafield: 'Jun', width: 60, align: 'center', cellsalign: 'right' },
                             { text: 'JUL', datafield: 'Jul', width: 60, align: 'center', cellsalign: 'right' },
                             { text: 'AUG', datafield: 'Aug', width: 60, align: 'center', cellsalign: 'right' },
                             { text: 'SEP', datafield: 'Sep', width: 60, align: 'center', cellsalign: 'right' },
                             { text: 'HALF YEAR', datafield: 'HalfYear', width: 80, align: 'center', cellsalign: 'right' },
                             { text: 'OCT', datafield: 'Oct', width: 60, align: 'center', cellsalign: 'right' },
					         { text: 'NOV', datafield: 'Nov', width: 60, align: 'center', cellsalign: 'right' },
                             { text: 'DEC', datafield: 'Dec', width: 60, align: 'center', cellsalign: 'right' },
                             { text: 'JAN', datafield: 'Jan', width: 60, align: 'center', cellsalign: 'right' },
                             { text: 'FEB', datafield: 'Feb', width: 60, align: 'center', cellsalign: 'right' },
                             { text: 'MAR', datafield: 'Mar', width: 60, align: 'center', cellsalign: 'right' },
                             { text: 'TOTAL', datafield: 'Total', width: 60, align: 'center', cellsalign: 'right' },
                             { text: 'SIGNUP %', datafield: 'Percentage', align: 'center', cellsalign: 'right', cellsformat: 'p' }
                ],
                showtoolbar: true,
                rendertoolbar: function (toolbar) {
                    var gridTitle = "<div style='width: 100%; height: 100%; text-align: center;'><b>ANNUAL SIGN UP RATES</b></div>";
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