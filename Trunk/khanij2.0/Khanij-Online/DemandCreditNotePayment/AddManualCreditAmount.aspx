<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddManualCreditAmount.aspx.cs"
    Inherits="DemandCreditNotePayment_AddManualCreditAmount" %>

<%@ Register Src="~/includes/navbar.ascx" TagPrefix="uc1" TagName="navbar" %>
<%@ Register Src="~/includes/leftsider.ascx" TagPrefix="uc1" TagName="leftsider" %>
<%@ Register Src="~/includes/navigation.ascx" TagPrefix="uc1" TagName="navigation" %>
<%@ Register Src="~/includes/util.ascx" TagPrefix="uc1" TagName="util" %>
<%@ Register Src="~/includes/footer.ascx" TagPrefix="uc1" TagName="footer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
        <!-- MAIN CONTENT AREA STARTS -->
        <uc1:navigation runat="server" ID="navigation" />
        <div class="row">
            <div class="col-12">
                <div class="main-tab">
                    <ul class="nav nav-tabs">
                        <li class="nav-item">
                            <a class="nav-link active" href="AddManualCreditAmount.aspx">
                                Add New Credit Amount Details
                            </a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="ViewManualCreditAmount.aspx">
                                View New Credit Amount Details
                            </a>
                        </li>
                    </ul>
                   <uc1:util runat="server" ID="util" />
                </div>

                <section class="box form-container">
                    <div class="content-body">
                        
                            <div class="row">
                                <div class="col-sm-6">
                                    <div class="form-group row">
                                        <label for="inputLoginId" class="col-sm-4 col-form-label">Payment Type <span class="text-danger">*</span></label>
                                        <div class="col-sm-7">
                                           <select class="form-control">
                                                <option>Select Payment Type</option>
                                                <option>Royalty</option>
                                                <option>DMF</option>
                                                 <option>Environmental Cess</option>
                                                <option>Infastructure & Devlopment Cess</option>
                                                 <option>TCS</option>
                                            </select>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-6">
                                    <div class="form-group row">
                                        <label for="inputLoginId" class="col-sm-4 col-form-label">Lessee Name<span class="text-danger">*</span></label>
                                        <div class="col-sm-7">
                                           <select class="form-control">
                                                <option>Select District master</option>
                                                <option>4231000901-Akhilesh Kumar-Akhilesh Kumar- Area : 4.479(laalpur)</option>
                                                <option>4231001301-Ashok Sarin-Ashok Sarin- Area : 10.121(madi)</option>
                                                 <option>4231002401-D.K Agrwal-D.K Agrwal- Area : 4.858(tandwa)</option>
                                                <option>4231004101-Kedar Agrawal-Kedar Agrawal- Area : 9.716(pathrakundi)</option>
                                                 <option>4231005101-Manish Sharma-Manish Sharma- Area : 4.834(matiya)</option>
                                            </select>
                                        </div>

                                    </div>

                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-6">
                                    <div class="form-group row">
                                        <label for="inputLoginId" class="col-sm-4 col-form-label">Credit Amount <span class="text-danger">*</span></label>
                                        <div class="col-sm-7">
                                                 <input type="text" class="form-control" />
                                        </div>

                                    </div>

                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-6">
                                    <div class="form-group row">
                                        <label for="inputName" class="col-sm-4 col-form-label">Upload Assessment Copy <span class="text-danger">*</span></label>
                                        <div class="col-sm-7">
                                         <input type="file" id="myFile" name="filename">
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-6 offset-sm-2">
                                    
                                    <a href="#" class="btn btn-primary btn-md ml-0">Submit</a>
                    <a href="#" class="btn btn-danger btn-md">Reset</a>
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
    <link rel="stylesheet" href="../css/searchable-select.min.css">
    <script src="../js/searchable-select.min.js"></script>
    <!-- alert 1-->
    <div class="modal fade alert-modal" tabindex="-1" role="dialog" aria-labelledby="alertModal"
        aria-hidden="true">
        <div class="modal-dialog modal-md" role="document">
            <div class="modal-content">
                <div class="modal-body text-center">
                    <h5 class="p-2 ">
                        <i class="fas fa-check fa-2x mb-3 text-success"></i>
                        <br>
                        Your Form has been submitted Successfully.</h5>
                    <a class="btn btn-primary btn-md" href="javascrip:;" data-dismiss="modal">Ok</a>
                </div>
            </div>
        </div>
    </div>
    <script>
        indicateMe = "yes"

        $(document).ready(function () {
            loadNavigation('AddManualCreditAmount', 'glTMng', 'plmineral', 'tl', 'Demand/CreditNote', 'Manual Credit Amount', '');

            $('.searchableselect').searchableselect();


        });
    </script>
</body>
</html>
