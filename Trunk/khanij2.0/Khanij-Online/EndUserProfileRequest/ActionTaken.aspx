﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ActionTaken.aspx.cs" Inherits="EndUserProfileRequest_ActionTaken" %>
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
                                    <li class="nav-item mr-md-1">
                                        <a class="nav-link " href="NewRequrest.aspx">
                                            Add New Request
                                        </a>
                                    </li>
                                    <li class="nav-item mr-md-1">
                                        <a class="nav-link " href="UpdationRequest.aspx">
                                           Updation Request
                                        </a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link active" href="ActionTaken.aspx">
                                           Action Taken
                                        </a>
                                    </li>
                                </ul>
                                <uc1:util runat="server" ID="util" />
                            </div>

                            <section class="box form-container">
                                <div class="search-box">
                                    <div class="searchform px-3 pt-3">
                                        <div class="row">
                                           

                                            <div class="col-sm-4">
                                                <div class="form-group row">
                                                    <label for="inputText" class="col-sm-3 col-form-label">
                                                       From Date </label>
                                                    <div class="col-sm-8">
                                                       <div class="input-group">
                                                      <input type="text" class="form-control datepicker" id="Text3">
                                                      <div class="input-group-prepend">
                                                        <label class="input-group-text" for="inputDate1"><i class="far fa-calendar"></i></label>
                                                      </div>
                                                 </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-sm-4">
                                                <div class="form-group row">
                                                    <label for="inputText" class="col-sm-3 col-form-label">
                                                       To Date </label>
                                                    <div class="col-sm-8">
                                                       <div class="input-group">
                                                      <input type="text" class="form-control datepicker" id="Text1">
                                                      <div class="input-group-prepend">
                                                        <label class="input-group-text" for="inputDate1"><i class="far fa-calendar"></i></label>
                                                      </div>
                                                 </div>
                                                    </div>
                                                </div>
                                            </div>
                                                

                                           
                                    <div class="col-sm-2">
                                        <a href="#" class="btn btn-sm btn-success m-0 waves-effect waves-light"> Show </a>
                                    </div>
                                    
                                        
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
                                                            <th width="40px">Sl#</th>
                                                            <th>Request Type</th>
                                                            <th>User Name/ Registration No.</th>
                                                            <th>Registration Type</th>
                                                            <th>User Type</th>
                                                            <th>Application Name</th>
                                                            <th>Company Name</th>
                                                            <th>District Name</th>
                                                            <th>State Name</th>
                                                            <th>Status</th>
                                                            <th>User Remark</th>
                                                            <th>Approved Remark</th>
                                                            <th>Request By</th>
                                                            <th>Request On</th>
                                                            <th>Action Taken By</th>
                                                            <th>Action Taken On</th>
                                                            <th width="100px">Actions</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <tr class="active-row">
                                                            <td >1</td>
                                                            <td class=" text-primary">New</td>
                                                            <td>EUP20201207001</td>
                                                            <td>Industry</td>
                                                            <td>Company</td>
                                                            <td>ARVIND AGARWAL</td>
                                                            <td>MAA SHAKUMBARI SPONGE PVT LTD</td>
                                                            <td>Sundergarh</td>
                                                            <td>Odisha</td>
                                                            <td class="text-success">Approved</td>
                                                            <td>NA</td>
                                                            <td>Approved</td>
                                                            <td>ARVIND AGARWAL</td>
                                                            <td>07-12-2020 11:29:39</td>
                                                            <td>Dr. Sanjay Khare</td>
                                                            <td>09-12-2020 17:04:32</td>
                                                            <td class="noprint">
                                                                <a href="ActionTakenView.aspx" 
                                                                class="btn-floating btn-outline-primary btn-sm"
                                                                        title="View">View Details</a>  
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
<link href="../css/bootstrap-datetimepicker.min.css" rel="stylesheet">
    <script src="../js/moment.min.js"></script> 
    <script src="../js/bootstrap-datetimepicker.min.js"></script>
    <script>
        excelMe = "yes"
        pdfMe = "yes"
        printMe = "yes"



        $(document).ready(function () {
            loadNavigation('NewRequrest', 'gldashboard', 'pl', 'tl', 'Dashboard', 'End User Profile Request', '');

            $('.searchableselect').searchableselect();

            $('#datatable').DataTable();

            $('.shorting-lnk').click(function () {
                $('.shorting-lnk i').toggleClass('fa-sort-amount-up-alt fa-sort-amount-down-alt ');
            });
           
        });
    </script>
    <script>
    $(document).ready(function () {
	    $('.datepicker').datetimepicker({
		    format: 'LT',
		    format: 'DD-MM-YYYY',
		    daysOfWeekDisabled: [0, 6],
	    });	
    });
    </script>
</body>
</html>



