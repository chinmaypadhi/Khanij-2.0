<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewEmpPersonalDetails.aspx.cs" Inherits="EmplyeeProfile_ViewEmpPersonalDetails" %>
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
                                        <a class="nav-link " href="EmpPersonalDetails.aspx">
                                          Add Employee Personal Details
                                        </a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link active" href="ViewEmpPersonalDetails.aspx">
                                          View Employee Personal Details
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
                                                            <th width="30px">Sl#</th>
                                                            <th>Employee Id</th>
                                                            <th>Name</th>
                                                            <th>Father/Mother/Husband Names</th>
                                                            <th>Employee Type</th>
                                                            <th>Aadhar No.</th>
                                                            <th>Current Designation</th>
                                                            <th>Category</th>
                                                            <th>Class</th>
                                                            <th>Mobile No.</th>
                                                            <th>Email Id</th>
                                                            <th>Date of birth</th>
                                                            <th>Home Status</th>
                                                            <th>Home District</th>
                                                            
                                                            <th  width="60px" class="noprint">Action</th>
                                                            
                                                            
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <tr class="active-row">
                                                            <td>1</td>
                                                            <td>Emp 001</td>
                                                            <td>Jeevan</td>
                                                             <td>Jyoti</td>
                                                            <td>Permanent</td>
                                                             <td>1234567898012</td>
                                                            <td>DGM</td>
                                                             <td>OBC</td>
                                                             <td>Class I</td>
                                                            <td>9658828089</td>
                                                             <td>jeevan@gmail.com</td>
                                                            <td>10-Feb-1990</td>
                                                            <td>Chhattisgarh</td>
                                                             <td>Raipur</td>
                                                            
                                                            <td class="noprint">
                                                            <a href="EmpPersonalDetails.aspx" class="btn-floating btn-outline-primary btn-sm waves-effect waves-light" title="" data-original-title="Edit"><i class="fas fa-pencil-alt"></i></a>
                                                      <a href="javascript:void(0);" class="btn-floating btn-outline-danger btn-sm waves-effect waves-light" data-toggle="tooltip" data-placement="top" title="Delete" "=""><i class="far fa-trash-alt"></i></a>
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

        $(document).ready(function () {
            loadNavigation('ViewEmpPersonalDetails', 'glempprofile', 'plemperinf', 'tl', 'Employee Profile', 'Emp Personal Details', ' ');

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











