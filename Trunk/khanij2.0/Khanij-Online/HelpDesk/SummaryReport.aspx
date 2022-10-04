<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SummaryReport.aspx.cs" Inherits="HelpDesk_SummaryReport" %>
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
<body class="summary-report">
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
                                          Summary Report
                                        </a>
                                    </li>
                                   
                                </ul>
                                <uc1:util runat="server" ID="util" />
                            </div>

                            <section class="box form-container">
                            <div class="content-body">

                          <div class="report-summary">
                            <div class="row">
                                <div class="col-sm-4">
                                <div class="card rounded-0 shadow-sm mb-4">
                                    <div class="card-header d-flex justify-content-between p-1 bg-primary text-white">
                                        <span class="text-uppercase">Khanij Online HDS Summary</span>
                                        <span class="text-uppercase">TOTAL</span>
                                    </div>
                                  <div class="card-body p-1 summary-card custom-scroll">
                                     <div class="mr-1">
                                    <ul class="p-0 mb-0">
                                        <li>
                                            <span>Issue Logged</span>
                                            <span><a target="_blank" href=Locationwisedetailsreport.aspx>13056</a></span>
                                        </li>
                                         <li>
                                            <span>Resolved Issues On Same Day</span>
                                            <span><a target="_blank" href="Locationwisedetailsreport.aspx">8237</a></span>
                                        </li>
                                        <li>
                                            <span>Previous Pending Issues Resolved</span>
                                            <span><a target="_blank" href="Locationwisedetailsreport.aspx">8237</a></span>
                                        </li>
                                        <li>
                                            <span>Total Issues Resolved</span>
                                            <span><a target="_blank" href="Locationwisedetailsreport.aspx">8237</a></span>
                                        </li>
                                        <li>
                                            <span>Today's Pending Issues</span>
                                            <span><a target="_blank" href="Locationwisedetailsreport.aspx">8237</a></span>
                                        </li>
                                    </ul>
                                    </div>
                                  </div>
                                </div>
                                    
                                </div>

                                <div class="col-sm-4">

                                <div class="card rounded-0 shadow-sm mb-4">
                                    <div class="card-header d-flex justify-content-between p-1 bg-primary text-white">
                                        <span class="text-uppercase">SOFTWARE ISSUES</span>
                                        <span class="text-uppercase">TOTAL</span>
                                    </div>
                                  <div class="card-body p-1 summary-card custom-scroll">
                                  <div class="mr-1">
                                    <ul class="p-0 mb-0">
                                        <li>
                                            <span>Issue Logged</span>
                                            <span><a target="_blank" href="Locationwisedetailsreport.aspx">13056</a></span>
                                        </li>
                                        
                                        <li>
                                            <span>Total Issues Resolved</span>
                                            <span><a target="_blank" href="Locationwisedetailsreport.aspx">8237</a></span>
                                        </li>
                                        <li>
                                            <span>Current Open Issue</span>
                                            <span><a target="_blank" href="Locationwisedetailsreport.aspx">8237</a></span>
                                        </li>
                                    </ul>
                                    </div>
                                  </div>
                                </div>
                                

                                </div>

                                <div class="col-sm-4">
                                    <div class="card rounded-0 shadow-sm mb-4">
                                        <div class="card-header d-flex justify-content-between p-1 bg-primary text-white">
                                            <span class="text-uppercase">HARDWARE ISSUES</span>
                                            <span class="text-uppercase">TOTAL</span>
                                        </div>
                                      <div class="card-body p-1 summary-card custom-scroll">
                                      <div class="mr-1">
                                        <ul class="p-0 mb-0">
                                            <li>
                                                <span>Issue Logged</span>
                                                <span><a target="_blank" href="Locationwisedetailsreport.aspx">13056</a></span>
                                            </li>
                                            <li>
                                                <span>Total Issues Resolved</span>
                                                <span><a target="_blank" href="Locationwisedetailsreport.aspx">8237</a></span>
                                            </li>
                                            <li>
                                                <span>Current Open Issue</span>
                                                <span><a target="_blank" href="Locationwisedetailsreport.aspx">8237</a></span>
                                            </li>
                                        </ul>
                                        </div>
                                      </div>
                                    </div>
                                </div>

                            
                                <div class="col-sm-4">
                                <div class="card rounded-0 shadow-sm mb-4">
                                        <div class="card-header d-flex justify-content-between p-1 bg-primary text-white">
                                            <span class="text-uppercase">NETWORK CALLS</span>
                                            <span class="text-uppercase">TOTAL</span>
                                        </div>
                                      <div class="card-body p-1 summary-card custom-scroll">
                                      <div class="mr-1">
                                        <ul class="p-0 mb-0">
                                            <li>
                                                <span>Server Down</span>
                                                <span><a target="_blank" href="Locationwisedetailsreport.aspx">13056</a></span>
                                            </li>
                                            <li>
                                                <span>Internet Connectivity at User Side</span>
                                                <span><a target="_blank" href="Locationwisedetailsreport.aspx">8237</a></span>
                                            </li>
                                        </ul>
                                        </div>
                                      </div>
                                    </div>
                               
                                </div>

                                <div class="col-sm-4">
                                <div class="card rounded-0 shadow-sm mb-4">
                                        <div class="card-header d-flex justify-content-between p-1 bg-primary text-white">
                                            <span class="text-uppercase">OTHER</span>
                                            <span class="text-uppercase">TOTAL</span>
                                        </div>
                                      <div class="card-body p-1 summary-card custom-scroll">
                                      <div class="mr-1">
                                        <ul class="p-0 mb-0">
                                            <li>
                                                <span>Queries/Suggestions/Grievance</span>
                                                <span><a target="_blank" href="Locationwisedetailsreport.aspx">13056</a></span>
                                            </li>
                                            
                                        </ul>
                                        </div>
                                      </div>
                                    </div>
                                    
                                </div>

                                 <div class="col-sm-4">
                                 <div class="card rounded-0 shadow-sm mb-4">
                                        <div class="card-header d-flex justify-content-between p-1 bg-primary text-white">
                                            <span class="text-uppercase">Status Wise Summary</span>
                                            <span class="text-uppercase">TOTAL</span>
                                        </div>
                                      <div class="card-body p-1 summary-card custom-scroll">
                                      <div class="mr-1">
                                        <ul class="p-0 mb-0">
                                            <li>
                                                <span>Initiated</span>
                                                <span><a target="_blank" href="Locationwisedetailsreport.aspx">13056</a></span>
                                            </li>
                                            <li>
                                                <span>FMS</span>
                                                <span><a target="_blank" href="Locationwisedetailsreport.aspx">13056</a></span>
                                            </li>
                                             <li>
                                                <span>OSU</span>
                                                <span><a target="_blank" href="Locationwisedetailsreport.aspx">13056</a></span>
                                            </li>
                                             <li>
                                                <span>Closed</span>
                                                <span><a target="_blank" href="Locationwisedetailsreport.aspx">13056</a></span>
                                            </li>
                                            <li>
                                                <span>Total</span>
                                                <span><a target="_blank" href="Locationwisedetailsreport.aspx">13056</a></span>
                                            </li>
                                            
                                        </ul>
                                        </div>
                                      </div>
                                    </div>
                                      
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
    <script src="../js/perfect-scrollbar.min.js" ></script>
    <script src="../js/searchable-select.min.js"></script>
    <link rel="stylesheet"href="../css/dataTables.bootstrap4.min.css">
    <script src="../js/jquery.dataTables.min.js"></script>
<script src="../js/dataTables.bootstrap4.min.js"></script>
    <script>
        excelMe = "yes"
        pdfMe = "yes"
        printMe = "yes"



        $(document).ready(function () {
            loadNavigation('SummaryReport', 'glhelpdesk', 'plsumrep', 'tl', 'Help Desk', 'Summary Report', '');
  
        });
    </script>

   
</body>
</html>


