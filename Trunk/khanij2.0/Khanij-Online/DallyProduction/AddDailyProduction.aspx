﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddDailyProduction.aspx.cs" Inherits="DallyProduction_AddDailyProduction" %>
<%@ Register Src="~/includes/navbar.ascx" TagPrefix="uc1" TagName="navbar" %>
<%@ Register Src="~/includes/leftsider.ascx" TagPrefix="uc1" TagName="leftsider" %>
<%@ Register Src="~/includes/navigation.ascx" TagPrefix="uc1" TagName="navigation" %>
<%@ Register Src="~/includes/util.ascx" TagPrefix="uc1" TagName="util" %>
<%@ Register Src="~/includes/footer.ascx" TagPrefix="uc1" TagName="footer" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="content-type" content="text/html;charset=UTF-8" />
    <meta charset="utf-8" />
    <title>Khanij Online </title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <meta content="" name="description" />
    <meta content="" name="author" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <link rel="stylesheet" href="../css/bootstrap.min.css" media="screen" />
<%--    <link rel="stylesheet" href="../css/mdb.min.css" media="screen" />--%>
    <link rel="stylesheet" href="../css/pace-theme-flash.css" media="screen" />
    <link rel="stylesheet" href="../css/all.min.css" />
    <link rel="stylesheet" href="../css/perfect-scrollbar.css" />   
    <link rel="stylesheet" href="../css/style.css"  type="text/css" />
    <link rel="alternate stylesheet" media="screen" title="infotheme" href="../css/theme-info.css" />
    <link rel="alternate stylesheet" media="screen" title="greentheme" href="../css/theme-success.css" />
    <link rel="alternate stylesheet" media="screen" title="orangetheme" href="../css/theme-warning.css" />
    <link rel="alternate stylesheet" media="screen" title="purpletheme" href="../css/theme-secondary.css" />
    <link rel="alternate stylesheet" media="screen" title="redtheme" href="../css/theme-danger.css" />
    <script src="../js/jquery.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
