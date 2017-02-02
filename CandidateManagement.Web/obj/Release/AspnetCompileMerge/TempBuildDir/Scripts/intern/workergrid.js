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
                     { name: 'ContractStart', type: 'date' },
                     { name: 'ContractEnd', type: 'date' },
                     { name: 'Client', type: 'string' }
                ],
                url: '../Worker/GetWorkers',
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
                    var gridTitle = "<div style='width: 100%; height: 100%; text-align: center;'><b>CURRENTLY ON CONTRACT</b></div>";
                    toolbar.append(gridTitle);
                },
                columns: [
                    { text: 'Id', datafield: 'Id', editable: false, visible: false },
                    { text: 'Name', datafield: 'FirstName' },
					{ text: 'Surname', datafield: 'Surname' },
                    { text: 'Client', datafield: 'Client' },
                    { text: 'Start Date', datafield: 'ContractStart', cellsformat: 'dd-MM-yyyy' },
                    { text: 'Contract End', datafield: 'ContractEnd', cellsformat: 'dd-MM-yyyy' }
                ],
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
            }
        };
    }());
    $(document).ready(function () {
        //Initializing the demo
        basicDemo.init();
    });
});