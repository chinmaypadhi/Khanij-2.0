<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MonthlyProgressReports.aspx.cs" Inherits="Geology_MonthlyProgressReports" %>
<%@ Register Src="~/includes/navbar.ascx" TagPrefix="uc1" TagName="navbar" %>
<%@ Register Src="~/includes/leftsider.ascx" TagPrefix="uc1" TagName="leftsider" %>
<%@ Register Src="~/includes/navigation.ascx" TagPrefix="uc1" TagName="navigation" %>
<%@ Register Src="~/includes/util.ascx" TagPrefix="uc1" TagName="util" %>
<%@ Register Src="~/includes/footer.ascx" TagPrefix="uc1" TagName="footer" %>
<!DOCTYPE html>

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
                                        <a class="nav-link active" href="MonthlyProgressReports.aspx">
                                           Add Monthly Progress Reports
                                        </a>
                                    </li>
                                     <li class="nav-item">
                                        <a class="nav-link" href="ViewMonthlyProgressReports.aspx">
                                           View Monthly Progress Reports
                                        </a>
                                    </li>
                                </ul>
                                <uc1:util runat="server" ID="util" />
                            </div>

                            <section class="box form-container">
                                <div class="content-body">

                                    <div class="row">
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label for="dropdownDist" class="col-sm-4 col-form-label font-weight-bolder">FPO Code <span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                    <select class="form-control form-control-sm searchableselect">
                                                          <option>select</option>
                                                      </select>                                                 
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label  class="col-sm-4 col-form-label font-weight-bolder">FPO Date</label>
                                                <div class="col-sm-7">
                                                    <div class="input-group">
                                                      <input type="text" class="form-control datepicker" id="inputDate2" disabled>
                                                      <div class="input-group-prepend">
                                                        <label class="input-group-text" for="inputDate2"><i class="far fa-calendar"></i></label>
                                                      </div>
                                                 </div>
                                                </div>
                                            </div>

                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label  class="col-sm-4 col-form-label font-weight-bolder">FPO Name</label>
                                                <div class="col-sm-7">
                                                    <input type="text" class="form-control" disabled>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label  class="col-sm-4 col-form-label font-weight-bolder">Field Season</label>
                                                <div class="col-sm-7">
                                                    <input type="text" class="form-control" disabled>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label  class="col-sm-4 col-form-label font-weight-bolder">Field Officer's Name</label>
                                                <div class="col-sm-7">
                                                    <input type="text" class="form-control" disabled>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label  class="col-sm-4 col-form-label font-weight-bolder">Field Officer's Designation</label>
                                                <div class="col-sm-7">
                                                    <input type="text" class="form-control" disabled>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label  class="col-sm-4 col-form-label font-weight-bolder">Field Officer's Mobile No.</label>
                                                <div class="col-sm-7">
                                                    <input type="text" class="form-control" disabled>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label  class="col-sm-4 col-form-label font-weight-bolder">Field Officer's Email Id</label>
                                                <div class="col-sm-7">
                                                    <input type="text" class="form-control" disabled>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label  class="col-sm-4 col-form-label font-weight-bolder">Report for the Month & year<span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                    <input type="text" class="form-control">
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label  class="col-sm-4 col-form-label font-weight-bolder">Report Type</label>
                                                <div class="col-sm-7">
                                                    <div class="py-2">
                                                      <div class="custom-control custom-radio custom-control-inline">
                                                        <input type="radio" class="custom-control-input" id="radiop" name="radio-iRequirement" value="1">
                                                        <label class="custom-control-label" for="radiop">Submission</label>
                                                      </div>
                                                      <div class="custom-control custom-radio custom-control-inline">
                                                        <input type="radio" class="custom-control-input" id="radiopro" name="radio-iRequirement" value="2">
                                                        <label class="custom-control-label" for="radiopro">Resubmission</label>
                                                      </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label  class="col-sm-4 col-form-label font-weight-bolder">Date of commencement of the investigationr</label>
                                                <div class="col-sm-7">
                                                    <div class="input-group">
                                                      <input type="text" class="form-control datepicker" id="inputDate1" disabled>
                                                      <div class="input-group-prepend">
                                                        <label class="input-group-text" for="inputDate1"><i class="far fa-calendar"></i></label>
                                                      </div>
                                                 </div>
                                                </div>
                                            </div>

                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label  class="col-sm-4 col-form-label font-weight-bolder">Name of Mineral<span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                    <select class="form-control form-control-sm searchableselect">
                                                          <option>select</option>
                                                      </select> 
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label  class="col-sm-4 col-form-label font-weight-bolder">Division<span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                    <select class="form-control form-control-sm searchableselect">
                                                          <option>select</option>
                                                      </select> 
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label  class="col-sm-4 col-form-label font-weight-bolder">Post Office <span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                    <input type="text" class="form-control">
                                                </div>
                                            </div>
                                        </div>
                                         <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label  class="col-sm-4 col-form-label font-weight-bolder">District<span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                    <select class="form-control form-control-sm searchableselect" >
                                                          <option>select</option>
                                                      </select> 
                                                </div>
                                            </div>
                                        </div>
                                         <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label  class="col-sm-4 col-form-label font-weight-bolder">Tehsil<span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                    <select class="form-control form-control-sm searchableselect" >
                                                          <option>select</option>
                                                      </select> 
                                                </div>
                                            </div>
                                        </div>
                                         <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label  class="col-sm-4 col-form-label font-weight-bolder">Village<span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                    <select class="form-control form-control-sm searchableselect" >
                                                          <option>select</option>
                                                      </select> 
                                                </div>
                                            </div>
                                        </div>
                                         <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label  class="col-sm-4 col-form-label font-weight-bolder">Regional Office<span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                    <select class="form-control form-control-sm searchableselect" >
                                                          <option>select</option>
                                                      </select> 
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label  class="col-sm-4 col-form-label font-weight-bolder">Block <span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                    <input type="text" class="form-control">
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label  class="col-sm-4 col-form-label font-weight-bolder">Pin Code <span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                    <input type="text" class="form-control">
                                                </div>
                                            </div>
                                        </div>
                                       </div>
                                       <div class="row">
                                        <div class="col-lg-8 col-md-12 col-sm-12">
                                                <div class="table-responsive">
                                              <table class="table table-sm border">
                                              <thead>
                                               <tr>
                                                   <th class="font-weight-bolder" colspan="4">Area Covered</th>
                                                   
                                                   <th width="100px" class="font-weight-bolder">Actions</th>
                                               </tr>
                                            </thead>
                                            <tbody>
                                                <tr>
                                                <td width="70px">
                                                         <input type="text" class="form-control" value="1" disabled>
                                                    </td>
                                                    <td>
                                                         <input type="text" class="form-control" placeholder="Latitudes">
                                                    </td>

                                                    <td>
                                                       <input type="text" class="form-control" placeholder="Longitudes">
                                                    </td>
                                                    <td>
                                                       <input type="text" class="form-control" placeholder="Top Sheet No">
                                                    </td>
                               
                                                    <td>
                                                         <a href="#" class="btn btn-success btn-md waves-effect waves-light" data-toggle="tooltip" data-placement="top" title="Add Row"><i class="fa fa-plus" aria-hidden="true"></i></a>
                                                    </td>

                                                </tr>
                                            </tbody>
                                        </table>  
                                        </div>
                                        </div>
                                       
                                         
                                       
                                            <div class="col-sm-6">
                                                <a href="#" class="btn btn-primary btn-md ml-0" data-toggle="modal"
                                                data-target=".alert-modal">Submit</a>
                                                <a href="#" class="btn btn-danger btn-md">Reset</a>
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
     <link href="../css/bootstrap-datetimepicker.min.css" rel="stylesheet">
    <script src="../js/moment.min.js"></script> 
    <script src="../js/bootstrap-datetimepicker.min.js"></script>


<!-- alert 1-->
    <div class="modal fade alert-modal" tabindex="-1" role="dialog" aria-labelledby="alertModal" aria-hidden="true">
        <div class="modal-dialog modal-md modal-dialog-centered" role="document">
            <div class="modal-content">
                <div class="modal-body text-center">
                    <h5 class="p-2 ">
                    <i class="fas fa-check fa-2x mb-3 text-success"></i><br>
                    Request Number : <span class="text-primary font-weight-bold">457857896545788</span>
                      </h5>
                    <a class="btn btn-primary btn-md" href="ViewMonthlyProgressReports.aspx" >Ok</a><%--data-dismiss="modal"--%>
                </div>
               
            </div>
        </div>
    </div>




    <script>
        indicateMe = "yes"

        $(document).ready(function () {
            loadNavigation('MonthlyProgressReports', 'glgeology', 'plmonprorep', 'tl', 'Geology', 'Monthly Progress Reports', ' ');
            $('.searchableselect').searchableselect();


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



