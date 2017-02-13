$(function () {
    var idx = 0;
    var id = 0;
    var delName = "";
    var source =
            {
                datatype: "json",
                datafields: [
					 { name: 'Id', type: 'int' },
					 { name: 'Name', type: 'string' },
					 { name: 'Description', type: 'string' }
                ],
                url: '../LeavingReason/GetLeavingReasons',
                id: 'Id'
            };
    var dataAdapter = new $.jqx.dataAdapter(source);

    var basicDemo = (function () {
        //Adding event listeners
        function _addEventListeners() {

            $('#delButton').click(function () {
                id = $("#grid").jqxGrid('getrowid', idx);
                delName = $("#grid").jqxGrid('getcelltext', idx, 'Name');
                if (id == null) {
                    alert('Please select a row');
                }
                $('#todelete').text(delName);
                $('#confirm').jqxWindow('open');
            });
            $('#addButton').click(function () {
                $("#addnameinput").val("");
                $("#adddescinput").val("");
                $('#addwindow').jqxWindow('open');
            });
            $('#addsaveButton').click(function () {
                var data = { name: $("#addnameinput").val(), description: $("#adddescinput").val() };
                $.ajax({
                    url: '../LeavingReason/Create',
                    data: data,
                    type: "POST",
                    error: errfunc
                });
                function errfunc(data) { alert(data); }
                $('#addwindow').jqxWindow('close');
                $("#grid").jqxDataTable('updateBoundData');
            });
            $('#editsaveButton').click(function () {
                var data = { id: id, name: $("#editnameinput").val(), description: $("#editdescinput").val() };
                $.ajax({
                    url: '../LeavingReason/Update',
                    data: data,
                    type: "POST",
                    error: errfunc
                });
                function errfunc(data) { alert(data); }
                $('#editwindow').jqxWindow('close');
            });
            $('#confirmOK').click(function () {
                var data = { id: id };
                $.ajax({
                    url: '../LeavingReason/Delete',
                    data: data,
                    type: "POST",
                    error: errfunc
                });
                function errfunc(data) { alert(data); }
                $('#confirm').jqxWindow('close');
                $('#grid').jqxDataTable('updateBoundData');
            });
            $('#confirmCancel').click(function () {
                $('#confirm').jqxWindow('close');
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
                pageSize: 22,
                showtoolbar: true,
                rendertoolbar: function (toolbar) {
                    var gridTitle = "<div style='width: 100%; height: 100%; text-align: center;'><b>BITE SERVICES</b></div>";
                    toolbar.append(gridTitle);
                },
                columns: [
                    { text: 'Id', datafield: 'Id', editable: false, visible: false },
                    { text: 'Name', datafield: 'Name' },
                    { text: 'Description', datafield: 'Description' }
                ],
            });
            $('#grid').on('rowdoubleclick',
                function (event) {
                    idx = args.rowindex;
                    id = $("#grid").jqxGrid('getrowid', idx, 'Id');
                    var val = $("#grid").jqxGrid('getcelltext', idx, 'Name');
                    $("#editnameinput").val(val);
                    val = $("#grid").jqxGrid('getcelltext', idx, 'Description');
                    $("#editdescinput").val(val);
                    $('#editwindow').jqxWindow('open');
                });
            $('#grid').on('rowclick',
                function (event) {
                    idx = args.rowindex;
                    id = $("#grid").jqxGrid('getrowid', idx);
                });
            
            $('#addButton').jqxButton({ width: '100px', theme: 'bite' });
            $('#addsaveButton').jqxButton({ width: '70px', theme: 'bite' });
            $('#delButton').jqxButton({ width: '100px', theme: 'bite' });
            $('#confirmOK').jqxButton({ width: '70px', theme: 'bite' });
            $('#confirmCancel').jqxButton({ width: '70px', theme: 'bite' });
            $('#editsaveButton').jqxButton({ width: '70px', theme: 'bite' });
            

        };
        //Creating the demo window
        function _createWindow() {
            $('#addwindow').jqxWindow({
                showCollapseButton: true, maxHeight: 200, maxWidth: 700, minHeight: 200, minWidth: 200, height: 300, width: 500,
                autoOpen: false,
                theme: 'bite',
                initContent: function () {
                    $('#addwindow').jqxWindow('focus');
                }
            });
            $('#editwindow').jqxWindow({
                showCollapseButton: true, maxHeight: 400, maxWidth: 700, minHeight: 100, minWidth: 200, height: 125, width: 500,
                autoOpen: false,
                theme: 'bite',
                initContent: function () {
                    $('#editwindow').jqxWindow('focus');
                }
            });
            $('#confirm').jqxWindow({
                showCollapseButton: true,
                Width: 250,
                Height: 75,
                autoOpen: false,
                theme: 'bite',
                initContent: function () {
                    $('#confirm ').jqxWindow('focus');
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