<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EmplyeeDeatilst.aspx.cs" Inherits="EmplyeeProfile_EmplyeeDeatilst" %>
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
                                        <a class="nav-link active" href="#">
                                           Emplyees Deatils
                                        </a>
                                    </li>
                                   
                                    
                                </ul>
                                <uc1:util runat="server" ID="util" />
                            </div>

                            <section class="box form-container">
                                <div class="content-body">
                                <div class="row">
                                <div class="col-lg-12 col-md-12 col-sm-12">
                                
                                <div class="bg-light p-2 shadow-sm">
                                <h5 class="text-brown font-weight-bold mt-0">Emp Personal Details</h5>
                                                       <div class="row">
                                                     
                                                           <div class="col-lg-4 col-md-6 col-sm-12">
                                                                <div class="form-group row">
                                                                    <label class="col-sm-5 col-form-label font-weight-bolder">Employee Id</label>
                                                                    <div class="col-sm-7">
                                                                        <label class="form-control-plaintext"><span class="colon">:</span>Dummy Text</label>
                                                                    </div>
                                                                </div>
                                                           </div>
                                                            <div class="col-lg-4 col-md-6 col-sm-12">
                                                               <div class="form-group row">
                                                                    <label class="col-sm-5 col-form-label font-weight-bolder">Name</label>
                                                                    <div class="col-sm-7">
                                                                        <label class="form-control-plaintext"><span class="colon">:</span>Dummy Text</label>
                                                                    </div>
                                                                </div>
                                                           </div>
                                                           <div class="col-lg-4 col-md-12 col-sm-12">
                                                                <div class="form-group row">
                                                                    <label class="col-sm-5 col-form-label font-weight-bolder">Father/Mother/ <br />Husband Names</label>
                                                                    <div class="col-sm-7">
                                                                        <label class="form-control-plaintext"><span class="colon">:</span> Dummy Text </label>
                                                                    </div>
                                                                </div>
                                                           </div>
                                                           <div class="col-lg-4 col-md-6 col-sm-12">
                                                               <div class="form-group row">
                                                                    <label class="col-sm-5 col-form-label font-weight-bolder">Employee Type</label>
                                                                    <div class="col-sm-7">
                                                                        <label class="form-control-plaintext"><span class="colon">:</span>Dummy Text</label>
                                                                    </div>
                                                                </div>
                                                           </div>
                                                           <div class="col-lg-4 col-md-6 col-sm-12">
                                                                <div class="form-group row">
                                                                    <label class="col-sm-5 col-form-label font-weight-bolder">Aadhar No.</label>
                                                                    <div class="col-sm-7">
                                                                        <label class="form-control-plaintext"><span class="colon">:</span>Dummy Text</label>
                                                                    </div>
                                                                </div>
                                                           </div>
                                                           <div class="col-lg-4 col-md-6 col-sm-12">
                                                                <div class="form-group row">
                                                                    <label class="col-sm-5 col-form-label font-weight-bolder">Aadhar Card</label>
                                                                    <div class="col-sm-7">
                                                                        <label class="form-control-plaintext"><span class="colon">:</span>Dummy Text</label>
                                                                    </div>
                                                                </div>
                                                           </div>
                                                           <div class="col-lg-4 col-md-6 col-sm-12">
                                                                <div class="form-group row">
                                                                    <label class="col-sm-5 col-form-label font-weight-bolder">Current Designation</label>
                                                                    <div class="col-sm-7">
                                                                        <label class="form-control-plaintext"><span class="colon">:</span>Dummy Text</label>
                                                                    </div>
                                                                </div>
                                                           </div>
                                                           <div class="col-lg-4 col-md-6 col-sm-12">
                                                                <div class="form-group row">
                                                                    <label class="col-sm-5 col-form-label font-weight-bolder">Category</label>
                                                                    <div class="col-sm-7">
                                                                        <label class="form-control-plaintext"><span class="colon">:</span>Dummy Text</label>
                                                                    </div>
                                                                </div>
                                                           </div>
                                                           <div class="col-lg-4 col-md-6 col-sm-12">
                                                                <div class="form-group row">
                                                                    <label class="col-sm-5 col-form-label font-weight-bolder">Class</label>
                                                                    <div class="col-sm-7">
                                                                        <label class="form-control-plaintext"><span class="colon">:</span>Dummy Text</label>
                                                                    </div>
                                                                </div>
                                                           </div>
                                                            <div class="col-lg-4 col-md-6 col-sm-12">
                                                                <div class="form-group row">
                                                                    <label class="col-sm-5 col-form-label font-weight-bolder">Mobile No.</label>
                                                                    <div class="col-sm-7">
                                                                        <label class="form-control-plaintext"><span class="colon">:</span>Dummy Text</label>
                                                                    </div>
                                                                </div>
                                                           </div>
                                                           <div class="col-lg-4 col-md-6 col-sm-12">
                                                                <div class="form-group row">
                                                                    <label class="col-sm-5 col-form-label font-weight-bolder">Email Id</label>
                                                                    <div class="col-sm-7">
                                                                        <label class="form-control-plaintext"><span class="colon">:</span>Dummy Text</label>
                                                                    </div>
                                                                </div>
                                                           </div>
                                                           <div class="col-lg-4 col-md-6 col-sm-12">
                                                                <div class="form-group row">
                                                                    <label class="col-sm-5 col-form-label font-weight-bolder"> Date of Birth</label>
                                                                    <div class="col-sm-7">
                                                                        <label class="form-control-plaintext"><span class="colon">:</span>Dummy Text</label>
                                                                    </div>
                                                                </div>
                                                           </div>
                                                            <div class="col-lg-4 col-md-6 col-sm-12">
                                                                <div class="form-group row">
                                                                    <label class="col-sm-5 col-form-label font-weight-bolder"> Home State</label>
                                                                    <div class="col-sm-7">
                                                                        <label class="form-control-plaintext"><span class="colon">:</span>Dummy Text</label>
                                                                    </div>
                                                                </div>
                                                           </div>
                                                           <div class="col-lg-4 col-md-6 col-sm-12">
                                                                <div class="form-group row">
                                                                    <label class="col-sm-5 col-form-label font-weight-bolder">Home District</label>
                                                                    <div class="col-sm-7">
                                                                        <label class="form-control-plaintext"><span class="colon">:</span>Dummy Text</label>
                                                                    </div>
                                                                </div>
                                                           </div>
                                                           <div class="col-lg-4 col-md-6 col-sm-12">
                                                                <div class="form-group row">
                                                                    <label class="col-sm-5 col-form-label font-weight-bolder">Gender</label>
                                                                    <div class="col-sm-7">
                                                                        <label class="form-control-plaintext"><span class="colon">:</span>Dummy Text</label>
                                                                    </div>
                                                                </div>
                                                           </div>
                                                            <div class="col-lg-4 col-md-6 col-sm-12">
                                                                <div class="form-group row">
                                                                    <label class="col-sm-5 col-form-label font-weight-bolder">Marital Status</label>
                                                                    <div class="col-sm-7">
                                                                        <label class="form-control-plaintext"><span class="colon">:</span>Dummy Text</label>
                                                                    </div>
                                                                </div>
                                                           </div>
                                                            <div class="col-lg-4 col-md-6 col-sm-12">
                                                                <div class="form-group row">
                                                                    <label class="col-sm-5 col-form-label font-weight-bolder">Signature</label>
                                                                    <div class="col-sm-7">
                                                                        <label class="form-control-plaintext"><span class="colon">:</span>Dummy Text</label>
                                                                    </div>
                                                                </div>
                                                           </div>
                                                           <div class="col-lg-4 col-md-6 col-sm-12">
                                                                <div class="form-group row">
                                                                    <label class="col-sm-5 col-form-label font-weight-bolder">Photo</label>
                                                                    <div class="col-sm-7">
                                                                        <label class="form-control-plaintext"><span class="colon">:</span>Dummy Text</label>
                                                                    </div>
                                                                </div>
                                                           </div>
                                                       </div>
                                                       <h5 class="text-brown font-weight-bold mt-0">Emp Current Posting Details</h5>
                                                       <div class="row">
                                                          <div class="col-lg-4 col-md-6 col-sm-12">
                                                                <div class="form-group row">
                                                                    <label class="col-sm-5 col-form-label font-weight-bolder">Current Posting Department</label>
                                                                    <div class="col-sm-7">
                                                                        <label class="form-control-plaintext"><span class="colon">:</span>Dummy Text</label>
                                                                    </div>
                                                                </div>
                                                           </div>
                                                           <div class="col-lg-4 col-md-6 col-sm-12">
                                                                <div class="form-group row">
                                                                    <label class="col-sm-5 col-form-label font-weight-bolder">Current Posting Distric</label>
                                                                    <div class="col-sm-7">
                                                                        <label class="form-control-plaintext"><span class="colon">:</span>Dummy Text</label>
                                                                    </div>
                                                                </div>
                                                           </div>
                                                            <div class="col-lg-4 col-md-6 col-sm-12">
                                                                <div class="form-group row">
                                                                    <label class="col-sm-5 col-form-label font-weight-bolder">Office Level</label>
                                                                    <div class="col-sm-7">
                                                                        <label class="form-control-plaintext"><span class="colon">:</span> Dummy Text </label>
                                                                    </div>
                                                                </div>
                                                           </div>
                                                          <div class="col-lg-4 col-md-6 col-sm-12">
                                                                <div class="form-group row">
                                                                    <label class="col-sm-5 col-form-label font-weight-bolder">Current Posting Office</label>
                                                                    <div class="col-sm-7">
                                                                        <label class="form-control-plaintext"><span class="colon">:</span>Dummy Text</label>
                                                                    </div>
                                                                </div>
                                                           </div>
                                                           <div class="col-lg-4 col-md-6 col-sm-12">
                                                                <div class="form-group row">
                                                                    <label class="col-sm-5 col-form-label font-weight-bolder">Date Of Joining</label>
                                                                    <div class="col-sm-7">
                                                                        <label class="form-control-plaintext"><span class="colon">:</span>Dummy Text</label>
                                                                    </div>
                                                                </div>
                                                           </div>
                                                           <div class="col-lg-4 col-md-6 col-sm-12">
                                                                <div class="form-group row">
                                                                    <label class="col-sm-5 col-form-label font-weight-bolder">Date Of Retirement</label>
                                                                    <div class="col-sm-7">
                                                                        <label class="form-control-plaintext"><span class="colon">:</span>Dummy Text</label>
                                                                    </div>
                                                                </div>
                                                           </div>
                                                            <div class="col-lg-4 col-md-6 col-sm-12">
                                                                <div class="form-group row">
                                                                    <label class="col-sm-5 col-form-label font-weight-bolder">Establishment office</label>
                                                                    <div class="col-sm-7">
                                                                        <label class="form-control-plaintext"><span class="colon">:</span>Dummy Text</label>
                                                                    </div>
                                                                </div>
                                                           </div>
                                                            <div class="col-lg-4 col-md-6 col-sm-12">
                                                                <div class="form-group row">
                                                                    <label class="col-sm-5 col-form-label font-weight-bolder">Mode of Recruitment</label>
                                                                    <div class="col-sm-7">
                                                                        <label class="form-control-plaintext"><span class="colon">:</span>Dummy Text</label>
                                                                    </div>
                                                                </div>
                                                           </div>
                                                            <div class="col-lg-4 col-md-6 col-sm-12">
                                                                <div class="form-group row">
                                                                    <label class="col-sm-5 col-form-label font-weight-bolder">Pay Band</label>
                                                                    <div class="col-sm-7">
                                                                        <label class="form-control-plaintext"><span class="colon">:</span>Dummy Text</label>
                                                                    </div>
                                                                </div>
                                                           </div>
                                                             <div class="col-lg-4 col-md-6 col-sm-12">
                                                                <div class="form-group row">
                                                                    <label class="col-sm-5 col-form-label font-weight-bolder">Current Basic Pay</label>
                                                                    <div class="col-sm-7">
                                                                        <label class="form-control-plaintext"><span class="colon">:</span>Dummy Text</label>
                                                                    </div>
                                                                </div>
                                                           </div>
                                                            <div class="col-lg-4 col-md-6 col-sm-12">
                                                                <div class="form-group row">
                                                                    <label class="col-sm-5 col-form-label font-weight-bolder">Current Grade Pay</label>
                                                                    <div class="col-sm-7">
                                                                        <label class="form-control-plaintext"><span class="colon">:</span>Dummy Text</label>
                                                                    </div>
                                                                </div>
                                                           </div>
                                                           
                                                       </div>
                                                       <h5 class="text-brown font-weight-bold mt-0">Emp Address Information</h5>
                                
                                 <div class="row">
                                                           <div class="col-lg-4 col-md-6 col-sm-12">
                                                                <div class="form-group row">
                                                                    <label class="col-sm-5 col-form-label font-weight-bolder">present Address</label>
                                                                    <div class="col-sm-7">
                                                                        <label class="form-control-plaintext"><span class="colon">:</span>Dummy Text</label>
                                                                    </div>
                                                                </div>
                                                           </div>
                                                            <div class="col-lg-4 col-md-6 col-sm-12">
                                                                <div class="form-group row">
                                                                    <label class="col-sm-5 col-form-label font-weight-bolder">District</label>
                                                                    <div class="col-sm-7">
                                                                        <label class="form-control-plaintext"><span class="colon">:</span>Dummy Text</label>
                                                                    </div>
                                                                </div>
                                                           </div>
                                                           <div class="col-lg-4 col-md-6 col-sm-12">
                                                                <div class="form-group row">
                                                                    <label class="col-sm-5 col-form-label font-weight-bolder">Pin Code</label>
                                                                    <div class="col-sm-7">
                                                                        <label class="form-control-plaintext"><span class="colon">:</span> Dummy Text </label>
                                                                    </div>
                                                                </div>
                                                           </div>
                                                          <div class="col-lg-4 col-md-6 col-sm-12">
                                                                <div class="form-group row">
                                                                    <label class="col-sm-5 col-form-label font-weight-bolder">Email Id</label>
                                                                    <div class="col-sm-7">
                                                                        <label class="form-control-plaintext"><span class="colon">:</span>Dummy Text</label>
                                                                    </div>
                                                                </div>
                                                           </div>
                                                         <div class="col-lg-4 col-md-6 col-sm-12">
                                                                <div class="form-group row">
                                                                    <label class="col-sm-5 col-form-label font-weight-bolder">present Address</label>
                                                                    <div class="col-sm-7">
                                                                        <label class="form-control-plaintext"><span class="colon">:</span>Dummy Text</label>
                                                                    </div>
                                                                </div>
                                                           </div>
                                                           <div class="col-lg-4 col-md-6 col-sm-12">
                                                                <div class="form-group row">
                                                                    <label class="col-sm-5 col-form-label font-weight-bolder">District</label>
                                                                    <div class="col-sm-7">
                                                                        <label class="form-control-plaintext"><span class="colon">:</span>Dummy Text</label>
                                                                    </div>
                                                                </div>
                                                           </div>
                                                           <div class="col-lg-4 col-md-6 col-sm-12">
                                                                <div class="form-group row">
                                                                    <label class="col-sm-5 col-form-label font-weight-bolder">Pin Code</label>
                                                                    <div class="col-sm-7">
                                                                        <label class="form-control-plaintext"><span class="colon">:</span> Dummy Text </label>
                                                                    </div>
                                                                </div>
                                                           </div>
                                                          <div class="col-lg-4 col-md-6 col-sm-12">
                                                                <div class="form-group row">
                                                                    <label class="col-sm-5 col-form-label font-weight-bolder">Email Id</label>
                                                                    <div class="col-sm-7">
                                                                        <label class="form-control-plaintext"><span class="colon">:</span>Dummy Text</label>
                                                                    </div>
                                                                </div>
                                                           </div>
                                                           
                                                       </div>
                                                      </div>
                                                       
                                </div>
                                                     
                              
                                </div>
                                <div class="form-group row mt-3">
                                                <label class="col-lg-2 col-md-4 col-sm-12 col-form-label font-weight-bolder">Remark<span class="text-danger">*</span></label>
                                                <div class="col-lg-4 col-md-6 col-sm-12">
                                                   <textarea name="textAddress" rows="1" cols="20" id="Textarea2" class="form-control"></textarea>
                                                 <small class="text-danger">Maximum <strong>500</strong> characters</small>
                                                </div>
                                            </div>
                                             <div class="form-group row">
                                            <div class="col-lg-6 ">
                                               
                                                <a href="javascript:void(0);" class="btn btn-primary btn-md ml-0 waves-effect waves-light">Forward</a>
                                                <a href="#" class="btn btn-dark btn-md waves-effect waves-light">Approve Return Back</a>
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
            loadNavigation('EmplyeeDeatilst', 'glempprofile', 'pllast', 'tl', 'Employee Profile', 'Employee Details', ' ');
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






