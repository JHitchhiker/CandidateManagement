$(function () {
    var idx = 0;
    var id = 0;
    var delName = "";
    var jobseekdate;
    var leavedate;
    var leavingReasonId;

    var source =
            {
                datatype: "json",
                datafields: [
					 { name: 'Id', type: 'int' },
					 { name: 'FirstName', type: 'string' },
					 { name: 'Surname', type: 'string' },
                     { name: 'ContractEnd', type: 'date' }
                ],
                url: '../Worker/GetOutOfContract',
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
    var leavingSource =
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
    var leavingdataAdapter = new $.jqx.dataAdapter(leavingSource);

    var basicDemo = (function () {
        function _addEventListeners() {
            $('#confirmjobseek').click(function () {
                var data = { id: id, startDate: jobseekdate };
                $.ajax({
                    url: '../Worker/ConvertToJobSeeker',
                    data: data,
                    type: "POST",
                    error: errfunc
                });
                function errfunc(data) { alert(data); }
                $('#jobseeker').jqxWindow('close');
                $('#grid').jqxDataTable('updateBoundData');
            });
            $('#confirmleaver').click(function () {
                var data = { id: id, finishDate: leavedate, leavingReasonId: leavingReasonId };
                $.ajax({
                    url: '../Worker/ConvertToLeaver',
                    data: data,
                    type: "POST",
                    error: errfunc
                });
                function errfunc(data) { alert(data); }
                $('#leaver').jqxWindow('close');
                window.location.href = "../Worker/OutOfContract";
            });
            $('#cancelleaver').click(function () {
                $('#leaver').jqxWindow('close');
            });
            $('#canceljobseek').click(function () {
                $('#jobseeker').jqxWindow('close');
            });
            $('#jobseekdate').on('valueChanged', function (event) {
                jobseekdate = $("#jobseekdate").val();
            });
            $('#leavedate').on('valueChanged', function (event) {
                leavedate = $("#leavedate").val();
            });
            $('#leavingReason').on('select', function (event) {
                var args = event.args;
                if (args) {
                    var item = args.item;
                    leavingReasonId = item.value;
                }
            });
        };
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
                    var gridTitle = "<div style='width: 100%; height: 100%; text-align: center;'><b>CURRENTLY OUT OF CONTRACT</b></div>";
                    toolbar.append(gridTitle);
                },
                columns: [
                    { text: 'Id', datafield: 'Id', editable: false, visible: false },
                    { text: 'Name', datafield: 'FirstName' },
					{ text: 'Surname', datafield: 'Surname' },
                    { text: 'Contract End', datafield: 'ContractEnd', cellsformat: 'dd-MM-yyyy' },
                    {
                        text: 'Job Seek', datafield: 'JobSeek', columntype: 'button', cellsrenderer: function () {
                            return "Job Seek";
                        }, buttonclick: function (row) {
                            // open the popup window when the user clicks a button.
                            editrow = row;

                            // get the clicked row's data and initialize the input fields.
                            var dataRecord = $("#grid").jqxGrid('getrowdata', editrow);
                            id = dataRecord.Id;
                            $("#jobseekfirstname").val(dataRecord.FirstName);
                            $("#jobseeksurname").val(dataRecord.Surname);

                            // show the popup window.
                            $("#jobseeker").jqxWindow('open');
                        }
                    },
                    {
                        text: 'Leaver', datafield: 'Leaver', columntype: 'button', cellsrenderer: function () {
                            return "Leaver";
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
            $('#confirmjobseek').jqxButton({ width: '70px', theme: 'bite' });
            $('#canceljobseek').jqxButton({ width: '70px', theme: 'bite' });
            $('#confirmleaver').jqxButton({ width: '70px', theme: 'bite' });
            $('#cancelleaver').jqxButton({ width: '70px', theme: 'bite' });

            $("#jobseekdate").jqxDateTimeInput({ width: '250px', height: '25px', formatString: 'dd-MM-yyyy', theme: 'bite' });
            $("#leavedate").jqxDateTimeInput({ width: '250px', height: '25px', formatString: 'dd-MM-yyyy', theme: 'bite' });

            $("#leavingReason").jqxDropDownList({ source: leavingdataAdapter, displayMember: "Name", valueMember: "Id" });
        };
        $("#grid").jqxDataTable('hideColumn', 'Id');
        function _createWindow() {

            $('#jobseeker').jqxWindow({
                showCollapseButton: true,
                Width: 800,
                Height: 300,
                autoOpen: false,
                theme: 'bite',
                initContent: function () {
                    $('#jobseeker').jqxWindow('focus');
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
        //Creating the demo window
        return {
            config: {
                dragArea: null
            },
            init: function () {
                //Creating all jqxWindgets except the window
                _createElements();
                _createWindow();
                _addEventListeners();
            }
        };
    }());
    $(document).ready(function () {
        //Initializing the demo
        basicDemo.init();
    });
});