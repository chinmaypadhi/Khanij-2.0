<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FPOApprover.aspx.cs" Inherits="Geology_FPOApprover" %>
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
                                        <a class="nav-link active" href="FPOApprover.aspx">
                                         FPO Approver
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
                                                            <th>FPO Code</th>
                                                            <th>FPO Name</th>
                                                            <th>Date of Submission</th>
                                                            <th>Field Season</th>
                                                            <th>Attachment</th>
                                                            <th>Status</th>
                                                            <th  width="100px" class="noprint">Action</th>
                                                            
                                                            
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <tr class="active-row">
                                                            <td>8138/2019-20</td>
                                                            <td>8138/Geo-I/F. No.7/F. Pro 2019-20/2019</td>
                                                            <td>01/02/2021</td>
                                                            <td>2019-2020</td>
                                                            <td><a href="#"><i class="far fa-file-pdf h3"></i></a></td>
                                                            <td class="text-success">Active</td>
                                                           
                                                            <td class="noprint">
                                                      <a data-toggle="modal"
                                                data-target=".modal1" href="javascript:void(0);" class="btn-floating btn-outline-primary btn-sm waves-effect waves-light">Take Action</a>
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
   <!-- alert 1-->
    <div class="modal fade modal1" tabindex="-1" role="dialog" aria-labelledby="alertModal" aria-hidden="true">
        <div class="modal-dialog modal-md modal-dialog-centered" role="document">
            <div class="modal-content">
            <div class="modal-header p-2">
        <h5 class="modal-title m-0">Approve FPO Order</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
                <div class="modal-body">
                <div class="row">
                    <div class="col-sm-12">
                        <div class="form-group row">
                            <label class="col-sm-4 col-form-label font-weight-bolder">Status<span class="text-danger">*</span></label>
                            <div class="col-sm-7">
                               <div class="py-2">
                                <div class="custom-control custom-radio custom-control-inline">
                                <input type="radio" class="custom-control-input" id="radiop" name="radio-iRequirement" value="1">
                                <label class="custom-control-label" for="radiop">Approve</label>
                                </div>
                                <div class="custom-control custom-radio custom-control-inline">
                                <input type="radio" class="custom-control-input" id="radiopro" name="radio-iRequirement" value="2">
                                <label class="custom-control-label" for="radiopro">Reject</label>
                                </div>
                            </div>
                            </div>
                        </div>
                    </div>
                     <div class="col-sm-12">
                        <div class="form-group row">
                            <label class="col-sm-4 col-form-label font-weight-bolder">Remarks</label>
                            <div class="col-sm-7">
                                <textarea class="form-control" rows="1"></textarea>
                                <small class="text-danger">Maximum <strong>500</strong> characters</small>
                            </div>
                        </div>
                    </div>
                    
                    
                    
                        </div>
                    <a class="btn btn-primary btn-md ml-0" href="#">Submit</a>
                   
                </div>
               
            </div>
        </div>
    </div>
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
            loadNavigation('FPOApprover', 'glgeology', 'plfpoappr', 'tl', 'Geology', 'FPO Approver', ' ');

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









