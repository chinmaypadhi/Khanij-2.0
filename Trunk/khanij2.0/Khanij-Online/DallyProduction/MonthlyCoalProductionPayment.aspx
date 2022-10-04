<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MonthlyCoalProductionPayment.aspx.cs" Inherits="DallyProduction_MonthlyCoalProductionPayment" %>
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
            
            
            <section class="wrapper main-wrapper row">
    <div class="col-12">
       <uc1:navigation runat="server" ID="navigation" />
        <!-- MAIN CONTENT AREA STARTS -->

        <div class="row">
            <div class="col-12">


                <section class="box form-container">
                    <div class="content-body">
                        

                            <div class="row">
                                <div class="col-sm-6">
                                    <div class="form-group row">
                                        <label for="inputLoginId" class="col-sm-4 col-form-label">Mineral Name<span class="text-danger">*</span></label>
                                        <div class="col-sm-7">
                                           
<input type="text" class="form-control" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-6">
                                    <div class="form-group row">
                                        <label for="inputName" class="col-sm-4 col-form-label">Select Month <span class="text-danger">*</span></label>
                                        <div class="col-sm-7">
                                            <div class="py-2">
                                                <select class="form-control">
                                                <option>Feb</option>
                                            </select>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-sm-6">
                                    <div class="form-group row">
                                        <label for="inputName" class="col-sm-4 col-form-label">Select Year <span class="text-danger">*</span></label>
                                        <div class="col-sm-7">
                                            <div class="py-2">
                                                <select class="form-control">
                                                <option>2021</option>
                                            </select>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-sm-6">
                                    <div class="form-group row">
                                        <label for="inputName" class="col-sm-4 col-form-label">Total Production (in MT)<span class="text-danger">*</span></label>
                                        <div class="col-sm-7">
                                            <div class="py-2">
                                               <input type="text" class="form-control" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-6">
                                    <div class="form-group row">
                                        <label for="inputName" class="col-sm-4 col-form-label">Monthly Amount(Auction Money)(Rs./MT)<span class="text-danger">*</span></label>
                                        <div class="col-sm-7">
                                            <div class="py-2">

                                              <input type="text" class="form-control" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-6">
                                    <div class="form-group row">
                                        <label for="inputName" class="col-sm-4 col-form-label">Total Payable(in Rs.)<span class="text-danger">*</span></label>
                                        <div class="col-sm-7">
                                            <div class="py-2">

                                                <input type="text" class="form-control" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>






                            <div class="row" id="divOnlineOptionDiv" >
                                <div class="col-md-12">
                                    <div class="col-lg-11 col-md-4 col-sm-12 col-xs-12 bhoechie-tab-container">
                                        <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 bhoechie-tab-menu">
                                            <div class="list-group">
                                                <a href="#" class="list-group-item  active text-center" id="divOnlineOption">
                                                    Online Payment
                                                </a>
                                            </div>
                                        </div>
                                        <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9 bhoechie-tab">
                                            <!-- Online payment section -->
                                            <div class="bhoechie-tab-content active ">
                                                <div class="row" id="divPaymentOptionOnline">
                                                    <div class="col-lg-12 col-md-4 col-xs-12">
                                                        <div id="divOnlineChallanDetails">
                                                            <div class="col-md-12">
                                                                <div class="col-md-12 default-form-control-style">
                                                                    <img src="@Url.Content("~/Areas/DailyProduction/Images/SBI.jpg")" alt="SBI" style="width:100px;height:50px;" />
                                                                    <input name="BankSelection" type="radio" id="chkSBI" value="SBI" checked="checked" />
                                                                </div>
                                                                <div class="col-md-12 default-form-control-style" style="text-align: left;">
                                                                    <img src="@Url.Content("~/Areas/DailyProduction/Images/ICICI.png")" alt="ICICI" style="width:100px;height:50px;" />
                                                                    <input name="BankSelection" type="radio" id="chkICICI" value="ICICI" />
                                                                </div>



                                                            </div>
                                                        </div>
                                                        <div class="row" id="divPaymentOption" style="display: none">
                                                            <div class="col-lg-12 col-md-12 col-xs-12">
                                                                <div id="divOnline">
                                                                    <div class="col-xs-12">
                                                                        <div class="col-md-4 default-form-control-style" style="text-align: left;">
                                                                            Net Banking
                                                                            <input name="ModeSelection" type="radio" id="chkICICINetBanking" value="NetBanking" />
                                                                        </div>
                                                                        <div class="col-md-4 default-form-control-style">
                                                                            NEFT/RTGS
                                                                            <input name="ModeSelection" type="radio" id="chkNEFT" value="NEFT" checked="checked" />
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="row" id="divNetBankingPayment" style="display: none">
                                                            <div class="col-lg-12 col-md-12 col-xs-12">
                                                                <div id="divNet">
                                                                    <div class="col-xs-12">
                                                                        <div class="col-md-4 default-form-control-style" style="text-align: left;">
                                                                           Corporate
                                                                            <input name="NetBankingSelection" type="radio" value="Corporate" checked="checked" />
                                                                        </div>
                                                                        <div class="col-md-4 default-form-control-style">
                                                                      Retail
                                                                            <input name="NetBankingSelection" type="radio" value="Retail" />
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>

                                                    </div>
                                                </div>
                                            </div>
                                            <!-- Offlineline payment section -->

                                        </div>
                                    </div>
                                    <br />
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        
                                        <input type="submit" id="makePayment" onclick="return onMakePayment();" class="btn-primary btn-sm edit" value="Make Payment" />
                                    </div>
                                </div>
                            </div>

                                                                                                              
                    </div>
                </section>
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
    <link rel="stylesheet"href="../css/searchable-select.min.css">
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
    <style>
    /*  bhoechie tab */
    div.bhoechie-tab-container {
        z-index: 0;
        background-color: #ffffff;
        padding: 0 !important;
        border-radius: 4px;
        -moz-border-radius: 4px;
        border: 1px solid #ddd;
        margin-top: 20px;
        margin-left: 0px;
        margin-bottom: 20px;
        -webkit-box-shadow: 0 6px 12px rgba(0,0,0,.175);
        box-shadow: 0 6px 12px rgba(0,0,0,.175);
        -moz-box-shadow: 0 6px 12px rgba(0,0,0,.175);
        background-clip: padding-box;
        opacity: 0.97;
        filter: alpha(opacity=97);
    }

    div.bhoechie-tab-menu {
        padding-right: 0;
        padding-left: 0;
        padding-bottom: 0;
    }

        div.bhoechie-tab-menu div.list-group {
            margin-bottom: 0;
        }

            div.bhoechie-tab-menu div.list-group > a {
                margin-bottom: 0;
            }

                div.bhoechie-tab-menu div.list-group > a .glyphicon,
                div.bhoechie-tab-menu div.list-group > a .fa {
                    color: #5A55A3;
                }

                div.bhoechie-tab-menu div.list-group > a:first-child {
                    border-top-right-radius: 0;
                    -moz-border-top-right-radius: 0;
                }

                div.bhoechie-tab-menu div.list-group > a:last-child {
                    border-bottom-right-radius: 0;
                    -moz-border-bottom-right-radius: 0;
                }

                div.bhoechie-tab-menu div.list-group > a.active,
                div.bhoechie-tab-menu div.list-group > a.active .glyphicon,
                div.bhoechie-tab-menu div.list-group > a.active .fa {
                    background-color: #5A55A3;
                    background-image: #5A55A3;
                    color: #ffffff;
                }

                    div.bhoechie-tab-menu div.list-group > a.active:after {
                        content: '';
                        position: absolute;
                        left: 100%;
                        top: 50%;
                        margin-top: -13px;
                        border-left: 0;
                        border-bottom: 13px solid transparent;
                        border-top: 13px solid transparent;
                        border-left: 10px solid #5A55A3;
                    }

    div.bhoechie-tab-content {
        background-color: #ffffff;
        /* border: 1px solid #eeeeee; */
        padding-left: 20px;
        padding-top: 10px;
    }

    div.bhoechie-tab div.bhoechie-tab-content:not(.active) {
        display: none;
    }
</style>
</body>
</html>