<uc1:navbar runat="server" ID="navbar" />
    <!-- END TOPBAR -->
    <!-- START CONTAINER -->
    <div class="page-container row-fluid container-fluid">
        <!-- SIDEBAR - START -->
        <div class="page-sidebar fixedscroll">
            <!-- MAIN MENU - START -->
            <uc1:leftsider runat="server" ID="leftsider" />
            <!-- MAIN MENU - END -->
        </div>
        <!--  SIDEBAR - END -->
        <!-- START CONTENT -->
        <div id="main-content">
            
            
            <section class="box form-container">
                    <div class="content-body">
                       
                            <div class="row">
                                <div class="col-sm-6">
                                    <div class="form-group row">
                                        <label for="inputLoginId" class="col-sm-4 col-form-label">Mineral Name <span class="text-danger">*</span></label>
                                        <div class="col-sm-7" style="font-size:large;font-weight:400">
                                           Coal
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-sm-6">
                                    <div class="form-group row">
                                        <label for="inputLoginId" class="col-sm-4 col-form-label">Select Date<span class="text-danger">*</span></label>
                                        <div class="col-sm-7">
                                            <input type="text" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-sm-6">
                                    <div class="form-group row">
                                        <label for="inputLoginId" class="col-sm-4 col-form-label">Production Status ?<span class="text-danger">*</span></label>
                                        <div class="col-sm-7">
                                             <asp:RadioButtonList ID="customRadio" class="custom-radio" runat="server" RepeatDirection="Horizontal" RepeatColumns="3">
            <asp:ListItem Value="1" Selected="True">Yes</asp:ListItem>
            <asp:ListItem Value="2">No</asp:ListItem>
        </asp:RadioButtonList>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-6">
                                    <div class="form-group row">
                                        <label for="inputLoginId" class="col-sm-4 col-form-label">Select Form<span class="text-danger">*</span></label>
                                        <div class="col-sm-7">

                                           <select class="form-control">
                                                <option>Select Form</option>
                                            </select>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-6">
                                    <div class="form-group row">
                                        <label for="inputLoginId" class="col-sm-4 col-form-label">Select Grade<span class="text-danger">*</span></label>
                                        <div class="col-sm-7">
                                           
                                            <select name="MineralGradeID" id="MineralGradeID" class="form-control"></select>

                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-6">
                                    <div class="form-group row">
                                        <label for="inputLoginId" class="col-sm-4 col-form-label">Enter Quantity ( In MT )<span class="text-danger">*</span></label>
                                        <div class="col-sm-7">
                                            <input type="text" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                            </div>

                           

                            <div class="row">
                                <div class="col-sm-6 offset-sm-2">
                                    <input type="button" id="btn_GenerateGrid" onclick="checkFormValidity() && generateGrid();" value="Add To List" class="btn btn-primary btn-md ml-0" />
                                </div>
                            </div>
                        
                    </div>
                    <div class="row" id="Grid">
                        <div class="col-sm-10 offset-sm-1">
                            <label>Daily Production Grid</label>
                            <table border="1" id="GridTable" class="table" style="margin-top: 15px;">
                                <thead>
                                    <tr>
                                        <th style="border-color: black;">Sr.No.</th>
                                        <th style="border-color: black;">Date</th>
                                        <th style="border-color: black;">Mineral Name</th>
                                        <th style="border-color: black;">Mineral Form</th>
                                        <th style="border-color: black;">Mineral Grade</th>
                                        <th style="border-color: black;">Quantity ( In MT )</th>
                                        <th style="border-color: black;"></th>
                                    </tr>
                                </thead>
                                <tbody>
                                </tbody>
                            </table>

                            <div class="row">
                                <div class="col-md-offset-5 col-md-7 col-xs-12">
                                    <input type="button" id="btn_SaveGridData" onclick="return saveGridData();" value="Save" class="btn btn-primary btn-md ml-0" />
                                </div>
                            </div>
                        </div>
                    </div>

                </section> 
           <uc1:footer runat="server" ID="footer" />
        </div>
        <!-- END CONTENT -->
    </div>
    <!-- END CONTAINER -->
    </form>
    <link rel="stylesheet"href="../css/searchable-select.min.css"/>
    <script src="../js/searchable-select.min.js"></script>
  
