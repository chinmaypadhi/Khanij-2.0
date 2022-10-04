﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewManualCreditAmount.aspx.cs"
    Inherits="DemandCreditNotePayment_ViewManualCreditAmount" %>

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
         <uc1:navigation runat="server" ID="navigation" />
        <!-- MAIN CONTENT AREA STARTS -->
        <div class="row">
            <div class="col-12">
                <div class="main-tab">
                    <ul class="nav nav-tabs">
                        <li class="nav-item">
                            <a class="nav-link" href="AddManualCreditAmount.aspx">
                                Add New Credit Amount Details
                            </a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link active" href="ViewManualCreditAmount.aspx">
                                View New Credit Amount Details
                            </a>
                        </li>
                    </ul>
                    <uc1:util runat="server" ID="util" />
                </div>
                <section class="box form-container">                
                    <div class="content-body pt-0">
                        <div class="row">
                            <div class="col-sm-12">
                                <div class="table-responsive" id="viewtable">
                                    <table id="datatable" class="table table-sm table-bordered">
                                        <thead>
                                            <tr>
                                                <th width="30"> Sl#</th>
                                                <th>
                                                   Payment Type
                                                </th>
                                                <th>
                                                    Lessee Name
                                                </th>
                                                <th>
                                                    Credit Amount
                                                </th>
                                                <th>
                                                    Assesment Copy
                                                </th>
                                               
                                            </tr>
                                        </thead>
                                        <tbody>
                                         <tr>
                                                <td>
                                                    <label>1</label>                                                   
                                                </td>
                                                <td><p class="m-0">Payable Royalty</p> </td>
                                                <td><p class="m-0">Akhilesh Kumar- Area : 4.479(laalpur) [ 4231000901 ] </p> </td>
                                                <td><p class="m-0">12444</p> </td>                                             
                                                <td><p class="m-0"><i class="fa fa-download" aria-hidden="true"></i></p> </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <label>2</label>                                                   
                                                </td>
                                                <td><p class="m-0">Payable Royalty</p> </td>
                                                <td><p class="m-0">4231002401-D.K Agrwal-D.K Agrwal- Area : 4.858(tandwa) [ 4231000921 ] </p> </td>
                                                <td><p class="m-0">2103</p> </td>                                             
                                                <td><p class="m-0"><i class="fa fa-download" aria-hidden="true"></i></p> </td>
                                            </tr>
                                        </tbody>
                                    </table>
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
    <link rel="stylesheet" href="../css/searchable-select.min.css">
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
            loadNavigation('AddManualCreditAmount', 'glTMng', 'plmineral', 'tl', 'Demand/CreditNote', 'Manual Credit Amount', '');

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
        });
    </script>
    <script>
        $('.datetime').datetimepicker({
            format: "DD/MM/YYYY"
        });
    </script>
</body>
</html>
