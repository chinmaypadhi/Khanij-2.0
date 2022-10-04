<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SubmitCases.aspx.cs" Inherits="Checkpost_SubmitCases" %>

<%@ Register Src="~/includes/navbar.ascx" TagPrefix="uc1" TagName="navbar" %>
<%@ Register Src="~/includes/leftsider.ascx" TagPrefix="uc1" TagName="leftsider" %>
<%@ Register Src="~/includes/navigation.ascx" TagPrefix="uc1" TagName="navigation" %>
<%@ Register Src="~/includes/util.ascx" TagPrefix="uc1" TagName="util" %>
<%@ Register Src="~/includes/footer.ascx" TagPrefix="uc1" TagName="footer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
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
        <div class="row">
            <div class="col-12">
                <section class="box form-container">   
                    <div class="search-box">
                                    <div class="searchform px-3 pt-3">
                                        <div class="row">
                                         <div class="col-sm-5">
                                                <div class="form-group row">
                                                    <label for="inputText" class="col-sm-3 col-form-label">
                                                        Cases of Irregularity </label>
                                                    <div class="col-sm-8">
                                                        <select class="form-control">
                                                           <option>Select Case</option>
                                                           <option>No Transit Pass</option>
                                                           <option>Excess Mineral Quantity</option>
                                                           <option>Invalid Transit Pass & Other Condition</option>
                                                      </select>
                                                    </div>
                                                </div>
                                            </div>
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
                    <div class="content-body pt-0">
                        <div class="row">
                            <div class="col-sm-12">
                                <div class="table-responsive" id="viewtable">
                                    <table id="datatable" class="table table-sm table-bordered">
                                        <thead>
                                            <tr>
                                                <th width="30"> Sl#</th>
                                                <th>
                                                   Type
                                                </th>
                                                <th>
                                                    Transit Pass No
                                                </th>
                                                <th>
                                                    Check Post Name
                                                </th>
                                                <th>
                                                    Check Time
                                                </th>
                                                <th>
                                                    Lessee/Licensee Name
                                                </th>
                                                 <th>
                                                    Licensee/Mining Details
                                                </th>
                                                 <th>
                                                    Name Of Mineral
                                                </th>
                                                <th>PreviousGrossWeight</th>
                                                <th>Previous Gross Weight</th>
                                                <th>Current Gross Weight</th>
                                                <th>Difference Weight</th>
                                                <th>Sale Valueof Mineral</th>
                                                <th>Date Of Dispatch</th>
                                                <th>Vehicle No</th>
                                                <th>Vehicle Type</th>
                                                <th>Transporter Name</th>
                                                <th>Driver Name</th>
                                                <th>Purchaser Name</th>
                                                <th>DONumber</th>
                                                <th>Destination</th>
                                                <th>Route</th>
                                                <th>Remark</th>
                                                <th>Case Of Irregularity</th>
                                                <th>Status</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                         <tr>
                                              <td>1</td>
                                              <td>abc</td>
                                              <td>abc</td>
                                              <td>abc</td>
                                              <td>abc</td>
                                              <td>abc</td>  
                                               <td>abc</td>
                                              <td>abc</td>
                                              <td>abc</td>
                                              <td>abc</td>
                                              <td>abc</td>
                                              <td>abc</td> 
                                               <td>abc</td>
                                              <td>abc</td>
                                              <td>abc</td>
                                              <td>abc</td>
                                              <td>abc</td>
                                              <td>abc</td> 
                                               <td>abc</td>
                                              <td>abc</td>
                                              <td>abc</td>
                                              <td>abc</td>
                                              <td>abc</td>
                                              <td>abc</td> 
                                              <td>abc</td>
                                            </tr>
                                            <tr>
                                                <td>2</td>
                                              <td>def</td>
                                             <td>def</td>
                                              <td>def</td>
                                             <td>def</td>
                                              <td>def</td>
                                            <td>def</td>
                                               <td>def</td>
                                             <td>def</td>
                                              <td>def</td>
                                             <td>def</td>
                                              <td>def</td>
                                            <td>def</td>
                                                <td>def</td>
                                             <td>def</td>
                                              <td>def</td>
                                             <td>def</td>
                                              <td>def</td>
                                            <td>def</td>
                                                <td>def</td>
                                             <td>def</td>
                                              <td>def</td>
                                             <td>def</td>
                                              <td>def</td>
                                            <td>def</td>
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
            loadNavigation('SubmitCases', 'glTMng', 'plmineral', 'tl', 'Checkpost', 'Submit Irregularity', '');

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
        $('.datetime').datetimepicker({
            format: "DD/MM/YYYY"
        });
    </script>
</body>
</html>
