<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SubmitionofTimeline.aspx.cs" Inherits="changeRequest_SubmitionofTimeline" %>
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
                                           Submition of Timeline
                                        </a>
                                    </li>
                                    
                                </ul>
                                <uc1:util runat="server" ID="util" />
                            </div>

                            <section class="box form-container">
                                <div class="content-body">

                                    <div class="row form-group">
                                    <div class="col-lg-12 col-md-12 col-sm-12">
                                    <div class="row">
                                               <label class="col-lg-2 col-md-3 col-sm-12 col-form-label font-weight-bolder">CR Number <span class="text-danger">*</span></label>
                                               <div class="col-lg-3 col-md-6 col-sm-12">
                                               <input type="text" class="form-control">
                                               </div>
                                               </div>
                                     </div>
                                     </div>
                                     <div class="row">
                                     <!--1 start-->
                                    
                                     <div class="col-lg-6 col-md-12 col-sm-12 pr-lg-4">
                                     <div class="bg-light p-2 border mb-3 ">
                                     <div class="row">
                                      <div class="col-lg-12 col-md-12 col-sm-12">
                                     <h5 class="text-brown font-weight-bold mt-0">SRS Details</h5>
                                     </div>
                                     <div class="col-lg-6 col-md-6 col-sm-12">
                                               <label class="col-form-label font-weight-bolder"> Start Date <span class="text-danger">*</span></label>
                                               <div class="input-group">
                                                      <input type="text" class="form-control datepicker" id="inputDate1">
                                                      <div class="input-group-prepend">
                                                        <label class="input-group-text" for="inputDate1"><i class="far fa-calendar"></i></label>
                                                      </div>
                                                 </div>
                                     </div>
                                     <div class="col-lg-6 col-md-6 col-sm-12">
                                               <label class="col-form-label font-weight-bolder">End Date <span class="text-danger">*</span></label>
                                               <div class="input-group">
                                                      <input type="text" class="form-control datepicker" id="inputDate2">
                                                      <div class="input-group-prepend">
                                                        <label class="input-group-text" for="inputDate2"><i class="far fa-calendar"></i></label>
                                                      </div>
                                                 </div>
                                     </div>
                                     <div class="col-lg-6 col-md-6 col-sm-12">
                                               <label class="col-form-label font-weight-bolder">Total Days <span class="text-danger">*</span></label>
                                               <input type="number" class="form-control">
                                     </div>
                                     <div class="col-lg-6 col-md-6 col-sm-12">
                                               <label class="col-form-label font-weight-bolder"> Remark <span class="text-danger">*</span></label>
                                               <textarea class="form-control" rows="1"></textarea>
                                               <small class="text-danger">Maximum <strong>500</strong> characters</small>
                                     </div>
                                     </div>
                                     </div>
                                     </div>
                                   
                                     <!-- 1 end -->

                                     <!--2 start-->
                                    
                                     <div class="col-lg-6 col-md-12 col-sm-12 pl-lg-0">
                                     <div class="bg-light p-2 border mb-3">
                                     <div class="row">
                                      <div class="col-lg-12 col-md-12 col-sm-12">
                                     <h5 class="text-brown font-weight-bold mt-0">Development Details</h5>
                                     </div>
                                     <div class="col-lg-6 col-md-6 col-sm-12">
                                               <label class="col-form-label font-weight-bolder"> Start Date <span class="text-danger">*</span></label>
                                               <div class="input-group">
                                                      <input type="text" class="form-control datepicker" id="inputDate3">
                                                      <div class="input-group-prepend">
                                                        <label class="input-group-text" for="inputDate3"><i class="far fa-calendar"></i></label>
                                                      </div>
                                                 </div>
                                     </div>
                                     <div class="col-lg-6 col-md-6 col-sm-12">
                                               <label class="col-form-label font-weight-bolder"> End Date <span class="text-danger">*</span></label>
                                               <div class="input-group">
                                                      <input type="text" class="form-control datepicker" id="inputDate4">
                                                      <div class="input-group-prepend">
                                                        <label class="input-group-text" for="inputDate4"><i class="far fa-calendar"></i></label>
                                                      </div>
                                                 </div>
                                     </div>
                                    
                                     <div class="col-lg-12 col-md-12 col-sm-12">
                                               <label class="col-form-label font-weight-bolder"> Remark <span class="text-danger">*</span></label>
                                               <textarea class="form-control" rows="1"></textarea>
                                               <small class="text-danger">Maximum <strong>500</strong> characters</small>
                                     </div>
                                     </div>
                                     </div>
                                     </div>
                                    
                                     <!-- 2 end -->
                                     <!--3 start-->
                                     <div class="col-lg-6 col-md-12 col-sm-12 pr-lg-4">
                                     <div class="bg-light p-2 border mb-3">
                                     <div class="row">
                                      <div class="col-lg-12 col-md-12 col-sm-12">
                                     <h5 class="text-brown font-weight-bold mt-0">Testing Details</h5>
                                     </div>
                                     <div class="col-lg-6 col-md-6 col-sm-12">
                                               <label class="col-form-label font-weight-bolder">Start Date <span class="text-danger">*</span></label>
                                               <div class="input-group">
                                                      <input type="text" class="form-control datepicker" id="inputDate5">
                                                      <div class="input-group-prepend">
                                                        <label class="input-group-text" for="inputDate5"><i class="far fa-calendar"></i></label>
                                                      </div>
                                                 </div>
                                     </div>
                                     <div class="col-lg-6 col-md-6 col-sm-12">
                                               <label class="col-form-label font-weight-bolder"> End Date <span class="text-danger">*</span></label>
                                               <div class="input-group">
                                                      <input type="text" class="form-control datepicker" id="inputDate6">
                                                      <div class="input-group-prepend">
                                                        <label class="input-group-text" for="inputDate6"><i class="far fa-calendar"></i></label>
                                                      </div>
                                                 </div>
                                     </div>
                                     <div class="col-lg-6 col-md-6 col-sm-12">
                                               <label class="col-form-label font-weight-bolder"> Total Days <span class="text-danger">*</span></label>
                                               <input type="number" class="form-control">
                                     </div>
                                     <div class="col-lg-6 col-md-6 col-sm-12">
                                               <label class="col-form-label font-weight-bolder">Remark<span class="text-danger">*</span></label>
                                               <textarea class="form-control" rows="1"></textarea>
                                               <small class="text-danger">Maximum <strong>500</strong> characters</small>
                                     </div>
                                     </div>
                                     </div>
                                     </div>
                                     <!-- 3 end -->
                                     <!--4 start-->
                                    
                                     <div class="col-lg-6 col-md-12 col-sm-12 pl-lg-0">
                                     <div class="bg-light p-2 border mb-3">
                                     <div class="row"><div class="col-lg-12 col-md-12 col-sm-12">
                                     <h5 class="text-brown font-weight-bold mt-0">UAT Details</h5>
                                     </div>
                                     <div class="col-lg-6 col-md-6 col-sm-12">
                                               <label class="col-form-label font-weight-bolder">Start Date <span class="text-danger">*</span></label>
                                               <div class="input-group">
                                                      <input type="text" class="form-control datepicker" id="inputDate7">
                                                      <div class="input-group-prepend">
                                                        <label class="input-group-text" for="inputDate7"><i class="far fa-calendar"></i></label>
                                                      </div>
                                                 </div>
                                     </div>
                                     <div class="col-lg-6 col-md-6 col-sm-12">
                                               <label class="col-form-label font-weight-bolder"> End Date <span class="text-danger">*</span></label>
                                               <div class="input-group">
                                                      <input type="text" class="form-control datepicker" id="inputDate8">
                                                      <div class="input-group-prepend">
                                                        <label class="input-group-text" for="inputDate8"><i class="far fa-calendar"></i></label>
                                                      </div>
                                                 </div>
                                     </div>
                                     <div class="col-lg-6 col-md-6 col-sm-12">
                                               <label class="col-form-label font-weight-bolder"> Total Days <span class="text-danger">*</span></label>
                                               <input type="number" class="form-control">
                                     </div>
                                     <div class="col-lg-6 col-md-6 col-sm-12">
                                               <label class="col-form-label font-weight-bolder">Remark<span class="text-danger">*</span></label>
                                               <textarea class="form-control" rows="1"></textarea>
                                               <small class="text-danger">Maximum <strong>500</strong> characters</small>
                                     </div></div>
                                     </div>
                                     </div>
                                    
                                     <!-- 4 end -->

                                     <!--5 start-->
                                     <div class="col-lg-12 col-md-12 col-sm-12">
                                     <div class="bg-light p-2 border mb-3">
                                     <div class="row">
                                     <div class="col-lg-12 col-md-12 col-sm-12">
                                     <h5 class="text-brown font-weight-bold mt-0">Implementation Online Details</h5>
                                     </div>
                                     <div class="col-lg-3 col-md-6 col-sm-12">
                                               <label class="col-form-label font-weight-bolder">Start Date</small> <span class="text-danger">*</span></label>
                                               <div class="input-group">
                                                      <input type="text" class="form-control datepicker" id="inputDate9">
                                                      <div class="input-group-prepend">
                                                        <label class="input-group-text" for="inputDate9"><i class="far fa-calendar"></i></label>
                                                      </div>
                                                 </div>
                                     </div>
                                     <div class="col-lg-3 col-md-6 col-sm-12">
                                               <label class="col-form-label font-weight-bolder">End Date<span class="text-danger">*</span></label>
                                               <div class="input-group">
                                                      <input type="text" class="form-control datepicker" id="inputDate10">
                                                      <div class="input-group-prepend">
                                                        <label class="input-group-text" for="inputDate10"><i class="far fa-calendar"></i></label>
                                                      </div>
                                                 </div>
                                     </div>
                                     <div class="col-lg-3 col-md-6 col-sm-12">
                                               <label class="col-form-label font-weight-bolder">Total Days<span class="text-danger">*</span></label>
                                               <input type="text" class="form-control">
                                     </div>
                                     <div class="col-lg-3 col-md-6 col-sm-12">
                                               <label class="col-form-label font-weight-bolder"> Remark <span class="text-danger">*</span></label>
                                               <textarea class="form-control" rows="1"></textarea>
                                               <small class="text-danger">Maximum <strong>500</strong> characters</small>
                                     </div>
                                     </div>
                                     </div>
                                     </div>
                                      <!-- 5 end -->

                                       <div class="col-sm-12">
                                                <a href="javascript:void(0);" class="btn btn-primary btn-md ml-0" data-toggle="modal"
                                                data-target=".alert-modal">Submit</a>
                                                <a href="#" class="btn btn-danger btn-md">Reset</a>
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
     <link href="../css/bootstrap-datetimepicker.min.css" rel="stylesheet">
    <script src="../js/moment.min.js"></script> 
    <script src="../js/bootstrap-datetimepicker.min.js"></script>





    <script>
        indicateMe = "yes"

        $(document).ready(function () {
            loadNavigation('SubmitionofTimeline', 'glchangerequest', 'plsubtim', 'tl', 'Change Request', 'Submition of Timeline', ' ');
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


