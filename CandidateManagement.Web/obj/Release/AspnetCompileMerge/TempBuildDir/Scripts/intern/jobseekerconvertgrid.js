$(function () {
    var idx = 0;
    var id = 0;
    var delName = "";
    var dateStart;
    var comments;
    var source =
            {
                datatype: "json",
                datafields: [
					 { name: 'Id', type: 'int' },
					 { name: 'FirstName', type: 'string' },
					 { name: 'Surname', type: 'string' },
                     { name: 'InterviewDate', type: 'date' },
                     { name: 'Description', type: 'string' }
                ],
                url: '../Interviewee/GetSignedUp',
                id: 'Id'
            };
    var dataAdapter = new $.jqx.dataAdapter(source);

    var basicDemo = (function () {
        //Adding event listeners
        function _addEventListeners() {

            $('#confirmOK').click(function () {
                var data = { id: id, startDate: dateStart, comments: $('#comments').val() };
                $.ajax({
                    url: '../JobSeeker/Convert',
                    data: data,
                    type: "POST",
                    error: errfunc
                });
                function errfunc(data) { alert(data); }
                $('#confirm').jqxWindow('close');
                window.location.href='../JobSeeker/Convert';
            });

            $('#startdate').on('valueChanged', function (event) {
                $("#startingdate").val($('#startdate').val());
                dateStart = $('#startdate').val();
            });
            $('#startdate').on('close', function (event) {
                dateStart = $('#startdate').val();
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
                sortable: true,
                filterable: true,
                showfilterrow: true,
                pageable: true,
                showtoolbar: true,
                rendertoolbar: function (toolbar) {
                    var gridTitle = "<div style='width: 100%; height: 100%; text-align: center;'><b>CONVERT TO JOB SEEKER</b></div>";
                    toolbar.append(gridTitle);
                },
                columns: [
                    { text: 'Id', datafield: 'Id', editable: false, visible: false },
                    { text: 'Name', datafield: 'FirstName' },
					{ text: 'Surname', datafield: 'Surname' },
                    { text: 'Interview Date', datafield: 'InterviewDate', cellsformat: 'dd/MM/yyyy' },
                    { text: 'Visa Type', datafield: 'Description' },   
                    { text: 'Convert', datafield: 'Convert', columntype: 'button', cellsrenderer: function () {
                        return "Convert";
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
                    }
                ],
            });
            $('#grid').on('rowClick',
                function (event) {
                    idx = args.index;
                    id = $("#grid").jqxDataTable('getCellValue', idx, 'Id');
                });
            $('#confirmOK').jqxButton({ width: '70px', theme: "bite" });
            $('#confirmCancel').jqxButton({ width: '70px', theme: "bite" });
            $("#startdate").jqxDateTimeInput({ width: '250px', height: '25px', formatString: 'dd-MM-yyyy' });
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