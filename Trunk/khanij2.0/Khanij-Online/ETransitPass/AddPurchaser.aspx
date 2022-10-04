<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddPurchaser.aspx.cs" Inherits="ETransitPass_AddPurchaser" %>

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
                            <div class="main-tab">
                                <ul class="nav nav-tabs">
                                    <li class="nav-item">
                                        <a class="nav-link active" href="javascript:void(0);">
                                           Add Purchase Consignee
                                        </a>
                                    </li>
                                    
                                </ul>
                                <uc1:util runat="server" ID="util" />
                            </div>

                            <section class="box form-container">
                                <div class="content-body">

                                    <div class="row">
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label  class="col-sm-4 col-form-label font-weight-bolder">Mineral Name</label>
                                                <div class="col-sm-7">
                                                    <input type="text" class="form-control">
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label for="inputName" class="col-sm-4 col-form-label font-weight-bolder">Mineral Form</label>
                                                <div class="col-sm-7">
                                                    <input type="text" class="form-control">
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label for="dropdownUserType" class="col-sm-4 col-form-label font-weight-bolder">Mineral Grade</label>
                                                <div class="col-sm-7">
                                                    <input type="text" class="form-control">
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label for="dropdownDepart" class="col-sm-4 col-form-label font-weight-bolder">e-Permit Qty</label>
                                                <div class="col-sm-7">
                                                   <input type="text" class="form-control">                                                    
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label for="dropdownDesign" class="col-sm-4 col-form-label font-weight-bolder">Remaining Qty</label>
                                                <div class="col-sm-7">
                                                     <input type="text" class="form-control">                                                    
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label for="inputPassword" class="col-sm-4 col-form-label font-weight-bolder">Select Type<span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                   <div class="py-2">
                                                      <div class="custom-control custom-radio custom-control-inline">
                                                        <input type="radio" class="custom-control-input" id="radio1" name="radio-iRequirement" value="1">
                                                        <label class="custom-control-label" for="radio1">End User</label>
                                                      </div>
                                                      <div class="custom-control custom-radio custom-control-inline">
                                                        <input type="radio" class="custom-control-input" id="radio2" name="radio-iRequirement" value="2">
                                                        <label class="custom-control-label" for="radio2">Licensee</label>
                                                      </div>
                                                    </div> 
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label for="dropdownState" class="col-sm-4 col-form-label font-weight-bolder">State<span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                      <select class="form-control form-control-sm searchableselect">
                                                            <option>Select</option>
                                                            <option></option>
                                                       </select>                                                   
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label for="dropdownDist" class="col-sm-4 col-form-label font-weight-bolder">District<span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                    <select class="form-control form-control-sm searchableselect">
                                                            <option>Select</option>
                                                            <option></option>
                                                       </select>                                                     
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label for="inputMobile" class="col-sm-4 col-form-label font-weight-bolder">Purchaser Consignee<span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                        <select class="form-control form-control-sm searchableselect">
                                                            <option>Select</option>
                                                            <option></option>
                                                       </select>  
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label for="inputMail" class="col-sm-4 col-form-label font-weight-bolder">Route </label>
                                                <div class="col-sm-7">
                                                     <select class="form-control form-control-sm searchableselect">
                                                            <option>Select</option>
                                                            <option></option>
                                                       </select>  
                                                </div>
                                            </div>
                                        </div>
                                         <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label for="inputMail" class="col-sm-4 col-form-label font-weight-bolder">Through Licensee<span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                   <div class="py-2">
                                                      <div class="custom-control custom-radio custom-control-inline">
                                                        <input type="radio" class="custom-control-input" id="radio3" name="radio-iRequirement" value="1">
                                                        <label class="custom-control-label" for="radio3">yes</label>
                                                      </div>
                                                      <div class="custom-control custom-radio custom-control-inline">
                                                        <input type="radio" class="custom-control-input" id="radio4" name="radio-iRequirement" value="2">
                                                        <label class="custom-control-label" for="radio4">No</label>
                                                      </div>
                                                    </div> 
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label for="inputMail" class="col-sm-4 col-form-label font-weight-bolder">Select Licensee District<span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                   <select class="form-control form-control-sm searchableselect">
                                                            <option>Select</option>
                                                            <option></option>
                                                       </select>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label for="inputMail" class="col-sm-4 col-form-label font-weight-bolder">Select Licensee Type<span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                   <select class="form-control form-control-sm searchableselect">
                                                            <option>Select</option>
                                                            <option></option>
                                                       </select>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label for="inputMail" class="col-sm-4 col-form-label font-weight-bolder">Select Licensee Plant<span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                   <select class="form-control form-control-sm searchableselect">
                                                            <option>Select</option>
                                                            <option></option>
                                                       </select>
                                                </div>
                                            </div>
                                        </div>
                                         <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label for="inputMail" class="col-sm-4 col-form-label font-weight-bolder">Destination <span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                    <textarea class="form-control"  rows="2"></textarea>
                                                </div>
                                            </div>
                                        </div>
                                         <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label for="inputMail" class="col-sm-4 col-form-label font-weight-bolder">Mode Of Transportation<span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                     <select class="form-control form-control-sm searchableselect">
                                                            <option>Select</option>
                                                            <option></option>
                                                       </select>  
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label for="inputMail" class="col-sm-4 col-form-label font-weight-bolder">RTP will be Generated By<span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                   <div class="py-2">
                                                      <div class="custom-control custom-radio custom-control-inline">
                                                        <input type="radio" class="custom-control-input" id="radio5" name="radio-iRequirement" value="1">
                                                        <label class="custom-control-label" for="radio5">Seller</label>
                                                      </div>
                                                      <div class="custom-control custom-radio custom-control-inline">
                                                        <input type="radio" class="custom-control-input" id="radio6" name="radio-iRequirement" value="2">
                                                        <label class="custom-control-label" for="radio6">Purchaser</label>
                                                      </div>
                                                    </div> 
                                                </div>
                                            </div>
                                        </div>
                                        
                                       
                                            <div class="col-lg-6 col-md-12 col-sm-12 offset-lg-2">
                                                <a href="javascript:void(0);" class="btn btn-primary btn-md ml-0" data-toggle="modal"
                                                data-target=".alert-modal">Submit</a>
                                                <a href="#" class="btn btn-danger btn-md">Reset</a>
                                            </div>
                                        </div>
                                    </div>
                            </section>
                        </div>
                    </div>
                 </div>
                    <!-- MAIN CONTENT AREA ENDS -->
            </section>
           <uc1:footer runat="server" ID="footer" />
        </div>
        <!-- END CONTENT -->
    </div>
    <!-- END CONTAINER -->
    </form>
    <link rel="stylesheet"href="../css/searchable-select.min.css">
    <script src="../js/searchable-select.min.js"></script>




    <script>
        indicateMe = "yes"
        backMe="yes"

        $(document).ready(function () {
            loadNavigation('AddPurchaser', 'gletransitpass', 'plpurcon', 'tl', 'E-Transit pass', 'Purchase Consignee', '');

            $('.searchableselect').searchableselect();

            $(".show-toast").click(function () {
                $("#myToast").toast({ autohide: false });
                $("#myToast").toast('show');
            });

            $(".alert-modal").modal({
                show: false,
                backdrop: 'static'
            });
        });
    </script>
</body>
</html>


