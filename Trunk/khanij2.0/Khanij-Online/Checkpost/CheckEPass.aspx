<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CheckEPass.aspx.cs" Inherits="Checkpost_CheckEPass" %>
<%@ Register Src="~/includes/navbar.ascx" TagPrefix="uc1" TagName="navbar" %>
<%@ Register Src="~/includes/leftsider.ascx" TagPrefix="uc1" TagName="leftsider" %>
<%@ Register Src="~/includes/navigation.ascx" TagPrefix="uc1" TagName="navigation" %>
<%@ Register Src="~/includes/util.ascx" TagPrefix="uc1" TagName="util" %>
<%@ Register Src="~/includes/footer.ascx" TagPrefix="uc1" TagName="footer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

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
    <link rel="stylesheet" href="../css/style.css" type="text/css" />
    <link rel="alternate stylesheet" media="screen" title="infotheme" href="../css/theme-info.css" />
    <link rel="alternate stylesheet" media="screen" title="greentheme" href="../css/theme-success.css" />
    <link rel="alternate stylesheet" media="screen" title="orangetheme" href="../css/theme-warning.css" />
    <link rel="alternate stylesheet" media="screen" title="purpletheme" href="../css/theme-secondary.css" />
    <link rel="alternate stylesheet" media="screen" title="redtheme" href="../css/theme-danger.css" />
    <link rel="stylesheet" href="../css/bootstrap-datetimepicker.min.css" type="text/css" />
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
            <section class="wrapper main-wrapper row">            
             <div class="col-12">
         <uc1:navigation runat="server" ID="navigation" />
        <!-- MAIN CONTENT AREA STARTS -->
       <div class="col-xs-12">                
                <div class="panel-body">
                    <input id="Type" name="Type" type="hidden" value=""/>
                    <div class="row">
                        <div class="col-md-3" id="Pass" style="display: block;">
                            <div class="panel panel-default" style="height: 140px; background-color: #E54C3B">
                                <h3 class="panel-title" style="color: white; padding: 10px 10px;">Pass Type</h3>                               
                                <div class="panel-body">
                                    <div class="row">
                                        <div class="col-sm-3" style="width: 125px; color: white">

                                            <label style="font-size: 20px;">
                                                <input type="radio" id="Auto" name="mode" style="width: 20px; border-color: black; border: 1px"/>e-Pass</label>
                                        </div>
                                        <div class="col-sm-4" style="width: 125px; color: white">
                                            <label style="font-size: 20px;">
                                                <input type="radio" id="Manual" name="mode" style="width: 20px; border-color: black; border: 1px"/>Manual</label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                           <div class="col-md-3" id="Epass" style="display: none">

                            <div class="panel panel-default" style="height: 140px; background-color: #E54C3B">
                                <h3 class="panel-title" style="color: white; padding: 10px 10px;">Transit Pass No</h3>
                                <div class="panel-heading">                                    
                                </div>
                                <div class="panel-body">
                                    <form>
                                        <div class="row">
                                            <div class="col-xs-9">
                                                <asp:TextBox ID="txtTransitPassNo" CssClass="form-control" runat="server" style = "height:50px;width:100%;border-bottom: 3px solid white;color:white" autofocus = "autofocus" AutoPostBack="false"></asp:TextBox>
                                            </div>
                                            <div class="col-xs-3">
                                                <button type="button" style="border: none; background: none" id="btnGet" accesskey="">
                                                    <span class="font-awsomecolor" style="font-size: 0.8em;">
                                                        <img style="width: 25px; height: 25px; margin-top: 20px" /></span>
                                                </button>
                                            </div>
                                        </div>
                                    </form>
                                </div>
                            </div>
                        </div>                   
                        <div class="col-md-3">
                            <div class="panel panel-default" style="height: 140px; background-color: #2E8AC5">
                                <h3 class="panel-title" style="color: white; padding: 10px 10px;">Weighing Data at Source</h3>                              
                                <div class="panel-body" style="height: 98px;">
                                    <h1 class="text-right font-height-set" style="height: 70px; color: white; margin-top: -4px;">
                                        <label id="PW">0</label></h1>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="panel panel-default" style="height: 140px; background-color: #F0C318">
                                <h3 class="panel-title" style="color: white; padding: 10px 10px;">Current Weighing Data</h3> 
                                 <div class="panel-body" style="height: 98px;">
                                 
                                    <div class="panel-body">                                 
                                   <input type="number"  class="TextBoxAsLabel custom-input text-right" id="CW" onkeydown="onChangeCW();" name="Current" style="height: 70px;" placeholder="0" />
                                    </div>
                                </div>                             
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="panel panel-default" style="height: 140px; background-color: #26B798">
                                <h3 class="panel-title" style="color: white; padding: 10px 10px;">Difference</h3>
                                
                                <div class="panel-body" style="height: 98px;">
                                    <h1 class="text-right font-height-set" style="height: 70px; color: white; margin-top: -4px;">
                                        <label id="DW">0</label></h1>                                  
                                </div>
                            </div>
                        </div>
                    </div>
                </div>                
            </div>
               
        </div>
           <div class="col-md-12" id="divEpass" style="display: none;">
                            
                        <div class="panel-heading" style="background-color: #F68C43; border: 2px; border-style: solid; border-color: lightgray;">
                            <h3 class="panel-title" style="color: white">Manual Pass Infomation - Transit Pass</h3>
                        </div>
                        <div class="panel-body" style="border: 2px; border-style: solid; border-color: lightgray;">

                            <div class="row">
                                <div class="col-md-6">
                                    <div class="col-md-5 default-form-control-style">
                                    <label for="inputName" class="col-sm-4 col-form-label">Transit Pass No <span class="text-danger">*</span></label>
                                    </div>
                                    <div class="col-md-2 default-form-control-style">
                                       <input type="text" class="form-control" />
                                    </div>
                                </div>
                                <div class="col-md-5">
                                    <div class="col-md-6 default-form-control-style">
                                    <label for="inputName" class="col-sm-4 col-form-label">Date and Time <span class="text-danger">*</span></label>
                                    </div>
                                    <div class="col-md-1 default-form-control-style">
                                       <asp:TextBox ID="txtdate" CssClass="form-control datetime" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="col-md-5 default-form-control-style">
                                    <label for="inputName" class="col-sm-4 col-form-label">Name oF Check Post <span class="text-danger">*</span></label>
                                    </div>
                                    <div class="col-md-2 default-form-control-style">
                                       <input type="text" class="form-control" />
                                    </div>
                                </div>
                                <div class="col-md-5">
                                    <div class="col-md-6 default-form-control-style">
                                    <label for="inputName" class="col-sm-4 col-form-label">Lessee/License <span class="text-danger">*</span></label>
                                        <span class="text-danger">*</span>
                                    </div>
                                    <div class="col-md-1 default-form-control-style">
                                        <input type="text" class="form-control" />
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-6">
                                    <div class="col-md-5 default-form-control-style">
                                    <label for="inputName" class="col-sm-4 col-form-label">Name of Mineral <span class="text-danger">*</span></label>
                                    </div>
                                    <div class="col-md-2 default-form-control-style">
                                         <input type="text" class="form-control" />
                                    </div>
                                </div>
                                <div class="col-md-5">
                                    <div class="col-md-6 default-form-control-style">
                                    <label for="inputName" class="col-sm-4 col-form-label">License/Mining Area Details <span class="text-danger">*</span></label>
                                    </div>
                                    <div class="col-md-1 default-form-control-style">
                                       <input type="text" class="form-control" />
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-6">
                                    <div class="col-md-5 default-form-control-style">
                                    <label for="inputName" class="col-sm-4 col-form-label">Unit <span class="text-danger">*</span></label>                                       
                                    </div>
                                    <div class="col-md-2 default-form-control-style">
                                       <input type="text" class="form-control" />
                                    </div>
                                </div>
                                <div class="col-md-5">
                                    <div class="col-md-6 default-form-control-style">
                                    <label for="inputName" class="col-sm-4 col-form-label">Previous Gross Weight <span class="text-danger">*</span></label>
                                    </div>
                                    <div class="col-md-1 default-form-control-style">
                                        <input type="text" class="form-control" />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="col-md-5 default-form-control-style">
                                    <label for="inputName" class="col-sm-4 col-form-label">Current gross Weight <span class="text-danger">*</span></label>
                                        <span class="text-danger">*</span>
                                    </div>
                                    <div class="col-md-2 default-form-control-style">
                                       <input type="text" class="form-control" />
                                    </div>
                                </div>
                                <div class="col-md-5">
                                    <div class="col-md-6 default-form-control-style">
                                    <label for="inputName" class="col-sm-4 col-form-label">Difference Weight <span class="text-danger">*</span></label>                                     
                                    </div>
                                    <div class="col-md-1 default-form-control-style">
                                        <input type="text" class="form-control" />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="col-md-5 default-form-control-style">
                                    <label for="inputName" class="col-sm-4 col-form-label">Sale Value of Mineral <span class="text-danger">*</span></label> 
                                    </div>
                                    <div class="col-md-2 default-form-control-style">
                                        <input type="text" class="form-control" />
                                    </div>
                                </div>
                                <div class="col-md-5">
                                    <div class="col-md-6 default-form-control-style">
                                    <label for="inputName" class="col-sm-4 col-form-label">Date & Time Of Mineral Dispatched <span class="text-danger">*</span></label> 
                                    </div>
                                    <div class="col-md-1 default-form-control-style">
                                    <asp:TextBox ID="txtMineraldispatched" CssClass="form-control datetime" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="col-md-5 default-form-control-style">
                                    <label for="inputName" class="col-sm-4 col-form-label">Vehicle No <span class="text-danger">*</span></label> 
                                    </div>
                                    <div class="col-md-2 default-form-control-style">
                                       <input type="text" class="form-control" />
                                    </div>
                                </div>
                                <div class="col-md-5">
                                    <div class="col-md-6 default-form-control-style">
                                    <label for="inputName" class="col-sm-4 col-form-label">Vehicle Type <span class="text-danger">*</span></label> 
                                    </div>
                                    <div class="col-md-1 default-form-control-style">
                                       <input type="text" class="form-control" />
                                    </div>
                                </div>
                            </div>


                            <div class="row">
                                <div class="col-md-6">
                                    <div class="col-md-5 default-form-control-style">
                                    <label for="inputName" class="col-sm-4 col-form-label">Vehicle Owner <span class="text-danger">*</span></label> 
                                    </div>
                                    <div class="col-md-2 default-form-control-style">
                                         <input type="text" class="form-control" />
                                    </div>
                                </div>
                                <div class="col-md-5">
                                    <div class="col-md-6 default-form-control-style">
                                    <label for="inputName" class="col-sm-4 col-form-label">Driver Name <span class="text-danger">*</span></label> 
                                    </div>
                                    <div class="col-md-1 default-form-control-style">
                                        <input type="text" class="form-control" />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="col-md-5 default-form-control-style">
                                     <label for="inputName" class="col-sm-4 col-form-label">Purchaser/Consignee Name <span class="text-danger">*</span></label> 
                                    </div>
                                    <div class="col-md-2 default-form-control-style">
                                       <input type="text" class="form-control" />
                                    </div>
                                </div>
                                <div class="col-md-5">
                                    <div class="col-md-6 default-form-control-style">
                                        <label for="inputName" class="col-sm-4 col-form-label">DO Number (If Applicable) <span class="text-danger">*</span></label> 
                                    </div>
                                    <div class="col-md-1 default-form-control-style">
                                       <input type="text" class="form-control" />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="col-md-5 default-form-control-style">
                                        <label for="inputName" class="col-sm-4 col-form-label">DO Date (If Applicable) <span class="text-danger">*</span></label> 
                                    </div>
                                    <div class="col-md-2 default-form-control-style">
                                      <asp:TextBox ID="txtDOD" CssClass="form-control datetime" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-5">
                                    <div class="col-md-6 default-form-control-style">
                                    <label for="inputName" class="col-sm-4 col-form-label">Mineral Destination <span class="text-danger">*</span></label> 
                                    </div>
                                    <div class="col-md-1 default-form-control-style">
                                       <input type="text" class="form-control" />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="col-md-5 default-form-control-style">
                                     <label for="inputName" class="col-sm-4 col-form-label">Route <span class="text-danger">*</span></label> 
                                    </div>
                                    <div class="col-md-2 default-form-control-style">
                                        <input type="text" class="form-control" />
                                    </div>
                                </div>
                                <div class="col-md-5">
                                    <div class="col-md-6 default-form-control-style">
                                    <label for="inputName" class="col-sm-4 col-form-label">Other Details <span class="text-danger">*</span></label> 
                                    </div>
                                    <div class="col-md-1 default-form-control-style">
                                        <input type="text" class="form-control" />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-offset-5 col-md-7 col-xs-12">
                                    <input type="submit" value="Save" id="SaveManualTP" class="k-button k-button-icontext k-primary k-grid-update" style="width: 100px; background-color: #F68C43; color: white" />
                                    <input type="button" value="Cancel" id="CancelManualTP" class="k-button k-button-icontext k-primary k-grid-update" style="width: 100px; background-color: #F68C43; color: white" />
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
    <link rel="stylesheet" href="../css/searchable-select.min.css">
    <script src="../js/jquery.min.js"></script>
    <script src="../js/searchable-select.min.js"></script>
    <link rel="stylesheet" href="../css/dataTables.bootstrap4.min.css">
    <script src="../js/jquery.dataTables.min.js"></script>
    <script src="../js/dataTables.bootstrap4.min.js"></script>
    <script src="../js/moment.min.js"></script>
    <script src="../js/bootstrap-datetimepicker.min.js"></script>
    <script>
        excelMe = "yes"
        pdfMe = "yes"
        printMe = "yes"
        $(document).ready(function () {
            loadNavigation('SubmitCases', 'glTMng', 'plmineral', 'tl', 'Checkpost', 'Check Transit Pass', '');

            $('.searchableselect').searchableselect();

            $('#datatable').DataTable();

            $('.shorting-lnk').click(function () {
                $('.shorting-lnk i').toggleClass('fa-sort-amount-up-alt fa-sort-amount-down-alt ');
            });
            $('.filter-dropdown').hide();
            $('.filter-lnk').click(function () {
                $(this).toggleClass('active');
                $(this).siblings('.filter-dropdown').slideToggle();
            });
            $('.filter-btn').click(function () {
                $(this).parent('.shorting-cell .filter-dropdown').slideUp();
                if ($(this).parent().parent('.shorting-cell').find('.filter-lnk').hasClass('active')) {
                    $(this).parent().siblings('.filter-lnk').removeClass('active');
                }

            });
            $('#TransitPassNo').keydown(function (e) {
                if (e.keyCode == 13) {
                    $('#btnGet').trigger('click');
                    e.preventDefault();
                }
            });
        });
        $('.datetime').datetimepicker({
            format: "DD/MM/YYYY"
        });
        function onChangeCW() {
            var value = $("#CW").val();
            if (value > 99) {
                alert('Current Weighing Data must be less than 99.');
                $("#CW").val(0);
            }
        }
        $("#Auto").click(function () {
            $("#Epass")[0].style.display = "block";
            $("#Pass")[0].style.display = "none";
            $("#divEpass")[0].style.display = "none";
            $("#CW").val("0");
            $("#PW").text("0");
            $("#DW").text("0");
        });
        $('#CW').blur(function () {
            var PW = $("#PW").text();
            var CW = parseFloat($("#CW").val());
            var sum = parseFloat(PW - CW);
            $("#DW").text(sum.toFixed(2));
        })
        $("#btnGet").click(function () {
            if ($("#txtTransitPassNo").val().trim() == "") {

                $("#Epass")[0].style.display = "none";
                $("#Pass")[0].style.display = "block";
                $("#CW").val("0");
                $("#PW").text("0");
                $("#DW").text("0");
                $("#RemarkA").text("");
                alert('Data Not Found !!!');
                return false;
            }
        });
        $("#Manual").click(function () {
            $("#divEpass")[0].style.display = "block";
            $("#CW").val("0");
            $("#PW").text("0");
            $("#DW").text("0");
        });
        $("#Manual").click(function () {
            $("#divEpass")[0].style.display = "block";
            $("#CW").val("0");
            $("#PW").text("0");
            $("#DW").text("0");
        });
    </script>
</body>
</html>