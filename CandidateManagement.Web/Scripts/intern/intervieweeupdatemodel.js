$(document).ready(function () {
    //optional fields

    //datasources
    var visatypeSource =
       {
           datatype: "json",
           datafields: [
                { name: 'Id', type: 'int' },
                { name: 'Name', type: 'string' },
                { name: 'Description', type: 'string' }
           ],
           url: '../../VisaType/GetVisaTypes',
           id: 'Id'
       };
    var visatypeAdapter = new $.jqx.dataAdapter(visatypeSource);
    var ethnicitySource =
       {
           datatype: "json",
           datafields: [
                { name: 'Id', type: 'int' },
                { name: 'Name', type: 'string' },
                { name: 'Description', type: 'string' }
           ],
           url: '../../Ethnicity/GetEthnicities',
           id: 'Id'
       };
    var ethnicityAdapter = new $.jqx.dataAdapter(ethnicitySource);
    var biteserviceSource =
       {
           datatype: "json",
           datafields: [
                { name: 'Id', type: 'int' },
                { name: 'Name', type: 'string' },
                { name: 'Description', type: 'string' }
           ],
           url: '../../BiteService/GetBiteServices',
           id: 'Id'
       };
    var biteserviceAdapter = new $.jqx.dataAdapter(biteserviceSource);
    var originSource =
       {
           datatype: "json",
           datafields: [
                { name: 'Id', type: 'int' },
                { name: 'Name', type: 'string' },
                { name: 'Description', type: 'string' }
           ],
           url: '../../Origin/GetOrigins',
           id: 'Id'
       };
    var originAdapter = new $.jqx.dataAdapter(originSource);
    var originatorSource =
       {
           datatype: "json",
           datafields: [
                { name: 'Id', type: 'int' },
                { name: 'Name', type: 'string' },
                { name: 'Description', type: 'string' }
           ],
           url: '../../Originator/GetOriginators',
           id: 'Id'
       };
    var originatorAdapter = new $.jqx.dataAdapter(originatorSource);
    var professionSource =
       {
           datatype: "json",
           datafields: [
                { name: 'Id', type: 'int' },
                { name: 'Name', type: 'string' },
                { name: 'Description', type: 'string' }
           ],
           url: '../../Profession/GetProfessions',
           id: 'Id'
       };
    var professionAdapter = new $.jqx.dataAdapter(professionSource);
    var skillSource =
       {
           datatype: "json",
           datafields: [
                { name: 'Id', type: 'int' },
                { name: 'Name', type: 'string' },
                { name: 'Description', type: 'string' }
           ],
           url: '../../Skill/GetSkills',
           id: 'Id'
       };
    var skillAdapter = new $.jqx.dataAdapter(skillSource);
    var interviewerSource =
       {
           datatype: "json",
           datafields: [
                { name: 'Id', type: 'int' },
                { name: 'Name', type: 'string' },
                { name: 'Description', type: 'string' }
           ],
           url: '../../Interviewer/GetInterviewers',
           id: 'Id'
       };
    var interviewerAdapter = new $.jqx.dataAdapter(interviewerSource);
    var outcomeSource =
       {
           datatype: "json",
           datafields: [
                { name: 'Id', type: 'int' },
                { name: 'Name', type: 'string' },
                { name: 'Description', type: 'string' }
           ],
           url: '../../Outcome/GetOutcomes',
           id: 'Id'
       };
    var outcomeAdapter = new $.jqx.dataAdapter(outcomeSource);

    //events
    var basicDemo = (function () {
        //Adding event listeners
        function _addEventListeners() {

            $('#visatype').on('select', function (event) {
                var args = event.args;
                if (args) {
                    var item = args.item;
                    $("#VisaTypeId").val(item.value);
                }
            });
            $('#ethnicity').on('select', function (event) {
                var args = event.args;
                if (args) {
                    var item = args.item;
                    $("#EthnicityId").val(item.value);
                }
            });
            $('#biteservice').on('select', function (event) {
                var args = event.args;
                if (args) {
                    var item = args.item;
                    $("#ServiceId").val(item.value);
                }
            });
            $('#origin').on('select', function (event) {
                var args = event.args;
                if (args) {
                    var item = args.item;
                    $("#OriginId").val(item.value);
                }
            });
            $('#originator').on('select', function (event) {
                var args = event.args;
                if (args) {
                    var item = args.item;
                    $("#OriginatorId").val(item.value);
                }
            });
            $('#profession').on('select', function (event) {
                var args = event.args;
                if (args) {
                    var item = args.item;
                    $("#ProfessionId").val(item.value);
                }
            });
            $('#skill').on('select', function (event) {
                var args = event.args;
                if (args) {
                    var item = args.item;
                    $("#SkillId").val(item.value);
                }
            });
            $('#interviewer').on('select', function (event) {
                var args = event.args;
                if (args) {
                    var item = args.item;
                    $("#InterviewerId").val(item.value);
                }
            });
            $('#outcome').on('select', function (event) {
                var args = event.args;
                if (args) {
                    var item = args.item;
                    $("#OutcomeId").val(item.value);
                }
            });
            $('#interviewdate').on('valueChanged', function (event) {
                $("#InterviewDate").val($('#interviewdate').val());
            });
            $('#signupdate').on('valueChanged', function (event) {
                $("#SignUpDate").val($('#signupdate').val());
            });
            $('#interviewdate').on('close', function (event) {
                $("#InterviewDate").val($('#interviewdate').val());
            });
            $('#signupdate').on('close', function (event) {
                $("#SignUpDate").val($('#signupdate').val());
            });
        };
        //Creating all page elements which are jqxWidgets
        function _createElements() {
            $("#visatype").jqxDropDownList({ source: visatypeAdapter, displayMember: "Name", valueMember: "Id" });
            $("#ethnicity").jqxDropDownList({ source: ethnicityAdapter, displayMember: "Name", valueMember: "Id" });
            $("#biteservice").jqxDropDownList({ source: biteserviceAdapter, displayMember: "Name", valueMember: "Id" });
            $("#origin").jqxDropDownList({ source: originAdapter, displayMember: "Name", valueMember: "Id" });
            $("#originator").jqxDropDownList({ source: originatorAdapter, displayMember: "Name", valueMember: "Id" });
            $("#profession").jqxDropDownList({ source: professionAdapter, displayMember: "Name", valueMember: "Id" });
            $("#skill").jqxDropDownList({ source: skillAdapter, displayMember: "Name", valueMember: "Id" });
            $("#interviewer").jqxDropDownList({ source: interviewerAdapter, displayMember: "Name", valueMember: "Id" });
            $("#outcome").jqxDropDownList({ source: outcomeAdapter, displayMember: "Name", valueMember: "Id" });

            //datepicker
            $("#interviewdate").jqxDateTimeInput({ width: '250px', height: '25px', formatString: 'dd-MM-yyyy' });
            $("#signupdate").jqxDateTimeInput({ width: '250px', height: '25px', formatString: 'dd-MM-yyyy' });

        };
        function _setValues() {
            $("#visatype").on('bindingComplete', function (event) {
                $("#visatype").jqxDropDownList('val', $("#VisaTypeId").val());
            });
            $("#ethnicity").on('bindingComplete', function (event) {
                $("#ethnicity").jqxDropDownList('val', $("#EthnicityId").val());
            });
            $("#biteservice").on('bindingComplete', function (event) {
                $("#biteservice").jqxDropDownList('val', $("#ServiceId").val());
            });
            $("#origin").on('bindingComplete', function (event) {
                $("#origin").jqxDropDownList('val', $("#OriginId").val());
            });
            $("#originator").on('bindingComplete', function (event) {
                $("#originator").jqxDropDownList('val', $("#OriginatorId").val());
            });
            $("#profession").on('bindingComplete', function (event) {
                $("#profession").jqxDropDownList('val', $("#ProfessionId").val());
            });
            $("#skill").on('bindingComplete', function (event) {
                $("#skill").jqxDropDownList('val', $("#SkillId").val());
            });
            $("#interviewer").on('bindingComplete', function (event) {
                $("#interviewer").jqxDropDownList('val', $("#InterviewerId").val());
            });
            $("#outcome").on('bindingComplete', function (event) {
                $("#outcome").jqxDropDownList('val', $("#OutcomeId").val());
            });
            
            var tempDate = $("#InterviewDate").val();
            var datePart = tempDate.split(/[^0-9]/);
            var interviewdate = new Date(datePart[2], datePart[1] - 1, datePart[0]);
            

            tempDate = $("#SignUpDate").val();
            datePart = tempDate.split(/[^0-9]/);
            var signupdate = new Date(datePart[2], datePart[1] - 1, datePart[0]);

            ////datepicker
            $("#interviewdate").jqxDateTimeInput('setDate', new Date(interviewdate));
            if (signupdate!=null)
            {
                $("#signupdate").jqxDateTimeInput('setDate', new Date(signupdate));
            }
            

        };

        return {
            config: {
                dragArea: null
            },
            init: function () {
                //Creating all jqxWindgets except the window
                _createElements();
                _addEventListeners();
                _setValues();
            }
        };
    }());
    $(document).ready(function () {
        //Initializing the demo
        basicDemo.init();
    });
});