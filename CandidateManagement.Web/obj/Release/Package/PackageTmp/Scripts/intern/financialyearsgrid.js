$(function () {
    var idx = 0;
    var id = 0;
    var startDate;
    var endDate;
    

    var source =
            {
                datatype: "json",
                datafields: [
					 { name: 'Id', type: 'int' },
					 { name: 'Year', type: 'string' },
					 { name: 'StartDate', type: 'date' },
                     { name: 'EndDate', type: 'date' }
                ],
                url: '../Admin/GetFinancialYears',
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
                var data = { year: $("#financialyear").val(), startDate: startDate, endDate: endDate };
                $.ajax({
                    url: '../Admin/NewFinancialYear',
                    data: data,
                    type: "POST",
                    error: errfunc
                });
                function errfunc(data) { alert(data); }
                $('#addwindow').jqxWindow('close');
                $("#grid").jqxDataTable('updateBoundData');
            });

            $('#startdate').on('valueChanged', function (event) {
                startDate = $('#startdate').val();
            });
            $('#enddate').on('valueChanged', function (event) {
                endDate = $('#enddate').val();
            });
            $('#startdate').on('close', function (event) {
                startDate = $('#startdate').val();
            });
            $('#signupdate').on('close', function (event) {
                endDate = $('#enddate').val();
            });
        };
        //Creating all page elements which are jqxWidgets
        function _createElements() {
            $("#grid").jqxGrid(
            {
                width: '100%',
                source: dataAdapter,
                theme: 'bite',
                pageSize: 15,
                sortable: true,
                filterable:true,
                showfilterrow: true,
                pageable: true,
                showtoolbar: true,
                rendertoolbar: function (toolbar) {
                    var gridTitle = "<div style='width: 100%; height: 100%; text-align: center;'><b>FINACIAL YEARS</b></div>";
                    toolbar.append(gridTitle);
                },
                columns: [
                    { text: 'Id', datafield: 'Id', editable: false, visible: false },
                    { text: 'Financial Year', datafield: 'Year' },
                    { text: 'Start Date', datafield: 'StartDate', cellsformat: 'dd-MM-yyyy' },
                    { text: 'End Date', datafield: 'EndDate', cellsformat: 'dd-MM-yyyy' }
                ],
            });
            $('#grid').on('rowClick',
                function (event) {
                    idx = args.index;
                    id = $("#grid").jqxDataTable('getCellValue', idx, 'Id');
                });
            $('#addButton').jqxButton({ width: '100px',theme:'bite' });
            $('#addsaveButton').jqxButton({ width: '70px', theme: 'bite' });

            $("#startdate").jqxDateTimeInput({ width: '250px', height: '25px', formatString: 'dd-MM-yyyy', theme: 'bite' });
            $("#enddate").jqxDateTimeInput({ width: '250px', height: '25px', formatString: 'dd-MM-yyyy', theme: 'bite' });
        };
        //Creating the demo window
        function _createWindow() {
            $('#addwindow').jqxWindow({
                showCollapseButton: true, maxHeight: 200, maxWidth: 700, minHeight: 200, minWidth: 200, height: 300, width: 500,
                autoOpen: false,
                theme:'bite',
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