<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CreditNotePayment.aspx.cs"
    Inherits="DemandCreditNotePayment_CreditNotePayment" %>

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
                            <a class="nav-link" href="DemandNotePayment.aspx" >
                                DemandNotePaymentSummary
                            </a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link active" href="CreditNotePayment.aspx">
                                CreditNotePaymentSummary
                            </a>
                        </li>
                    </ul>
                    <uc1:util runat="server" ID="util" />
                </div>
                <section class="box form-container"> 
                 <div class="search-box">
                                    <div class="searchform px-3 pt-3">
                                        <div class="row">
                                            <div class="col-sm-5">
                                                <div class="form-group row">
                                                    <label for="inputText" class="col-sm-3 col-form-label">
                                                        From date </label>
                                                    <div class="col-sm-8">
                                                       <asp:TextBox ID="txtFromdate" CssClass="form-control datetime" runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-sm-5">
                                                <div class="form-group row">
                                                    <label for="inputText" class="col-sm-3 col-form-label">
                                                        To date </label>
                                                    <div class="col-sm-8">
                                                       <asp:TextBox ID="txtTodate" CssClass="form-control datetime" runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-sm-2">
                                                <div class="form-group row">
                                                        <a href="#" class="btn btn-sm btn-success m-0"> Show </a> 
                                                </div>
                                            </div>
                                          
                                        </div>
                                    
                                       
                                        </div>

                                   
                                </div>
                                <div>
                                Summary :- From Date : 08/02/2021 and End Date : 08/02/2021
                                <asp:Button ID="btnSend" CssClass="btn-secondary" runat="server" Text="Verify & Send"/>
                                </div>                 
                    <div class="content-body pt-0">
                        <div class="row">
                            <div class="col-sm-12">
                                <div class="table-responsive" id="viewtable">
                                    <table id="datatable" class="table table-sm table-bordered">
                                        <thead>
                                            <tr>
                                                <th width="30"> Sl#</th>
                                                <th>
                                                   Verify
                                                </th>
                                                <th>
                                                    District Name
                                                </th>
                                                <th>
                                                    User Name
                                                </th>
                                                <th>
                                                    Lessee Name
                                                </th>
                                                <th>
                                                    Credit Note No
                                                </th>
                                                 <th>
                                                    Date of Issuance
                                                </th>
                                                 <th>
                                                   From Date
                                                </th>
                                                <th>
                                                    To Date
                                                </th>
                                                <th>
                                                    Online Payment
                                                </th>
                                                <th>
                                                    Shall be paid separately
                                                </th>
                                                 <th>
                                                   Download File
                                                </th>
                                                <th>
                                                    Payment Status
                                                </th>
                                                 <th>
                                                   Bank Transaction Details
                                                </th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                         <tr>
                                                <td>
                                                    <label>1</label>                                                   
                                                </td>
                                                <td><input type="checkbox" id="chk1" name="" value=""/></td>
                                                <td><p class="m-0">Durg</p> </td>
                                                <td><p class="m-0">5101000601</p> </td>
                                                <td><p class="m-0">ACC Jamul Area:36000(Pathariya)	</p> </td>
                                                <td><p class="m-0">5101000601/201/339F21093676</p> </td>
                                                <td><p class="m-0">12/01/2021</p> </td>
                                                <td><p class="m-0">20/02/2021</p> </td>
                                                <td><p class="m-0">20/02/2021</p> </td>
                                                <td><p class="m-0">
                                                Royalty rate: 100
                                                Royalty: 200
                                                NMET: 300
                                                DMF:0
                                                Monthly Periodic Amount: 100
                                                Total Amount: 700
                                                </p> </td>
                                                 <td><p class="m-0">
                                                TCS: 100
                                                Infrastructure Devlopment: 200
                                                CESS: 300
                                                Environmental Cess:0
                                                Total Amount: 600
                                                </p> </td>
                                                <td><p class="m-0"><i class="fa fa-download" aria-hidden="true"></i></p> </td>
                                                <td><p class="m-0"><i class="fa fa-credit-card" aria-hidden="true"></i></p> </td>
                                               <td><p class="m-0"></p> </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <label>2</label>                                                   
                                                </td>
                                                 <td><input type="checkbox" id="chk2" name="" value=""/></td>
                                                <td><p class="m-0">Durg</p> </td>
                                                <td><p class="m-0">5101000601</p> </td>
                                                <td><p class="m-0">ACC Jamul Area:36000(Pathariya)	</p> </td>
                                                <td><p class="m-0">5101000601/201/339F21093676</p> </td>
                                                <td><p class="m-0">12/01/2021</p> </td>
                                                <td><p class="m-0">20/02/2021</p> </td>
                                                 <td><p class="m-0">20/02/2021</p> </td>
                                                <td><p class="m-0">
                                                Royalty rate: 100
                                                Royalty: 200
                                                NMET: 300
                                                DMF:0
                                                Monthly Periodic Amount: 100
                                                Total Amount: 700
                                                </p> </td>
                                                 <td><p class="m-0">
                                                TCS: 100
                                                Infrastructure Devlopment: 200
                                                CESS: 300
                                                Environmental Cess:0
                                                Total Amount: 600
                                                </p> </td>
                                                <td><p class="m-0"><i class="fa fa-download" aria-hidden="true"></i></p> </td>
                                                <td><p class="m-0"><i class="fa fa-credit-card" aria-hidden="true"></i></p> </td>
                                               <td><p class="m-0"></p> </td>
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
            loadNavigation('DemandNotePayment', 'glTMng', 'pldistrict', 'tl', 'Demand/CreditNote', 'DemandCreditNotePayment', '');

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
