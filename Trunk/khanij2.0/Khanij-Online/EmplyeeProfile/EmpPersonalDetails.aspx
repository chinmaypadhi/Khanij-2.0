<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EmpPersonalDetails.aspx.cs" Inherits="EmplyeeProfile_EmpPersonal_Details" %>
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
                                        <a class="nav-link active" href="EmpPersonalDetails.aspx">
                                          Employee Personal Details
                                        </a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link " href="ViewEmpPersonalDetails.aspx">
                                          View Employee Personal Details
                                        </a>
                                    </li>
                                </ul>
                                <uc1:util runat="server" ID="util" />
                            </div>

                            <section class="box form-container">
                                <div class="content-body">
                                 <ul class="nav nav-tabs progressbar border-0" id="myTab" role="tablist">
                                    <li class="startstep activestep1">
                                      <a  class="active" id="first-tab" data-toggle="tab" href="#first" role="tab" aria-controls="first" aria-selected="true">Employee Personal Details</a>
                                    </li>
                                    <li>
                                        <a  id="second-tab" data-toggle="tab" href="#second" role="tab" aria-controls="second" aria-selected="false">Address Information</a>
                                    </li>
                                    <li>
                                         <a  id="third-tab" data-toggle="tab" href="#third" role="tab" aria-controls="third" aria-selected="false">Emp Current Posting Detail</a>
                                    </li>
                                </ul>

                                <div class="tab-content" id="myTabContent">
                                  <div class="tab-pane fade show active" id="first" role="tabpanel" aria-labelledby="first-tab">
                                
                                        <h5 class="text-brown font-weight-bold">Employee Personal Details</h5>
                                        <div class="form-group row">
                                            <div class="col-sm-3">
                                               <label class="col-form-label font-weight-bolder">Employee Id<span class="text-danger">*</span></label>
                                                <input type="text" class="form-control">
                                            </div>
                                            <div class="col-sm-3">
                                                 <label  class="col-form-label font-weight-bolder">Name<span class="text-danger">*</span></label>
                                                  <input type="text" class="form-control">
                                            </div>
                                             <div class="col-sm-3">
                                                <label class="col-form-label font-weight-bolder">Father/Mother/Husband Names<span class="text-danger">*</span></label>
                                                <input type="text" class="form-control">
                                            </div>
                                            <div class="col-sm-3">
                                                <label class="col-form-label font-weight-bolder">Employee Type<span class="text-danger">*</span></label>
                                                <select class="form-control form-control-sm searchableselect">
                                                          <option>select</option>
                                                    <option>Permanent </option>
                                                    <option>temporary</option>
                                                      </select>
                                            </div>
                                           
                                       </div>

                                        <div class="form-group row">
                                             <div class="col-sm-3">
                                               <label class="col-form-label font-weight-bolder">Adhar No.<span class="text-danger">*</span></label>
                                                <input type="text" class="form-control">
                                            </div>
                                            <div class="col-sm-3">
                                                 <label  class="col-form-label font-weight-bolder">Aadhar Card<span class="text-danger">*</span></label>
                                                 <div class="custom-file">
                                                    <input type="file" class="custom-file-input" id="File5" name="filename">
                                                    <label class="custom-file-label" for="customFile">Choose Files</label>
                                                </div>
                                            </div>
                                             <div class="col-sm-3">
                                                <label class="col-form-label font-weight-bolder">Current Designation<span class="text-danger">*</span></label>
                                                <select class="form-control form-control-sm searchableselect">
                                                          <option>select</option>
                                                    <option>DGM</option>
                                                    <option>MRD</option>
                                                      </select>
                                            </div>
                                            <div class="col-sm-3">
                                                <label class="col-form-label font-weight-bolder">Category<span class="text-danger">*</span></label>
                                                <select class="form-control form-control-sm searchableselect">
                                                          <option>select</option>
                                                           <option>Unreserved</option>
                                                    <option>OBC</option>
                                                    <option>SC</option>
                                                    <option>ST</option>
                                                      </select>
                                            </div>
                                       </div>

                                        <div class="form-group row">
                                             <div class="col-sm-3">
                                               <label class="col-form-label font-weight-bolder">Class<span class="text-danger">*</span></label>
                                                <select class="form-control form-control-sm searchableselect">
                                                          <option>select</option>
                                                    <option>Class I</option>
                                                     <option>Class II</option>
                                                     <option>Class III</option>
                                                     <option>Class IV</option>
                                                      </select>
                                            </div>
                                            <div class="col-sm-3">
                                                 <label  class="col-form-label font-weight-bolder">Mobile No.<span class="text-danger">*</span></label>
                                                  <input type="text" class="form-control"/>
                                            </div>
                                             <div class="col-sm-3">
                                                <label class="col-form-label font-weight-bolder">Email Id<span class="text-danger">*</span></label>
                                                <input type="text" class="form-control">
                                            </div>
                                            <div class="col-sm-3">
                                                <label class="col-form-label font-weight-bolder">Date of Birth<span class="text-danger">*</span></label>
                                                <div class="input-group">
                                                      <input type="text" class="form-control datepicker" id="Date1">
                                                      <div class="input-group-prepend">
                                                        <label class="input-group-text" for="Date1"><i class="far fa-calendar"></i></label>
                                                      </div>
                                                 </div>
                                            </div>
                                       </div>
                                       <div class="form-group row">
                                             <div class="col-sm-3">
                                               <label class="col-form-label font-weight-bolder">Home State<span class="text-danger">*</span></label>
                                                <select class="form-control form-control-sm searchableselect">
                                                          <option>select</option>
                                                    <option>Chhattisgarh </option>
                                                      </select>
                                            </div>
                                            <div class="col-sm-3">
                                                 <label  class="col-form-label font-weight-bolder">Home District<span class="text-danger">*</span></label>
                                                 <select class="form-control form-control-sm searchableselect">
                                                     <option>select</option>
                                                          <option>Raipur</option>
                                                      </select>
                                            </div>
                                             <div class="col-sm-3">
                                                <label class="col-form-label font-weight-bolder">Gender<span class="text-danger">*</span></label>
                                               <select class="form-control form-control-sm searchableselect">
                                                   <option>select</option>
                                                          <option>Female </option>
                                                    <option>Male, other</option>
                                                   <option>Other</option>
                                                      </select>
                                            </div>
                                            <div class="col-sm-3">
                                                <label class="col-form-label font-weight-bolder">Marital Status<span class="text-danger">*</span></label>
                                                <select class="form-control form-control-sm searchableselect">
                                                          <option>select</option>
                                                    <option>Single </option>
                                                    <option>Marriaged</option>
                                                      </select>
                                            </div>
                                       </div>
                                       <div class="form-group row">
                                             <div class="col-sm-3">
                                               <label class="col-form-label font-weight-bolder">Signature<span class="text-danger">*</span></label>
                                                <div class="custom-file">
                                                    <input type="file" class="custom-file-input" id="File3" name="filename">
                                                    <label class="custom-file-label" for="customFile">Choose Files</label>
                                                </div>
                                            </div>
                                            <div class="col-sm-3">
                                                 <label  class="col-form-label font-weight-bolder">Photo<span class="text-danger">*</span></label>
                                                  <div class="custom-file">
                                                    <input type="file" class="custom-file-input" id="File4" name="filename">
                                                    <label class="custom-file-label" for="customFile">Choose Files</label>
                                                </div>
                                            </div>
                                       </div>

                                      
                                       
                                       <div class="row mt-3">
                                        <div class="col-sm-12 text-center">
                                            <%--<a href="javascript:void(0);" class="btn btn-success btn-md ml-0">Submit</a>--%>
                                            <a class="btn btn-danger btn-md ml-0 waves-effect waves-light">Reset</a>
                                            <a class="btn btn-success btn-md ml-0 waves-effect waves-light btnNext">Submit</a>
                                        </div>
                                     </div>
                                       
                                     
                                   
                                  </div>
                                  <div class="tab-pane fade" id="second" role="tabpanel" aria-labelledby="second-tab">
                                        
                                        <div class="row">
                                     
                                    <div class="col-xl-6">
                                      <h5 class="text-brown font-weight-bold mt-0">Present Address</h5>
                                        <div class="bg-light p-2 form-group border">
                                       <div class="row">
                                      
                                     <div class="col-lg-6 col-md-6 col-sm-12">
                                               <label class="col-form-label font-weight-bolder pt-0">present Address<span class="text-danger">*</span></label>
                                                <textarea name="textAddress" rows="1" cols="20" id="Textarea2" class="form-control"></textarea>
                                                 <small class="text-danger">Maximum <strong>500</strong> characters</small>
                                     </div>
                                     <div class="col-lg-6 col-md-6 col-sm-12">
                                               <label class="col-form-label font-weight-bolder pt-0">District<span class="text-danger">*</span></label>
                                                 <select class="form-control form-control-sm searchableselect">
                                                          <option>select</option>
                                                      <option>Raipur</option>
                                                      </select>
                                     </div>
                                     <div class="col-lg-6 col-md-6 col-sm-12">
                                               <label class="col-form-label font-weight-bolder pt-0">Pin Code <span class="text-danger">*</span></label>
                                               <input type="text" class="form-control">
                                     </div>
                                      <div class="col-lg-6 col-md-6 col-sm-12">
                                               <label class="col-form-label font-weight-bolder pt-0">Email Id<span class="text-danger">*</span></label>
                                              <input type="email" class="form-control">
                                     </div>
                                    
                                     </div>
                                       </div>
                                  </div>
                                      
                                        
                                        
                                       <div class="col-xl-6">
                                        <h5 class="text-brown font-weight-bold mt-0">Permanent  Address</h5>
                                        <div class="bg-light p-2  border">
                                       <div class="row">
                                      
                                     <div class="col-lg-6 col-md-6 col-sm-12">
                                               <label class="col-form-label font-weight-bolder pt-0">Permanent Address<span class="text-danger">*</span></label>
                                                <textarea name="textAddress" rows="1" cols="20" id="Textarea1" class="form-control"></textarea>
                                                 <small class="text-danger">Maximum <strong>500</strong> characters</small>
                                     </div>
                                     <div class="col-lg-6 col-md-6 col-sm-12">
                                               <label class="col-form-label font-weight-bolder pt-0">District<span class="text-danger">*</span></label>
                                                 <select class="form-control form-control-sm searchableselect">
                                                          <option>select</option>
                                                     <option>Raipur</option>
                                                      </select>
                                     </div>
                                     <div class="col-lg-6 col-md-6 col-sm-12">
                                               <label class="col-form-label font-weight-bolder pt-0">Pin Code <span class="text-danger">*</span></label>
                                               <input type="text" class="form-control">
                                     </div>
                                      <div class="col-lg-6 col-md-6 col-sm-12">
                                               <label class="col-form-label font-weight-bolder pt-0">Email Id<span class="text-danger">*</span></label>
                                              <input type="email" class="form-control">
                                     </div>
                                    
                                     </div>
                                       </div>
                                  </div>
                                        
                                      
                                       
                                            
                                             
                                       
                                       
                                    </div>
                                        

                                        
                                       <div class="row mt-3">
                                        <div class="col-sm-12 text-center">
                                            <%--<a href="javascript:void(0);" class="btn btn-success btn-md ml-0">Submit</a>--%>
                                            <a  class="btn btn-dark btn-md ml-0 waves-effect waves-light btnPrevious">Previous</a>
                                            <a class="btn btn-danger btn-md ml-0 waves-effect waves-light">Reset</a>
                                            <a  class="btn btn-success btn-md ml-0 waves-effect waves-light btnNext">Submit</a> 
                                        </div>
                                     </div>
                                    
                                  </div>
                                  <div class="tab-pane fade" id="third" role="tabpanel" aria-labelledby="third-tab">

                                  <h5 class="text-brown font-weight-bold">Emp Current Posting Details</h5>
                                  
                                        <div class="form-group row">
                                            <div class="col-sm-3">
                                               <label class="col-form-label font-weight-bolder">Current Posting Department<span class="text-danger">*</span></label>
                                                <select class="form-control form-control-sm searchableselect">
                                                          <option>select</option>
                                                    <option>DGM</option>
                                                    <option>DD</option>
                                                      </select>
                                            </div>
                                            <div class="col-sm-3">
                                                 <label  class="col-form-label font-weight-bolder">Current Posting District<span class="text-danger">*</span></label>
                                                  <select class="form-control form-control-sm searchableselect">
                                                          <option>select</option>
                                                      <option>Raipur</option>
                                                      </select>
                                            </div>
                                             <div class="col-sm-3">
                                                <label class="col-form-label font-weight-bolder">Office Level<span class="text-danger">*</span></label>
                                                <select class="form-control form-control-sm searchableselect">
                                                          <option>select</option>
                                                    <option>District Office	</option>
                                                      </select>
                                            </div>
                                            <div class="col-sm-3">
                                                <label  class="col-form-label font-weight-bolder">Current Posting Office<span class="text-danger">*</span></label>
                                                <input type="number" class="form-control">
                                            </div>
                                       </div>

                                        <div class="form-group row">
                                            <div class="col-sm-3">
                                                 <label for="inputLoginId" class="col-form-label font-weight-bolder">Date Of Joining<span class="text-danger">*</span></label>
                                                 <div class="input-group">
                                                      <input type="text" class="form-control datepicker" id="Date2">
                                                      <div class="input-group-prepend">
                                                        <label class="input-group-text" for="Date2"><i class="far fa-calendar"></i></label>
                                                      </div>
                                                 </div>
                                            </div>
                                            <div class="col-sm-3">
                                                 <label for="inputLoginId" class="col-form-label font-weight-bolder">Date of Retirement<span class="text-danger">*</span></label>
                                                 <div class="input-group">
                                                      <input type="text" class="form-control datepicker" id="Date3">
                                                      <div class="input-group-prepend">
                                                        <label class="input-group-text" for="Date3"><i class="far fa-calendar"></i></label>
                                                      </div>
                                                 </div>
                                            </div>
                                            <div class="col-sm-3">
                                                 <label for="inputLoginId" class="col-form-label font-weight-bolder">Establishment office<span class="text-danger">*</span></label>
                                                  <select class="form-control form-control-sm searchableselect">
                                                          <option>select</option>
                                                      <option>Mr ABC</option>
                                                      </select>
                                            </div>
                                            <div class="col-sm-3">
                                                 <label for="inputLoginId" class="col-form-label font-weight-bolder">Mode of Recruitment<span class="text-danger">*</span></label>
                                                  <select class="form-control form-control-sm searchableselect">
                                                          <option>select</option>
                                                      <option>Direct</option>
                                                      <option>Promotion</option>
                                                      <option>Contract</option>
                                                      <option>On deputation</option>
                                                      </select>
                                            </div>
                                       </div>

                                       <div class="form-group row">
                                            <div class="col-sm-3">
                                                 <label for="inputLoginId" class="col-form-label font-weight-bolder">Pay Band<span class="text-danger">*</span></label>
                                                 <input type="number" class="form-control">
                                            </div>
                                            <div class="col-sm-3">
                                                 <label for="inputLoginId" class="col-form-label font-weight-bolder">Current Basic Pay<span class="text-danger">*</span></label>
                                                 <input type="number" class="form-control">
                                            </div>
                                            <div class="col-sm-3">
                                                 <label for="inputLoginId" class="col-form-label font-weight-bolder">Current Grade Pay<span class="text-danger">*</span></label>
                                                 <input type="number" class="form-control">
                                            </div>
                                           
                                       </div>

                                       <div class="row mt-3">
                                        <div class="col-sm-12 text-center">
                                           
                                            <a  class="btn btn-dark btn-md ml-0 waves-effect waves-light btnPrevious">Previous</a>
                                            <a class="btn btn-danger btn-md ml-0 waves-effect waves-light">Reset</a>
                                             <a href="ViewEmpPersonalDetails.aspx" class="btn btn-success btn-md ml-0">Submit</a>
                                            <%--<a  class="btn btn-primary btn-md ml-0 waves-effect waves-light btnNext">Next</a> --%>
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
    <link rel="stylesheet"href="../css/searchable-select.min.css">
    <script src="../js/searchable-select.min.js"></script>
     <link href="../css/bootstrap-datetimepicker.min.css" rel="stylesheet">
    <script src="../js/moment.min.js"></script> 
    <script src="../js/bootstrap-datetimepicker.min.js"></script>






    <script>
        indicateMe = "yes"

        $(document).ready(function () {
            loadNavigation('EmpPersonalDetails', 'glempprofile', 'plemperinf', 'tl', 'Employee Profile', 'Emp Personal Details', ' ');
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






