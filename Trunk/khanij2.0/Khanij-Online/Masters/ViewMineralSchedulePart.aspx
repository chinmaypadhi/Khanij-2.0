<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewMineralSchedulePart.aspx.cs" Inherits="Masters_ViewMineralSchedulePart" %>

<%@ Register Src="~/includes/navbar.ascx" TagPrefix="uc1" TagName="navbar" %>
<%@ Register Src="~/includes/leftsider.ascx" TagPrefix="uc1" TagName="leftsider" %>
<%@ Register Src="~/includes/navigation.ascx" TagPrefix="uc1" TagName="navigation" %>
<%@ Register Src="~/includes/util.ascx" TagPrefix="uc1" TagName="util" %>
<%@ Register Src="~/includes/footer.ascx" TagPrefix="uc1" TagName="footer" %>

<!DOCTYPE html>
<html lang="en">
<head id="Head1" runat="server">
    <meta http-equiv="content-type" content="text/html;charset=UTF-8" />
    <meta charset="utf-8" />
    <title>Khanij Online </title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <meta content="" name="description" />
    <meta content="" name="author" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <link rel="stylesheet" href="../css/bootstrap.min.css" media="screen" />
    <link rel="stylesheet" href="../css/mdb.min.css" media="screen" />
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
                            <a class="nav-link" href="addMineralSchedulePart.aspx">
                                Add Mineral Schedule Part
                            </a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link active" href="javascript:void(0);">

                                View
                            </a>
                        </li>
                    </ul>
                    <uc1:util runat="server" ID="util" />
                </div>

                <section class="box form-container">


                    <div class="content-body pt-0">
                        <div class="legend-box">
                            <ul class="d-flex mb-1 justify-content-end list-unstyled">
                                <li><span class="bg-success"></span> Active</li>
                                <li><span class="bg-warning"></span> Inactive</li>
                            </ul>
                        </div>
                        <div class="row">
                            <div class="col-sm-12">
                                <div class="table-responsive" id="viewtable">
                                    <table id="datatable" class="table table-sm table-bordered">
                                        <thead>
                                            <tr>
                                                <th width="30">Sl#</th>
                                                <th>Mineral Category</th>
                                                <th>Mineral Schedule </th>
                                                <th>Mineral Schedule Part</th>
                                                <th>Status </th>
                                                <th>Action</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                           
                                            <tr>
                                                <td>1</td>
                                                <td>Major Mineral </td>
                                                <td>Fourth Schedule of MMDR Act 1957</td>
                                                <td>Not Applicable </td>
                                                <td>Active</td>
                                                <td class="noprint">
                                                    <a href="#"
                                                       class="btn-floating btn-outline-primary btn-sm"
                                                       title="Edit"><i class="fas fa-pencil-alt"></i></a>
                                                    <a href="#"
                                                       class="btn-floating btn-outline-danger btn-sm"
                                                       title="Delete"><i class="far fa-trash-alt"></i></a>
                                                </td>
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
    <link rel="stylesheet"href="../css/dataTables.bootstrap4.min.css">
    <script src="../js/jquery.dataTables.min.js"></script>
<script src="../js/dataTables.bootstrap4.min.js"></script>
    <script>
        excelMe = "yes"
        pdfMe = "yes"
        printMe = "yes"



        $(document).ready(function () {
            loadNavigation('ViewSchdulePart', 'glTMng', 'pldistrict', 'tl', 'Masters', 'Schdule Part', '');

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
</body>
</html>
