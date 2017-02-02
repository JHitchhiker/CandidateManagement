$(function () {
    var idx = 0;
    var id = 0;
    var delName = "";
    var source =
            {
                datatype: "json",
                datafields: [
					 { name: 'Outcome', type: 'string' },
					 { name: 'Ctr', type: 'int' },
					 { name: 'Percentage', type: 'float' },
                ],
                url: '../Report/GetOutcomeYTD',
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
                pageSize: 15,
                pageable: true,

                columns: [
                            { text: 'Outcome', datafield: 'Outcome', width: '33.33%', align: 'center', cellsalign: 'left' },
                            { text: 'Candidates', datafield: 'Ctr', width: '33.33%', align: 'center', cellsalign: 'right' },
                            { text: '% Candidates', datafield: 'Percentage', width: '33.33%', cellsformat: 'p', align:'center', cellsalign:'right' }
                ],
                showtoolbar: true,
                rendertoolbar: function (toolbar) {
                    var gridTitle = "<div style='width: 100%; height: 100%; text-align: center;'><b>OUTCOMES YTD</b></div>";
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