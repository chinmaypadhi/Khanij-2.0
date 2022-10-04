<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LicenseAreaDetails.aspx.cs" Inherits="LicenseeProfile_LicenseAreaDetails" %>
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
                                        <a class="nav-link active" href="javascript:void(0);">
                                        License Area Details
                                        </a>
                                    </li>
                                </ul>
                                <uc1:util runat="server" ID="util" />
                            </div>

                            <section class="box form-container">
                                <div class="content-body">
                                
                                <ul class="nav nav-tabs progressbar border-0" id="myTab" role="tablist">
                                  <li class="startstep activestep1">
                                    <a class="active" id="Location-tab" data-toggle="tab" href="#Location" role="tab" aria-controls="Location" aria-selected="true">Location</a>
                                  </li>
                                  <li >
                                    <a  id="Area-tab" data-toggle="tab" href="#Area" role="tab" aria-controls="Area" aria-selected="false">Area in Hectare</a>
                                  </li>
 
                                </ul>
                                <div class="tab-content" id="myTabContent">
                                  <div class="tab-pane fade show active" id="Location" role="tabpanel" aria-labelledby="Location-tab">
                                    <h5 class="text-brown font-weight-bold">Location</h5>
                                    <div class="row">
                                            <div class="col-lg-4 col-md-6 col-sm-12 form-group">
                                                <label class="col-form-label  font-weight-bolder">State <span class="text-danger">*</span></label>
                                                <select class="form-control">
                                                    <option value="Select">Select</option>
                                                </select>
                                            </div>
                                            <div class="col-lg-4 col-md-6 col-sm-12 form-group">
                                                 <label class="col-form-label  font-weight-bolder">District<span class="text-danger">*</span></label>
                                                  <select class="form-control">
                                                    <option value="Select">Select</option>
                                                </select>
                                            </div>
                                             <div class="col-lg-4 col-md-6 col-sm-12 form-group">
                                                <label class="col-form-label font-weight-bolder">Tehsil/Forest Division<span class="text-danger">*</span></label>
                                                <select class="form-control">
                                                    <option value="Select">Select</option>
                                                </select>
                                            </div>
                                       
                                            <div class="col-lg-4 col-md-6 col-sm-12 form-group">
                                                <label class="col-form-label font-weight-bolder">Village/Forest Range<span class="text-danger">*</span></label>
                                                <select class="form-control">
                                                    <option value="Select">Select</option>
                                                </select>
                                            </div>
                                            <div class="col-lg-4 col-md-6 col-sm-12 form-group">
                                                <label for="inputLoginId" class="col-form-label font-weight-bolder">Block Forest Range<span class="text-danger">*</span></label>
                                                <input type="text" class="form-control">
                                            </div>
                                            <div class="col-lg-4 col-md-6 col-sm-12 form-group">
                                                 <label for="inputLoginId" class="col-form-label font-weight-bolder">Pincode<span class="text-danger">*</span></label>
                                                  <input type="text" class="form-control">
                                            </div>
                                            
                                      
                                            <div class="col-lg-4 col-md-6 col-sm-12 form-group">
                                                <label class="col-form-label font-weight-bolder">Type of Land<span class="text-danger">*</span></label>
                                                <select class="form-control">
                                                    <option value="Select">Select</option>
                                                </select>
                                            </div>
                                            <div class="col-lg-4 col-md-6 col-sm-12 form-group">
                                                <label class="col-form-label font-weight-bolder">Gram Panchayat<span class="text-danger">*</span></label>
                                                  <input type="text" class="form-control">
                                            </div>
                                            <div class="col-lg-4 col-md-6 col-sm-12 form-group">
                                                <label class="col-form-label font-weight-bolder">Police Station<span class="text-danger">*</span></label>
                                                <input type="text" class="form-control">
                                            </div>
                                           
                                            
                                       </div>
                                    <div class="row mt-3">
                                        <div class="col-sm-12 text-center">
                                            <a class="btn btn-danger btn-md ml-0 waves-effect waves-light">Reset</a>
                                            <a class="btn btn-primary btn-md ml-0 waves-effect waves-light btnNext">Next</a>
                                        </div>
                                     </div>
                                    </div>
                                    <div class="tab-pane fade" id="Area" role="tabpanel" aria-labelledby="Area-tab">
                                     <h5 class="text-brown font-weight-bold">Area in Hectare</h5>  
                                    <div class="row">
                                            <div class="col-lg-4 col-md-6 col-sm-12 form-group">
                                                <label class="col-form-label font-weight-bolder">Area in Hectare <span class="text-danger">*</span></label>
                                                <input type="text" class="form-control">
                                            </div>
                                            <div class="col-lg-4 col-md-6 col-sm-12 form-group">
                                                 <label class="col-form-label font-weight-bolder">Toposheet Number<span class="text-danger">*</span></label>
                                                  <input type="text" class="form-control">
                                            </div>
                                             <div class="col-lg-4 col-md-6 col-sm-12 form-group">
                                                <label class="col-form-label font-weight-bolder">Coordinates Number<span class="text-danger">*</span></label>
                                                <input type="text" class="form-control">
                                            </div>
                                       
                                            <div class="col-lg-4 col-md-12 col-sm-12 form-group">
                                                <label class="col-form-label font-weight-bolder"> 
                        Demarcation Report/DGPS/GPS/Total Station Survey Report/Coordinates<span class="text-danger">*</span></label>
                                                <div class="custom-file">
                                                    <input type="file" class="custom-file-input" id="File1" name="filename">
                                                    <label class="custom-file-label" for="customFile">Choose Files</label>
                                                </div>
                                            </div>
                                            <div class="col-lg-4 col-md-12 col-sm-12 form-group">
                                                <label for="inputLoginId" class="col-form-label font-weight-bolder">Remarks<span class="text-danger">*</span></label>
                                                <textarea name="textAddress" rows="1" cols="20" id="textAddress" class="form-control"></textarea>
                                            </div>
                                            
                                            
                                       </div>
                                    
                                
                                        <div class="row mt-3">
                                        <div class="col-sm-12 text-center">
                                            <a  class="btn btn-dark btn-md ml-0 waves-effect waves-light btnPrevious">Previous</a>
                                            <a class="btn btn-danger btn-md ml-0 waves-effect waves-light">Reset</a>
                                            <a class="btn btn-success btn-md ml-0 waves-effect waves-light">Save & Update</a> 
                                             <a href="#" class="btn btn-warning text-dark btn-md waves-effect waves-light">Forward to DMO</a>
                                        </div>
                                     </div>
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
     <link href="../css/bootstrap-datetimepicker.min.css" rel="stylesheet">
    <script src="../js/moment.min.js"></script> 
    <script src="../js/bootstrap-datetimepicker.min.js"></script>
    
    <script>
        indicateMe = "yes"
        backMe = "yes"
        $(document).ready(function () {
            loadNavigation('LicenseAreaDetails', 'glRoleRes', 'pllicenprof', 'tl', 'Roles and Responsibity', 'Licensee Profile', ' ');
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




