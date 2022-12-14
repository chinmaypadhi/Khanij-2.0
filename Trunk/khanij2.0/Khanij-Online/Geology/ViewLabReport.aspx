<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewLabReport.aspx.cs" Inherits="Geology_ViewLabReport" %>

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
                                        <a class="nav-link " href="AddLabReport.aspx">
                                           Add Lab Report
                                        </a>
                                    </li>
                                     <li class="nav-item">
                                        <a class="nav-link active" href="ViewLabReport.aspx">
                                           View Lab Report
                                        </a>
                                    </li>
                                </ul>
                                <uc1:util runat="server" ID="util" />
                            </div>

                            <section class="box form-container">
                                <div class="search-box">
                                    <div class="searchform px-3 py-3">
                                        <div class="row">
                                           

                                            <div class="col-lg-4 col-md-6 col-sm-12">
                                                <div class="form-group row">
                                                    <label for="inputText" class="col-sm-4 col-form-label">
                                                       From Date </label>
                                                    <div class="col-sm-8">
                                                       <div class="input-group">
                                                      <input type="text" class="form-control datepicker" id="inputDate1">
                                                      <div class="input-group-prepend">
                                                        <label class="input-group-text" for="inputDate1"><i class="far fa-calendar"></i></label>
                                                      </div>
                                                 </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-lg-4 col-md-6 col-sm-12">
                                                <div class="form-group row">
                                                    <label for="inputText" class="col-sm-3 col-form-label">
                                                       To Date </label>
                                                    <div class="col-sm-8">
                                                       <div class="input-group">
                                                      <input type="text" class="form-control datepicker" id="inputDate2">
                                                      <div class="input-group-prepend">
                                                        <label class="input-group-text" for="inputDate2"><i class="far fa-calendar"></i></label>
                                                      </div>
                                                 </div>
                                                    </div>
                                                </div>
                                            </div>
                                                

                                           
                                    <div class="col-sm-2">
                                        <a href="#" class="btn btn-md btn-success m-0 waves-effect waves-light"> Show </a>
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
                                                    <th rowspan="2">Sl#</th>
                                                     <th  rowspan="2">FPO Code</th>
                                                      <th  rowspan="2">Report MM/Year</th>
                                                     <th  colspan="5" class="text-center">Area Details</th>
                                                     <th  rowspan="2">Camp Incharge</th>
                                                    <th  rowspan="2">Designation</th>
                                                    <th  rowspan="2">Type Of Sample</th>
                                                    <th  rowspan="2">No of Samples</th>
                                                    <th  rowspan="2">Type of Study</th>
                                                    <th  rowspan="2">Submission Date</th>
                                                    <th  rowspan="2">Attachment</th>
                                                    <th  rowspan="2">Status</th>
                                                    
                                                     <th  rowspan="2" width="60px"></th> 
                                                   </tr>
                                                   <tr>
                                                   <th >Name of Camp</th>
                                                    <th>Village</th>
                                                    <th>Tehsil</th>
                                                    <th>District</th>
                                                    <th>Regional Office</th>
                                                  
                                                </tr>
                                                   
                                                       
                                                    </thead>
                                                    <tbody>
                                                    <tr class="active-row">
                                                        <td>1</td>
                                                        <td>6474/2020-21</td>
                                                        <td>May 2021</td>
                                                        <td>tser</td>
                                                        <td>Chirimiri</td>
                                                        <td>Khadgawan</td>
                                                        <td>Korea</td>
                                                        <td>Raipur</td>
                                                        <td>Shri Anurag Diwan</td>
                                                        <td>Joint Director (Mineral Administration)</td>
                                                        <td>tryrt</td>
                                                        <td>rtgr</td>
                                                        <td>XRF</td>
                                                        <td>04/02/2021</td>
                                                        <td></td>
                                                        <td>Pending for Submission</td>
    
                                                        <td class="noprint">
                                                          <a class="btn-floating btn-outline-primary btn-sm waves-effect waves-light" data-placement="top" data-original-title="Edit" href="AddLabReport.aspx"><i class="fas fa-pencil-alt"></i></a>
                                                          <a href="javascript:void(0);" class="btn-floating btn-outline-danger btn-sm waves-effect waves-light" data-placement="top" title="" data-original-title="Delete"><i class="far fa-trash-alt"></i></a>
                                                         
                                                       </td>
                                                    </tr>
                                                     <tr class="active-row">
                                                        <td>1</td>
                                                        <td>6474/2020-21</td>
                                                        <td>May 2021</td>
                                                        <td>tser</td>
                                                        <td>Chirimiri</td>
                                                        <td>Khadgawan</td>
                                                        <td>Korea</td>
                                                        <td>Raipur</td>
                                                        <td>Shri Anurag Diwan</td>
                                                        <td>Joint Director (Mineral Administration)</td>
                                                        <td>tryrt</td>
                                                        <td>rtgr</td>
                                                        <td>XRF</td>
                                                        <td>04/02/2021</td>
                                                        <td></td>
                                                        <td>Forwarded to Lab</td>
                                                        <td></td>
                                                       
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

        $(document).ready(function () {
            loadNavigation('ViewLabReport', 'glgeology', 'pllabrep', 'tl', 'Geology', 'Lab Report', ' ');


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








