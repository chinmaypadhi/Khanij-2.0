<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddAppraisalforDriver.aspx.cs" Inherits="AEC_AddAppraisalforDriver" %>
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
                                        <a class="nav-link active" href="AddAppraisalforDriver.aspx">
                                          Add Appraisal for Driver
                                        </a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" href="ViewAppraisalforDriver.aspx">
                                          View Appraisal for Driver
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
                                                <label  class="col-lg-4 col-md-6 col-sm-12 col-form-label font-weight-bolder">Name  <span class="text-danger">*</span></label>
                                                <div class="col-lg-7 col-md-6 col-sm-12">
                                                    <input type="text" class="form-control">
                                                </div>
                                            </div>
                                        </div>
                                       
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label  class="col-lg-4 col-md-6 col-sm-12 col-form-label font-weight-bolder"> Date of Requirement   <span class="text-danger">*</span></label>
                                                <div class="col-lg-7 col-md-6 col-sm-12">
                                                   <div class="input-group">
                                                      <input type="text" class="form-control datepicker" id="inputDate1">
                                                      <div class="input-group-prepend">
                                                        <label class="input-group-text" for="inputDate1"><i class="far fa-calendar"></i></label>
                                                      </div>
                                                 </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label  class="col-lg-4 col-md-6 col-sm-12 col-form-label font-weight-bolder">Behavior <span class="text-danger">*</span></label>
                                                <div class="col-lg-7 col-md-6 col-sm-12">
                                                   <input type="text" class="form-control">
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label  class="col-lg-4 col-md-6 col-sm-12 col-form-label font-weight-bolder">Physical fitness <span class="text-danger">*</span></label>
                                                <div class="col-lg-7 col-md-6 col-sm-12">
                                                   <input type="text" class="form-control">
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label  class="col-lg-4 col-md-6 col-sm-12 col-form-label font-weight-bolder">Ability to drive  <span class="text-danger">*</span></label>
                                                <div class="col-lg-7 col-md-6 col-sm-12">
                                                <input type="text" class="form-control">
                                                    
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label  class="col-lg-4 col-md-6 col-sm-12 col-form-label font-weight-bolder">Safety <span class="text-danger">*</span></label>
                                                <div class="col-lg-7 col-md-6 col-sm-12">
                                                   <input type="text" class="form-control">
                                                </div>
                                            </div>
                                        </div>
                                       
                                         <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label  class="col-lg-4 col-md-6 col-sm-12 col-form-label font-weight-bolder"> BOL <span class="text-danger">*</span></label>
                                                <div class="col-lg-7 col-md-6 col-sm-12">
                                                      <input type="text" class="form-control" "> 
                                                </div>
                                            </div>
                                        </div>
                                         <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label  class="col-lg-4 col-md-6 col-sm-12 col-form-label font-weight-bolder">Maintenance of vehicle  <span class="text-danger">*</span></label>
                                                <div class="col-lg-7 col-md-6 col-sm-12">
                                                      <input type="text" class="form-control" "> 
                                                </div>
                                            </div>
                                        </div>
                                         <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label  class="col-lg-4 col-md-6 col-sm-12 col-form-label font-weight-bolder"> Present <span class="text-danger">*</span></label>
                                                <div class="col-lg-7 col-md-6 col-sm-12">
                                                      <input type="text" class="form-control" "> 
                                                </div>
                                            </div>
                                        </div>
                                         <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label  class="col-lg-4 col-md-6 col-sm-12 col-form-label font-weight-bolder"> punctual  <span class="text-danger">*</span></label>
                                                <div class="col-lg-7 col-md-6 col-sm-12">
                                                      <input type="text" class="form-control" "> 
                                                </div>
                                            </div>
                                        </div>
                                         <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label  class="col-lg-4 col-md-6 col-sm-12 col-form-label font-weight-bolder"> Uniform related remarks <Time span class="text-danger">*</span></label>
                                                <div class="col-lg-7 col-md-6 col-sm-12">
                                                      <input type="text" class="form-control" "> 
                                                </div>
                                            </div>
                                        </div>
                                         <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label  class="col-lg-4 col-md-6 col-sm-12 col-form-label font-weight-bolder"> Character <span class="text-danger">*</span></label>
                                                <div class="col-lg-7 col-md-6 col-sm-12">
                                                      <input type="text" class="form-control" "> 
                                                </div>
                                            </div>
                                        </div>
                                         <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label  class="col-lg-4 col-md-6 col-sm-12 col-form-label font-weight-bolder">Appreciation <span class="text-danger">*</span></label>
                                                <div class="col-lg-7 col-md-6 col-sm-12">
                                                      <input type="text" class="form-control" "> 
                                                </div>
                                            </div>
                                        </div>
                                         <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label  class="col-lg-4 col-md-6 col-sm-12 col-form-label font-weight-bolder">Grade <span class="text-danger">*</span></label>
                                                <div class="col-lg-7 col-md-6 col-sm-12">
                                                      <select class="form-control form-control-sm searchableselect">
                                                          <option>select</option>
                                                      </select>
                                                </div>
                                            </div>
                                        </div>
                                         
                                         
                                        
                                   
                                    

                                  
                                      
                                        
                                       
                                       
                                            <div class="col-lg-6 offset-lg-2 offset-md-5">
                                                <a href="javascript:void(0);" class="btn btn-primary btn-md ml-0">Submit</a>
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






    <script>
        indicateMe = "yes"

        $(document).ready(function () {
            loadNavigation('AddAppraisalforDriver', 'glaec', 'plaecad', 'tl', 'AEC', 'Appraisal for Driver', ' ');
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











