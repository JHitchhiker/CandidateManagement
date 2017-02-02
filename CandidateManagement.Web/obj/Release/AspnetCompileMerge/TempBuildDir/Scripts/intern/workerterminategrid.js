$(function () {
    var idx = 0;
    var id = 0;
    var dateStart;
    var comments;
    var source =
            {
                datatype: "json",
                datafields: [
					 { name: 'Id', type: 'int' },
					 { name: 'FirstName', type: 'string' },
					 { name: 'Surname', type: 'string' },
                     { name: 'ContractEnd', type: 'date' }
                ],
                url: '../Worker/GetWorkers',
                id: 'Id'
            };
    var dataAdapter = new $.jqx.dataAdapter(source);

    var basicDemo = (function () {
        //Adding event listeners
        function _addEventListeners() {
            $('#confirmOK').click(function () {
                var data = { id: id, terminateDate: dateStart, leaver: false };
                $.ajax({
                    url: '../Worker/TerminateWorker',
                    data: data,
                    type: "POST",
                    error: errfunc
                });
                function errfunc(data) { alert(data); }
                $('#confirm').jqxWindow('close');
                window.location.href='../Worker/Terminate';
            });

            $('#confirmleaver').click(function () {
                var data = { id: id, terminateDate: dateStart, leaver: true};
                $.ajax({
                    url: '../Worker/TerminateWorker',
                    data: data,
                    type: "POST",
                    error: errfunc
                });
                function errfunc(data) { alert(data); }
                $('#confirmleaver').jqxWindow('close');
                window.location.href='../Worker/Terminate';
            });

            $('#jobseekdate').on('valueChanged', function (event) {
                dateStart = $('#jobseekdate').val();
            });
            $('#leavedate').on('valueChanged', function (event) {
                dateStart = $('#leavedate').val();
            });
        };
        //Creating all page elements which are jqxWidgets
        function _createElements() {
            $("#grid").jqxGrid(
            {
                width: '100%',
                height: 700,
                source: dataAdapter,
                theme: 'bite',
                pageSize: 20,
                filterable: true,
                showfilterrow: true,
                pageable: true,
                showtoolbar: true,
                rendertoolbar: function (toolbar) {
                    var gridTitle = "<div style='width: 100%; height: 100%; text-align: center;'><b>TERMINATE WORKER</b></div>";
                    toolbar.append(gridTitle);
                },
                columns: [
                    { text: 'Id', datafield: 'Id', align: 'center', editable: false, visible: false },
                    { text: 'Name', datafield: 'FirstName', align: 'center' },
					{ text: 'Surname', datafield: 'Surname', align: 'center' },
                    { text: 'Contract Ending', datafield: 'ContractEnd', cellsformat: 'dd-MM-yyyy', align: 'center' },
                    {
                        text: 'To Job Seeker', align: 'center', datafield: 'JobSeek', columntype: 'button', cellsrenderer: function () {
                        return "Terminate";
                    }, buttonclick: function (row) {
                        // open the popup window when the user clicks a button.
                        editrow = row;

                        // get the clicked row's data and initialize the input fields.
                        var dataRecord = $("#grid").jqxGrid('getrowdata', editrow);
                        id = dataRecord.Id;
                        $("#firstname").val(dataRecord.FirstName);
                        $("#surname").val(dataRecord.Surname);
                        
                        // show the popup window.
                        $("#confirm").jqxWindow('open');
                        }
                    },
                    {
                        text: 'To Leaver', align: 'center', datafield: 'Leaver', columntype: 'button', cellsrenderer: function () {
                            return "Terminate";
                        }, buttonclick: function (row) {
                            // open the popup window when the user clicks a button.
                            editrow = row;

                            // get the clicked row's data and initialize the input fields.
                            var dataRecord = $("#grid").jqxGrid('getrowdata', editrow);
                            id = dataRecord.Id;
                            $("#firstname").val(dataRecord.FirstName);
                            $("#surname").val(dataRecord.Surname);

                            // show the popup window.
                            $("#leaver").jqxWindow('open');
                        }
                    }
                ],
            });
            $('#grid').on('rowClick',
                function (event) {
                    idx = args.index;
                    id = $("#grid").jqxDataTable('getCellValue', idx, 'Id');
                });
            $('#confirmOK').jqxButton({ width: '70px', theme: 'bite' });
            $('#confirmCancel').jqxButton({ width: '70px', theme: 'bite' });
            $('#confirmleaver').jqxButton({ width: '70px', theme: 'bite' });
            $('#confirmleaver').jqxButton({ width: '70px', theme: 'bite' });

            $("#jobseekdate").jqxDateTimeInput({ width: '250px', height: '25px', formatString: 'dd-MM-yyyy', theme: 'bite' });
            $("#leavedate").jqxDateTimeInput({ width: '250px', height: '25px', formatString: 'dd-MM-yyyy', theme: 'bite' });
        };
        $("#grid").jqxDataTable('hideColumn', 'Id');
        //Creating the demo window
        function _createWindow() {

            $('#confirm').jqxWindow({
                showCollapseButton: true,
                Width: 800,
                Height: 300,
                autoOpen: false,
                theme: 'bite',
                initContent: function () {
                    $('#confirm').jqxWindow('focus');
                }
            });

            $('#leaver').jqxWindow({
                showCollapseButton: true,
                Width: 800,
                Height: 300,
                autoOpen: false,
                theme: 'bite',
                initContent: function () {
                    $('#leaver').jqxWindow('focus');
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