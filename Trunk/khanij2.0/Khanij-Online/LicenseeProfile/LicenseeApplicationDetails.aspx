<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LicenseeApplicationDetails.aspx.cs" Inherits="LicenseeProfile_LicenseeApplicationDetails" %>
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
                                         Licensee Profile
                                        </a>
                                    </li>
                                </ul>
                                <uc1:util runat="server" ID="util" />
                            </div>

                            <section class="box form-container">
                                <div class="content-body">

                                <ul class="nav nav-tabs progressbar border-0" id="myTab" role="tablist">
                                  <li  class="startstep activestep1">
                                    <a class="active" id="Licensee-tab" data-toggle="tab" href="#Licensee" role="tab" aria-controls="Licensee" aria-selected="true">Licensee Information</a>
                                  </li>
                                  <li >
                                    <a id="Attachments-tab" data-toggle="tab" href="#Attachments" role="tab" aria-controls="Attachments" aria-selected="false">Attachments</a>
                                  </li>
                                  <li >
                                    <a  id="Fees-tab" data-toggle="tab" href="#Fees" role="tab" aria-controls="Fees" aria-selected="false">Fees Details</a>
                                  </li>
                                   <li >
                                    <a  id="Renewal-tab" data-toggle="tab" href="#Renewal" role="tab" aria-controls="Renewal" aria-selected="false">Renewal Case</a>
                                  </li>
                                   <li >
                                    <a  id="Transfer-tab" data-toggle="tab" href="#Transfer" role="tab" aria-controls="Transfer" aria-selected="false">Transfer Case</a>
                                  </li>
                                </ul>
                                <div class="tab-content" id="myTabContent">
                                  <div class="tab-pane fade show active" id="Licensee" role="tabpanel" aria-labelledby="Licensee-tab">
                                   <h5 class="text-brown font-weight-bold">Licensee Information</h5> 
                                        <div class="row">
                                            <div class="col-lg-4 col-md-6 col-sm-12 form-group">
                                               <label class="col-form-label font-weight-bolder">Mineral Category<span class="text-danger">*</span></label>
                                               <input type="text" class="form-control">
                                            </div>
                                            <div class="col-lg-4 col-md-6 col-sm-12 form-group">
                                                 <label  class="col-form-label font-weight-bolder">Minerals Deal With<span class="text-danger">*</span></label>
                                                  <input type="text" class="form-control">
                                            </div>
                                             <div class="col-lg-4 col-md-6 col-sm-12 form-group">
                                                <label class="col-form-label font-weight-bolder">Mineral Form<span class="text-danger">*</span></label>
                                                <input type="text" class="form-control">
                                            </div>
                                      
                                            <div class="col-lg-4 col-md-6 col-sm-12 form-group">
                                                <label  class="col-form-label font-weight-bolder">Mineral Grade <span class="text-danger">*</span></label>
                                                <input type="text" class="form-control">
                                            </div>
                                            <div class="col-lg-4 col-md-6 col-sm-12 form-group">
                                                 <label for="inputLoginId" class="col-form-label font-weight-bolder">License Capacity  <span class="text-danger">*</span></label>
                                                 <input type="text" class="form-control">
                                            </div>
                                             <div class="col-lg-4 col-md-6 col-sm-12 form-group">
                                                <label for="inputLoginId" class="col-form-label font-weight-bolder">License Capacity Unit<span class="text-danger">*</span></label>
                                                <select class="form-control">
                                                    <option value="Select">Select</option>
                                                </select>
                                            </div>
                                      
                                            <div class="col-lg-4 col-md-6 col-sm-12 form-group">
                                                <label  class="col-form-label font-weight-bolder">Application Form Number<span class="text-danger">*</span></label>
                                                <input type="text" class="form-control">
                                            </div>
                                            <div class="col-lg-4 col-md-6 col-sm-12 form-group">
                                                 <label class="col-form-label font-weight-bolder">Application Form Copy<span class="text-danger">*</span></label>
                                                 <div class="custom-file">
                                                    <input type="file" class="custom-file-input" id="File1" name="filename">
                                                    <label class="custom-file-label" for="customFile">Choose Files</label>
                                                </div>
                                            </div>
                                             <div class="col-lg-4 col-md-6 col-sm-12 form-group">
                                                <label for="inputLoginId" class="col-form-label font-weight-bolder">PAN Card Number<span class="text-danger">*</span></label>
                                                <input type="text" class="form-control">
                                            </div>
                                      
                                            <div class="col-lg-4 col-md-6 col-sm-12 form-group">
                                                <label class="col-form-label font-weight-bolder">PAN Card Copy<span class="text-danger">*</span></label>
                                                 <div class="custom-file">
                                                    <input type="file" class="custom-file-input" id="File2" name="filename">
                                                    <label class="custom-file-label" for="customFile">Choose Files</label>
                                                </div>
                                            </div>
                                            <div class="col-lg-4 col-md-6 col-sm-12 form-group">
                                                <label class="col-form-label font-weight-bolder">Aadhaar Card Number<span class="text-danger">*</span></label>
                                                <input type="text" class="form-control">
                                            </div>
                                            <div class="col-lg-4 col-md-6 col-sm-12 form-group">
                                                <label class="col-form-label font-weight-bolder">Aadhaar Card Copy<span class="text-danger">*</span></label>
                                                 <div class="custom-file">
                                                    <input type="file" class="custom-file-input" id="File3" name="filename">
                                                    <label class="custom-file-label" for="customFile">Choose Files</label>
                                                </div>
                                            </div>
                                       
                                            <div class="col-lg-4 col-md-6 col-sm-12 form-group">
                                                <label class="col-form-label font-weight-bolder">TIN Card Number<span class="text-danger">*</span></label>
                                                 <input type="text" class="form-control">
                                            </div>
                                            <div class="col-lg-4 col-md-6 col-sm-12 form-group">
                                                <label class="col-form-label font-weight-bolder">TIN Card Copy<span class="text-danger">*</span></label>
                                                <div class="custom-file">
                                                    <input type="file" class="custom-file-input" id="File18" name="filename">
                                                    <label class="custom-file-label" for="customFile">Choose Files</label>
                                                </div>
                                            </div>
                                            <div class="col-lg-4 col-md-6 col-sm-12 form-group">
                                                <label class="col-form-label font-weight-bolder">Firm Registration Deed Number<span class="text-danger">*</span></label>
                                                 <input type="text" class="form-control">
                                            </div>
                                      
                                            <div class="col-lg-4 col-md-6 col-sm-12 form-group">
                                                <label class="col-form-label font-weight-bolder">Firm Registration Deed Copy<span class="text-danger">*</span></label>
                                                 <div class="custom-file">
                                                    <input type="file" class="custom-file-input" id="File6" name="filename">
                                                    <label class="custom-file-label" for="customFile">Choose Files</label>
                                                </div>
                                            </div>
                                            <div class="col-lg-4 col-md-6 col-sm-12 form-group">
                                                <label class="col-form-label font-weight-bolder">Certificate Of Incorporation Number<span class="text-danger">*</span></label>
                                                <input type="text" class="form-control">
                                            </div>
                                            <div class="col-lg-4 col-md-6 col-sm-12 form-group">
                                                <label class="col-form-label font-weight-bolder">Certificate Of Incorporation Copy<span class="text-danger">*</span></label>
                                                <div class="custom-file">
                                                    <input type="file" class="custom-file-input" id="File20" name="filename">
                                                    <label class="custom-file-label" for="customFile">Choose Files</label>
                                                </div>
                                            </div>
                                       
                                            <div class="col-lg-4 col-md-6 col-sm-12 form-group">
                                                <label class="col-form-label font-weight-bolder">License Type<span class="text-danger">*</span></label>
                                                 <select class="form-control">
                                                    <option value="Select">Select</option>
                                                </select>
                                            </div>
                                       </div>
                                       <div class="row mt-3">
                                        <div class="col-sm-12 text-center">
                                            <a class="btn btn-danger btn-md ml-0 waves-effect waves-light">Reset</a>
                                            <a class="btn btn-primary btn-md ml-0 waves-effect waves-light btnNext">Next</a>
                                        </div>
                                     </div>
                                      
                                  </div>
                                  <div class="tab-pane fade" id="Attachments" role="tabpanel" aria-labelledby="Attachments-tab">
                                   <h5 class="text-brown font-weight-bold">Attachments</h5> 
                                        <div class="row">
                                            <div class="col-lg-4 col-md-6 col-sm-12 form-group">
                                               <label class="col-form-label font-weight-bolder">Power of Atorny<span class="text-danger">*</span></label>
                                                <div class="custom-file">
                                                    <input type="file" class="custom-file-input" id="File13" name="filename">
                                                    <label class="custom-file-label" for="customFile">Choose Files</label>
                                                </div>
                                            </div>
                                            <div class="col-lg-4 col-md-6 col-sm-12 form-group">
                                                 <label  class="col-form-label font-weight-bolder">Affidavits/Mining Due Certificate<span class="text-danger">*</span></label>
                                                  <div class="custom-file">
                                                    <input type="file" class="custom-file-input" id="File12" name="filename">
                                                    <label class="custom-file-label" for="customFile">Choose Files</label>
                                                </div>
                                            </div>
                                             <div class="col-lg-4 col-md-6 col-sm-12 form-group">
                                                <label class="col-form-label font-weight-bolder">Khasara Panchsala<span class="text-danger">*</span></label>
                                                <div class="custom-file">
                                                    <input type="file" class="custom-file-input" id="File4" name="filename">
                                                    <label class="custom-file-label" for="customFile">Choose Files</label>
                                                </div>
                                            </div>
                                       
                                            <div class="col-lg-4 col-md-6 col-sm-12 form-group">
                                                <label  class="col-form-label font-weight-bolder">Map/Plan of applied area <span class="text-danger">*</span></label>
                                                <div class="custom-file">
                                                    <input type="file" class="custom-file-input" id="File11" name="filename">
                                                    <label class="custom-file-label" for="customFile">Choose Files</label>
                                                </div>
                                            </div>
                                            <div class="col-lg-4 col-md-6 col-sm-12 form-group">
                                                 <label for="inputLoginId" class="col-form-label font-weight-bolder">Forest Report <span class="text-danger">*</span></label>
                                                 <div class="custom-file">
                                                    <input type="file" class="custom-file-input" id="File10" name="filename">
                                                    <label class="custom-file-label" for="customFile">Choose Files</label>
                                                </div>
                                            </div>
                                             <div class="col-lg-4 col-md-6 col-sm-12 form-group">
                                                <label for="inputLoginId" class="col-form-label font-weight-bolder">Revenue Officer Report<span class="text-danger">*</span></label>
                                                <div class="custom-file">
                                                    <input type="file" class="custom-file-input" id="File9" name="filename">
                                                    <label class="custom-file-label" for="customFile">Choose Files</label>
                                                </div>
                                            </div>
                                       
                                            <div class="col-lg-4 col-md-6 col-sm-12 form-group">
                                                <label  class="col-form-label font-weight-bolder">Spot Inspection and Analysis Report<span class="text-danger">*</span></label>
                                                <div class="custom-file">
                                                    <input type="file" class="custom-file-input" id="File8" name="filename">
                                                    <label class="custom-file-label" for="customFile">Choose Files</label>
                                                </div>
                                            </div>
                                            <div class="col-lg-4 col-md-6 col-sm-12 form-group">
                                                 <label class="col-form-label font-weight-bolder">Mining Inspector Report<span class="text-danger">*</span></label>
                                                 <div class="custom-file">
                                                    <input type="file" class="custom-file-input" id="File5" name="filename">
                                                    <label class="custom-file-label" for="customFile">Choose Files</label>
                                                </div>
                                            </div>
                                             <div class="col-lg-4 col-md-6 col-sm-12 form-group">
                                                <label for="inputLoginId" class="col-form-label font-weight-bolder">Gram Panchayat Proposal<span class="text-danger">*</span></label>
                                                <div class="custom-file">
                                                    <input type="file" class="custom-file-input" id="File7" name="filename">
                                                    <label class="custom-file-label" for="customFile">Choose Files</label>
                                                </div>
                                            </div>
                                       </div>
                                       <div class="row mt-3">
                                        <div class="col-sm-12 text-center">
                                            
                                            <a  class="btn btn-dark btn-md ml-0 waves-effect waves-light btnPrevious">Previous</a>
                                            <a class="btn btn-danger btn-md ml-0 waves-effect waves-light">Reset</a>
                                            <a  class="btn btn-primary btn-md ml-0 waves-effect waves-light btnNext">Next</a> 
                                        </div>
                                     </div>
                                  </div>
                                  <div class="tab-pane fade" id="Fees" role="tabpanel" aria-labelledby="Fees-tab">
                                  <h5 class="text-brown font-weight-bold">Fees Details</h5> 
                                        <div class="row">
                                            <div class="col-lg-4 col-md-6 col-sm-12 form-group">
                                               <label class="col-form-label font-weight-bolder">Application Fees (Rs.)<span class="text-danger">*</span></label>
                                                <input type="text" class="form-control">
                                            </div>
                                            <div class="col-lg-4 col-md-6 col-sm-12 form-group">
                                                 <label  class="col-form-label font-weight-bolder">Application Fees Date<span class="text-danger">*</span></label>
                                                  <div class="input-group">
                                                      <input type="text" class="form-control datepicker" id="inputDate1">
                                                      <div class="input-group-prepend">
                                                        <label class="input-group-text" for="inputDate1"><i class="far fa-calendar"></i></label>
                                                      </div>
                                                 </div>
                                            </div>
                                             <div class="col-lg-4 col-md-6 col-sm-12 form-group">
                                                <label class="col-form-label font-weight-bolder">Application Fees Copy<span class="text-danger">*</span></label>
                                                <div class="custom-file">
                                                    <input type="file" class="custom-file-input" id="File16" name="filename">
                                                    <label class="custom-file-label" for="customFile">Choose Files</label>
                                                </div>
                                            </div>
                                       
                                            <div class="col-lg-4 col-md-6 col-sm-12 form-group">
                                                <label  class="col-form-label font-weight-bolder">Security Deposit Challan/DD Amount (Rs.) <span class="text-danger">*</span></label>
                                                <input type="text" class="form-control">
                                            </div>
                                            <div class="col-lg-4 col-md-6 col-sm-12 form-group">
                                                 <label for="inputLoginId" class="col-form-label font-weight-bolder">Security Deposit Challan/DD Date <span class="text-danger">*</span></label>
                                                 <div class="input-group">
                                                      <input type="text" class="form-control datepicker" id="Text1">
                                                      <div class="input-group-prepend">
                                                        <label class="input-group-text" for="inputDate1"><i class="far fa-calendar"></i></label>
                                                      </div>
                                                 </div>
                                            </div>
                                             <div class="col-lg-4 col-md-6 col-sm-12 form-group">
                                                <label for="inputLoginId" class="col-form-label font-weight-bolder">Security Deposit Challan/DD Copy<span class="text-danger">*</span></label>
                                                <div class="custom-file">
                                                    <input type="file" class="custom-file-input" id="File19" name="filename">
                                                    <label class="custom-file-label" for="customFile">Choose Files</label>
                                                </div>
                                            </div>
                                      
                                            <div class="col-lg-4 col-md-6 col-sm-12 form-group">
                                                <label  class="col-form-label font-weight-bolder">Bank Guarrantee Amount (Rs.)<span class="text-danger">*</span></label>
                                                <input type="text" class="form-control">
                                            </div>
                                            <div class="col-lg-4 col-md-6 col-sm-12 form-group">
                                                 <label class="col-form-label font-weight-bolder">Bank Guarranty Date<span class="text-danger">*</span></label>
                                                 <div class="input-group">
                                                      <input type="text" class="form-control datepicker" id="Text2">
                                                      <div class="input-group-prepend">
                                                        <label class="input-group-text" for="inputDate1"><i class="far fa-calendar"></i></label>
                                                      </div>
                                                 </div>
                                            </div>
                                             <div class="col-lg-4 col-md-6 col-sm-12 form-group">
                                                <label for="inputLoginId" class="col-form-label font-weight-bolder">Bank Guarranty Copy<span class="text-danger">*</span></label>
                                                <div class="custom-file">
                                                    <input type="file" class="custom-file-input" id="File22" name="filename">
                                                    <label class="custom-file-label" for="customFile">Choose Files</label>
                                                </div>
                                            </div>
                                      
                                            <div class="col-lg-4 col-md-6 col-sm-12 form-group">
                                                <label  class="col-form-label font-weight-bolder">Surety Bond Amount (Rs.)<span class="text-danger">*</span></label>
                                                <input type="text" class="form-control">
                                            </div>
                                            <div class="col-lg-4 col-md-6 col-sm-12 form-group">
                                                 <label class="col-form-label font-weight-bolder">Surety Bond Date<span class="text-danger">*</span></label>
                                                 <div class="input-group">
                                                      <input type="text" class="form-control datepicker" id="Text3">
                                                      <div class="input-group-prepend">
                                                        <label class="input-group-text" for="inputDate1"><i class="far fa-calendar"></i></label>
                                                      </div>
                                                 </div>
                                            </div>
                                             <div class="col-lg-4 col-md-6 col-sm-12 form-group">
                                                <label for="inputLoginId" class="col-form-label font-weight-bolder">Surety Bond Copy<span class="text-danger">*</span></label>
                                                <div class="custom-file">
                                                    <input type="file" class="custom-file-input" id="File25" name="filename">
                                                    <label class="custom-file-label" for="customFile">Choose Files</label>
                                                </div>
                                            </div>
                                    
                                            <div class="col-lg-4 col-md-6 col-sm-12 form-group">
                                                <label  class="col-form-label font-weight-bolder">Fixed Deposits Monthly Income Scheme Certificate<span class="text-danger">*</span></label>
                                                <div class="custom-file">
                                                    <input type="file" class="custom-file-input" id="File26" name="filename">
                                                    <label class="custom-file-label" for="customFile">Choose Files</label>
                                                </div>
                                            </div>
                                            
                                       </div>
                                        <div class="row mt-3">
                                        <div class="col-sm-12 text-center">
                                            
                                            <a  class="btn btn-dark btn-md ml-0 waves-effect waves-light btnPrevious">Previous</a>
                                            <a class="btn btn-danger btn-md ml-0 waves-effect waves-light">Reset</a>
                                            <a  class="btn btn-primary btn-md ml-0 waves-effect waves-light btnNext">Next</a> 
                                        </div>
                                     </div>
                                      
                                  </div>
                                  <div class="tab-pane fade" id="Renewal" role="tabpanel" aria-labelledby="Renewal-tab">
                                   <h5 class="text-brown font-weight-bold">Renewal Case</h5> 
                                        <div class="row">
                                            <div class="col-lg-4 col-md-6 col-sm-12 form-group">
                                               <label class="col-form-label font-weight-bolder">Date Of Renewal<span class="text-danger">*</span></label>
                                                <div class="input-group">
                                                      <input type="text" class="form-control datepicker" id="Text7">
                                                      <div class="input-group-prepend">
                                                        <label class="input-group-text" for="inputDate1"><i class="far fa-calendar"></i></label>
                                                      </div>
                                                 </div>
                                            </div>
                                            <div class="col-lg-4 col-md-6 col-sm-12 form-group">
                                                 <label  class="col-form-label font-weight-bolder">Renewal Grant Order Copy<span class="text-danger">*</span></label>
                                                  <div class="custom-file">
                                                    <input type="file" class="custom-file-input" id="File15" name="filename">
                                                    <label class="custom-file-label" for="customFile">Choose Files</label>
                                                </div>
                                            </div>
                                             <div class="col-lg-4 col-md-6 col-sm-12 form-group">
                                                <label class="col-form-label font-weight-bolder">Period Of Renewal From<span class="text-danger">*</span></label>
                                                <div class="input-group">
                                                      <input type="text" class="form-control datepicker" id="Text8">
                                                      <div class="input-group-prepend">
                                                        <label class="input-group-text" for="inputDate1"><i class="far fa-calendar"></i></label>
                                                      </div>
                                                 </div>
                                            </div>
                                       
                                            <div class="col-lg-4 col-md-6 col-sm-12 form-group">
                                                <label  class="col-form-label font-weight-bolder">Period Of Renewal To <span class="text-danger">*</span></label>
                                                <div class="input-group">
                                                      <input type="text" class="form-control datepicker" id="Text6">
                                                      <div class="input-group-prepend">
                                                        <label class="input-group-text" for="inputDate1"><i class="far fa-calendar"></i></label>
                                                      </div>
                                                 </div>
                                            </div>
                                           
                                            
                                       </div>
                                       <div class="row mt-3">
                                        <div class="col-sm-12 text-center">
                                            
                                            <a  class="btn btn-dark btn-md ml-0 waves-effect waves-light btnPrevious">Previous</a>
                                            <a class="btn btn-danger btn-md ml-0 waves-effect waves-light">Reset</a>
                                            <a  class="btn btn-primary btn-md ml-0 waves-effect waves-light btnNext">Next</a> 
                                        </div>
                                     </div>
                                  </div>
                                  <div class="tab-pane fade" id="Transfer" role="tabpanel" aria-labelledby="Transfer-tab">
                                  <h5 class="text-brown font-weight-bold">Transfer Case</h5> 
                                        <div class="row">
                                            <div class="col-lg-4 col-md-6 col-sm-12 form-group">
                                               <label class="col-form-label font-weight-bolder">Name Of Transferee<span class="text-danger">*</span></label>
                                                <input type="text" class="form-control">
                                            </div>
                                            <div class="col-lg-4 col-md-6 col-sm-12 form-group">
                                                 <label  class="col-form-label font-weight-bolder">Address Of Transferee<span class="text-danger">*</span></label>
                                                  <input type="text" class="form-control">
                                            </div>
                                             <div class="col-lg-4 col-md-6 col-sm-12 form-group">
                                                <label class="col-form-label font-weight-bolder">Transfer Grant Order Copy<span class="text-danger">*</span></label>
                                                <div class="custom-file">
                                                    <input type="file" class="custom-file-input" id="File14" name="filename">
                                                    <label class="custom-file-label" for="customFile">Choose Files</label>
                                                </div>
                                            </div>
                                     
                                            <div class="col-lg-4 col-md-6 col-sm-12 form-group">
                                                <label  class="col-form-label font-weight-bolder">Transfer Lease Deed Copy <span class="text-danger">*</span></label>
                                                <div class="custom-file">
                                                    <input type="file" class="custom-file-input" id="File17" name="filename">
                                                    <label class="custom-file-label" for="customFile">Choose Files</label>
                                                </div>
                                            </div>
                                            <div class="col-lg-4 col-md-6 col-sm-12 form-group">
                                                 <label for="inputLoginId" class="col-form-label font-weight-bolder">Date Of Transfer<span class="text-danger">*</span></label>
                                                 <div class="input-group">
                                                      <input type="text" class="form-control datepicker" id="Text5">
                                                      <div class="input-group-prepend">
                                                        <label class="input-group-text" for="inputDate1"><i class="far fa-calendar"></i></label>
                                                      </div>
                                                 </div>
                                            </div>
                                             <div class="col-lg-4 col-md-6 col-sm-12 form-group">
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
            loadNavigation('LicenseeApplicationDetails', 'glRoleRes', 'pllicenprof', 'tl', 'Roles and Responsibity', 'Licensee Profile', ' ');
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


