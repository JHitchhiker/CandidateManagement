$(function () {
    var idx = 0;
    var id = 0;
    var delName = "";
    var source =
            {
                datatype: "json",
                datafields: [
                    { name : 'Interviewer', type: 'string'},
                    { name : 'CXD', type: 'int'},
                    { name : 'Decline', type: 'int'},
                    { name : 'EXPREQ', type: 'int'},
                    { name : 'NOSHOW', type: 'int'},
                    { name : 'NTU', type: 'int'},
                    { name : 'Pending', type: 'int'},
                    { name : 'Reschedule', type: 'int'},
                    { name : 'SIGNEDUP', type: 'int'},
                    { name : 'T2No', type: 'int'},
                    { name : 'T2POTENTIAL', type: 'int'},
                    { name : 'T2Yes', type: 'int'},
                    { name : 'TOTAL', type: 'int'},
                    { name: 'PERCENTAGE', type: 'double' },
                    { name: 'NSP', type: 'int' },
                    { name : 'SIGNUPPERCENTAGE', type: 'double'}
                ],
                url: '../Report/GetInterviewerClosures',
                id: 'Id'
            };
    var dataAdapter = new $.jqx.dataAdapter(source);

    var basicDemo = (function () {
        //Creating all page elements which are jqxWidgets
        function _createElements() {
            $("#grid").jqxDataTable(
            {
                width: '100%',
                theme: 'metro',
                source: dataAdapter,
                pageSize: 20,
                pageable: true,

                columns: [
                    { text: 'Interviewer', datafield: 'Interviewer', width: '6.7%' },
                    { text : 'CXD', datafield: 'CXD', width:'6.7%', cellsalign: 'right'},
                    { text : 'Declined', datafield: 'Decline', width:'6.7%', cellsalign: 'right'},
                    { text : 'EXPREQ', datafield: 'EXPREQ', width:'6.7%', cellsalign: 'right'},
                    { text : 'NO SHOW', datafield: 'NOSHOW', width:'6.7%', cellsalign: 'right'},
                    { text : 'NTU', datafield: 'NTU', width:'6.7%', cellsalign: 'right'},
                    { text : 'Pending', datafield: 'Pending', width:'6.7%', cellsalign: 'right'},
                    { text : 'Reschedule', datafield: 'Reschedule', width:'6.7%', cellsalign: 'right'},
                    { text : 'SIGNEDUP', datafield: 'SIGNEDUP', width:'6.7%', cellsalign: 'right'},
                    { text : 'T2No', datafield: 'T2No', width:'6.7%', cellsalign: 'right'},
                    { text : 'T2POTENTIAL', datafield: 'T2POTENTIAL', width:'6.7%', cellsalign: 'right'},
                    { text : 'T2Yes', datafield: 'T2Yes', width:'6.7%', cellsalign: 'right'},
                    { text : 'TOTAL', datafield: 'TOTAL', width:'6.7%', cellsalign: 'right'},
                    { text: '%', datafield: 'PERCENTAGE', width: '6.7%', cellsformat: 'p', cellsalign: 'right' },
                    { text: 'NSP', datafield: 'NSP', width: '6.7%', cellsalign: 'right' },
                    { text : 'Sign Up %', datafield: 'SIGNUPPERCENTAGE',  cellsformat: 'p', width:'6.7%', cellsalign: 'right'}
                ],
                showtoolbar: true,
                rendertoolbar: function (toolbar) {
                    var gridTitle = "<div style='width: 100%; height: 100%; text-align: center;'><b>INTERVIEWER CLOSURE RATES</b></div>";
                    toolbar.append(gridTitle);
                }
            });
        };

        return {
            config: {
                dragArea: null
            },
            init: function () {
                _createElements();
            }
        };
    }());
    $(document).ready(function () {
        //Initializing the demo
        basicDemo.init();
    });
});