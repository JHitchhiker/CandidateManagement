$(function () {
    var idx = 0;
    var id = 0;
    var delName = "";
    var data;
    var source =
            {
                datatype: "json",
                datafields: [
					 { name: 'Id', type: 'int' },
					 { name: 'UserName', type: 'string' },
                     { name: 'Email', type: 'string' }
                ],
                url: '../User/GetUsers',
                id: 'Id'
            };
    var dataAdapter = new $.jqx.dataAdapter(source);
    var rolesource =
                                    {
                                        datatype: "json",
                                        data: data,
                                        datafields: [
					                            { name: 'Id', type: 'int' },
					                            { name: 'Name', type: 'string' },
                                                { name: 'Enabled', type: 'bool' }
                                        ],
                                        url: '../Role/GetEnableRoles',
                                        id: 'Id'
                                    };
    var roleAdapter = new $.jqx.dataAdapter(rolesource);

    var basicDemo = (function () {
        //Adding event listeners
        function _addEventListeners() {

          
            $('#saveButton').click(function () {
                var roles = $('#rolegrid').jqxGrid('getrows');
                
                for (idx == 0 ; idx < roles.length; idx++)
                {
                    var rowdata = $('#rolegrid').jqxGrid('getrowdata', idx);
                    var data = {userid: id, model: rowdata};
                    $.ajax({
                            url: '../User/UpdateRoles',
                            data: data,
                            type: "POST",
                            error: errfunc
                        });
                }
                function errfunc(data) { alert(data); }
                $('#rolewindow').jqxWindow('close');
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
                    var gridTitle = "<div style='width: 100%; height: 100%; text-align: center;'><b>USERS</b></div>";
                    toolbar.append(gridTitle);
                },
                columns: [
                    { text: 'Id', datafield: 'Id', editable: false, visible: false },
                    { text: 'Username', datafield: 'UserName' },
                    { text: 'Email', datafield: 'Email' }
                ],
            });
            $('#grid').on('rowdoubleclick',
                function (event) {
                    idx = args.rowindex;
                    id = $("#grid").jqxGrid('getrowid', idx, 'Id');
                    var data = { userid: id };
                    var rolesource =
                                    {
                                        datatype: "json",
                                        data: data,
                                        datafields: [
					                            { name: 'Id', type: 'int' },
					                            { name: 'Name', type: 'string' },
                                                { name: 'Enabled', type: 'bool' }
                                        ],
                                        url: '../Role/GetEnableRoles',
                                        id: 'Id'
                                    };
                    var roleAdapter = new $.jqx.dataAdapter(rolesource);
                    roleAdapter.dataBind();
                    $("#rolegrid").jqxGrid({ source: roleAdapter });
                    var val = $("#grid").jqxGrid('getcelltext', idx, 'Name');
                    $("#editnameinput").val(val);
                    val = $("#grid").jqxGrid('getcelltext', idx, 'Description');
                    $("#editdescinput").val(val);
                    $('#rolewindow').jqxWindow('open');
                });
            $('#grid').on('rowclick',
                function (event) {
                    idx = args.rowindex;
                    id = $("#grid").jqxGrid('getrowid', idx);
                });

            $("#rolegrid").jqxGrid(
            {
                width: '100%',
                height: 300,
                source: roleAdapter,
                theme: 'bite',
                pageSize: 20,
                pageable: true,
                showtoolbar: true,
                editable: true,
                rendertoolbar: function (toolbar) {
                    var gridTitle = "<div style='width: 100%; height: 100%; text-align: center;'><b>USERS</b></div>";
                    toolbar.append(gridTitle);
                },
                columns: [
                    { text: 'Id', editable:false, datafield: 'Id', visible: false },
                    { text: 'Name',  editable: false, datafield: 'Name' },
                    { text: 'Enable', datafield: 'Enabled', columntype: 'checkbox'}
                ],
            });
            $('#saveButton').jqxButton({ width: '70px', theme:"bite" });
        };
        //Creating the demo window
        function _createWindow() {
            $('#rolewindow').jqxWindow({
                showCollapseButton: true, maxWidth: 700, minWidth: 200, height: 500, width: 500,
                autoOpen: false,
                theme: "bite",
                initContent: function () {
                    $('#rolewindow').jqxWindow('focus');
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