$(function () {
    var idx = 0;
    var id = 0;
    var delName = "";
    var source =
            {
                datatype: "json",
                datafields: [
					 { name: 'Id', type: 'int' },
					 { name: 'Name', type: 'string' }
                ],
                url: '../Role/GetRoles',
                id: 'Id'
            };
    var dataAdapter = new $.jqx.dataAdapter(source);

    var basicDemo = (function () {
        //Adding event listeners
        function _addEventListeners() {

            
            $('#addButton').click(function () {
                $("#addnameinput").val("");
                $("#adddescinput").val("");
                $('#addwindow').jqxWindow('open');
            });
            $('#addsaveButton').click(function () {
                var data = { name: $("#addnameinput").val() };
                $.ajax({
                    url: '../Role/Create',
                    data: data,
                    type: "POST",
                    error: errfunc
                });
                function errfunc(data) { alert(data); }
                $('#addwindow').jqxWindow('close');
                $("#grid").jqxDataTable('updateBoundData');
            });
            
        };
        //Creating all page elements which are jqxWidgets
        function _createElements() {
            $("#grid").jqxGrid(
            {
                width: '100%',
                height: 660,
                source: dataAdapter,
                theme: 'bite',
                pageSize: 20,
                pageable: true,
                showtoolbar: true,
                rendertoolbar: function (toolbar) {
                    var gridTitle = "<div style='width: 100%; height: 100%; text-align: center;'><b>SYSTEM ROLES</b></div>";
                    toolbar.append(gridTitle);
                },
                columns: [
                    { text: 'Id', datafield: 'Id', editable: false, visible: false },
                    { text: 'Name', datafield: 'Name' }
                ],
            });
            $('#grid').on('rowclick',
                function (event) {
                    idx = args.rowindex;
                    id = $("#grid").jqxGrid('getrowid', idx);
                });
            $('#addButton').jqxButton({ width: '100px',theme:"bite" });
            $('#addsaveButton').jqxButton({ width: '70px', theme:"bite" });
        };
        //Creating the demo window
        function _createWindow() {
            $('#addwindow').jqxWindow({
                showCollapseButton: true, maxHeight: 200, maxWidth: 700, minHeight: 200, minWidth: 200, height: 300, width: 500,
                autoOpen: false,
                theme:"bite",
                initContent: function () {
                    $('#addwindow').jqxWindow('focus');
                }
            });

        };
        return {
            config: {
                dragArea: null
            },
            init: function () {
                //Creating all jqxWindgets except the window
                _createElements();
                //Attaching event listeners
                _addEventListeners();
                //Adding jqxWindow
                _createWindow();
            }
        };
    }());
    $(document).ready(function () {
        //Initializing the demo
        basicDemo.init();
    });
});