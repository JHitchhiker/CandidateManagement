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
                     { name: 'InterviewDate', type: 'date' },
                     { name: 'Description', type: 'string' },
                     { name: 'Originator', type: 'string' },
                     { name: 'Interviewer', type: 'string' }
                ],
                url: '../Interviewee/GetInterviewees',
                id: 'Id'
            };
    var dataAdapter = new $.jqx.dataAdapter(source);

    var basicDemo = (function () {
        //Adding event listeners
        function _addEventListeners() {
            $('#delButton').click(function () {
                window.location.href = '../Interviewee/Create';
            });
        };
        //Creating all page elements which are jqxWidgets
        function _createElements() {
            $("#grid").jqxGrid(
            {
                width: '100%',
                height: 720,
                source: dataAdapter,
                theme: 'bite',
                pageSize: 21,
                filterable: true,
                showfilterrow: true,
                pageable: true,

                columns: [
                    { text: 'Id', datafield: 'Id', editable: false},
                    { text: 'First Name', datafield: 'FirstName' },
					{ text: 'Surname', datafield: 'Surname' },
                    { text: 'Interview Date', datafield: 'InterviewDate', cellsformat: 'dd-MM-yyyy' },
                    { text: 'Status', datafield: 'Description' },
                    { text: 'Resourcer', datafield: 'Originator' },
                    { text: 'Interviewer', datafield: 'Interviewer' },
                ],

                showtoolbar: true,
                rendertoolbar: function (toolbar) {
                    var gridTitle = "<div style='width: 100%; height: 100%; text-align: center;'><b>INTERVIEWEES</b></div>";
                    toolbar.append(gridTitle);
                    }
            });
            $('#grid').on('rowdoubleclick',
                function (event) {
                    idx = args.rowindex;
                    id = $("#grid").jqxGrid('getcelltext', idx, 'Id');
                    var data = { id: id };
                    window.location.href ='../Interviewee/Update/' + id;
                });
            $('#grid').on('rowclick',
                function (event) {
                    idx = args.index;
                    id = $("#grid").jqxGrid('getCellValue', idx, 'Id');
                });
            $('#delButton').jqxButton({ width: '70px' });
            
        };
        $("#grid").jqxDataTable('hideColumn', 'Id');

        return {
            config: {
                dragArea: null
            },
            init: function () {
                _createElements();
                _addEventListeners();
            }
        };
    }());
    $(document).ready(function () {
        //Initializing the demo
        basicDemo.init();
    });
});