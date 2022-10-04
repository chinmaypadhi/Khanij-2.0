<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Locationwisedetailsreport.aspx.cs"
    Inherits="HelpDesk_Locationwisedetailsreport" %>

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
    <link rel="stylesheet" href="../css/style.css" type="text/css" />
    <link rel="alternate stylesheet" media="screen" title="infotheme" href="../css/theme-info.css" />
    <link rel="alternate stylesheet" media="screen" title="greentheme" href="../css/theme-success.css" />
    <link rel="alternate stylesheet" media="screen" title="orangetheme" href="../css/theme-warning.css" />
    <link rel="alternate stylesheet" media="screen" title="purpletheme" href="../css/theme-secondary.css" />
    <link rel="alternate stylesheet" media="screen" title="redtheme" href="../css/theme-danger.css" />
    <style type="text/css">
        .collon
        {
            position: absolute;
            left: -10px;
            font-weight: 600;
        }
    </style>
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
                                           Reported Ticket List
                                        </a>
                                    </li>
                                   
                                </ul>
                                <uc1:util runat="server" ID="util" />
                            </div>

                            <section class="box form-container">
                             
                                <div class="search-box">
                                    <div class="searchform px-3 py-3">
                                        <div class="row">
                                            <div class="col-sm-12">
                                                

                                           
                                            
                                        </div>
                                    
                                        
                                        </div>

                                      

                                    
                                </div>

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
                                                    <th>Ticket Number</th>
                                                    <th>Open Date & time</th>
                                                    <th>Delay Time</th>
                                                    <th>State</th>
                                                    <th>District</th>
                                                    <th>Complainer Name</th>
                                                   
                                                    <th>Complainer Mobile No</th>
                                                    <th>Complainer Email</th>
                                                    <th>User Id</th>
                                                    <th>Category:Module:Item</th>
                                                    <th>Problem Description</th>
                                                    <th>Solution Description</th>
                                                     <th>Priority</th> <th>Status</th> <th>Issued Reported By</th>
                                                      <th>Designation</th>                                               </tr>
                                            </thead>
                                            <tbody>
                                            <tr class="active-row">
                                            <td><p class="m-0">1</p></td>
                                            
                                                    <td><p class="m-0">Ticket_00000000010</p></td>
                                                    <td><p class="m-0">04-Feb-2021 , 09:32</p></td>
                                                     <td><p class="m-0">5 day/120 Hours/4 Minutes</p></td>
                                                       <td><p class="m-0">Odisha</p></td>
                                                    <td><p class="m-0">Chhattisgarh</p></td>
                                                    <td><p class="m-0">Suroj kumar Pradhan</p></td>
                                                     <td><p class="m-0">9853150842</p></td>
                                                     <td><p class="m-0">Suroj.pradhan@yahoo.in</p></td>
                                                      <td><p class="m-0">4150023687</p></td>
                                                    <td><p class="m-0">Software:End User Registration:End User Registration</p></td>
                                                    <td><p class="m-0">Testing</p></td>
                                                    <td><p class="m-0">ok</p></td>
                                                    <td><p class="m-0">High</p></td>
                                                    <td><p class="m-0">Initiated</p></td>
                                                    <td><p class="m-0">Issued Reported by Nikhil Ray</p></td>
                                                    <td><p class="m-0">Helpdesk</p></td>
                                                    

                                                   
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
    <link rel="stylesheet" href="../css/searchable-select.min.css">
    <script src="../js/searchable-select.min.js"></script>
    <link rel="stylesheet" href="../css/dataTables.bootstrap4.min.css">
    <script src="../js/jquery.dataTables.min.js"></script>
    <script src="../js/dataTables.bootstrap4.min.js"></script>
    <script>
        excelMe = "yes"
        pdfMe = "yes"
        printMe = "yes"



        $(document).ready(function () {
            loadNavigation('ReportedTicketList', 'glhelpdesk', 'plrepticlis', 'tl', 'Help Desk', 'Reported Ticket List', '');

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
    <!-- alert 1-->
    <div class="modal fade alert-modal" tabindex="-1" role="dialog" aria-labelledby="alertModal"
        aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header p-2">
                    <h5 class="modal-title mt-0">
                        Complainer Details</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">×</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="form-group row">
                        <label class="col-sm-3 col-form-label text-left">
                            State</label>
                        <label class="col-sm-3 form-control-plaintext">
                            <span class="collon">:</span>Chhattisgarh</label>
                        <label class="col-sm-3 col-form-label text-left">
                            District</label>
                        <label class="col-sm-3 form-control-plaintext">
                            <span class="collon">:</span>Raipur</label>
                    </div>
                    <div class="form-group row">
                        <label class="col-sm-3 col-form-label text-left">
                            Complainer Name</label>
                        <label class="col-sm-3 form-control-plaintext">
                            <span class="collon">:</span>Vaibhav Mayee</label>
                        <label class="col-sm-3 col-form-label text-left">
                            Complainer Mobile No.</label>
                        <label class="col-sm-3 form-control-plaintext">
                            <span class="collon">:</span>9372211223</label>
                    </div>
                    <div class="form-group row">
                        <label class="col-sm-3 col-form-label text-left">
                            User Name</label>
                        <label class="col-sm-3 form-control-plaintext">
                            <span class="collon">:</span>CTL_Vaibhav</label>
                        <label class="col-sm-3 col-form-label text-left">
                            Category</label>
                        <label class="col-sm-3 form-control-plaintext">
                            <span class="collon">:</span>Software</label>
                    </div>
                    <div class="form-group row">
                        <label class="col-sm-3 col-form-label text-left">
                            Module</label>
                        <label class="col-sm-3 form-control-plaintext">
                            <span class="collon">:</span>E-Permit</label>
                        <label class="col-sm-3 col-form-label text-left">
                            Item</label>
                        <label class="col-sm-3 form-control-plaintext">
                            <span class="collon">:</span>E-Permit</label>
                    </div>
                    <div class="form-group row">
                        <label class="col-sm-3 col-form-label text-left">
                            Priority</label>
                        <label class="col-sm-3 form-control-plaintext">
                            <span class="collon">:</span>Medium</label>
                    </div>
                </div>
            </div>
        </div>
    </div>
</body>