<!-- alert 1-->
    <div class="modal fade alert-modal" tabindex="-1" role="dialog" aria-labelledby="alertModal" aria-hidden="true">
        <div class="modal-dialog modal-md" role="document">
            <div class="modal-content">
                <div class="modal-body text-center">
                    <h5 class="p-2 "><i class="fas fa-check fa-2x mb-3 text-success"></i><br> Your Form has been submitted
                        Successfully.</h5>
                    <a class="btn btn-primary btn-md" href="javascrip:;" data-dismiss="modal">Ok</a>
                </div>
               
            </div>
        </div>
    </div>




    <script>
        indicateMe = "yes"

        $(document).ready(function () {
            loadNavigation('Add Mineral Category', 'glTMng', 'plmineral', 'tl', 'Masters', 'Mineral Category', '');

            $('.searchableselect').searchableselect();


        });
    </script>

    <script>

    $(document).ready(function () {
        $('#Grid').hide();
        //$("#MineralFormID").data("kendoComboBox").enable(false);
    });

    function checkFormValidity() {
        if ($("#Date").val() == null || $("#Date").val() == "") { alert("Please Select Date"); $("#Date").focus(); return false; }

        var SelectedRadioVal = $("input[name='ProductionDataAvailableStatus']:checked").val();

        if (SelectedRadioVal == 'YES') {
            if ($("#MineralFormID").val() == null || $("#MineralFormID").val() == "" || $("#MineralFormID").val() == 0) { alert("Please Select Form"); $("#MineralFormID").data('kendoComboBox').focus(); return false; }
            if ($("#MineralGradeID").val() == null || $("#MineralGradeID").val() == "" || $("#MineralGradeID").val() == 0) { alert("Please Select Grade"); $("#MineralGradeID").focus(); return false; }
            if ($("#Quantity").val() == null || $("#Quantity").val() == "") { alert("Please Enter Quantity ( In MT )"); $("#Quantity").focus(); return false; }
        }
        return true;
    }

    function clearControls() {
        //$("#Date").val('').trigger("change");
        $("#MineralFormID").val('');
        $('#MineralGradeID').val('');
        $('#Quantity').val('');
        //$("#MineralFormID").data("kendoComboBox").enable(false);
    }

    function generateGrid() {

        //Get the reference of the Table's TBODY element.
        var tBody = $("#GridTable > TBODY")[0];

        var CurrentSelectedDate = $("#Date").val();
        var CurrentSelectedGradeID = $('#MineralGradeID').val();

        var rowCount = $('#GridTable tbody tr').length;
        if (rowCount > 0) {
            var ListOfDates = document.getElementsByClassName("datelist");
            var ListOfGrades = document.getElementsByClassName("mineralgradeidlist");
            var RecordMatchFound = 0;

            for (var i = 0; i < ListOfDates.length; i++) {
                //$("#GridTable tbody").find('tr').each(function (i) {
                //var qty = $(this).find('td.quantitylist');//Refers to TD element
                //var dt = $(this).find('td.datelist');//Refers to TD element
                //var form = $(this).find('td.mineralformidlist');//Refers to TD element
                //var grade = $(this).find('td.mineralgradeidlist');//Refers to TD element
                //});

                if (ListOfDates[i].innerHTML == CurrentSelectedDate && ListOfGrades[i].innerHTML == CurrentSelectedGradeID) {
                    RecordMatchFound = 1;
                }
            }

            if (RecordMatchFound == 0) {
                //Add Row.
                row = tBody.insertRow(-1);

                //Add Sr.No. cell.
                var rowCount = $('#GridTable tr').length;
                var cell = $(row.insertCell(-1));
                cell.html(rowCount - 1);

                //Add Date cell.
                var cell = $(row.insertCell(-1));
                cell.addClass("datelist");
                cell.html($("#Date").val());

                //Add Mineral Name cell.
                var cell = $(row.insertCell(-1));
                cell.html($("#MineralName").val());

                //Add Mineral Form cell.
                var cell = $(row.insertCell(-1));
                //cell.html($('#MineralFormID').text());
                cell.html($("#MineralFormID option:selected").text());



                //Add Mineral Grade cell.
                var cell = $(row.insertCell(-1));
                //cell.html($('#MineralGradeID').text());
                cell.html($("#MineralGradeID option:selected").text());

                //Add Quantity cell.
                var cell = $(row.insertCell(-1));
                cell.addClass("quantitylist");
                if ($('#Quantity').val() > 0) {
                    cell.html($('#Quantity').val());
                }
                else { cell.html(0); }
                //Add Button cell.
                cell = $(row.insertCell(-1));
                var btnRemove = $("<input class='k-button k-button-icontext k-primary' />");
                btnRemove.attr("type", "button");
                btnRemove.attr("onclick", "Remove(this);");
                btnRemove.val("Remove");
                cell.append(btnRemove);

                //Add Mineral Form Id cell.
                var cell = $(row.insertCell(-1));
                //cell.html($('#MineralFormID').val());
                cell.html($("#MineralFormID option:selected").val());
                cell.addClass("mineralformidlist");
                cell.attr("name", "mineralformidlist");
                cell.css("visibility", "hidden");

                //Add Mineral Grade Id cell.
                var cell = $(row.insertCell(-1));
                //cell.html($('#MineralGradeID').val());
                cell.html($("#MineralGradeID option:selected").val());
                cell.addClass("mineralgradeidlist");
                cell.css("visibility", "hidden");

                clearControls();
                //var var_quantitylist = document.getElementsByClassName('quantitylist')

                //for (var i = 0 ; i < var_quantitylist.length; i++) {
                //    if (var_quantitylist[i].value == undefined) {
                //        var_quantitylist[i].innerHTML = 0;
                //    }
                //}
                $('#Grid').show();
            }
            else {
                alert("Record already exist with the selected date and grade in the List !");
            }
        }
        else {
            //Add Row.
            row = tBody.insertRow(-1);

            //Add Sr.No. cell.
            var rowCount = $('#GridTable tr').length;
            var cell = $(row.insertCell(-1));
            cell.html(rowCount - 1);

            //Add Date cell.
            var cell = $(row.insertCell(-1));
            cell.addClass("datelist");
            cell.html($("#Date").val());

            //Add Mineral Name cell.
            var cell = $(row.insertCell(-1));
            cell.html($("#MineralName").val());

            //Add Mineral Form cell.
            var cell = $(row.insertCell(-1));
            //cell.html($('#MineralFormID').text());
            cell.html($("#MineralFormID option:selected").text());

            //Add Mineral Grade cell.
            var cell = $(row.insertCell(-1));
            //cell.html($('#MineralGradeID').text());
            cell.html($("#MineralGradeID option:selected").text());

            //Add Quantity cell.
            var cell = $(row.insertCell(-1));
            cell.addClass("quantitylist");
            if ($('#Quantity').val() > 0) {
                cell.html($('#Quantity').val());
            }
            else { cell.html(0); }

            //Add Button cell.
            cell = $(row.insertCell(-1));
            var btnRemove = $("<input class='k-button k-button-icontext k-primary' />");
            btnRemove.attr("type", "button");
            btnRemove.attr("onclick", "Remove(this);");
            btnRemove.val("Remove");
            cell.append(btnRemove);

            //Add Mineral Form Id cell.
            var cell = $(row.insertCell(-1));
            //cell.html($('#MineralFormID').val());
            cell.html($("#MineralFormID option:selected").val());
            cell.addClass("mineralformidlist");
            cell.attr("name", "mineralformidlist");
            cell.css("visibility", "hidden");

            //Add Mineral Grade Id cell.
            var cell = $(row.insertCell(-1));
            //cell.html($('#MineralGradeID').val());
            cell.html($("#MineralGradeID option:selected").val());
            cell.addClass("mineralgradeidlist");
            cell.css("visibility", "hidden");

            clearControls();
            //var var_quantitylist = document.getElementsByClassName('quantitylist')

            //for (var i = 0 ; i < var_quantitylist.length; i++) {
            //    if (var_quantitylist[i].value == undefined) {
            //        var_quantitylist[i].innerHTML = 0;
            //    }
            //}
            $('#Grid').show();
        }
    }

    function Remove(button) {
        //Determine the reference of the Row using the Button.
        var row = $(button).closest("TR");
        var name = $("TD", row).eq(0).html();
        if (confirm("Do you want to delete: " + name)) {

            //Get the reference of the Table.
            var table = $("#GridTable")[0];

            //Delete the Table row using it's Index.
            table.deleteRow(row[0].rowIndex);
        }
        var rowCount = $('#GridTable tr').length;
        if (rowCount == 1) {
            $('#Grid').hide();
        }
        else {
            $('#Grid').show();
        }
    }

    function saveGridData() {
        debugger;
        var quantityArray="", dateArray ="", mineralformidArray = "", mineralgradeidArray = "";

        var sum = 0;
        var ProductionCap= $('#ProductionCap').val()
        var TotalQty=$('#TotalQty').val()
        var quantitylist=document.getElementsByClassName('quantitylist')
        for (var i = 0;i<= quantitylist.length; i++)
        {
            if (quantitylist[i] != undefined && quantitylist[i] != "")
            {
                sum = sum + parseFloat(quantitylist[i].innerHTML);
            }
        }
        sum = sum || 0;
        var total = parseFloat(TotalQty) + parseFloat(sum)
        if (parseFloat(ProductionCap) < parseFloat(total)) {
            alert("Your Total Qty " + parseFloat(total) + " Excced the limit of Permitted Quantity " + ProductionCap)

        }
        else {
             
                $("#GridTable > tbody").find("tr").each(function () { //get all rows in table
                  
                var qty = $(this).find('td.quantitylist');//Refers to TD element
                quantityArray= quantityArray+(qty[0].innerHTML)+',';
                    
                var dt = $(this).find('td.datelist');//Refers to TD element
                dateArray=dateArray+(dt[0].innerHTML)+',';

                var form = $(this).find('td.mineralformidlist');//Refers to TD element
                 mineralformidArray= mineralformidArray+(form[0].innerHTML)+',';

                var grade = $(this).find('td.mineralgradeidlist');//Refers to TD element
                 mineralgradeidArray= mineralgradeidArray+(grade[0].innerHTML)+',';
            });
            var gg = JSON.stringify({
                QtyArray: quantityArray,
                dtArray: dateArray,
                mineralformidArray: mineralformidArray,
                mineralgradeidArray: mineralgradeidArray
            });
            
           
        }
    }

    function GetGrade() {
        return {
            MineralFormID: $("#MineralFormID").val()
        };
    }

    function OnProductionDateChange() {
        var SelectedDate = $("#Date").val();
        var SelectedRadioVal = $("input[name='ProductionDataAvailableStatus']:checked").val();

        $.ajax({
            url: '@Url.Action("SelectedDateMonthSubmitted", "DailyProduction")',
            type: "GET",
            data: { Date: SelectedDate },
            success: function (data) {
                console.log(data);
                if (data != "" && data != 0) {
                    alert("Record already submitted for the selected month.");
                    window.location.reload();
                }
            },
            error: function (data) {
            }
        });

        if (SelectedRadioVal == 'YES') {
            $("#MineralFormID").enable(true);
            $('#Quantity').enable(true);
            $("#MineralFormID").value('');
            $('#MineralGradeID').value('');
            $('#Quantity').value('');
        }
        else {
            $("#MineralFormID").enable(false);
            $('#Quantity').enable(false);
            $("#MineralFormID").value('');
            $('#MineralGradeID').value('');
            $('#Quantity').value('');
        }


    }

    function OnMineralGradeChange(e) {

        var mineralGradeWidget = e.sender;
        if (mineralGradeWidget.value() && mineralGradeWidget.select() === -1) {
            mineralGradeWidget.value(""); //reset widget
        }
        else {
            var SelectedDate = $("#Date").val();
            var MineralGrade = $('#MineralGradeID').val();

            if (MineralGrade != "") {
                $.ajax({
                    url: '@Url.Action("GradeWiseCheckQTYEntry", "DailyProduction")',
                    type: "GET",
                    data: { MineralGradeId: MineralGrade, Date: SelectedDate },
                    success: function (data) {
                        if (data != "" && data != 0) {
                            alert("Record already exist in the selected date and grade. Please Delete the Record from Daily Production Details.");
                            clearControls();
                        }
                    },
                    error: function (data) {
                    }
                });
            }
        }
    }

    function onRadioChange() {
        var SelectedRadioVal = $("input[name='ProductionDataAvailableStatus']:checked").val();

        if (SelectedRadioVal == 'YES') {
            if ($("#Date").val()) {
                //$("#MineralFormID").enable(true);
                $("#MineralFormID").prop("disabled", false);

                //$('#Quantity').enable(true);
                $("#Quantity").prop("disabled", false);
            }
            else {
                //$("#MineralFormID").enable(false);
                $("#MineralFormID").prop("disabled", true);
                //$('#Quantity').enable(false);
                $("#Quantity").prop("disabled", true);

                $("#MineralFormID").val('');
                $('#MineralGradeID').val('');
                $('#Quantity').val('');
            }
        }
        else {

            //$("#MineralFormID").enable(false);
            $("#MineralFormID").prop("disabled", true);
            //$('#Quantity').enable(false);
            $("#Quantity").prop("disabled", true);


            $("#MineralFormID").val('');

            $('#MineralGradeID').val('');
            $('#Quantity').val('');
        }
    }

    function onChangeMineralForm(e) {
        var mineralFormWidget = e.sender;
        if (mineralFormWidget.value() && mineralFormWidget.select() === -1) {
            mineralFormWidget.value(""); //reset widget
        }
     }
</script>
</body>
</html>
