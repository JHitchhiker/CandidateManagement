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
    
    var basicDemo = (function () {
        //Creating all page elements which are jqxWidgets
        function _createElements() {
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