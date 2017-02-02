$(function () {
    var idx = 0;
    var id = 0;
    var delName = "";
    var dateStart;
    var dateEnd;

    var comments;
    var source =
            {
                datatype: "json",
                datafields: [
					 { name: 'Id', type: 'int' },
					 { name: 'FirstName', type: 'string' },
					 { name: 'Surname', type: 'string' },
                     { name: 'DateStart', type: 'date' },
                     { name: 'Visa', type: 'string' }
                ],
                url: '../JobSeeker/GetCurrentJobSeekers',
                id: 'Id'
            };
    var dataAdapter = new $.jqx.dataAdapter(source);
    var contractStatusSource =
       {
           datatype: "json",
           datafields: [
                { name: 'Id', type: 'int' },
                { name: 'Name', type: 'string' },
                { name: 'Description', type: 'string' }
           ],
           url: '../ContractStatus/GetContractStatuses',
           id: 'Id'
       };
    var contractStatusAdapter = new $.jqx.dataAdapter(contractStatusSource);

    var basicDemo = (function () {
        //Adding event listeners
        function _addEventListeners() {

            $('#confirmOK').click(function () {
                var data = { id: id, contractStatus: $("#contractstatus").val(), startDate: dateStart, endDate: dateEnd, agencyName: $("#agencyname").val(), clientName: $("#clientname").val(), comments: $('#comments').val() };
                $.ajax({
                    url: '../Worker/Convert',
                    data: data,
                    type: "POST",
                    error: errfunc
                });
                function errfunc(data) { alert(data); }
                $('#confirm').jqxWindow('close');
                window.location.href='../Worker/Convert/';
            });
            $('#confirmCancel').click(function () {
                $('#confirm').jqxWindow('close');
            });
            $('#startdate').on('valueChanged', function (event) {
                $("#startingdate").val($('#contractstart').val());
                dateStart = $('#startdate').val();
            });
            $('#startdate').on('close', function (event) {
                dateStart = $('#startdate').val();
            });
            $('#enddate').on('valueChanged', function (event) {
                dateEnd = $('#enddate').val();
            });
            $('#enddate').on('close', function (event) {
                dateEnd = $('#enddate').val();
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
                pageSize: 21,
                sortable: true,
                filterable: true,
                pageable: true,
                showtoolbar: true,
                showfilterrow: true,
                rendertoolbar: function (toolbar) {
                    var gridTitle = "<div style='width: 100%; height: 100%; text-align: center;'><b>CONVERT TO WORKER</b></div>";
                    toolbar.append(gridTitle);
                },

                columns: [
                    { text: 'Id', datafield: 'Id', editable: false, visible: false },
                    { text: 'Name', datafield: 'FirstName' },
					{ text: 'Surname', datafield: 'Surname' },
                    { text: 'Start Date', datafield: 'DateStart', cellsformat: 'dd-MM-yyyy' },
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
            $('#confirmOK').jqxButton({ width: '70px', theme:'bite' });
            $('#confirmCancel').jqxButton({ width: '70px', theme:'bite' });
            $("#startdate").jqxDateTimeInput({ width: '250px', height: '25px', formatString: 'dd-MM-yyyy', theme:'bite' });
            $("#enddate").jqxDateTimeInput({ width: '250px', height: '25px', formatString: 'dd-MM-yyyy', theme:'bite' });
            $("#contractstatus").jqxDropDownList({ source: contractStatusAdapter, displayMember: "Name", valueMember: "Id", theme:'bite' });
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