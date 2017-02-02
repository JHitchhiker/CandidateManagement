$(function () {
    var idx = 0;
    var id = 0;
    var delName = "";
    var source =
            {
                datatype: "json",
                datafields: [
					 { name: 'Id', type: 'int' },
					 { name: 'FirstName', type: 'string' },
					 { name: 'Surname', type: 'string' },
                     { name: 'LeavingDate', type: 'date' }
                ],
                url: '../Leaver/GetLeavers',
                id: 'Id'
            };
    var dataAdapter = new $.jqx.dataAdapter(source);

    var basicDemo = (function () {
        function _createElements() {
            $("#grid").jqxGrid(
            {
                width: '100%',
                height: 700,
                source: dataAdapter,
                theme: 'bite',
                pageSize: 20,
                sortable: true,
                filterable: true,
                showfilterrow: true,
                pageable: true,
                showtoolbar: true,
                rendertoolbar: function (toolbar) {
                    var gridTitle = "<div style='width: 100%; height: 100%; text-align: center;'><b>LEAVERS</b></div>";
                    toolbar.append(gridTitle);
                },
                columns: [
                    { text: 'Id', datafield: 'Id', editable: false, visible: false },
                    { text: 'First Name', datafield: 'FirstName' },
					{ text: 'Surname', datafield: 'Surname' },
                    { text: 'Date Left', datafield: 'LeavingDate', cellsformat: 'yyyy-MM-dd' }
                ],
            });
        };
        $("#grid").jqxDataTable('hideColumn', 'Id');

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