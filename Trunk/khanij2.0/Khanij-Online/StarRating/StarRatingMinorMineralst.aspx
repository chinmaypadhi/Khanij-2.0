<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StarRatingMinorMineralst.aspx.cs" Inherits="StarRating_StarRatingMinorMineralst" %>
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
                                          Star Rating Minor Minerals
                                        </a>
                                    </li>
                                </ul>
                                <uc1:util runat="server" ID="util" />
                            </div>

                            <section class="box form-container">
                                <div class="content-body star-rating">
                                <ul class="nav nav-tabs progressbar border-0" id="myTab" role="tablist">
                                  <li class="startstep activestep1">
                                    <a class="active" id="general-tab" data-toggle="tab" href="#general" role="tab" aria-controls="home" aria-selected="true">General Information</a>
                                  </li>
                                  <li>
                                    <a  id="sustainable-tab" data-toggle="tab" href="#sustainable" role="tab" aria-controls="profile" aria-selected="false">Sustainable information</a>
                                  </li>
                                  <li>
                                    <a  id="contact-tab" data-toggle="tab" href="#Confirmation" role="tab" aria-controls="contact" aria-selected="false">Confirmation</a>
                                  </li>
                                </ul>
                                <div class="tab-content" id="myTabContent">
                                  <div class="tab-pane fade show active" id="general" role="tabpanel" aria-labelledby="generale-tab">
                                        <div class="mb-md-4">
                                        <h5 class="text-brown font-weight-bold">Lease Details</h5>
                                        <div class="form-group row">
                                            <div class="col-lg-4 col-md-6 col-sm-12">
                                                <label class="col-form-label font-weight-bolder pt-0">Unique Lease Id <small>(Allotted by State Government) </small><span class="text-danger">*</span></label>
                                                <input type="text" class="form-control">
                                            </div>
                                            <div class="col-lg-2 col-md-6 col-sm-12">
                                                 <label  class="col-form-label font-weight-bolder pt-0">Reporting Year (RY)  <span class="text-danger">*</span></label>
                                                  <select  class="form-control">
                                                    <option value="Select">Select</option>
                                                </select>
                                            </div>
                                             <div class="col-lg-2 col-md-6 col-sm-12">
                                                <label class="col-form-label font-weight-bolder pt-0">Khasra /Survey No.<span class="text-danger">*</span></label>
                                                <input type="number" class="form-control">
                                            </div>
                                             <div class="col-lg-2 col-md-6 col-sm-12">
                                                <label  class="col-form-label font-weight-bolder pt-0">State <span class="text-danger">*</span></label>
                                               <select  class="form-control">
                                                    <option value="Select">Select</option>
                                                </select>
                                            </div>
                                            <div class="col-lg-2 col-md-6 col-sm-12">
                                                 <label for="inputLoginId" class="col-form-label font-weight-bolder pt-0">District  <span class="text-danger">*</span></label>
                                                <select  class="form-control">
                                                    <option value="Select">Select</option>
                                                </select>
                                            </div>
                                       </div>

                                        <div class="form-group row">
                                             <div class="col-lg-2 col-md-6 col-sm-12">
                                                <label for="inputLoginId" class="col-form-label font-weight-bolder">Tehsil<span class="text-danger">*</span></label>
                                                <select  class="form-control">
                                                    <option value="Select">Select</option>
                                                </select>
                                            </div>
                                            <div class="col-lg-2 col-md-6 col-sm-12">
                                                <label  class="col-form-label font-weight-bolder">Village<span class="text-danger">*</span></label>
                                                <select  class="form-control">
                                                    <option value="Select">Select</option>
                                                </select>
                                            </div>
                                            <div class="col-lg-2 col-md-6 col-sm-12">
                                                 <label class="col-form-label font-weight-bolder">Lease Period (From)<span class="text-danger">*</span></label>
                                                 <div class="input-group">
                                                      <input type="text" class="form-control datepicker" id="inputDate1">
                                                      <div class="input-group-prepend">
                                                        <label class="input-group-text" for="inputDate1"><i class="far fa-calendar"></i></label>
                                                      </div>
                                                 </div>
                                            </div>
                                             <div class="col-lg-2 col-md-6 col-sm-12">
                                                <label for="inputLoginId" class="col-form-label font-weight-bolder">Lease Period (To)<span class="text-danger">*</span></label>
                                                <div class="input-group">
                                                      <input type="text" class="form-control datepicker" id="inputDate2">
                                                      <div class="input-group-prepend">
                                                        <label class="input-group-text" for="inputDate2"><i class="far fa-calendar"></i></label>
                                                      </div>
                                                 </div>
                                            </div>
                                             <div class="col-lg-4 col-md-6 col-sm-12">
                                                <label class="col-form-label font-weight-bolder">Minerals<span class="text-danger">*</span></label>
                                                <select  class="form-control">
                                                    <option value="Select">Select</option>
                                                </select>
                                            </div>
                                       </div>

                                       
                                       

                                        <div class="row mt-md-4">
                                         <div class="col-lg-6 col-md-12 col-sm-12">
                                                <div class="table-responsive">
                                              <table class="table table-sm border" id="insert">
                                              <thead>
                                               <tr>
                                                   <th class="font-weight-bolder">
                                                       Total Resource Available Lease Area <small>(Mineral Wise tones)</small>
                                                       <span class="text-danger">*</span>
                                                   </th>
                                                   <th></th> 
                                                   <th width="130px" class="font-weight-bolder">Actions</th>
                                               </tr>
                                            </thead>
                                            <tbody>
                                                <tr>
                                                    <td id="t1">
                                                        <select  class="form-control">
                                                    <option value="Select">Select</option>
                                                </select>
                                                    </td>

                                                    <td id="t2">
                                                       <input type="text" class="form-control">
                                                    </td>
                               
                                                    <td>
                                                         <a href="#" class="btn btn-success btn-md add-btn" data-toggle="tooltip" data-placement="top" title="Add Row"><i class="fa fa-plus" aria-hidden="true"></i></a>
                                                    </td>

                                                </tr>
                                            </tbody>
                                        </table>  
                                        </div>
                                        </div>

                                         <div class="col-lg-6 col-md-12 col-sm-12">
                                                <div class="table-responsive">
                                              <table class="table table-sm border">
                                              <thead>
                                               <tr>
                                                   <th class="font-weight-bolder">
                                                       Lease Boundary Coordinates <small>(Latitudes & Longitudes)</small>
                                                       <span class="text-danger">*</span>
                                                   </th>
                                                   <th></th> 
                                                   <th width="100px" class="font-weight-bolder">Actions</th>
                                               </tr>
                                            </thead>
                                            <tbody>
                                                <tr>
                                                    <td>
                                                         <input type="text" class="form-control" placeholder="Latitudes">
                                                    </td>

                                                    <td>
                                                       <input type="text" class="form-control" placeholder="Longitudes">
                                                    </td>
                               
                                                    <td>
                                                         <a href="#" class="btn btn-success btn-md" data-toggle="tooltip" data-placement="top" title="Add Row"><i class="fa fa-plus" aria-hidden="true"></i></a>
                                                    </td>

                                                </tr>
                                            </tbody>
                                        </table>  
                                        </div>
                                        </div>

                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                                <div class="table-responsive">
                                              <table class="table table-sm border mb-0">
                                              <thead>
                                               <tr>
                                                   <th class="font-weight-bolder">
                                                       
                                                        Total Lease Area <small>(in hectare)</small>
                                                       <span class="text-danger">*</span>
                                                   </th>
                                                   <th></th> 
                                                   <th width="130px" class="font-weight-bolder">Actions</th>
                                               </tr>
                                            </thead>
                                            <tbody>
                                                <tr>
                                                    <td>
                                                        <select  class="form-control">
                                                    <option value="Select">Select</option>
                                                </select>
                                                    </td>

                                                    <td>
                                                       <input type="text" class="form-control">
                                                    </td>
                               
                                                    <td>
                                                         <a href="#" class="btn btn-success btn-md" data-toggle="tooltip" data-placement="top" title="Add Row">
                                                         <i class="fa fa-plus" aria-hidden="true"></i></a>
                                                    </td>

                                                </tr>
                                            </tbody>
                                        </table>  
                                        </div>
                                        </div>
                                        </div>

                                        
                                        </div>

                                        <div class="mb-md-4">
                                            <h5 class="text-brown font-weight-bold">Lessee Details</h5>
                                            <div class="form-group row">
                                            <div class="col-lg-4 col-md-6 col-sm-12">
                                                <label class="col-form-label font-weight-bolder pt-0">Type of Lessee<span class="text-danger">*</span></label>
                                                <select  class="form-control">
                                                    <option value="Select">Select</option>
                                                </select>
                                            </div>
                                             <div class="col-lg-4 col-md-6 col-sm-12">
                                               <label class="col-form-label font-weight-bolder pt-0">Name of Person/Company/Partnership firm<span class="text-danger">*</span></label>
                                               <input type="text" class="form-control">
                                            </div>
                                             <div class="col-lg-4 col-md-12 col-sm-12">
                                             <label class="col-form-label font-weight-bolder pt-0">Name of Managing Director / Managing Partner<span class="text-danger">*</span></label>
                                              <input type="text" class="form-control">
                                            </div>
                                       </div>

                                            <div class=" row">
                                            <div class="col-lg-2 col-md-6 col-sm-12">
                                                <label class="col-form-label font-weight-bolder">Mobile Number <span class="text-danger">*</span></label>
                                                <input type="number" class="form-control">
                                            </div>
                                             <div class="col-lg-2 col-md-6 col-sm-12">
                                               <label class="col-form-label font-weight-bolder">Email Id<span class="text-danger">*</span></label>
                                               <input type="text" class="form-control">
                                            </div>
                                             <div class="col-lg-8 col-md-6 col-sm-12">
                                             <label class="col-form-label font-weight-bolder">Address<span class="text-danger">*</span></label>
                                              <textarea class="form-control" rows="1"></textarea>
                                              <small class="text-danger">Maximum <strong>500</strong> characters</small>
                                            </div>
                                       </div>
                                       </div>

                                       <div class="mb-md-4">
                                       <h5 class="text-brown font-weight-bold">Working Details</h5>
                                       <div class="form-group row">
                                            <div class="col-lg-4 col-md-6 col-sm-12">
                                                <label class="col-form-label font-weight-bolder pt-0">Method of Mining<span class="text-danger">*</span></label>
                                                <select  class="form-control">
                                                    <option value="Select">Select</option>
                                                </select>
                                            </div>
                                             <div class="col-lg-4 col-md-12 col-sm-12">
                                               <label class="col-form-label font-weight-bolder pt-0">Status of the lease on date of filing<span class="text-danger">*</span></label>
                                               <select  class="form-control">
                                                    <option value="Select">Select</option>
                                                </select>
                                            </div>
                                             <div class="col-lg-4 col-md-12 col-sm-12">
                                             <label class="col-form-label font-weight-bolder pt-0">No. of working days during Reporting Year<span class="text-danger">*</span></label>
                                              <input type="number" class="form-control">
                                            </div>
                                       </div>

                                       <div class="form-group row">
                                             <div class="col-lg-4 col-md-12 col-sm-12">
                                               <label class="col-form-label font-weight-bolder">No. of days of temporary discontinuance during Reporting Year<span class="text-danger">*</span></label>
                                               <input type="number" class="form-control">
                                            </div>
                                             <div class="col-lg-4 col-md-12 col-sm-12">
                                             <label class="col-form-label font-weight-bolder">No. of days under suspension during Reporting Year <span class="text-danger">*</span></label>
                                              <input type="number" class="form-control">
                                            </div>
                                       </div>

                                       <div class="bg-light p-2  border">
                                         <label class="col-form-label font-weight-bolder pt-0">Name &amp; Contact details of the Agent/Manger
                                        responsible to ensure filing for Star Rating Template 
                                        ( For the purpose owner may nominate himself as a Agent / Manager)</label>

                                            <div class=" row">
                                             <div class="col-sm-3">
                                               <input type="text" class="form-control" placeholder="Name">
                                            </div>
                                             <div class="col-sm-3">
                                              <input type="number" class="form-control" placeholder="Mobile No.">
                                            </div>
                                            <div class="col-sm-3">
                                              <input type="text" class="form-control" placeholder="Email Id">
                                            </div>
                                            <div class="col-sm-3">
                                              <input type="text" class="form-control" placeholder="Address">
                                            </div>
                                       </div>
                                       </div>
                                       </div>


                                       <div class="mb-md-4">
                                       <h5 class="text-brown font-weight-bold">Approvals/Consent obtained from govt. agencies</h5>
                                       <div class="row">
                                        <div class="col-xl-6">
                                        <div class="bg-light p-2 form-group border">
                                        <label class="col-form-label font-weight-bolder pt-0">Details of Approved Quarry Plan by the State Govt.</label>
                                            <div class="row">
                                             <div class="col-sm-4">
                                              <small>Validity from</small>
                                               <div class="input-group">
                                                      <input type="text" class="form-control datepicker" id="inputDate4">
                                                      <div class="input-group-prepend">
                                                        <label class="input-group-text" for="inputDate4"><i class="far fa-calendar"></i></label>
                                                        
                                                      </div>
                                                     
                                                 </div>
                                            </div>
                                             <div class="col-sm-4">
                                             <small>Validity to</small>
                                              <div class="input-group">

                                                      <input type="text" class="form-control datepicker" id="inputDate5">
                                                      <div class="input-group-prepend">
                                                        <label class="input-group-text" for="inputDate5"><i class="far fa-calendar"></i></label>
                                                      </div>
                                                 </div>
                                            </div>
                                            <div class="col-sm-4">
                                            <small>Quantity Approved</small>
                                              <input type="text" class="form-control" />
                                            </div>
                                           
                                       </div>
                                       </div>
                                        </div>
                                        <div class="col-xl-6">
                                        <div class="bg-light p-2 form-group border">
                                        <label class="col-form-label font-weight-bolder pt-0">Details of Environment clearance Obtained</label>

                                            <div class="row">
                                             <div class="col-sm-4">
                                             <small>Validity from</small>
                                               <div class="input-group">
                                                      <input type="text" class="form-control datepicker" id="inputDate6">
                                                      <div class="input-group-prepend">
                                                        <label class="input-group-text" for="inputDate6"><i class="far fa-calendar"></i></label>
                                                      </div>
                                                 </div>
                                            </div>
                                             <div class="col-sm-4">
                                             <small>Validity to</small>
                                              <div class="input-group">
                                                      <input type="text" class="form-control datepicker" id="inputDate7">
                                                      <div class="input-group-prepend">
                                                        <label class="input-group-text" for="inputDate7"><i class="far fa-calendar"></i></label>
                                                      </div>
                                                 </div>
                                            </div>
                                            <div class="col-sm-4">
                                             <small>Quantity Approved</small>
                                              <input type="text" class="form-control" >
                                            </div>
                                           
                                       </div>
                                       </div>
                                        </div>
                                         <div class="col-xl-6">
                                         <div class="bg-light p-2 form-group border">
                                        <label class="col-form-label font-weight-bolder pt-0">Details of SPCB Approvals received</label>

                                            <div class="row">
                                             <div class="col-sm-6">
                                             <small>Validity from</small>
                                               <div class="input-group">
                                                      <input type="text" class="form-control datepicker" id="inputDate8">
                                                      <div class="input-group-prepend">
                                                        <label class="input-group-text" for="inputDate8"><i class="far fa-calendar"></i></label>
                                                      </div>
                                                 </div>
                                            </div>
                                            
                                            <div class="col-sm-6">
                                            <small>Quantity Approved</small>
                                              <input type="text" class="form-control">
                                            </div>
                                           
                                       </div>
                                       </div>
                                         </div>
                                         <div class="col-xl-6">
                                         <div class="bg-light p-2 form-group border">
                                        <label class="col-form-label font-weight-bolder pt-0">Details of Forest Clearance Obtained, If applicable</label>

                                            <div class="row">
                                             <div class="col-sm-6">
                                              <small>Validity from</small>
                                               <div class="input-group">
                                                      <input type="text" class="form-control datepicker" id="inputDate11">
                                                      <div class="input-group-prepend">
                                                        <label class="input-group-text" for="inputDate11"><i class="far fa-calendar"></i></label>
                                                      </div>
                                                 </div>
                                            </div>
                                            
                                           
                                           
                                       </div>
                                       </div>
                                         </div>
                                       </div>
                                       

                                       

                                       

                                       

                                       <div class="bg-light p-2 form-group border">
                                        <label class="col-form-label font-weight-bolder pt-0">Has Obtains All Required NOCs / Certificates/ Permits from Govt. Departments</label>

                                            <div class=" row">
                                             <div class="col-sm-2">
                                               <div class="input-group">
                                                      <select class="form-control">
                                                         <option value="Select">Select DGMS</option>
                                                      </select>
                                                 </div>
                                            </div>
                                             <div class="col-sm-2">
                                               <div class="input-group">
                                                     <select class="form-control">
                                                         <option value="Select">Select Blasting License</option>
                                                      </select>
                                                 </div>
                                            </div>
                                            <div class="col-sm-2">
                                               <div class="input-group">
                                                      <select class="form-control">
                                                         <option value="Select">Select Environment Clearance</option>
                                                      </select>
                                                 </div>
                                            </div>
                                            <div class="col-sm-2">
                                               <select class="form-control">
                                                         <option value="Select">Select Air Consent</option>
                                                      </select>
                                            </div>
                                            <div class="col-sm-2">
                                                      <select class="form-control">
                                                         <option value="Select">Select Water Consent</option>
                                                    </select>
                                            </div>
                                            <div class="col-sm-2">
                                                <div class="custom-file">
                                                    <input type="file" class="custom-file-input" id="customFile" name="filename">
                                                    <label class="custom-file-label" for="customFile">Choose Files</label>
                                                </div>
                                            </div>
                                           
                                       </div>
                                       </div>
                                       </div>

                                       <div class="mb-md-0">
                                       <h5 class="text-brown font-weight-bold">Contribution to govt exchequer during financial (<small><i class="fas fa-rupee-sign ml-1"></i></small>)</h5>
                                       <div class="form-group row">
                                            <div class="col-sm-4">
                                                <label class="col-form-label font-weight-bolder pt-0">Royalty Paid<span class="text-danger">*</span></label>
                                               <input type="text" class="form-control">
                                            </div>
                                             <div class="col-sm-4">
                                               <label class="col-form-label font-weight-bolder pt-0">Dead Rent Paid<span class="text-danger">*</span></label>
                                               <input type="text" class="form-control">
                                            </div>
                                             <div class="col-sm-4">
                                             <label class="col-form-label font-weight-bolder pt-0">Contribution to DMF<span class="text-danger">*</span></label>
                                              <input type="text" class="form-control">
                                            </div>
                                       </div>
                                       </div>
                                       <div class="row mt-3">
                                        <div class="col-sm-12 text-center">
                                            <a class="btn btn-danger btn-md ml-0 waves-effect waves-light">Reset</a>
                                            <a class="btn btn-primary btn-md ml-0 waves-effect waves-light btnNext">Next</a>
                                        </div>
                                     </div>
                                     
                                  </div>
                              <div class="tab-pane fade" id="sustainable" role="tabpanel" aria-labelledby="sustainable-tab">
                                    
                                      <h5 class="text-brown font-weight-bold">Module- I <span class="text-dark">(systamatic And Sustainable Mining)</span></h5>
                                      <div class="module-sec custom-scroll">
                                      <div class="mr-3">
                                       <div class="row">
                                       <div class="col-lg-12">
                                       <div class="bg-light p-2  border mb-4">
                                         <label class="col-form-label font-weight-bolder pt-0">Total Production Mineral wise during Reporting Year (RY)</label>

                                            <div class="form-group row">
                                             <div class="col-sm-3">
                                             <label class="col-form-label pt-0 font-weight-bolder">Approved Quantity (Tonnes)</label>
                                               <input type="text" class="form-control">
                                            </div>
                                             <div class="col-sm-3">
                                             <label class="col-form-label pt-0 font-weight-bolder">Actual (Tonnes)</label>
                                              <input type="text" class="form-control">
                                            </div>
                                            <div class="col-sm-3">
                                            <label class="col-form-label pt-0 font-weight-bolder active">Max Mark</label>
                                              <input type="text" class="form-control" placeholder="Max Mark" readonly>
                                            </div>
                                            <div class="col-sm-3">
                                            <label class="col-form-label pt-0 font-weight-bolder">Lessee Mark</label>
                                              <select class="form-control disable" readonly="readonly">
                                                    <option>Select Lessee Mark</option>
                                                    <option>&gt;= 50% to 100%</option>
                                                    <option>Between 30% &amp; 50%</option>
                                                    <option>&lt;= 30% and &gt; 100%</option>
                                                </select>
                                            </div>
                                             
                                       </div>
                                       <div class="form-group row">
                                             
                                             <div class="col-sm-3">
                                             <label class="col-form-label pt-0 font-weight-bolder">Mining Inspector Mark</label>
                                              <select class="form-control disable" readonly="readonly">
                                                <option selected="selected" value="0">select Mining Inspector Mark</option>
                                                    <option value="5">&gt;= 50% to 100%</option>
                                                    <option value="2">Between 30% &amp; 50%</option>
                                                    <option value="0">&lt;= 30% and &gt; 100%</option>
                                                </select>
                                            </div>
                                            <div class="col-sm-3">
                                            <label class="col-form-label pt-0 font-weight-bolder active">Comment</label>
                                                <textarea  rows="1"  class="form-control" placeholder="Enter remark"></textarea>
                                            </div>
                                            <div class="col-sm-3">
                                            <label class="col-form-label pt-0 font-weight-bolder">DD/MO Mark</label>
                                              <select class="form-control disable" readonly="readonly">
                                                        <option>Select DD/MO Mark</option>
                                                        <option value="5">&gt;= 50% to 100%</option>
                                                        <option value="2">Between 30% &amp; 50%</option>
                                                        <option>&lt;= 30% and &gt; 100%</option>
                                                    </select>
                                            </div>
                                            <div class="col-sm-3">
                                            <label class="col-form-label pt-0 font-weight-bolder active">Comment</label>
                                             <textarea  rows="1"  class="form-control" placeholder="Enter remark"></textarea>
                                            </div>
                                            
                                       </div>
                                       <div class="form-group row">
                                             
                                            <div class="col-sm-3">
                                               <label class="col-form-label pt-0 font-weight-bolder">DGM Mark</label>                            
                                            <select class="form-control">

                                            <option>Select DGM Mark</option>
                                            <option>&gt;= 50% to 100%</option>
                                            <option>Between 30% &amp; 50%</option>
                                            <option>&lt;= 30% and &gt; 100%</option>
                                        </select>

                                            </div>
                                            <div class="col-sm-3">
                                            <label class="col-form-label pt-0 font-weight-bolder active">Comment</label>
                                              <textarea  rows="1"  class="form-control" placeholder="Enter remark"></textarea>
                                            </div>
                                            <div class="col-sm-3">
                                            <label class="col-form-label pt-0 font-weight-bolder active">Mark</label>
                                              <input type="text" class="form-control" placeholder="Mark" readonly>
                                            </div>
                                       </div>
                                       </div>
                                       </div>
                                        <div class="col-lg-6">
                                       <div class="bg-light p-2  border mb-4">
                                         <label class="col-form-label font-weight-bolder pt-0 d-block">Reject Dump Management (excluding topsoil)</label>
                                          <label class="col-form-label font-weight-bolder pt-0 ">As per the Approved Quarry Plan</label>

                                            <div class="row">
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Max Mark</label>
                                              <input type="text" class="form-control form-group" placeholder="5" readonly>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Lessee Mark</label>
                                              <select class="form-control disable form-group" readonly="readonly">
                                                    <option>Select Lessee Mark</option>
                                                    <option>&gt;= 50% to 100%</option>
                                                    <option>Between 30% &amp; 50%</option>
                                                    <option>&lt;= 30% and &gt; 100%</option>
                                                </select>
                                            </div>
                                             <div class="col-sm-6">
                                             <label class="col-form-label pt-0 font-weight-bolder">Mining Inspector Mark</label>
                                              <select class="form-control disable form-group" readonly="readonly">
                                                <option selected="selected" value="0">select Mining Inspector Mark</option>
                                                    <option value="5">&gt;= 50% to 100%</option>
                                                    <option value="2">Between 30% &amp; 50%</option>
                                                    <option value="0">&lt;= 30% and &gt; 100%</option>
                                                </select>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Comment</label>
                                                <textarea  rows="1"  class="form-control form-group" placeholder="Enter remark"></textarea>
                                            </div>
                                           
                                            
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">DD/MO Mark</label>
                                              <select class="form-control disable form-group" readonly="readonly">
                                                        <option>Select DD/MO Mark</option>
                                                        <option value="5">&gt;= 50% to 100%</option>
                                                        <option value="2">Between 30% &amp; 50%</option>
                                                        <option>&lt;= 30% and &gt; 100%</option>
                                                    </select>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Comment</label>
                                             <textarea  rows="1"  class="form-control form-group" placeholder="Enter remark"></textarea>
                                            </div>
                                            
                                       
                                             
                                            <div class="col-sm-6">
                                              <label class="col-form-label pt-0 font-weight-bolder">DGM Mark</label>                             
                                            <select class="form-control form-group">
                                            <option>Select DGM Mark</option>
                                            <option>&gt;= 50% to 100%</option>
                                            <option>Between 30% &amp; 50%</option>
                                            <option>&lt;= 30% and &gt; 100%</option>
                                        </select>

                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Comment</label>
                                              <textarea  rows="1"  class="form-control form-group" placeholder="Enter remark"></textarea>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Mark</label>
                                              <input type="text" class="form-control form-group" placeholder="0" readonly>
                                            </div>
                                       </div>
                                       </div>
                                       </div>
                                        <div class="col-lg-6">
                                       <div class="bg-light p-2  border mb-4">
                                         <label class="col-form-label font-weight-bolder pt-0 d-block">Formation of safe and stable benches (open pit) or drives (underground)</label>
                                          <label class="col-form-label font-weight-bolder pt-0 ">As per the Approved Quarry Plan</label>

                                            <div class="row">
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Max Mark</label>
                                              <input type="text" class="form-control form-group" placeholder="5" readonly>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Lessee Mark</label>
                                              <select class="form-control disable form-group" readonly="readonly">
                                                    <option>Select Lessee Mark</option>
                                                    <option>&gt;= 50% to 100%</option>
                                                    <option>Between 30% &amp; 50%</option>
                                                    <option>&lt;= 30% and &gt; 100%</option>
                                                </select>
                                            </div>
                                             <div class="col-sm-6">
                                             <label class="col-form-label pt-0 font-weight-bolder">Mining Inspector Mark</label>
                                              <select class="form-control disable form-group" readonly="readonly">
                                                <option selected="selected" value="0">select Mining Inspector Mark</option>
                                                    <option value="5">&gt;= 50% to 100%</option>
                                                    <option value="2">Between 30% &amp; 50%</option>
                                                    <option value="0">&lt;= 30% and &gt; 100%</option>
                                                </select>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Comment</label>
                                                <textarea  rows="1"  class="form-control form-group" placeholder="Enter remark"></textarea>
                                            </div>
                                           
                                            
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">DD/MO Mark</label>
                                              <select class="form-control disable form-group" readonly="readonly">
                                                        <option>Select DD/MO Mark</option>
                                                        <option value="5">&gt;= 50% to 100%</option>
                                                        <option value="2">Between 30% &amp; 50%</option>
                                                        <option>&lt;= 30% and &gt; 100%</option>
                                                    </select>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Comment</label>
                                             <textarea  rows="1"  class="form-control form-group" placeholder="Enter remark"></textarea>
                                            </div>
                                            
                                       
                                             
                                            <div class="col-sm-6">
                                              <label class="col-form-label pt-0 font-weight-bolder">DGM Mark</label>                             
                                            <select class="form-control form-group">
                                            <option>Select DGM Mark</option>
                                            <option>&gt;= 50% to 100%</option>
                                            <option>Between 30% &amp; 50%</option>
                                            <option>&lt;= 30% and &gt; 100%</option>
                                        </select>

                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Comment</label>
                                              <textarea  rows="1"  class="form-control form-group" placeholder="Enter remark"></textarea>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Mark</label>
                                              <input type="text" class="form-control form-group" placeholder="0" readonly>
                                            </div>
                                       </div>
                                       </div>
                                       </div>
                                       <div class="col-lg-6">
                                       <div class="bg-light p-2  border mb-4">
                                         <label class="col-form-label font-weight-bolder pt-0 d-block">Dust Suppression measures <small class="text-danger"> [Maximum will be 15 points in cases where No Crusher no drilling takes place]</small></label>
                                          <label class="col-form-label font-weight-bolder pt-0 ">Crusher Plant Covered (Within or adjoining lease area)</label>

                                            <div class="row">
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Max Mark</label>
                                              <input type="text" class="form-control form-group" placeholder="5" readonly>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Lessee Mark</label>
                                              <select class="form-control disable form-group" readonly="readonly">
                                                    <option>Select Lessee Mark</option>
                                                    <option>&gt;= 50% to 100%</option>
                                                    <option>Between 30% &amp; 50%</option>
                                                    <option>&lt;= 30% and &gt; 100%</option>
                                                </select>
                                            </div>
                                             <div class="col-sm-6">
                                             <label class="col-form-label pt-0 font-weight-bolder">Mining Inspector Mark</label>
                                              <select class="form-control disable form-group" readonly="readonly">
                                                <option selected="selected" value="0">select Mining Inspector Mark</option>
                                                    <option value="5">&gt;= 50% to 100%</option>
                                                    <option value="2">Between 30% &amp; 50%</option>
                                                    <option value="0">&lt;= 30% and &gt; 100%</option>
                                                </select>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Comment</label>
                                                <textarea  rows="1"  class="form-control form-group" placeholder="Enter remark"></textarea>
                                            </div>
                                           
                                            
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">DD/MO Mark</label>
                                              <select class="form-control disable form-group" readonly="readonly">
                                                        <option>Select DD/MO Mark</option>
                                                        <option value="5">&gt;= 50% to 100%</option>
                                                        <option value="2">Between 30% &amp; 50%</option>
                                                        <option>&lt;= 30% and &gt; 100%</option>
                                                    </select>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Comment</label>
                                             <textarea  rows="1"  class="form-control form-group" placeholder="Enter remark"></textarea>
                                            </div>
                                            
                                       
                                             
                                            <div class="col-sm-6">
                                              <label class="col-form-label pt-0 font-weight-bolder">DGM Mark</label>                             
                                            <select class="form-control form-group">
                                            <option>Select DGM Mark</option>
                                            <option>&gt;= 50% to 100%</option>
                                            <option>Between 30% &amp; 50%</option>
                                            <option>&lt;= 30% and &gt; 100%</option>
                                        </select>

                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Comment</label>
                                              <textarea  rows="1"  class="form-control form-group" placeholder="Enter remark"></textarea>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Mark</label>
                                              <input type="text" class="form-control form-group" placeholder="0" readonly>
                                            </div>
                                       </div>
                                       </div>
                                       </div>
                                       <div class="col-lg-6">
                                       <div class="bg-light p-2  border mb-4">
                                         <label class="col-form-label font-weight-bolder pt-0 d-block">Dust Suppression measures <small class="text-danger"> [Maximum will be 15 points in cases where No Crusher no drilling takes place]</small></label>
                                          <label class="col-form-label font-weight-bolder pt-0 ">Transportation of mineral in covered vehicles</label>

                                            <div class="row">
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Max Mark</label>
                                              <input type="text" class="form-control form-group" placeholder="5" readonly>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Lessee Mark</label>
                                              <select class="form-control disable form-group" readonly="readonly">
                                                    <option>Select Lessee Mark</option>
                                                    <option>&gt;= 50% to 100%</option>
                                                    <option>Between 30% &amp; 50%</option>
                                                    <option>&lt;= 30% and &gt; 100%</option>
                                                </select>
                                            </div>
                                             <div class="col-sm-6">
                                             <label class="col-form-label pt-0 font-weight-bolder">Mining Inspector Mark</label>
                                              <select class="form-control disable form-group" readonly="readonly">
                                                <option selected="selected" value="0">select Mining Inspector Mark</option>
                                                    <option value="5">&gt;= 50% to 100%</option>
                                                    <option value="2">Between 30% &amp; 50%</option>
                                                    <option value="0">&lt;= 30% and &gt; 100%</option>
                                                </select>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Comment</label>
                                                <textarea  rows="1"  class="form-control form-group" placeholder="Enter remark"></textarea>
                                            </div>
                                           
                                            
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">DD/MO Mark</label>
                                              <select class="form-control disable form-group" readonly="readonly">
                                                        <option>Select DD/MO Mark</option>
                                                        <option value="5">&gt;= 50% to 100%</option>
                                                        <option value="2">Between 30% &amp; 50%</option>
                                                        <option>&lt;= 30% and &gt; 100%</option>
                                                    </select>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Comment</label>
                                             <textarea  rows="1"  class="form-control form-group" placeholder="Enter remark"></textarea>
                                            </div>
                                            
                                       
                                             
                                            <div class="col-sm-6">
                                              <label class="col-form-label pt-0 font-weight-bolder">DGM Mark</label>                             
                                            <select class="form-control form-group">
                                            <option>Select DGM Mark</option>
                                            <option>&gt;= 50% to 100%</option>
                                            <option>Between 30% &amp; 50%</option>
                                            <option>&lt;= 30% and &gt; 100%</option>
                                        </select>

                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Comment</label>
                                              <textarea  rows="1"  class="form-control form-group" placeholder="Enter remark"></textarea>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Mark</label>
                                              <input type="text" class="form-control form-group" placeholder="0" readonly>
                                            </div>
                                       </div>
                                       </div>
                                       </div>
                                       <div class="col-lg-6">
                                       <div class="bg-light p-2  border mb-4">
                                         <label class="col-form-label font-weight-bolder pt-0 d-block">Dust Suppression measures <small class="text-danger"> [Maximum will be 15 points in cases where No Crusher no drilling takes place]</small></label>
                                          <label class="col-form-label font-weight-bolder pt-0 ">Water sprinkling</label>

                                            <div class="row">
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Max Mark</label>
                                              <input type="text" class="form-control form-group" placeholder="5" readonly>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Lessee Mark</label>
                                              <select class="form-control disable form-group" readonly="readonly">
                                                    <option>Select Lessee Mark</option>
                                                    <option>&gt;= 50% to 100%</option>
                                                    <option>Between 30% &amp; 50%</option>
                                                    <option>&lt;= 30% and &gt; 100%</option>
                                                </select>
                                            </div>
                                             <div class="col-sm-6">
                                             <label class="col-form-label pt-0 font-weight-bolder">Mining Inspector Mark</label>
                                              <select class="form-control disable form-group" readonly="readonly">
                                                <option selected="selected" value="0">select Mining Inspector Mark</option>
                                                    <option value="5">&gt;= 50% to 100%</option>
                                                    <option value="2">Between 30% &amp; 50%</option>
                                                    <option value="0">&lt;= 30% and &gt; 100%</option>
                                                </select>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Comment</label>
                                                <textarea  rows="1"  class="form-control form-group" placeholder="Enter remark"></textarea>
                                            </div>
                                           
                                            
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">DD/MO Mark</label>
                                              <select class="form-control disable form-group" readonly="readonly">
                                                        <option>Select DD/MO Mark</option>
                                                        <option value="5">&gt;= 50% to 100%</option>
                                                        <option value="2">Between 30% &amp; 50%</option>
                                                        <option>&lt;= 30% and &gt; 100%</option>
                                                    </select>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Comment</label>
                                             <textarea  rows="1"  class="form-control form-group" placeholder="Enter remark"></textarea>
                                            </div>
                                            
                                       
                                             
                                            <div class="col-sm-6">
                                              <label class="col-form-label pt-0 font-weight-bolder">DGM Mark</label>                             
                                            <select class="form-control form-group">
                                            <option>Select DGM Mark</option>
                                            <option>&gt;= 50% to 100%</option>
                                            <option>Between 30% &amp; 50%</option>
                                            <option>&lt;= 30% and &gt; 100%</option>
                                        </select>

                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Comment</label>
                                              <textarea  rows="1"  class="form-control form-group" placeholder="Enter remark"></textarea>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Mark</label>
                                              <input type="text" class="form-control form-group" placeholder="0" readonly>
                                            </div>
                                       </div>
                                       </div>
                                       </div>
                                       <div class="col-lg-6">
                                       <div class="bg-light p-2  border mb-4">
                                         <label class="col-form-label font-weight-bolder pt-0 d-block">Dust Suppression measures <small class="text-danger"> [Maximum will be 15 points in cases where No Crusher no drilling takes place]</small></label>
                                          <label class="col-form-label font-weight-bolder pt-0 ">Wet drilling</label>

                                            <div class="row">
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Max Mark</label>
                                              <input type="text" class="form-control form-group" placeholder="5" readonly>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Lessee Mark</label>
                                              <select class="form-control disable form-group" readonly="readonly">
                                                    <option>Select Lessee Mark</option>
                                                    <option>&gt;= 50% to 100%</option>
                                                    <option>Between 30% &amp; 50%</option>
                                                    <option>&lt;= 30% and &gt; 100%</option>
                                                </select>
                                            </div>
                                             <div class="col-sm-6">
                                             <label class="col-form-label pt-0 font-weight-bolder">Mining Inspector Mark</label>
                                              <select class="form-control disable form-group" readonly="readonly">
                                                <option selected="selected" value="0">select Mining Inspector Mark</option>
                                                    <option value="5">&gt;= 50% to 100%</option>
                                                    <option value="2">Between 30% &amp; 50%</option>
                                                    <option value="0">&lt;= 30% and &gt; 100%</option>
                                                </select>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Comment</label>
                                                <textarea  rows="1"  class="form-control form-group" placeholder="Enter remark"></textarea>
                                            </div>
                                           
                                            
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">DD/MO Mark</label>
                                              <select class="form-control disable form-group" readonly="readonly">
                                                        <option>Select DD/MO Mark</option>
                                                        <option value="5">&gt;= 50% to 100%</option>
                                                        <option value="2">Between 30% &amp; 50%</option>
                                                        <option>&lt;= 30% and &gt; 100%</option>
                                                    </select>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Comment</label>
                                             <textarea  rows="1"  class="form-control form-group" placeholder="Enter remark"></textarea>
                                            </div>
                                            <div class="col-sm-6">
                                              <label class="col-form-label pt-0 font-weight-bolder">DGM Mark</label>                             
                                            <select class="form-control form-group">
                                            <option>Select DGM Mark</option>
                                            <option>&gt;= 50% to 100%</option>
                                            <option>Between 30% &amp; 50%</option>
                                            <option>&lt;= 30% and &gt; 100%</option>
                                        </select>

                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Comment</label>
                                              <textarea  rows="1"  class="form-control form-group" placeholder="Enter remark"></textarea>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Mark</label>
                                              <input type="text" class="form-control form-group" placeholder="0" readonly>
                                            </div>
                                       </div>
                                       </div>
                                       </div>
                                       <div class="col-lg-12">
                                       <div class="bg-light p-2  border mb-4">
                                         <label class="col-form-label font-weight-bolder pt-0 d-block">Total</label>
                                            <div class="form-group row">
                                            <div class="col">
                                              <label class="col-form-label pt-0 font-weight-bolder">Max Mark</label>
                                              <input type="text" class="form-control" value="5" readonly>
                                            </div>
                                            <div class="col">
                                             <label class="col-form-label pt-0 font-weight-bolder">Lessee Mark</label>
                                              <input type="text" class="form-control" value="7"  readonly>
                                            </div>
                                            <div class="col">
                                            <label class="col-form-label pt-0 font-weight-bolder">Mining Inspector Mark</label>
                                             <input type="text" class="form-control" value="9" readonly>
                                            </div>
                                           
                                            <div class="col">
                                              <label class="col-form-label pt-0 font-weight-bolder">DD/MO Mark</label>
                                              <input type="text" class="form-control" value="14" readonly>
                                            </div>
                                            
                                            <div class="col">
                                            <label class="col-form-label pt-0 font-weight-bolder">DGM Mark</label>
                                                <input type="text" class="form-control" value="3" readonly>
                                            </div>
                                        
                                            <div class="col">
                                             <label class="col-form-label pt-0 font-weight-bolder">Mark</label>
                                              <input type="text" class="form-control" value="4" readonly>
                                            </div>
                                       </div>
                                       </div>
                                       </div>
                                    </div>
                                     </div>
                                       </div> 
                                       <h5 class="text-brown font-weight-bold">Module-ii <span class="text-dark">(protection Of Environment And Conservation Of Water)</span></h5>
                                        <div class="module-sec custom-scroll">
                                        <div class="mr-3">
                                       <div class="row">
                                       <div class="col-lg-6">
                                       <div class="bg-light p-2  border mb-4">
                                         <label class="col-form-label font-weight-bolder pt-0 d-block">Compliance reporting of environmental parameters(air, water, etc)</label>
                                         <label class="col-form-label font-weight-bolder pt-0 "> As per SPCB norms(To be submitted)<a href="#"><i class="fa fa-download ml-2" aria-hidden="true"></i></a></label>
                                            <div class="row">
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Max Mark</label>
                                              <input type="text" class="form-control form-group" placeholder="5" readonly>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Lessee Mark</label>
                                              <select class="form-control disable form-group" readonly="readonly">
                                                    <option>Select Lessee Mark</option>
                                                    <option>&gt;= 50% to 100%</option>
                                                    <option>Between 30% &amp; 50%</option>
                                                    <option>&lt;= 30% and &gt; 100%</option>
                                                </select>
                                            </div>
                                             <div class="col-sm-6">
                                             <label class="col-form-label pt-0 font-weight-bolder">Mining Inspector Mark</label>
                                              <select class="form-control disable form-group" readonly="readonly">
                                                <option selected="selected" value="0">select Mining Inspector Mark</option>
                                                    <option value="5">&gt;= 50% to 100%</option>
                                                    <option value="2">Between 30% &amp; 50%</option>
                                                    <option value="0">&lt;= 30% and &gt; 100%</option>
                                                </select>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Comment</label>
                                                <textarea  rows="1"  class="form-control form-group" placeholder="Enter remark"></textarea>
                                            </div>
                                           
                                            
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">DD/MO Mark</label>
                                              <select class="form-control disable form-group" readonly="readonly">
                                                        <option>Select DD/MO Mark</option>
                                                        <option value="5">&gt;= 50% to 100%</option>
                                                        <option value="2">Between 30% &amp; 50%</option>
                                                        <option>&lt;= 30% and &gt; 100%</option>
                                                    </select>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Comment</label>
                                             <textarea  rows="1"  class="form-control form-group" placeholder="Enter remark"></textarea>
                                            </div>
                                            
                                       
                                             
                                            <div class="col-sm-6">
                                              <label class="col-form-label pt-0 font-weight-bolder">DGM Mark</label>                             
                                            <select class="form-control form-group">
                                            <option>Select DGM Mark</option>
                                            <option>&gt;= 50% to 100%</option>
                                            <option>Between 30% &amp; 50%</option>
                                            <option>&lt;= 30% and &gt; 100%</option>
                                        </select>

                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Comment</label>
                                              <textarea  rows="1"  class="form-control form-group" placeholder="Enter remark"></textarea>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Mark</label>
                                              <input type="text" class="form-control form-group" placeholder="0" readonly>
                                            </div>
                                       </div>
                                       </div>
                                       </div>
                                        <div class="col-lg-6">
                                       <div class="bg-light p-2  border mb-4">
                                         <label class="col-form-label font-weight-bolder pt-0 d-block">Compliance reporting of environmental parameters (As per EC condition)</label>
                                          <label class="col-form-label font-weight-bolder pt-0 ">As per Moef norms (To be submitted)<a href="#"><i class="fa fa-download ml-2" aria-hidden="true"></i></a></label>

                                            <div class="row">
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Max Mark</label>
                                              <input type="text" class="form-control form-group" placeholder="5" readonly>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Lessee Mark</label>
                                              <select class="form-control disable form-group" readonly="readonly">
                                                    <option>Select Lessee Mark</option>
                                                    <option>&gt;= 50% to 100%</option>
                                                    <option>Between 30% &amp; 50%</option>
                                                    <option>&lt;= 30% and &gt; 100%</option>
                                                </select>
                                            </div>
                                             <div class="col-sm-6">
                                             <label class="col-form-label pt-0 font-weight-bolder">Mining Inspector Mark</label>
                                              <select class="form-control disable form-group" readonly="readonly">
                                                <option selected="selected" value="0">select Mining Inspector Mark</option>
                                                    <option value="5">&gt;= 50% to 100%</option>
                                                    <option value="2">Between 30% &amp; 50%</option>
                                                    <option value="0">&lt;= 30% and &gt; 100%</option>
                                                </select>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Comment</label>
                                                <textarea  rows="1"  class="form-control form-group" placeholder="Enter remark"></textarea>
                                            </div>
                                           
                                            
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">DD/MO Mark</label>
                                              <select class="form-control disable form-group" readonly="readonly">
                                                        <option>Select DD/MO Mark</option>
                                                        <option value="5">&gt;= 50% to 100%</option>
                                                        <option value="2">Between 30% &amp; 50%</option>
                                                        <option>&lt;= 30% and &gt; 100%</option>
                                                    </select>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Comment</label>
                                             <textarea  rows="1"  class="form-control form-group" placeholder="Enter remark"></textarea>
                                            </div>
                                            
                                       
                                             
                                            <div class="col-sm-6">
                                              <label class="col-form-label pt-0 font-weight-bolder">DGM Mark</label>                             
                                            <select class="form-control form-group">
                                            <option>Select DGM Mark</option>
                                            <option>&gt;= 50% to 100%</option>
                                            <option>Between 30% &amp; 50%</option>
                                            <option>&lt;= 30% and &gt; 100%</option>
                                        </select>

                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Comment</label>
                                              <textarea  rows="1"  class="form-control form-group" placeholder="Enter remark"></textarea>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Mark</label>
                                              <input type="text" class="form-control form-group" placeholder="0" readonly>
                                            </div>
                                       </div>
                                       </div>
                                       </div>
                                        <div class="col-lg-6">
                                       <div class="bg-light p-2  border mb-4">
                                         <label class="col-form-label font-weight-bolder pt-0 d-block">Total Plantation/ compensatory aforestation done as per approved Document (EC/FC) and Survival rate of plants</label>
                                          <label class="col-form-label font-weight-bolder pt-0 ">Approved Quantity(Nos)<a href="#"><i class="fa fa-download ml-2" aria-hidden="true"></i></a></label>

                                            <div class="row">
                                             <div class="col-sm-4">
                                               <input type="text" class="form-control form-group" placeholder="Approved Quantity (Tonnes)">
                                            </div>
                                            <div class="col-sm-4">
                                              <input type="text" class="form-control form-group" placeholder="Actual (Tonnes)">
                                            </div>
                                            <div class="col-sm-4">
                                              <input type="text" class="form-control form-group" placeholder="Trees/Plants Survived">
                                            </div>
                                           
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Max Mark</label>
                                              <input type="text" class="form-control form-group" placeholder="5" readonly>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Lessee Mark</label>
                                              <select class="form-control disable form-group" readonly="readonly">
                                                    <option>Select Lessee Mark</option>
                                                    <option>&gt;= 50% to 100%</option>
                                                    <option>Between 30% &amp; 50%</option>
                                                    <option>&lt;= 30% and &gt; 100%</option>
                                                </select>
                                            </div>
                                             <div class="col-sm-6">
                                             <label class="col-form-label pt-0 font-weight-bolder">Mining Inspector Mark</label>
                                              <select class="form-control disable form-group" readonly="readonly">
                                                <option selected="selected" value="0">select Mining Inspector Mark</option>
                                                    <option value="5">&gt;= 50% to 100%</option>
                                                    <option value="2">Between 30% &amp; 50%</option>
                                                    <option value="0">&lt;= 30% and &gt; 100%</option>
                                                </select>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Comment</label>
                                                <textarea  rows="1"  class="form-control form-group" placeholder="Enter remark"></textarea>
                                            </div>
                                           
                                            
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">DD/MO Mark</label>
                                              <select class="form-control disable form-group" readonly="readonly">
                                                        <option>Select DD/MO Mark</option>
                                                        <option value="5">&gt;= 50% to 100%</option>
                                                        <option value="2">Between 30% &amp; 50%</option>
                                                        <option>&lt;= 30% and &gt; 100%</option>
                                                    </select>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Comment</label>
                                             <textarea  rows="1"  class="form-control form-group" placeholder="Enter remark"></textarea>
                                            </div>
                                            
                                       
                                             
                                            <div class="col-sm-6">
                                              <label class="col-form-label pt-0 font-weight-bolder">DGM Mark</label>                             
                                            <select class="form-control form-group">
                                            <option>Select DGM Mark</option>
                                            <option>&gt;= 50% to 100%</option>
                                            <option>Between 30% &amp; 50%</option>
                                            <option>&lt;= 30% and &gt; 100%</option>
                                        </select>

                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Comment</label>
                                              <textarea  rows="1"  class="form-control form-group" placeholder="Enter remark"></textarea>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Mark</label>
                                              <input type="text" class="form-control form-group" placeholder="0" readonly>
                                            </div>
                                      
                                       </div>
                                       </div>
                                       </div>
                                       <div class="col-lg-6">
                                       <div class="bg-light p-2  border mb-4">
                                         <label class="col-form-label font-weight-bolder pt-0 d-block">Use of recycled water for drinking, agriculture, mining, other activities, etc</label>
                                         

                                            <div class="row">
                                             <div class="col-sm-12">
                                               <input type="text" class="form-control form-group" placeholder="We are Using  recycled water in water sprinkling and agriculture use">
                                            </div>
                                          
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Max Mark</label>
                                              <input type="text" class="form-control form-group" placeholder="5" readonly>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Lessee Mark</label>
                                              <select class="form-control disable form-group" readonly="readonly">
                                                    <option>Select Lessee Mark</option>
                                                    <option>&gt;= 50% to 100%</option>
                                                    <option>Between 30% &amp; 50%</option>
                                                    <option>&lt;= 30% and &gt; 100%</option>
                                                </select>
                                            </div>
                                             <div class="col-sm-6">
                                             <label class="col-form-label pt-0 font-weight-bolder">Mining Inspector Mark</label>
                                              <select class="form-control disable form-group" readonly="readonly">
                                                <option selected="selected" value="0">select Mining Inspector Mark</option>
                                                    <option value="5">&gt;= 50% to 100%</option>
                                                    <option value="2">Between 30% &amp; 50%</option>
                                                    <option value="0">&lt;= 30% and &gt; 100%</option>
                                                </select>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Comment</label>
                                                <textarea  rows="1"  class="form-control form-group" placeholder="Enter remark"></textarea>
                                            </div>
                                           
                                            
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">DD/MO Mark</label>
                                              <select class="form-control disable form-group" readonly="readonly">
                                                        <option>Select DD/MO Mark</option>
                                                        <option value="5">&gt;= 50% to 100%</option>
                                                        <option value="2">Between 30% &amp; 50%</option>
                                                        <option>&lt;= 30% and &gt; 100%</option>
                                                    </select>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Comment</label>
                                             <textarea  rows="1"  class="form-control form-group" placeholder="Enter remark"></textarea>
                                            </div>
                                            
                                       
                                             
                                            <div class="col-sm-6">
                                              <label class="col-form-label pt-0 font-weight-bolder">DGM Mark</label>                             
                                            <select class="form-control form-group">
                                            <option>Select DGM Mark</option>
                                            <option>&gt;= 50% to 100%</option>
                                            <option>Between 30% &amp; 50%</option>
                                            <option>&lt;= 30% and &gt; 100%</option>
                                        </select>

                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Comment</label>
                                              <textarea  rows="1"  class="form-control form-group" placeholder="Enter remark"></textarea>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Mark</label>
                                              <input type="text" class="form-control form-group" placeholder="0" readonly>
                                            </div>
                                      
                                       </div>
                                       </div>
                                       </div>
                                       <div class="col-lg-12">
                                       <div class="bg-light p-2  border mb-4">
                                         <label class="col-form-label font-weight-bolder pt-0 d-block">Total</label>
                                            <div class="form-group row">
                                            <div class="col">
                                              <label class="col-form-label pt-0 font-weight-bolder">Max Mark</label>
                                              <input type="text" class="form-control" value="5" readonly>
                                            </div>
                                            <div class="col">
                                             <label class="col-form-label pt-0 font-weight-bolder">Lessee Mark</label>
                                              <input type="text" class="form-control" value="7"  readonly>
                                            </div>
                                            <div class="col">
                                            <label class="col-form-label pt-0 font-weight-bolder">Mining Inspector Mark</label>
                                             <input type="text" class="form-control" value="9" readonly>
                                            </div>
                                           
                                            <div class="col">
                                              <label class="col-form-label pt-0 font-weight-bolder">DD/MO Mark</label>
                                              <input type="text" class="form-control" value="14" readonly>
                                            </div>
                                            
                                            <div class="col">
                                            <label class="col-form-label pt-0 font-weight-bolder">DGM Mark</label>
                                                <input type="text" class="form-control" value="3" readonly>
                                            </div>
                                        
                                            <div class="col">
                                             <label class="col-form-label pt-0 font-weight-bolder">Mark</label>
                                              <input type="text" class="form-control" value="4" readonly>
                                            </div>
                                       </div>
                                       </div>
                                       </div>
                                    </div>
                                       </div>  
                                       </div>
                                                
                                       <h5 class="text-brown font-weight-bold">Module-iii <span class="text-dark">(health Safety And Welfare Of Workers)</span></h5>
                                        <div class="module-sec custom-scroll">
                                        <div class="mr-3">
                                       <div class="row">
                                       <div class="col-lg-6">
                                       <div class="bg-light p-2  border mb-4">
                                         <label class="col-form-label font-weight-bolder pt-0 d-block">Percentage of total employees/workers to whom DGMS approved Personnel Protection Equipment (PPE), Helmets, Shoes, gloves & dust mask, safety jacket has been provided & complied</label>
                                       
                                            <div class="row">
                                            <div class="col-sm-6">
                                           
                                            <label class="col-form-label pt-0 font-weight-bolder"> Av. total employment</label>
                                               <input type="text" class="form-control form-group" placeholder="7">
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">% of total employment whom PPE provided</label>
                                            
                                               <input type="text" class="form-control form-group" placeholder="14">
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Max Mark</label>
                                              <input type="text" class="form-control form-group" placeholder="5" readonly>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Lessee Mark</label>
                                              <select class="form-control disable form-group" readonly="readonly">
                                                    <option>Select Lessee Mark</option>
                                                    <option>&gt;= 50% to 100%</option>
                                                    <option>Between 30% &amp; 50%</option>
                                                    <option>&lt;= 30% and &gt; 100%</option>
                                                </select>
                                            </div>
                                             <div class="col-sm-6">
                                             <label class="col-form-label pt-0 font-weight-bolder">Mining Inspector Mark</label>
                                              <select class="form-control disable form-group" readonly="readonly">
                                                <option selected="selected" value="0">select Mining Inspector Mark</option>
                                                    <option value="5">&gt;= 50% to 100%</option>
                                                    <option value="2">Between 30% &amp; 50%</option>
                                                    <option value="0">&lt;= 30% and &gt; 100%</option>
                                                </select>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Comment</label>
                                                <textarea  rows="1"  class="form-control form-group" placeholder="Enter remark"></textarea>
                                            </div>
                                           
                                            
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">DD/MO Mark</label>
                                              <select class="form-control disable form-group" readonly="readonly">
                                                        <option>Select DD/MO Mark</option>
                                                        <option value="5">&gt;= 50% to 100%</option>
                                                        <option value="2">Between 30% &amp; 50%</option>
                                                        <option>&lt;= 30% and &gt; 100%</option>
                                                    </select>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Comment</label>
                                             <textarea  rows="1"  class="form-control form-group" placeholder="Enter remark"></textarea>
                                            </div>
                                            
                                       
                                             
                                            <div class="col-sm-6">
                                              <label class="col-form-label pt-0 font-weight-bolder">DGM Mark</label>                             
                                            <select class="form-control form-group">
                                            <option>Select DGM Mark</option>
                                            <option>&gt;= 50% to 100%</option>
                                            <option>Between 30% &amp; 50%</option>
                                            <option>&lt;= 30% and &gt; 100%</option>
                                        </select>

                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Comment</label>
                                              <textarea  rows="1"  class="form-control form-group" placeholder="Enter remark"></textarea>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Mark</label>
                                              <input type="text" class="form-control form-group" placeholder="0" readonly>
                                            </div>
                                       </div>
                                       </div>
                                       </div>
                                        <div class="col-lg-6">
                                       <div class="bg-light p-2  border mb-4">
                                         <label class="col-form-label font-weight-bolder pt-0 d-block">Percentage of total employment whom Periodical Medical Examination (PME)
                                          has been done as per Mine Rules 1955</label>
                                        

                                            <div class="row">
                                            <div class="col-sm-6">
                                           
                                            <label class="col-form-label pt-0 font-weight-bolder"> Av. total employment</label>
                                               <input type="text" class="form-control form-group" placeholder="7">
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">% of total employment whom PPE provided</label>
                                            
                                               <input type="text" class="form-control form-group" placeholder="14">
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Max Mark</label>
                                              <input type="text" class="form-control form-group" placeholder="5" readonly>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Lessee Mark</label>
                                              <select class="form-control disable form-group" readonly="readonly">
                                                    <option>Select Lessee Mark</option>
                                                    <option>&gt;= 50% to 100%</option>
                                                    <option>Between 30% &amp; 50%</option>
                                                    <option>&lt;= 30% and &gt; 100%</option>
                                                </select>
                                            </div>
                                             <div class="col-sm-6">
                                             <label class="col-form-label pt-0 font-weight-bolder">Mining Inspector Mark</label>
                                              <select class="form-control disable form-group" readonly="readonly">
                                                <option selected="selected" value="0">select Mining Inspector Mark</option>
                                                    <option value="5">&gt;= 50% to 100%</option>
                                                    <option value="2">Between 30% &amp; 50%</option>
                                                    <option value="0">&lt;= 30% and &gt; 100%</option>
                                                </select>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Comment</label>
                                                <textarea  rows="1"  class="form-control form-group" placeholder="Enter remark"></textarea>
                                            </div>
                                           
                                            
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">DD/MO Mark</label>
                                              <select class="form-control disable form-group" readonly="readonly">
                                                        <option>Select DD/MO Mark</option>
                                                        <option value="5">&gt;= 50% to 100%</option>
                                                        <option value="2">Between 30% &amp; 50%</option>
                                                        <option>&lt;= 30% and &gt; 100%</option>
                                                    </select>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Comment</label>
                                             <textarea  rows="1"  class="form-control form-group" placeholder="Enter remark"></textarea>
                                            </div>
                                            
                                       
                                             
                                            <div class="col-sm-6">
                                              <label class="col-form-label pt-0 font-weight-bolder">DGM Mark</label>                             
                                            <select class="form-control form-group">
                                            <option>Select DGM Mark</option>
                                            <option>&gt;= 50% to 100%</option>
                                            <option>Between 30% &amp; 50%</option>
                                            <option>&lt;= 30% and &gt; 100%</option>
                                        </select>

                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Comment</label>
                                              <textarea  rows="1"  class="form-control form-group" placeholder="Enter remark"></textarea>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Mark</label>
                                              <input type="text" class="form-control form-group" placeholder="0" readonly>
                                            </div>
                                       </div>
                                       </div>
                                       </div>
                                        <div class="col-lg-6">
                                       <div class="bg-light p-2  border mb-4">
                                         <label class="col-form-label font-weight-bolder pt-0 d-block">Provision of drinking water & Sanitation 
                                         facilities to all workers<a href="#"><i class="fa fa-download ml-2" aria-hidden="true"></i></a></label>
                                        

                                            <div class="row">
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Max Mark</label>
                                              <input type="text" class="form-control form-group" placeholder="5" readonly>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Lessee Mark</label>
                                              <select class="form-control disable form-group" readonly="readonly">
                                                    <option>Select Lessee Mark</option>
                                                    <option>&gt;= 50% to 100%</option>
                                                    <option>Between 30% &amp; 50%</option>
                                                    <option>&lt;= 30% and &gt; 100%</option>
                                                </select>
                                            </div>
                                             <div class="col-sm-6">
                                             <label class="col-form-label pt-0 font-weight-bolder">Mining Inspector Mark</label>
                                              <select class="form-control disable form-group" readonly="readonly">
                                                <option selected="selected" value="0">select Mining Inspector Mark</option>
                                                    <option value="5">&gt;= 50% to 100%</option>
                                                    <option value="2">Between 30% &amp; 50%</option>
                                                    <option value="0">&lt;= 30% and &gt; 100%</option>
                                                </select>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Comment</label>
                                                <textarea  rows="1"  class="form-control form-group" placeholder="Enter remark"></textarea>
                                            </div>
                                           
                                            
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">DD/MO Mark</label>
                                              <select class="form-control disable form-group" readonly="readonly">
                                                        <option>Select DD/MO Mark</option>
                                                        <option value="5">&gt;= 50% to 100%</option>
                                                        <option value="2">Between 30% &amp; 50%</option>
                                                        <option>&lt;= 30% and &gt; 100%</option>
                                                    </select>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Comment</label>
                                             <textarea  rows="1"  class="form-control form-group" placeholder="Enter remark"></textarea>
                                            </div>
                                            
                                       
                                             
                                            <div class="col-sm-6">
                                              <label class="col-form-label pt-0 font-weight-bolder">DGM Mark</label>                             
                                            <select class="form-control form-group">
                                            <option>Select DGM Mark</option>
                                            <option>&gt;= 50% to 100%</option>
                                            <option>Between 30% &amp; 50%</option>
                                            <option>&lt;= 30% and &gt; 100%</option>
                                        </select>

                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Comment</label>
                                              <textarea  rows="1"  class="form-control form-group" placeholder="Enter remark"></textarea>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Mark</label>
                                              <input type="text" class="form-control form-group" placeholder="0" readonly>
                                            </div>
                                      
                                       </div>
                                       </div>
                                       </div>
                                       <div class="col-lg-6">
                                       <div class="bg-light p-2  border mb-4">
                                         <label class="col-form-label font-weight-bolder pt-0 d-block">Provision of basic amenities to women employees Crèche, Toilet & Restrooms<a href="#"><i class="fa fa-download ml-2" aria-hidden="true"></i></a></label>
                                         

                                            <div class="row">
                                             
                                          
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Max Mark</label>
                                              <input type="text" class="form-control form-group" placeholder="5" readonly>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Lessee Mark</label>
                                              <select class="form-control disable form-group" readonly="readonly">
                                                    <option>Select Lessee Mark</option>
                                                    <option>&gt;= 50% to 100%</option>
                                                    <option>Between 30% &amp; 50%</option>
                                                    <option>&lt;= 30% and &gt; 100%</option>
                                                </select>
                                            </div>
                                             <div class="col-sm-6">
                                             <label class="col-form-label pt-0 font-weight-bolder">Mining Inspector Mark</label>
                                              <select class="form-control disable form-group" readonly="readonly">
                                                <option selected="selected" value="0">select Mining Inspector Mark</option>
                                                    <option value="5">&gt;= 50% to 100%</option>
                                                    <option value="2">Between 30% &amp; 50%</option>
                                                    <option value="0">&lt;= 30% and &gt; 100%</option>
                                                </select>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Comment</label>
                                                <textarea  rows="1"  class="form-control form-group" placeholder="Enter remark"></textarea>
                                            </div>
                                           
                                            
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">DD/MO Mark</label>
                                              <select class="form-control disable form-group" readonly="readonly">
                                                        <option>Select DD/MO Mark</option>
                                                        <option value="5">&gt;= 50% to 100%</option>
                                                        <option value="2">Between 30% &amp; 50%</option>
                                                        <option>&lt;= 30% and &gt; 100%</option>
                                                    </select>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Comment</label>
                                             <textarea  rows="1"  class="form-control form-group" placeholder="Enter remark"></textarea>
                                            </div>
                                            
                                       
                                             
                                            <div class="col-sm-6">
                                              <label class="col-form-label pt-0 font-weight-bolder">DGM Mark</label>                             
                                            <select class="form-control form-group">
                                            <option>Select DGM Mark</option>
                                            <option>&gt;= 50% to 100%</option>
                                            <option>Between 30% &amp; 50%</option>
                                            <option>&lt;= 30% and &gt; 100%</option>
                                        </select>

                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Comment</label>
                                              <textarea  rows="1"  class="form-control form-group" placeholder="Enter remark"></textarea>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Mark</label>
                                              <input type="text" class="form-control form-group" placeholder="0" readonly>
                                            </div>
                                      
                                       </div>
                                       </div>
                                       </div>
                                       <div class="col-lg-6">
                                       <div class="bg-light p-2  border mb-4">
                                         <label class="col-form-label font-weight-bolder pt-0 d-block">Cases of Silicosis’ or other occupational disease detected
                                          amongst mine workers during the RY</label>
                                            <div class="row">
                                            <div class="col-sm-12">
                                            <label class="col-form-label pt-0 font-weight-bolder">Details to be provided</label>
                                            
                                               <input type="text" class="form-control form-group" >
                                            </div>
                                          
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Max Mark</label>
                                              <input type="text" class="form-control form-group" placeholder="5" readonly>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Lessee Mark</label>
                                              <select class="form-control disable form-group" readonly="readonly">
                                                    <option>Select Lessee Mark</option>
                                                    <option>&gt;= 50% to 100%</option>
                                                    <option>Between 30% &amp; 50%</option>
                                                    <option>&lt;= 30% and &gt; 100%</option>
                                                </select>
                                            </div>
                                             <div class="col-sm-6">
                                             <label class="col-form-label pt-0 font-weight-bolder">Mining Inspector Mark</label>
                                              <select class="form-control disable form-group" readonly="readonly">
                                                <option selected="selected" value="0">select Mining Inspector Mark</option>
                                                    <option value="5">&gt;= 50% to 100%</option>
                                                    <option value="2">Between 30% &amp; 50%</option>
                                                    <option value="0">&lt;= 30% and &gt; 100%</option>
                                                </select>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Comment</label>
                                                <textarea  rows="1"  class="form-control form-group" placeholder="Enter remark"></textarea>
                                            </div>
                                           
                                            
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">DD/MO Mark</label>
                                              <select class="form-control disable form-group" readonly="readonly">
                                                        <option>Select DD/MO Mark</option>
                                                        <option value="5">&gt;= 50% to 100%</option>
                                                        <option value="2">Between 30% &amp; 50%</option>
                                                        <option>&lt;= 30% and &gt; 100%</option>
                                                    </select>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Comment</label>
                                             <textarea  rows="1"  class="form-control form-group" placeholder="Enter remark"></textarea>
                                            </div>
                                            
                                       
                                             
                                            <div class="col-sm-6">
                                              <label class="col-form-label pt-0 font-weight-bolder">DGM Mark</label>                             
                                            <select class="form-control form-group">
                                            <option>Select DGM Mark</option>
                                            <option>&gt;= 50% to 100%</option>
                                            <option>Between 30% &amp; 50%</option>
                                            <option>&lt;= 30% and &gt; 100%</option>
                                        </select>

                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Comment</label>
                                              <textarea  rows="1"  class="form-control form-group" placeholder="Enter remark"></textarea>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Mark</label>
                                              <input type="text" class="form-control form-group" placeholder="0" readonly>
                                            </div>
                                       </div>
                                       </div>
                                       </div>
                                       <div class="col-lg-6">
                                       <div class="bg-light p-2  border mb-4">
                                         <label class="col-form-label font-weight-bolder pt-0 d-block">Welfare measures undertaken by the lesee for mine workers /
                                          in near by areas as part of CSR
                                         </label>
                                            <div class="row">
                                            <div class="col-sm-12">
                                            <label class="col-form-label pt-0 font-weight-bolder">Details to be provided</label>
                                            
                                               <input type="text" class="form-control form-group" >
                                            </div>
                                          
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Max Mark</label>
                                              <input type="text" class="form-control form-group" placeholder="5" readonly>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Lessee Mark</label>
                                              <select class="form-control disable form-group" readonly="readonly">
                                                    <option>Select Lessee Mark</option>
                                                    <option>&gt;= 50% to 100%</option>
                                                    <option>Between 30% &amp; 50%</option>
                                                    <option>&lt;= 30% and &gt; 100%</option>
                                                </select>
                                            </div>
                                             <div class="col-sm-6">
                                             <label class="col-form-label pt-0 font-weight-bolder">Mining Inspector Mark</label>
                                              <select class="form-control disable form-group" readonly="readonly">
                                                <option selected="selected" value="0">select Mining Inspector Mark</option>
                                                    <option value="5">&gt;= 50% to 100%</option>
                                                    <option value="2">Between 30% &amp; 50%</option>
                                                    <option value="0">&lt;= 30% and &gt; 100%</option>
                                                </select>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Comment</label>
                                                <textarea  rows="1"  class="form-control form-group" placeholder="Enter remark"></textarea>
                                            </div>
                                           
                                            
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">DD/MO Mark</label>
                                              <select class="form-control disable form-group" readonly="readonly">
                                                        <option>Select DD/MO Mark</option>
                                                        <option value="5">&gt;= 50% to 100%</option>
                                                        <option value="2">Between 30% &amp; 50%</option>
                                                        <option>&lt;= 30% and &gt; 100%</option>
                                                    </select>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Comment</label>
                                             <textarea  rows="1"  class="form-control form-group" placeholder="Enter remark"></textarea>
                                            </div>
                                            
                                       
                                             
                                            <div class="col-sm-6">
                                              <label class="col-form-label pt-0 font-weight-bolder">DGM Mark</label>                             
                                            <select class="form-control form-group">
                                            <option>Select DGM Mark</option>
                                            <option>&gt;= 50% to 100%</option>
                                            <option>Between 30% &amp; 50%</option>
                                            <option>&lt;= 30% and &gt; 100%</option>
                                        </select>

                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Comment</label>
                                              <textarea  rows="1"  class="form-control form-group" placeholder="Enter remark"></textarea>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Mark</label>
                                              <input type="text" class="form-control form-group" placeholder="0" readonly>
                                            </div>
                                       </div>
                                       </div>
                                       </div>
                                       <div class="col-lg-6">
                                       <div class="bg-light p-2  border mb-4">
                                         <label class="col-form-label font-weight-bolder pt-0 d-block">Provision to tackle mine hazards/ rescue operation
                                         </label>
                                            <div class="row">
                                            <div class="col-sm-12">
                                            <label class="col-form-label pt-0 font-weight-bolder">Details to be provided</label>
                                            
                                               <input type="text" class="form-control form-group" >
                                            </div>
                                          
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Max Mark</label>
                                              <input type="text" class="form-control form-group" placeholder="5" readonly>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Lessee Mark</label>
                                              <select class="form-control disable form-group" readonly="readonly">
                                                    <option>Select Lessee Mark</option>
                                                    <option>&gt;= 50% to 100%</option>
                                                    <option>Between 30% &amp; 50%</option>
                                                    <option>&lt;= 30% and &gt; 100%</option>
                                                </select>
                                            </div>
                                             <div class="col-sm-6">
                                             <label class="col-form-label pt-0 font-weight-bolder">Mining Inspector Mark</label>
                                              <select class="form-control disable form-group" readonly="readonly">
                                                <option selected="selected" value="0">select Mining Inspector Mark</option>
                                                    <option value="5">&gt;= 50% to 100%</option>
                                                    <option value="2">Between 30% &amp; 50%</option>
                                                    <option value="0">&lt;= 30% and &gt; 100%</option>
                                                </select>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Comment</label>
                                                <textarea  rows="1"  class="form-control form-group" placeholder="Enter remark"></textarea>
                                            </div>
                                           
                                            
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">DD/MO Mark</label>
                                              <select class="form-control disable form-group" readonly="readonly">
                                                        <option>Select DD/MO Mark</option>
                                                        <option value="5">&gt;= 50% to 100%</option>
                                                        <option value="2">Between 30% &amp; 50%</option>
                                                        <option>&lt;= 30% and &gt; 100%</option>
                                                    </select>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Comment</label>
                                             <textarea  rows="1"  class="form-control form-group" placeholder="Enter remark"></textarea>
                                            </div>
                                            
                                       
                                             
                                            <div class="col-sm-6">
                                              <label class="col-form-label pt-0 font-weight-bolder">DGM Mark</label>                             
                                            <select class="form-control form-group">
                                            <option>Select DGM Mark</option>
                                            <option>&gt;= 50% to 100%</option>
                                            <option>Between 30% &amp; 50%</option>
                                            <option>&lt;= 30% and &gt; 100%</option>
                                        </select>

                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Comment</label>
                                              <textarea  rows="1"  class="form-control form-group" placeholder="Enter remark"></textarea>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Mark</label>
                                              <input type="text" class="form-control form-group" placeholder="0" readonly>
                                            </div>
                                       </div>
                                       </div>
                                       </div>
                                       <div class="col-lg-6">
                                       <div class="bg-light p-2  border mb-4">
                                         <label class="col-form-label font-weight-bolder pt-0 d-block">Training Programme for workers/ Labours/ Machine Operators etc (In every Six Months)
                                         </label>
                                            <div class="row">
                                            <div class="col-sm-12">
                                            <label class="col-form-label pt-0 font-weight-bolder">Details to be provided</label>
                                            
                                               <input type="text" class="form-control form-group" >
                                            </div>
                                          
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Max Mark</label>
                                              <input type="text" class="form-control form-group" placeholder="5" readonly>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Lessee Mark</label>
                                              <select class="form-control disable form-group" readonly="readonly">
                                                    <option>Select Lessee Mark</option>
                                                    <option>&gt;= 50% to 100%</option>
                                                    <option>Between 30% &amp; 50%</option>
                                                    <option>&lt;= 30% and &gt; 100%</option>
                                                </select>
                                            </div>
                                             <div class="col-sm-6">
                                             <label class="col-form-label pt-0 font-weight-bolder">Mining Inspector Mark</label>
                                              <select class="form-control disable form-group" readonly="readonly">
                                                <option selected="selected" value="0">select Mining Inspector Mark</option>
                                                    <option value="5">&gt;= 50% to 100%</option>
                                                    <option value="2">Between 30% &amp; 50%</option>
                                                    <option value="0">&lt;= 30% and &gt; 100%</option>
                                                </select>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Comment</label>
                                                <textarea  rows="1"  class="form-control form-group" placeholder="Enter remark"></textarea>
                                            </div>
                                           
                                            
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">DD/MO Mark</label>
                                              <select class="form-control disable form-group" readonly="readonly">
                                                        <option>Select DD/MO Mark</option>
                                                        <option value="5">&gt;= 50% to 100%</option>
                                                        <option value="2">Between 30% &amp; 50%</option>
                                                        <option>&lt;= 30% and &gt; 100%</option>
                                                    </select>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Comment</label>
                                             <textarea  rows="1"  class="form-control form-group" placeholder="Enter remark"></textarea>
                                            </div>
                                            
                                       
                                             
                                            <div class="col-sm-6">
                                              <label class="col-form-label pt-0 font-weight-bolder">DGM Mark</label>                             
                                            <select class="form-control form-group">
                                            <option>Select DGM Mark</option>
                                            <option>&gt;= 50% to 100%</option>
                                            <option>Between 30% &amp; 50%</option>
                                            <option>&lt;= 30% and &gt; 100%</option>
                                        </select>

                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Comment</label>
                                              <textarea  rows="1"  class="form-control form-group" placeholder="Enter remark"></textarea>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Mark</label>
                                              <input type="text" class="form-control form-group" placeholder="0" readonly>
                                            </div>
                                       </div>
                                       </div>
                                       </div>
                                       <div class="col-lg-12">
                                       <div class="bg-light p-2  border mb-4">
                                         <label class="col-form-label font-weight-bolder pt-0 d-block">Total</label>
                                            <div class="form-group row">
                                            <div class="col">
                                              <label class="col-form-label pt-0 font-weight-bolder">Max Mark</label>
                                              <input type="text" class="form-control" value="5" readonly>
                                            </div>
                                            <div class="col">
                                             <label class="col-form-label pt-0 font-weight-bolder">Lessee Mark</label>
                                              <input type="text" class="form-control" value="7"  readonly>
                                            </div>
                                            <div class="col">
                                            <label class="col-form-label pt-0 font-weight-bolder">Mining Inspector Mark</label>
                                             <input type="text" class="form-control" value="9" readonly>
                                            </div>
                                           
                                            <div class="col">
                                              <label class="col-form-label pt-0 font-weight-bolder">DD/MO Mark</label>
                                              <input type="text" class="form-control" value="14" readonly>
                                            </div>
                                            
                                            <div class="col">
                                            <label class="col-form-label pt-0 font-weight-bolder">DGM Mark</label>
                                                <input type="text" class="form-control" value="3" readonly>
                                            </div>
                                        
                                            <div class="col">
                                             <label class="col-form-label pt-0 font-weight-bolder">Mark</label>
                                              <input type="text" class="form-control" value="4" readonly>
                                            </div>
                                       </div>
                                       </div>
                                       </div>
                                    </div>
                                       </div>
                                       </div>
                                       
                                       
                                       <h5 class="text-brown font-weight-bold">Module-iv <span class="text-dark">(statutory Compliance)</span></h5>
                                        <div class="module-sec custom-scroll">
                                        <div class="mr-3">
                                       <div class="row">
                                       <div class="col-lg-6">
                                       <div class="bg-light p-2  border mb-4">
                                         <label class="col-form-label font-weight-bolder pt-0 d-block">Submission of All returns and last assessment</label>
                                       
                                            <div class="row">
                                            <div class="col-sm-12">
                                             <label class="col-form-label pt-0 font-weight-bolder">Details to be provided</label>
                                               <input type="text" class="form-control form-group" value=" We have submited all returns and done assesment up to 30.06.2020 timely.">
                                            </div>
                                           
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Max Mark</label>
                                              <input type="text" class="form-control form-group" placeholder="5" readonly>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Lessee Mark</label>
                                              <select class="form-control disable form-group" readonly="readonly">
                                                    <option>Select Lessee Mark</option>
                                                    <option>&gt;= 50% to 100%</option>
                                                    <option>Between 30% &amp; 50%</option>
                                                    <option>&lt;= 30% and &gt; 100%</option>
                                                </select>
                                            </div>
                                             <div class="col-sm-6">
                                             <label class="col-form-label pt-0 font-weight-bolder">Mining Inspector Mark</label>
                                              <select class="form-control disable form-group" readonly="readonly">
                                                <option selected="selected" value="0">select Mining Inspector Mark</option>
                                                    <option value="5">&gt;= 50% to 100%</option>
                                                    <option value="2">Between 30% &amp; 50%</option>
                                                    <option value="0">&lt;= 30% and &gt; 100%</option>
                                                </select>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Comment</label>
                                                <textarea  rows="1"  class="form-control form-group" placeholder="Enter remark"></textarea>
                                            </div>
                                           
                                            
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">DD/MO Mark</label>
                                              <select class="form-control disable form-group" readonly="readonly">
                                                        <option>Select DD/MO Mark</option>
                                                        <option value="5">&gt;= 50% to 100%</option>
                                                        <option value="2">Between 30% &amp; 50%</option>
                                                        <option>&lt;= 30% and &gt; 100%</option>
                                                    </select>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Comment</label>
                                             <textarea  rows="1"  class="form-control form-group" placeholder="Enter remark"></textarea>
                                            </div>
                                            
                                       
                                             
                                            <div class="col-sm-6">
                                              <label class="col-form-label pt-0 font-weight-bolder">DGM Mark</label>                             
                                            <select class="form-control form-group">
                                            <option>Select DGM Mark</option>
                                            <option>&gt;= 50% to 100%</option>
                                            <option>Between 30% &amp; 50%</option>
                                            <option>&lt;= 30% and &gt; 100%</option>
                                        </select>

                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Comment</label>
                                              <textarea  rows="1"  class="form-control form-group" placeholder="Enter remark"></textarea>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Mark</label>
                                              <input type="text" class="form-control form-group" placeholder="0" readonly>
                                            </div>
                                       </div>
                                       </div>
                                       </div>
                                        <div class="col-lg-6">
                                       <div class="bg-light p-2  border mb-4">
                                         <label class="col-form-label font-weight-bolder pt-0 d-block">Rectification of all the violations pointed out by any Govt Agencies DGMS ,MRD,SPCB</label>
                                        

                                            <div class="row">
                                            <div class="col-sm-12">
                                             <label class="col-form-label pt-0 font-weight-bolder">Details to be provided</label>
                                               <input type="text" class="form-control form-group">
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Max Mark</label>
                                              <input type="text" class="form-control form-group" placeholder="5" readonly>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Lessee Mark</label>
                                              <select class="form-control disable form-group" readonly="readonly">
                                                    <option>Select Lessee Mark</option>
                                                    <option>&gt;= 50% to 100%</option>
                                                    <option>Between 30% &amp; 50%</option>
                                                    <option>&lt;= 30% and &gt; 100%</option>
                                                </select>
                                            </div>
                                             <div class="col-sm-6">
                                             <label class="col-form-label pt-0 font-weight-bolder">Mining Inspector Mark</label>
                                              <select class="form-control disable form-group" readonly="readonly">
                                                <option selected="selected" value="0">select Mining Inspector Mark</option>
                                                    <option value="5">&gt;= 50% to 100%</option>
                                                    <option value="2">Between 30% &amp; 50%</option>
                                                    <option value="0">&lt;= 30% and &gt; 100%</option>
                                                </select>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Comment</label>
                                                <textarea  rows="1"  class="form-control form-group" placeholder="Enter remark"></textarea>
                                            </div>
                                           
                                            
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">DD/MO Mark</label>
                                              <select class="form-control disable form-group" readonly="readonly">
                                                        <option>Select DD/MO Mark</option>
                                                        <option value="5">&gt;= 50% to 100%</option>
                                                        <option value="2">Between 30% &amp; 50%</option>
                                                        <option>&lt;= 30% and &gt; 100%</option>
                                                    </select>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Comment</label>
                                             <textarea  rows="1"  class="form-control form-group" placeholder="Enter remark"></textarea>
                                            </div>
                                            
                                       
                                             
                                            <div class="col-sm-6">
                                              <label class="col-form-label pt-0 font-weight-bolder">DGM Mark</label>                             
                                            <select class="form-control form-group">
                                            <option>Select DGM Mark</option>
                                            <option>&gt;= 50% to 100%</option>
                                            <option>Between 30% &amp; 50%</option>
                                            <option>&lt;= 30% and &gt; 100%</option>
                                        </select>

                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Comment</label>
                                              <textarea  rows="1"  class="form-control form-group" placeholder="Enter remark"></textarea>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Mark</label>
                                              <input type="text" class="form-control form-group" placeholder="0" readonly>
                                            </div>
                                       </div>
                                       </div>
                                       </div>
                                        <div class="col-lg-6">
                                       <div class="bg-light p-2  border mb-4">
                                         <label class="col-form-label font-weight-bolder pt-0 d-block">
                                         Appointment of Competent persons as per statute(QUARRY PLAN) MinesManager
                                         <a href="#"><i class="fa fa-download ml-2" aria-hidden="true"></i></a></label>
                                        

                                            <div class="row">
                                             <div class="col-sm-12">
                                             <label class="col-form-label pt-0 font-weight-bolder">Enter Name</label>
                                               <input type="text" class="form-control form-group">
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Max Mark</label>
                                              <input type="text" class="form-control form-group" placeholder="5" readonly>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Lessee Mark</label>
                                              <select class="form-control disable form-group" readonly="readonly">
                                                    <option>Select Lessee Mark</option>
                                                    <option>&gt;= 50% to 100%</option>
                                                    <option>Between 30% &amp; 50%</option>
                                                    <option>&lt;= 30% and &gt; 100%</option>
                                                </select>
                                            </div>
                                             <div class="col-sm-6">
                                             <label class="col-form-label pt-0 font-weight-bolder">Mining Inspector Mark</label>
                                              <select class="form-control disable form-group" readonly="readonly">
                                                <option selected="selected" value="0">select Mining Inspector Mark</option>
                                                    <option value="5">&gt;= 50% to 100%</option>
                                                    <option value="2">Between 30% &amp; 50%</option>
                                                    <option value="0">&lt;= 30% and &gt; 100%</option>
                                                </select>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Comment</label>
                                                <textarea  rows="1"  class="form-control form-group" placeholder="Enter remark"></textarea>
                                            </div>
                                           
                                            
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">DD/MO Mark</label>
                                              <select class="form-control disable form-group" readonly="readonly">
                                                        <option>Select DD/MO Mark</option>
                                                        <option value="5">&gt;= 50% to 100%</option>
                                                        <option value="2">Between 30% &amp; 50%</option>
                                                        <option>&lt;= 30% and &gt; 100%</option>
                                                    </select>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Comment</label>
                                             <textarea  rows="1"  class="form-control form-group" placeholder="Enter remark"></textarea>
                                            </div>
                                            
                                       
                                             
                                            <div class="col-sm-6">
                                              <label class="col-form-label pt-0 font-weight-bolder">DGM Mark</label>                             
                                            <select class="form-control form-group">
                                            <option>Select DGM Mark</option>
                                            <option>&gt;= 50% to 100%</option>
                                            <option>Between 30% &amp; 50%</option>
                                            <option>&lt;= 30% and &gt; 100%</option>
                                        </select>

                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Comment</label>
                                              <textarea  rows="1"  class="form-control form-group" placeholder="Enter remark"></textarea>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Mark</label>
                                              <input type="text" class="form-control form-group" placeholder="0" readonly>
                                            </div>
                                      
                                       </div>
                                       </div>
                                       </div>
                                       <div class="col-lg-6">
                                       <div class="bg-light p-2  border mb-4">
                                         <label class="col-form-label font-weight-bolder pt-0 d-block">
                                       Appointment of Competent persons as per statute(QUARRY PLAN)  Foreman
                                         <a href="#"><i class="fa fa-download ml-2" aria-hidden="true"></i></a></label>
                                        

                                            <div class="row">
                                             <div class="col-sm-12">
                                             <label class="col-form-label pt-0 font-weight-bolder">Enter Name</label>
                                               <input type="text" class="form-control form-group">
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Max Mark</label>
                                              <input type="text" class="form-control form-group" placeholder="5" readonly>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Lessee Mark</label>
                                              <select class="form-control disable form-group" readonly="readonly">
                                                    <option>Select Lessee Mark</option>
                                                    <option>&gt;= 50% to 100%</option>
                                                    <option>Between 30% &amp; 50%</option>
                                                    <option>&lt;= 30% and &gt; 100%</option>
                                                </select>
                                            </div>
                                             <div class="col-sm-6">
                                             <label class="col-form-label pt-0 font-weight-bolder">Mining Inspector Mark</label>
                                              <select class="form-control disable form-group" readonly="readonly">
                                                <option selected="selected" value="0">select Mining Inspector Mark</option>
                                                    <option value="5">&gt;= 50% to 100%</option>
                                                    <option value="2">Between 30% &amp; 50%</option>
                                                    <option value="0">&lt;= 30% and &gt; 100%</option>
                                                </select>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Comment</label>
                                                <textarea  rows="1"  class="form-control form-group" placeholder="Enter remark"></textarea>
                                            </div>
                                           
                                            
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">DD/MO Mark</label>
                                              <select class="form-control disable form-group" readonly="readonly">
                                                        <option>Select DD/MO Mark</option>
                                                        <option value="5">&gt;= 50% to 100%</option>
                                                        <option value="2">Between 30% &amp; 50%</option>
                                                        <option>&lt;= 30% and &gt; 100%</option>
                                                    </select>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Comment</label>
                                             <textarea  rows="1"  class="form-control form-group" placeholder="Enter remark"></textarea>
                                            </div>
                                            
                                       
                                             
                                            <div class="col-sm-6">
                                              <label class="col-form-label pt-0 font-weight-bolder">DGM Mark</label>                             
                                            <select class="form-control form-group">
                                            <option>Select DGM Mark</option>
                                            <option>&gt;= 50% to 100%</option>
                                            <option>Between 30% &amp; 50%</option>
                                            <option>&lt;= 30% and &gt; 100%</option>
                                        </select>

                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Comment</label>
                                              <textarea  rows="1"  class="form-control form-group" placeholder="Enter remark"></textarea>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Mark</label>
                                              <input type="text" class="form-control form-group" placeholder="0" readonly>
                                            </div>
                                      
                                       </div>
                                       </div>
                                       </div>
                                       <div class="col-lg-6">
                                       <div class="bg-light p-2  border mb-4">
                                         <label class="col-form-label font-weight-bolder pt-0 d-block">
                                       Appointment of Competent persons as per statute(QUARRY PLAN) Mining Mate
                                         <a href="#"><i class="fa fa-download ml-2" aria-hidden="true"></i></a></label>
                                        

                                            <div class="row">
                                             <div class="col-sm-12">
                                             <label class="col-form-label pt-0 font-weight-bolder">Enter Name</label>
                                               <input type="text" class="form-control form-group">
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Max Mark</label>
                                              <input type="text" class="form-control form-group" placeholder="5" readonly>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Lessee Mark</label>
                                              <select class="form-control disable form-group" readonly="readonly">
                                                    <option>Select Lessee Mark</option>
                                                    <option>&gt;= 50% to 100%</option>
                                                    <option>Between 30% &amp; 50%</option>
                                                    <option>&lt;= 30% and &gt; 100%</option>
                                                </select>
                                            </div>
                                             <div class="col-sm-6">
                                             <label class="col-form-label pt-0 font-weight-bolder">Mining Inspector Mark</label>
                                              <select class="form-control disable form-group" readonly="readonly">
                                                <option selected="selected" value="0">select Mining Inspector Mark</option>
                                                    <option value="5">&gt;= 50% to 100%</option>
                                                    <option value="2">Between 30% &amp; 50%</option>
                                                    <option value="0">&lt;= 30% and &gt; 100%</option>
                                                </select>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Comment</label>
                                                <textarea  rows="1"  class="form-control form-group" placeholder="Enter remark"></textarea>
                                            </div>
                                           
                                            
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">DD/MO Mark</label>
                                              <select class="form-control disable form-group" readonly="readonly">
                                                        <option>Select DD/MO Mark</option>
                                                        <option value="5">&gt;= 50% to 100%</option>
                                                        <option value="2">Between 30% &amp; 50%</option>
                                                        <option>&lt;= 30% and &gt; 100%</option>
                                                    </select>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Comment</label>
                                             <textarea  rows="1"  class="form-control form-group" placeholder="Enter remark"></textarea>
                                            </div>
                                            
                                       
                                             
                                            <div class="col-sm-6">
                                              <label class="col-form-label pt-0 font-weight-bolder">DGM Mark</label>                             
                                            <select class="form-control form-group">
                                            <option>Select DGM Mark</option>
                                            <option>&gt;= 50% to 100%</option>
                                            <option>Between 30% &amp; 50%</option>
                                            <option>&lt;= 30% and &gt; 100%</option>
                                        </select>

                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Comment</label>
                                              <textarea  rows="1"  class="form-control form-group" placeholder="Enter remark"></textarea>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Mark</label>
                                              <input type="text" class="form-control form-group" placeholder="0" readonly>
                                            </div>
                                      
                                       </div>
                                       </div>
                                       </div>
                                       <div class="col-lg-6">
                                       <div class="bg-light p-2  border mb-4">
                                         <label class="col-form-label font-weight-bolder pt-0 d-block">
                                       Appointment of Competent persons as per statute(QUARRY PLAN) Blaster
                                         <a href="#"><i class="fa fa-download ml-2" aria-hidden="true"></i></a></label>
                                        

                                            <div class="row">
                                             <div class="col-sm-12">
                                             <label class="col-form-label pt-0 font-weight-bolder">Enter Name</label>
                                               <input type="text" class="form-control form-group">
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Max Mark</label>
                                              <input type="text" class="form-control form-group" placeholder="5" readonly>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Lessee Mark</label>
                                              <select class="form-control disable form-group" readonly="readonly">
                                                    <option>Select Lessee Mark</option>
                                                    <option>&gt;= 50% to 100%</option>
                                                    <option>Between 30% &amp; 50%</option>
                                                    <option>&lt;= 30% and &gt; 100%</option>
                                                </select>
                                            </div>
                                             <div class="col-sm-6">
                                             <label class="col-form-label pt-0 font-weight-bolder">Mining Inspector Mark</label>
                                              <select class="form-control disable form-group" readonly="readonly">
                                                <option selected="selected" value="0">select Mining Inspector Mark</option>
                                                    <option value="5">&gt;= 50% to 100%</option>
                                                    <option value="2">Between 30% &amp; 50%</option>
                                                    <option value="0">&lt;= 30% and &gt; 100%</option>
                                                </select>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Comment</label>
                                                <textarea  rows="1"  class="form-control form-group" placeholder="Enter remark"></textarea>
                                            </div>
                                           
                                            
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">DD/MO Mark</label>
                                              <select class="form-control disable form-group" readonly="readonly">
                                                        <option>Select DD/MO Mark</option>
                                                        <option value="5">&gt;= 50% to 100%</option>
                                                        <option value="2">Between 30% &amp; 50%</option>
                                                        <option>&lt;= 30% and &gt; 100%</option>
                                                    </select>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Comment</label>
                                             <textarea  rows="1"  class="form-control form-group" placeholder="Enter remark"></textarea>
                                            </div>
                                            
                                       
                                             
                                            <div class="col-sm-6">
                                              <label class="col-form-label pt-0 font-weight-bolder">DGM Mark</label>                             
                                            <select class="form-control form-group">
                                            <option>Select DGM Mark</option>
                                            <option>&gt;= 50% to 100%</option>
                                            <option>Between 30% &amp; 50%</option>
                                            <option>&lt;= 30% and &gt; 100%</option>
                                        </select>

                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Comment</label>
                                              <textarea  rows="1"  class="form-control form-group" placeholder="Enter remark"></textarea>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Mark</label>
                                              <input type="text" class="form-control form-group" placeholder="0" readonly>
                                            </div>
                                      
                                       </div>
                                       </div>
                                       </div>
                                       <div class="col-lg-6">
                                       <div class="bg-light p-2  border mb-4">
                                         <label class="col-form-label font-weight-bolder pt-0 d-block">
                                       Authenticated lease Sketch with Boundary Co-ordinates
                                         <a href="#"><i class="fa fa-download ml-2" aria-hidden="true"></i></a></label>
                                        

                                            <div class="row">
                                             
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Max Mark</label>
                                              <input type="text" class="form-control form-group" placeholder="5" readonly>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Lessee Mark</label>
                                              <select class="form-control disable form-group" readonly="readonly">
                                                    <option>Select Lessee Mark</option>
                                                    <option>&gt;= 50% to 100%</option>
                                                    <option>Between 30% &amp; 50%</option>
                                                    <option>&lt;= 30% and &gt; 100%</option>
                                                </select>
                                            </div>
                                             <div class="col-sm-6">
                                             <label class="col-form-label pt-0 font-weight-bolder">Mining Inspector Mark</label>
                                              <select class="form-control disable form-group" readonly="readonly">
                                                <option selected="selected" value="0">select Mining Inspector Mark</option>
                                                    <option value="5">&gt;= 50% to 100%</option>
                                                    <option value="2">Between 30% &amp; 50%</option>
                                                    <option value="0">&lt;= 30% and &gt; 100%</option>
                                                </select>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Comment</label>
                                                <textarea  rows="1"  class="form-control form-group" placeholder="Enter remark"></textarea>
                                            </div>
                                           
                                            
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">DD/MO Mark</label>
                                              <select class="form-control disable form-group" readonly="readonly">
                                                        <option>Select DD/MO Mark</option>
                                                        <option value="5">&gt;= 50% to 100%</option>
                                                        <option value="2">Between 30% &amp; 50%</option>
                                                        <option>&lt;= 30% and &gt; 100%</option>
                                                    </select>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Comment</label>
                                             <textarea  rows="1"  class="form-control form-group" placeholder="Enter remark"></textarea>
                                            </div>
                                            
                                       
                                             
                                            <div class="col-sm-6">
                                              <label class="col-form-label pt-0 font-weight-bolder">DGM Mark</label>                             
                                            <select class="form-control form-group">
                                            <option>Select DGM Mark</option>
                                            <option>&gt;= 50% to 100%</option>
                                            <option>Between 30% &amp; 50%</option>
                                            <option>&lt;= 30% and &gt; 100%</option>
                                        </select>

                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Comment</label>
                                              <textarea  rows="1"  class="form-control form-group" placeholder="Enter remark"></textarea>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Mark</label>
                                              <input type="text" class="form-control form-group" placeholder="0" readonly>
                                            </div>
                                      
                                       </div>
                                       </div>
                                       </div>
                                       <div class="col-lg-6">
                                       <div class="bg-light p-2  border mb-4">
                                         <label class="col-form-label font-weight-bolder pt-0 d-block">
                                      Erection of DGPS/GPS Boundary Pillars in the lease area as per rule
                                         <a href="#"><i class="fa fa-download ml-2" aria-hidden="true"></i></a></label>
                                        

                                            <div class="row">
                                             
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Max Mark</label>
                                              <input type="text" class="form-control form-group" placeholder="5" readonly>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Lessee Mark</label>
                                              <select class="form-control disable form-group" readonly="readonly">
                                                    <option>Select Lessee Mark</option>
                                                    <option>&gt;= 50% to 100%</option>
                                                    <option>Between 30% &amp; 50%</option>
                                                    <option>&lt;= 30% and &gt; 100%</option>
                                                </select>
                                            </div>
                                             <div class="col-sm-6">
                                             <label class="col-form-label pt-0 font-weight-bolder">Mining Inspector Mark</label>
                                              <select class="form-control disable form-group" readonly="readonly">
                                                <option selected="selected" value="0">select Mining Inspector Mark</option>
                                                    <option value="5">&gt;= 50% to 100%</option>
                                                    <option value="2">Between 30% &amp; 50%</option>
                                                    <option value="0">&lt;= 30% and &gt; 100%</option>
                                                </select>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Comment</label>
                                                <textarea  rows="1"  class="form-control form-group" placeholder="Enter remark"></textarea>
                                            </div>
                                           
                                            
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">DD/MO Mark</label>
                                              <select class="form-control disable form-group" readonly="readonly">
                                                        <option>Select DD/MO Mark</option>
                                                        <option value="5">&gt;= 50% to 100%</option>
                                                        <option value="2">Between 30% &amp; 50%</option>
                                                        <option>&lt;= 30% and &gt; 100%</option>
                                                    </select>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Comment</label>
                                             <textarea  rows="1"  class="form-control form-group" placeholder="Enter remark"></textarea>
                                            </div>
                                            
                                       
                                             
                                            <div class="col-sm-6">
                                              <label class="col-form-label pt-0 font-weight-bolder">DGM Mark</label>                             
                                            <select class="form-control form-group">
                                            <option>Select DGM Mark</option>
                                            <option>&gt;= 50% to 100%</option>
                                            <option>Between 30% &amp; 50%</option>
                                            <option>&lt;= 30% and &gt; 100%</option>
                                        </select>

                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Comment</label>
                                              <textarea  rows="1"  class="form-control form-group" placeholder="Enter remark"></textarea>
                                            </div>
                                            <div class="col-sm-6">
                                            <label class="col-form-label pt-0 font-weight-bolder">Mark</label>
                                              <input type="text" class="form-control form-group" placeholder="0" readonly>
                                            </div>
                                      
                                       </div>
                                       </div>
                                       </div>
                                       
                                     
                                       <div class="col-lg-12">
                                       <div class="bg-light p-2  border mb-4">
                                         <label class="col-form-label font-weight-bolder pt-0 d-block">Total</label>
                                            <div class="form-group row">
                                            <div class="col">
                                              <label class="col-form-label pt-0 font-weight-bolder">Max Mark</label>
                                              <input type="text" class="form-control" value="5" readonly>
                                            </div>
                                            <div class="col">
                                             <label class="col-form-label pt-0 font-weight-bolder">Lessee Mark</label>
                                              <input type="text" class="form-control" value="7"  readonly>
                                            </div>
                                            <div class="col">
                                            <label class="col-form-label pt-0 font-weight-bolder">Mining Inspector Mark</label>
                                             <input type="text" class="form-control" value="9" readonly>
                                            </div>
                                           
                                            <div class="col">
                                              <label class="col-form-label pt-0 font-weight-bolder">DD/MO Mark</label>
                                              <input type="text" class="form-control" value="14" readonly>
                                            </div>
                                            
                                            <div class="col">
                                            <label class="col-form-label pt-0 font-weight-bolder">DGM Mark</label>
                                                <input type="text" class="form-control" value="3" readonly>
                                            </div>
                                        
                                            <div class="col">
                                             <label class="col-form-label pt-0 font-weight-bolder">Mark</label>
                                              <input type="text" class="form-control" value="4" readonly>
                                            </div>
                                       </div>
                                       </div>
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
                                  <div class="tab-pane fade" id="Confirmation" role="tabpanel" aria-labelledby="Confirmation-tab">
                                        <div class="mb-md-4">
                                        <h5 class="text-brown font-weight-bold">Summary points for star rating</h5>
                                            <div class="bg-light p-2 form-group border">
                                            <div class="row">
                                             <div class="col-sm-4">
                                               <label class="col-form-label font-weight-bolder">Applicable Maximum Points</label>
                                               <input type="text" class="form-control" value="10" readonly="">
                                            </div>
                                             <div class="col-sm-4">
                                             <label class="col-form-label font-weight-bolder">Points Scored</label>
                                              <input type="text" class="form-control" value="5" readonly="">
                                            </div>
                                       </div>
                                       </div>
                                        </div>

                                       
                                           
                                            <div class="row">
                                            <div class="col-sm-12">
                                            <h5 class="text-brown font-weight-bold">Overall performance & star rating</h5>
                                             <div class="table-responsive">
                                             <table class="table table-bordered">
                                    <thead>
                                        <tr>
                                            <th width="120px" class="font-weight-bold">Series</th>
                                            <th class="font-weight-bold">Module Name</th>
                                            <th class="font-weight-bold">Sum of Applicable Maximum Points in all Modules(a)</th>
                                            <th class="font-weight-bold">Sum of Points Scored in all Modules (b)</th>
                                            <th class="font-weight-bold">Percentage (b/a)*100</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <td>
                                                Module 1
                                            </td>
                                            <td>
                                                Systamatic and sustainable mining
                                            </td>
                                            <td>
                                                30
                                            </td>
                                            <td>
                                                <label id="lblsumSS"></label>

                                            </td>
                                            <td>
                                                <label id="lblpSS"></label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Module 2
                                            </td>
                                            <td>
                                                Protection of environment and conservation of water
                                            </td>
                                            <td>
                                                25
                                            </td>
                                            <td>
                                                <label id="lblsumPE"></label>
                                            </td>
                                            <td>
                                                <label id="lblpPE"></label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Module 3
                                            </td>
                                            <td>
                                                Health safety and welfare of workers
                                            </td>
                                            <td>
                                                15
                                            </td>
                                            <td>
                                                <label id="lblsumHS"></label>
                                            </td>
                                            <td>
                                                <label id="lblpHS"></label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Module 4
                                            </td>
                                            <td>
                                                Statutory compliance
                                            </td>
                                            <td>
                                                30
                                            </td>
                                            <td>
                                                <label id="lblsumSC"></label>
                                            </td>
                                            <td>
                                                <label id="lblpSC"></label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                TOTAL
                                            </td>
                                            <td></td>
                                            <td>
                                                100
                                            </td>
                                            <td><label id="TotalPoint"></label></td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                % Obtained
                                            </td>
                                            <td colspan="3">
                                                <label id="PercentObtained"></label>
                                            </td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Star Rating
                                            </td>
                                            <td colspan="3">
                                                <label id="lblstarRating"></label>
                                            </td>
                                            <td></td>
                                        </tr>
                                    </tbody>
                                </table>
                                            </div>
                                             </div>
                                            <div class="col-sm-6">
                                            <h5 class="text-brown font-weight-bold">Criteria for star rating</h5>
                                            <div class="table-responsive">
                                            <table class="table table-bordered mb-0">
                                            <thead>
                                            <tr>
                                            <th class="font-weight-bold">Percentage obtained</th>
                                            <th width="100px" class="font-weight-bold">Criteria</th>
                                        </tr>
                                            </thead>
                                    <tbody>
                                        
                                        <tr>
                                            <td> = &gt; 80 to 100 %</td>
                                            <td> 5 Star</td>
                                        </tr>
                                        <tr>
                                            <td>
                                                = &gt; 60 to &lt; 80 %
                                            </td>
                                            <td>
                                                4 Star
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                = &gt; 50 to &lt; 60 %
                                            </td>
                                            <td>
                                                3 Star
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                 = &gt; 40 to &lt; 50 %
                                            </td>
                                            <td>
                                                2 Star
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                 = &gt; 25 to &lt; 40 %
                                            </td>
                                            <td>
                                                1 Star
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &lt; = 25 %
                                            </td>
                                            <td>
                                                No rating
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                                            </div>
                                            </div>
                                            </div>
                                               
                          
                                      

                                        

                                      <div class="row mt-3">
                                        <div class="col-sm-12 text-center">
                                            <a  class="btn btn-dark btn-md ml-0 waves-effect waves-light btnPrevious">Previous</a>
                                           
                                            <a class="btn btn-success btn-md ml-0 waves-effect waves-light">Save & Update</a> 
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
    <style type="text/css">
        .col-form-label {padding-top: 0rem;}
        
    </style>
     <link href="../css/bootstrap-datetimepicker.min.css" rel="stylesheet">
    <script src="../js/moment.min.js"></script> 
    <script src="../js/bootstrap-datetimepicker.min.js"></script>
    
    <script>
        indicateMe = "yes"
        backMe="yes"
        $(document).ready(function () {
            loadNavigation('StarRatingMinorMineralst', 'glStar', 'pl', 'tl', 'Star Rating Minor Minerals', 'Star Rating Minor Minerals', '');
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
    <script>
        var add = '<tr><td id="t1"><select  class="form-control"><option value="Select">Select</option></select></td><td id="t2"><input type="text" class="form-control"></td><td><button class="btn btn-danger btn-md remove  m-0 mr-1" data-toggle="tooltip" data-placement="top" title="Remove Row"><i class="fa fa-times" aria-hidden="true"></i></button><a href="#" class="btn btn-success btn-md add-btn  m-0 mr-1" data-toggle="tooltip" data-placement="top" title="Add Row"><i class="fa fa-plus" aria-hidden="true"></i></a></td></tr>;'

        $(document).ready(function () {
            $(document).on('click', '.add-btn', function () {
                $("#insert").find('tbody').append(add);
               // $('a').tooltip('enable');
            });

            $("#insert").on('Click', '.remove', function () {
                $(this).parents('tr').remove();
               // $('a').tooltip('enable');

            });

            $(function () {
                $("body").tooltip({
                    selector: '[data-toggle="tooltip"]',
                    container: 'body'
                });
            })

        }); 
</script>

<script>
     $(document).ready(function () {
         $(window).on("load resize ", function () {
             var scrollWidth = $('.tbl-content').width() - $('.tbl-content table').width();
             $('.tbl-header').css({ 'padding-right': scrollWidth });
         }).resize();
});
</script>
    
</body>
</html>

