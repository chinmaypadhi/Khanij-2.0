<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RemarkReportingAuthority.aspx.cs" Inherits="AEC_RemarkReportingAuthority" %>
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
                                           Remark Reporting Authority
                                        </a>
                                    </li>
                                     
                                </ul>
                                <uc1:util runat="server" ID="util" />
                            </div>

                            <section class="box form-container">
                                <div class="content-body">
                                    <div class="row">
                                    <div class="col-xl-12">
                                   <div class="bg-light p-3 form-group border">
                                    <h5 class="text-brown font-weight-bold mt-0">Self Appraisal Class 1,2,3 Details</h5>
                                   <div class="row">
                                    <div class="col-lg-4 col-md-12 col-sm-12">
                                            <div class="mb-2 row">
                                                <label  class="col-lg-5 col-md-6 col-sm-12 col-form-label font-weight-bolder">Person Name</label>
                                                <div class="col-lg-7 col-md-6 col-sm-12">
                                                    <label class="form-control-plaintext"><span class="colon">:</span>Khusbu kumari singh deo</label>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-4 col-md-12 col-sm-12">
                                            <div class="mb-2 row">
                                                <label  class="col-lg-5 col-md-6 col-sm-12 col-form-label font-weight-bolder">Designation</label>
                                                <div class="col-lg-7 col-md-6 col-sm-12">
                                                    <label class="form-control-plaintext"><span class="colon">:</span>Additional Director</label>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-4 col-md-12 col-sm-12">
                                            <div class="mb-2 row">
                                                <label  class="col-lg-5 col-md-6 col-sm-12 col-form-label font-weight-bolder">Department</label>
                                                <div class="col-lg-7 col-md-6 col-sm-12">
                                                    <label class="form-control-plaintext"><span class="colon">:</span>DGM</label>
                                                </div>
                                            </div>
                                        </div>
                                         
                                        
                                         <div class="col-lg-4 col-md-12 col-sm-12">
                                            <div class="mb-2 row">
                                                <label  class="col-lg-5 col-md-6 col-sm-12 col-form-label font-weight-bolder">Requirement Type </label>
                                                <div class="col-lg-7 col-md-6 col-sm-12">
                                                    <label class="form-control-plaintext"><span class="colon">:</span>consectetur adipiscing elit</label>
                                                </div>
                                            </div>
                                        </div>
                                         <div class="col-lg-4 col-md-12 col-sm-12">
                                            <div class="mb-2 row">
                                                <label  class="col-lg-5 col-md-6 col-sm-12 col-form-label font-weight-bolder">Joining Date</label>
                                                <div class="col-lg-7 col-md-6 col-sm-12">
                                                    <label class="form-control-plaintext"><span class="colon">:</span>12-03-2021</label>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-4 col-md-12 col-sm-12"></div>
                                         <div class="col-lg-4 col-md-12 col-sm-12">
                                            <div class="mb-2 row">
                                                <label  class="col-lg-5 col-md-6 col-sm-12 col-form-label font-weight-bolder">Work Description </label>
                                                <div class="col-lg-7 col-md-6 col-sm-12">
                                                    <label class="form-control-plaintext"><span class="colon">:</span>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent blandit magna vitae mattis hendrerit. Proin laoreet vehicula massa, a fringilla turpis auctor vitae.</label>
                                                </div>
                                            </div>
                                        </div>
                                         <div class="col-lg-4 col-md-12 col-sm-12">
                                            <div class="mb-2 row">
                                                <label  class="col-lg-5 col-md-6 col-sm-12 col-form-label font-weight-bolder">Goal Description</label>
                                                <div class="col-lg-7 col-md-6 col-sm-12">
                                                    <label class="form-control-plaintext"><span class="colon">:</span>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent blandit magna vitae mattis hendrerit. Proin laoreet vehicula massa, a fringilla turpis auctor vitae.</label>
                                                </div>
                                            </div>
                                        </div>
                                         <div class="col-lg-4 col-md-12 col-sm-12">
                                            <div class="mb-2 row">
                                                <label  class="col-lg-5 col-md-6 col-sm-12 col-form-label font-weight-bolder">Describe obstacles arises in achieve your goal</label>
                                                <div class="col-lg-7 col-md-6 col-sm-12">
                                                    <label class="form-control-plaintext"><span class="colon">:</span>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent blandit magna vitae mattis hendrerit. Proin laoreet vehicula massa, a fringilla turpis auctor vitae.</label>
                                                </div>
                                            </div>
                                        </div>

                                        </div>
                                        </div>
                                        </div>

                                        
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label  class="col-lg-4 col-md-6 col-sm-12 col-form-label font-weight-bolder"> Remarks about target and achievement<span class="text-danger">*</span></label>
                                                <div class="col-lg-7 col-md-6 col-sm-12">
                                                     <textarea name="textAddress" rows="2" cols="20" id="Textarea12" class="form-control"></textarea>
                                                 <small class="text-danger">Maximum <strong>500</strong> characters</small>
                                                </div>
                                            </div>
                                        </div>
                                       
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label  class="col-lg-4 col-md-6 col-sm-12 col-form-label font-weight-bolder"> Describe the quality of work <span class="text-danger">*</span></label>
                                                <div class="col-lg-7 col-md-6 col-sm-12">
                                                     <textarea name="textAddress" rows="2" cols="20" id="Textarea11" class="form-control"></textarea>
                                                 <small class="text-danger">Maximum <strong>500</strong> characters</small>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label  class="col-lg-4 col-md-6 col-sm-12 col-form-label font-weight-bolder">Kindly provide the work details<span class="text-danger">*</span></label>
                                                <div class="col-lg-7 col-md-6 col-sm-12">
                                                    <textarea name="textAddress" rows="2" cols="20" id="Textarea10" class="form-control"></textarea>
                                                 <small class="text-danger">Maximum <strong>500</strong> characters</small>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label  class="col-lg-4 col-md-6 col-sm-12 col-form-label font-weight-bolder">Remarks about work consternation<span class="text-danger">*</span></label>
                                                <div class="col-lg-7 col-md-6 col-sm-12">
                                                    <textarea name="textAddress" rows="2" cols="20" id="Textarea9" class="form-control"></textarea>
                                                 <small class="text-danger">Maximum <strong>500</strong> characters</small>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label  class="col-lg-4 col-md-6 col-sm-12 col-form-label font-weight-bolder"> Decision tacking quality <span class="text-danger">*</span></label>
                                                <div class="col-lg-7 col-md-6 col-sm-12">
                                                   <textarea name="textAddress" rows="2" cols="20" id="Textarea7" class="form-control"></textarea>
                                                 <small class="text-danger">Maximum <strong>500</strong> characters</small>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label  class="col-lg-4 col-md-6 col-sm-12 col-form-label font-weight-bolder"> Unsuspected handling capacity. <span class="text-danger">*</span></label>
                                                <div class="col-lg-7 col-md-6 col-sm-12">
                                                    <textarea name="textAddress" rows="2" cols="20" id="Textarea1" class="form-control"></textarea>
                                                 <small class="text-danger">Maximum <strong>500</strong> characters</small>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label  class="col-lg-4 col-md-6 col-sm-12 col-form-label font-weight-bolder">  Capability to trust of colleagues <span class="text-danger">*</span></label>
                                                <div class="col-lg-7 col-md-6 col-sm-12">
                                                   <textarea name="textAddress" rows="2" cols="20" id="Textarea2" class="form-control"></textarea>
                                                 <small class="text-danger">Maximum <strong>500</strong> characters</small>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label  class="col-lg-4 col-md-6 col-sm-12 col-form-label font-weight-bolder">Communication and logic   <span class="text-danger">*</span></label>
                                                <div class="col-lg-7 col-md-6 col-sm-12">
                                                    <textarea name="textAddress" rows="2" cols="20" id="Textarea3" class="form-control"></textarea>
                                                 <small class="text-danger">Maximum <strong>500</strong> characters</small>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label  class="col-lg-4 col-md-6 col-sm-12 col-form-label font-weight-bolder"> Respect to others<span class="text-danger">*</span></label>
                                                <div class="col-lg-7 col-md-6 col-sm-12">
                                                   <textarea name="textAddress" rows="2" cols="20" id="Textarea4" class="form-control"></textarea>
                                                 <small class="text-danger">Maximum <strong>500</strong> characters</small>
                                                      
                                                </div>
                                            </div>
                                        </div>
                                         <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label  class="col-lg-4 col-md-6 col-sm-12 col-form-label font-weight-bolder">Public Relation <span class="text-danger">*</span></label>
                                                <div class="col-lg-7 col-md-6 col-sm-12">
                                                   <textarea name="textAddress" rows="2" cols="20" id="Textarea5" class="form-control"></textarea>
                                                 <small class="text-danger">Maximum <strong>500</strong> characters</small>
                                                      
                                                </div>
                                            </div>
                                        </div>
                                         <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label  class="col-lg-4 col-md-6 col-sm-12 col-form-label font-weight-bolder"> Ability to making plan<span class="text-danger">*</span></label>
                                                <div class="col-lg-7 col-md-6 col-sm-12">
                                                   <textarea name="textAddress" rows="2" cols="20" id="Textarea6" class="form-control"></textarea>
                                                 <small class="text-danger">Maximum <strong>500</strong> characters</small>
                                                      
                                                </div>
                                            </div>
                                        </div>
                                         <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label  class="col-lg-4 col-md-6 col-sm-12 col-form-label font-weight-bolder">Sincere <span class="text-danger">*</span></label>
                                                <div class="col-lg-7 col-md-6 col-sm-12">
                                                   <textarea name="textAddress" rows="2" cols="20" id="Textarea8" class="form-control"></textarea>
                                                 <small class="text-danger">Maximum <strong>500</strong> characters</small>
                                                      
                                                </div>
                                            </div>
                                        </div>
                                         <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label  class="col-lg-4 col-md-6 col-sm-12 col-form-label font-weight-bolder">Ability to check<span class="text-danger">*</span></label>
                                                <div class="col-lg-7 col-md-6 col-sm-12">
                                                   <select class="form-control form-control-sm searchableselect">
                                                          <option>select</option>
                                                      </select>
                                                </div>
                                            </div>
                                        </div>
                                        
                                         <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label  class="col-lg-4 col-md-6 col-sm-12 col-form-label font-weight-bolder">Grade<span class="text-danger">*</span></label>
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
            loadNavigation('RemarkReportingAuthority', 'glaec', 'plrera', 'tl', 'AEC', 'Remark Reporting Authority', ' ');
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






