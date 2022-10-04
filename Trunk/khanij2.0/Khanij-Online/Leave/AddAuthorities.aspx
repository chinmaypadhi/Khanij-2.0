<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddAuthorities.aspx.cs" Inherits="Leave_AddAuthorities" %>
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
                                        <a class="nav-link active" href="AddAuthorities.aspx">
                                           Add Authorities
                                        </a>
                                    </li>
                                     <li class="nav-item">
                                        <a class="nav-link" href="ViewAuthorities.aspx">
                                           View Authorities
                                        </a>
                                    </li>
                                </ul>
                                <uc1:util runat="server" ID="util" />
                            </div>

                            <section class="box form-container">
                                <div class="content-body">

                                    <div class="row">
                                    <div class="col-lg-12 col-md-12 col-sm-12">
                                    <h5 class="text-brown font-weight-bold mt-0">Apply Authorities</h5>
                                   </div>
                                   <div class="col-xl-12">
                                        <div class="bg-light p-2 form-group border">
                                       <div class="row">
                                      
                                     <div class="col-lg-3 col-md-6 col-sm-12">
                                               <label class="col-form-label font-weight-bolder pt-0">State<span class="text-danger">*</span></label>
                                               <select class="form-control form-control-sm searchableselect">
                                                          <option>select</option>
                                                      </select>
                                     </div>
                                     <div class="col-lg-3 col-md-6 col-sm-12">
                                               <label class="col-form-label font-weight-bolder pt-0">Department<span class="text-danger">*</span></label>
                                                <select class="form-control form-control-sm searchableselect">
                                                          <option>select</option>
                                                      </select>
                                     </div>
                                     <div class="col-lg-3 col-md-6 col-sm-12">
                                               <label class="col-form-label font-weight-bolder pt-0">District <span class="text-danger">*</span></label>
                                               <select class="form-control form-control-sm searchableselect">
                                                          <option>select</option>
                                                      </select>
                                     </div>
                                      <div class="col-lg-3 col-md-6 col-sm-12">
                                               <label class="col-form-label font-weight-bolder pt-0">Section<span class="text-danger">*</span></label>
                                               <select class="form-control form-control-sm searchableselect">
                                                          <option>select</option>
                                                      </select>
                                     </div>
                                    
                                     </div>
                                       </div>
                                  </div>
                                   
                                  <div class="col-xl-4">
                                  <h5 class="text-brown font-weight-bold mt-0">Verify</h5>
                                      <div class="bg-light p-2 form-group border">
                                       <div class="row">
                                         <div class="col-lg-12 col-md-12 col-sm-12">
                                              <label class="col-form-label font-weight-bolder pt-0">Designation<span class="text-danger">*</span></label>
                                               <select class="form-control form-control-sm searchableselect">
                                                     <option>select</option>
                                              </select>
                                         </div>
                                     </div>
                                     </div>
                                  </div>
                                  <div class="col-xl-8">
                                   <h5 class="text-brown font-weight-bold mt-0">Forward</h5>
                                        <div class="bg-light p-2 form-group border">
                                       <div class="row">
                                      
                                     <div class="col-lg-6 col-md-6 col-sm-12">
                                               <label class="col-form-label font-weight-bolder pt-0">Department<span class="text-danger">*</span></label>
                                               <select class="form-control form-control-sm searchableselect">
                                                          <option>select</option>
                                                      </select>
                                     </div>
                                     <div class="col-lg-6 col-md-6 col-sm-12">
                                               <label class="col-form-label font-weight-bolder pt-0">Designation<span class="text-danger">*</span></label>
                                               <select class="form-control form-control-sm searchableselect">
                                                          <option>select</option>
                                                      </select>
                                     </div>
                                    
                                    
                                     </div>
                                       </div>
                                  </div>
                                  <div class="col-xl-4">
                                  <h5 class="text-brown font-weight-bold mt-0">OIC Establishment</h5>
                                      <div class="bg-light p-2 form-group border">
                                       <div class="row">
                                         <div class="col-lg-12 col-md-12 col-sm-12">
                                              <label class="col-form-label font-weight-bolder pt-0">Officer<span class="text-danger">*</span></label>
                                               <select class="form-control form-control-sm searchableselect">
                                                     <option>select</option>
                                              </select>
                                         </div>
                                     </div>
                                     </div>
                                  </div>
                                  <div class="col-xl-8">
                                  <h5 class="text-brown font-weight-bold mt-0">Approve/Reject</h5>
                                        <div class="bg-light p-2 form-group border">
                                       <div class="row">
                                      
                                     <div class="col-lg-6 col-md-6 col-sm-12">
                                               <label class="col-form-label font-weight-bolder pt-0">Designation<span class="text-danger">*</span></label>
                                               <select class="form-control form-control-sm searchableselect">
                                                          <option>select</option>
                                                      </select>
                                     </div>
                                     <div class="col-lg-6 col-md-6 col-sm-12">
                                               <label class="col-form-label font-weight-bolder pt-0">User<span class="text-danger">*</span></label>
                                               <select class="form-control form-control-sm searchableselect">
                                                          <option>select</option>
                                                      </select>
                                     </div>
                                    
                                    
                                     </div>
                                       </div>
                                  </div>
                                   <div class="col-xl-4">
                                    <h5 class="text-brown font-weight-bold mt-0">Days Exceed </h5>
                                      <div class="bg-light p-2 form-group border">
                                       <div class="row">
                                         <div class="col-lg-12 col-md-12 col-sm-12">
                                              <label class="col-form-label font-weight-bolder pt-0">If No. of Days Exceed<span class="text-danger">*</span></label>
                                               <select class="form-control form-control-sm searchableselect">
                                                     <option>select</option>
                                              </select>
                                         </div>
                                     </div>
                                     </div>
                                  </div>
                                  <div class="col-xl-8">
                                   <h5 class="text-brown font-weight-bold mt-0">Next Approve/Reject </h5>
                                        <div class="bg-light p-2 form-group border">
                                       <div class="row">
                                      
                                     <div class="col-lg-6 col-md-6 col-sm-12">
                                               <label class="col-form-label font-weight-bolder pt-0">Designation<span class="text-danger">*</span></label>
                                               <select class="form-control form-control-sm searchableselect">
                                                          <option>select</option>
                                                      </select>
                                     </div>
                                     <div class="col-lg-6 col-md-6 col-sm-12">
                                               <label class="col-form-label font-weight-bolder pt-0">User<span class="text-danger">*</span></label>
                                               <select class="form-control form-control-sm searchableselect">
                                                          <option>select</option>
                                                      </select>
                                     </div>
                                    
                                    
                                     </div>
                                       </div>
                                  </div>
                                  <div class="col-xl-4">
                                  <h5 class="text-brown font-weight-bold mt-0">Days Exceed </h5>
                                      <div class="bg-light p-2 form-group border">
                                       <div class="row">
                                         <div class="col-lg-12 col-md-12 col-sm-12">
                                              <label class="col-form-label font-weight-bolder pt-0">If No. of Days Exceed<span class="text-danger">*</span></label>
                                               <select class="form-control form-control-sm searchableselect">
                                                     <option>select</option>
                                              </select>
                                         </div>
                                     </div>
                                     </div>
                                  </div>
                                  <div class="col-xl-8">
                                   <h5 class="text-brown font-weight-bold mt-0">Next Approve and Reset </h5>
                                        <div class="bg-light p-2 form-group border">
                                       <div class="row">
                                      
                                     <div class="col-lg-6 col-md-6 col-sm-12">
                                               <label class="col-form-label font-weight-bolder pt-0">Designation<span class="text-danger">*</span></label>
                                               <select class="form-control form-control-sm searchableselect">
                                                          <option>select</option>
                                                      </select>
                                     </div>
                                     <div class="col-lg-6 col-md-6 col-sm-12">
                                               <label class="col-form-label font-weight-bolder pt-0">User<span class="text-danger">*</span></label>
                                               <select class="form-control form-control-sm searchableselect">
                                                          <option>select</option>
                                                      </select>
                                     </div>
                                    
                                    
                                     </div>
                                       </div>
                                  </div>
                                  
                                  
                                   
                                       
                                            <div class="col-sm-6 ">
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
            loadNavigation('AddAuthorities', 'glholiday', 'plauth', 'tl', 'Leave', 'Authorities', ' ');
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



