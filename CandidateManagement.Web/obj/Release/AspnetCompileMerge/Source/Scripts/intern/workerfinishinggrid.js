﻿$(function () {
    var idx = 0;
    var id = 0;
    var delName = "";
    var jobseekdate;
    var leavedate;
    var dateStart;
    var dateEnd;

    var source =
            {
                datatype: "json",
                datafields: [
					 { name: 'Id', type: 'int' },
					 { name: 'FirstName', type: 'string' },
					 { name: 'Surname', type: 'string' },
                     { name: 'ContractEnd', type: 'date' }
                ],
                url: '../Worker/GetFinishingSoon',
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
                var data = { id: id, finishDate: dateEnd };
                $.ajax({
                    url: '../Worker/ConvertToLeaver',
                    data: data,
                    type: "POST",
                    error: errfunc
                });
                function errfunc(data) { alert(data); }
                $('#leaver').jqxWindow('close');
                $('#grid').jqxGrid('updateBoundData');
            });
            $('#confirmrenewal').click(function () {
                var data = { id: id, contractStatus: $("#contractstatus").val(), startDate: dateStart, endDate: dateEnd, agencyName: $("#agencyname").val(), clientName: $("#clientname").val(), comments: $('#comments').val() };
                $.ajax({
                    url: '../Worker/RenewContract',
                    data: data,
                    type: "POST",
                    error: errfunc
                });
                function errfunc(data) { alert(data); }
                $('#renew').jqxWindow('close');
                $('#grid').jqxDataTable('updateBoundData');
            });
            $('#jobseekdate').on('valueChanged', function (event) {
                jobseekdate = $('#jobseekdate').val();
            });
            $('#leavedate').on('valueChanged', function (event) {
                dateEnd = $('#leavedate').val();
            });
            $('#startdate').on('valueChanged', function (event) {
                dateStart = $('#startdate').val();
            });
            $('#enddate').on('valueChanged', function (event) {
                dateEnd = $('#enddate').val();
            });
            $('#jobseekdate').on('close', function (event) {
                jobseekdate = $('#jobseekdate').val();
            });
            $('#leavedate').on('close', function (event) {
                dateEnd = $('#leavedate').val();
            });
            $('#startdate').on('close', function (event) {
                dateStart = $('#startdate').val();
            });
            $('#enddate').on('close', function (event) {
                dateEnd = $('#enddate').val();
            });
            $('#contractstatus').on('select', function (event) {
                var args = event.args;
                if (args) {
                    var item = args.item;
                    $("#contractstatus").val(item.value);
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
                    var gridTitle = "<div style='width: 100%; height: 100%; text-align: center;'><b>CONTRACTS ENDING WITHIN 30 DAYS</b></div>";
                    toolbar.append(gridTitle);
                },
                columns: [
                    { text: 'Id', datafield: 'Id', editable: false, visible: false },
                    { text: 'Name', datafield: 'FirstName' },
					{ text: 'Surname', datafield: 'Surname' },
                    { text: 'Contract End', datafield: 'ContractEnd', cellsformat: 'dd-MM-yyyy' },
                ],
            });
            $('#confirmjobseek').jqxButton({ width: '70px', theme: 'bite' });
            $('#canceljobseek').jqxButton({ width: '70px',theme: 'bite' });
            $('#confirmrenewal').jqxButton({ width: '70px', theme: 'bite' });
            $('#cancelrenewal').jqxButton({ width: '70px', theme: 'bite' });
            $('#confirmleaver').jqxButton({ width: '70px', theme: 'bite' });
            $('#cancelleaver').jqxButton({ width: '70px', theme: 'bite' });

            $("#contractstatus").jqxDropDownList({ source: contractStatusAdapter, displayMember: "Name", valueMember: "Id", theme: 'bite' });

            $("#jobseekdate").jqxDateTimeInput({ width: '250px', height: '25px', formatString: 'dd-MM-yyyy', theme: 'bite' });
            $("#leavedate").jqxDateTimeInput({ width: '250px', height: '25px', formatString: 'dd-MM-yyyy', theme: 'bite' });

            $("#startdate").jqxDateTimeInput({ width: '250px', height: '25px', formatString: 'dd-MM-yyyy',theme: 'bite' });
            $("#enddate").jqxDateTimeInput({ width: '250px', height: '25px', formatString: 'dd-MM-yyyy', theme: 'bite' });
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
            $('#renew').jqxWindow({
                showCollapseButton: true,
                Width: 800,
                Height: 300,
                autoOpen: false,
                theme: 'bite',
                initContent: function () {
                    $('#renew').jqxWindow('focus');
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