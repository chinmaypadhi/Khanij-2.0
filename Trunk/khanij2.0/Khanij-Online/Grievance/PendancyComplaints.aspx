<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PendancyComplaints.aspx.cs" Inherits="Grievance_PendancyComplaints" %>
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
                                        <a class="nav-link" href="PendancyComplaints.aspx">
                                            Pendancy Complaints
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
                                                            <th width="30">Complaint Number</th>
                                                           
                                                            <th>
                                                              
                                                          Subject of complaint
                                                            </th>
                                                            <th> 
                                                           Name of complainer
                                                            </th>
                                                           
                                                            <th>Complain Related to Person</th>
                                                            <th>                                                                 
                                                            Date of complaint
                                                            </th>

                                                            
                                                            
                                                              <th>                                                                 
                                                           Remark
                                                            </th>
                                                              <th>                                                                 
                                                          Attachment
                                                            </th>
                                                              <th>                                                                 
                                                          View Details
                                                            </th>
                                                           
                                                          
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <tr class="active-row">
                                                            <td>CL-1</td>
                                                            
                                                            <td>
																<p class="m-0">Illigal Transportation</p>
															</td>
                                                            
                                                            <td>
																<p class="m-0">RAMA UDYOG PVT. LTD.</p>
															</td>
                                                             <td>
																<p class="m-0">Ranjit Singh</p>
															</td>

                                                             <td>
																<p class="m-0">24/12/2018</p>
															</td>
                                                             
                                                             <td>
																<p class="m-0">	Please Solve</p>
															</td>
                                                             <td class="noprint">
																<p class="m-0">	
                                                                <a  title="Edit">Download</a>
                                                                </p>
															</td>
                                                             <td class="noprint" style="width:100px">
																<p class="m-0">	
                                                                <a href="AddComplaintRegistrationForm.aspx" title="View Details">View Details</a>
                                                                </p>
															</td>
                                                           
                                                        </tr>
                                                      <tr class="active-row">
                                                            <td>CL-3</td>
                                                            
                                                            <td>
																<p class="m-0">Illigal Mining</p>
															</td>
                                                            
                                                            <td>
																<p class="m-0">C.Krishnamachari</p>
															</td>
                                                             <td>
																<p class="m-0">Rajgopal Berma</p>
															</td>

                                                             <td>
																<p class="m-0">17/12/2018</p>
															</td>
                                                            
                                                             <td>
																<p class="m-0">Please Solve	</p>
															</td>
                                                             <td class="noprint">
																<p class="m-0">	
                                                                <a  title="Edit">Download</a>
                                                                </p>
															</td>
                                                             <td class="noprint" style="width:100px">
																<p class="m-0">	
                                                                <a href="AddComplaintRegistrationForm.aspx" title="View Details">View Details</a>
                                                                </p>
															</td>
                                                           
                                                        </tr>
                                                          <tr class="active-row">
                                                            <td>CL-6</td>
                                                            
                                                            <td>
																<p class="m-0">Illigal Mining</p>
															</td>
                                                            
                                                            <td>
																<p class="m-0">Anurag Diwan</p>
															</td>
                                                             <td>
																<p class="m-0">Anjan Swain</p>
															</td>

                                                             <td>
																<p class="m-0">11/10/2019</p>
															</td>
                                                             
                                                             <td>
																<p class="m-0">Plese Solve	</p>
															</td>
                                                             <td class="noprint">
																<p class="m-0">	
                                                                <a title="Edit">Download</a>
                                                                </p>
															</td>
                                                             <td class="noprint" style="width:100px">
																<p class="m-0">	
                                                                <a href="AddComplaintRegistrationForm.aspx" title="View Details">View Details</a>
                                                                </p>
															</td>
                                                           
                                                        </tr>
                                                          <tr class="active-row">
                                                            <td>CL-13</td>
                                                            
                                                            <td>
																<p class="m-0">Illigal Mining</p>
															</td>
                                                            
                                                            <td>
																<p class="m-0">Debaraj</p>
															</td>
                                                             <td>
																<p class="m-0">Ranjit Singh</p>
															</td>

                                                             <td>
																<p class="m-0">10/10/2019</p>
															</td>
                                                            
                                                             <td>
																<p class="m-0">Please Solve	</p>
															</td>
                                                             <td class="noprint">
																<p class="m-0">	
                                                                <a title="Edit">Download</a>
                                                                </p>
															</td>
                                                             <td class="noprint" style="width:100px">
																<p class="m-0">	
                                                                <a href="AddComplaintRegistrationForm.aspx" title="View Details">View Details</a>
                                                                </p>
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
            loadNavigation('ViewPaymentHead', 'glTMng', 'plpaymenthead', 'tl', 'Grievance', 'Pendancy Complaints', ' ');

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
