<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LesseeProfile.aspx.cs" Inherits="RolesResponsibity_LesseeProfile" %>
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
                                           Lessee Profile
                                        </a>
                                    </li>
                                   
                                </ul>
                                
                                <uc1:util runat="server" ID="util" />
                              
                            </div>

                            <section class="box form-container">
                                <div class="content-body">
                                <div class=" mb-2">
                                    <div class="col bg-light px-3 py-2 mb-2">
                                        <div class="row">
                                          <div class="col-lg-8">
                                           <div class="row">
                                            <div class="col">
                                                 <p class="mb-3 "><span class="font-weight-bold">Customer Id :</span> <span class="badge badge-info font-weight-bold" style="font-size:16px;">2075077501</span></p>
                                             </div>
                                             <div class="col">
                                                <p class="mb-3"><span class="font-weight-bold">Status :</span> <span class="text-primary">Progress / </span><span class="text-warning">In-Progress</span></p>
                                             </div>
                                             </div>
                                             <div class="row">
                                             <div class="col">
                                                <p class="mb-0"><span class="font-weight-bold">Mobile Number :</span> 9617196726</p>
                                             </div>
                                             <div class="col">
                                                <p class="mb-0"><span class="font-weight-bold">Email Id :</span> ppssaigal@sail-bhilaisteel.com</p>
                                             </div>
                                           </div>
                                           </div>
                                           <div class="col-lg-4"> 
                                               <p class="m-0 text-primary font-weight-550">Click to switch different offices<small> <span class="d-md-block">(Mobile No. & Email Id)</span></small></p>
                                               <ul class="offices-switch d-flex pl-0  mb-0 pl-0 list-unstyled">
                                                   <li class="mr-2"><a href="#" title="Click corporate office">1. Corporate</a></li>
                                                   <li class="mr-2"><a href="#" title="Click branch office">2. Branch</a></li>
                                                   <li class="mr-2"><a href="#" title="Click site office">3. Site</a></li>
                                                   <li><a href="#" title="Click agent office">4. Agent</a></li>
                                               </ul>
                                           </div>
                                        </div>
                                       
                                        
                                    </div>
                                    <div class="col">
                                         <ul class="lessee-legend d-flex pl-0 list-unstyled">
                                        <li class="mr-4"><i class="fas fa-circle text-success mr-2"></i><span>Application Approved</span></li>
                                        <li> <i class="fas fa-circle text-primary mr-2"></i><span>Application Forwarded</span></li>
                                    </ul>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-9">
                                        <div class="lessee-profile-left">
                                        <div class="row">
                                              <div class="col-lg-4 col-md-6 col-sm-12">
                                                <div class="card mb-4 ">
                                                  <div class="card-body ">
                                                        <div class="d-flex justify-content-between">
                                                            <h6 class="card-title mt-0 font-weight-bold  text-brown">Lessee Application Details</h6>
                                                            <i class="fas fa-circle text-success"></i>
                                                      </div>
                                                      
                                                     <div class="custom-scroll lessee-body">
                                                    <div class="mr-2">
                                                    <p class="card-text mb-0">
                                                        <p  class="mb-1"><span class="font-weight-bold">Name :</span> Hirri Dolomite Mines , SAIL Bhilai Steel Plant Bilaspur- Area:128.770 (Pendridih(tehsil-bilha)Chtoun</p>
                                                        <p class="mb-1"><span class="font-weight-bold">Type :</span> QL , Mine Code : 2075077501</p>
                                                        <p class="mb-1"><span class="font-weight-bold">Address :</span> Hiri Dolomite Mines, post - Hi ...</p>
                                                        <p class="mb-0"><span class="font-weight-bold">Application Type :</span> Without Auction</p>
                                                    </p>
                                                    </div>
                                                    </div>
                                                   
                                                  <div class="lessee-footer">
                                                     <p class="text-brown mb-2">Attachments <i class="fas fa-paperclip"></i></p>
                                                      <ul class="d-inline-flex  pl-0 list-unstyled mb-0 border">
                                                          <li class="border-right px-2"><a href="#" data-toggle="modal" data-target="#attachment" title="Application Form">A</a></li>
                                                          <li class="border-right px-2"><a href="#" data-toggle="modal" data-target="#attachment" title="Spot Inspection and Analysis Report">S</a></li>
                                                          <li class="border-right px-2"><a href="#" data-toggle="modal" data-target="#attachment" title="Mining Inspector Report">M</a></li>
                                                          <li class="border-right px-2"><a href="#" data-toggle="modal" data-target="#attachment" title="Khasara Panchshala">K</a></li>
                                                          <li class="border-right px-2"><a href="#" data-toggle="modal" data-target="#attachment" title="Forest Report">F</a></li>
                                                          <li class="border-right px-2"><a href="#" data-toggle="modal" data-target="#attachment" title="Gram Panchayat Proposal">G</a></li>
                                                          <li class="border-right px-2"><a href="#" data-toggle="modal" data-target="#attachment" title="Revenue Officer Report">R</a></li>
                                                          <li class="border-right px-2"><a href="#" data-toggle="modal" data-target="#attachment" title="Map/Plan of Granted area">M</a></li>
                                                      </ul>
                                                  </div>
                                                   <a class="view-more text-brown" href="../LesseeProfile/LesseDetails.aspx" title="View Details">View More</a>
                                                  </div>
                                                  
                                               
                                                </div>
                                                
                                              </div>
                                              <div class="col-lg-4 col-md-6 col-sm-12">
                                                <div class="card mb-4">
                                                  <div class="card-body">
                                                  <div class="d-flex justify-content-between">
                                                     <h6 class="card-title mt-0 font-weight-bold  text-brown">Grant Order &amp; Lease Deed Details</h6>
                                                     <i class="fas fa-circle text-success"></i>
                                                     </div>
                                                     <div class="custom-scroll lessee-body">
                                                    <div class="mr-2">
                                                     <p class="card-text">
                                                        <p class="mb-1"><span class="font-weight-bold">Order No :</span> f-3-2/2019/12</p>
                                                        <p class="mb-1"><span class="font-weight-bold">Order Date :</span> 28/02/2020</p>
                                                        <p class="mb-1"><span class="font-weight-bold">Lease Deed No. :</span> 0</p>
                                                        <p class="mb-1"><span class="font-weight-bold">Lease Deed Date :</span> 31/03/2020</p>
                                                        <p class="mb-0"><span class="font-weight-bold">Lease Validity :</span> 06/05/1959 to 05/05/2029</p>
                                                     </p>
                                                     </div>
                                                     </div>
                                                   <div class="lessee-footer">
                                                     <p class="text-brown mb-2">Attachments <i class="fas fa-paperclip"></i></p>
                                                      <ul class="d-inline-flex  pl-0 list-unstyled mb-0 border">
                                                          <li class="border-right px-2"><a href="#" data-toggle="modal" data-target="#attachment" title="Grant Order Copy">G</a></li>
                                                          <li class="border-right px-2"><a href="#" data-toggle="modal" data-target="#attachment" title="Lease Deed Copy" >D</a></li>
                                                      </ul>
                                                  </div>
                                                  <a class="view-more text-brown" href="../LesseeProfile/GrantOrderDetails.aspx" title="View Details">View More</a>
                                                  </div>
                                                
                                                </div>
                                              </div>
                                              <div class="col-lg-4 col-md-6 col-sm-12">
                                                <div class="card mb-4">
                                                  <div class="card-body">
                                                  <div class="d-flex justify-content-between">
                                                      <h6 class="card-title mt-0 font-weight-bold  text-brown">Lease Information Details</h6>
                                                      <i class="fas fa-circle text-success"></i>
                                                      </div>
                                                      <div class="custom-scroll lessee-body">
                                                    <div class="mr-2">
                                                    <p class="card-text">
                                                    <p class="mb-1"><span class="font-weight-bold">Village :</span> CHHATAUNA  &nbsp; District : Bilaspur</p>
                                                        <p class="mb-1"><span class="font-weight-bold">State :</span> Chhattisgarh</p>
                                                        <p class="mb-1"><span class="font-weight-bold">Pin Code :</span> </p>
                                                        <p class="mb-1"><span class="font-weight-bold">Type Of Land :</span> </p>
                                                        <p class="mb-1"><span class="font-weight-bold">Area (Hect):</span> 128.770</p>
                                                        <p class="mb-0"><span class="font-weight-bold">Date Of Agreement :</span> 06/05/1999</p>
                                                    </p>
                                                    </div>
                                                    </div>
                                                    <div class="lessee-footer">
                                                     <p class="text-brown mb-2">Attachments <i class="fas fa-paperclip"></i></p>
                                                      <ul class="d-inline-flex  pl-0 list-unstyled mb-0 border">
                                                          <li class="border-right px-2"><a href="#" data-toggle="modal" data-target="#attachment"  title="Demarcation Report">D</a></li>
                                                          <li class="border-right px-2"><a href="#" data-toggle="modal" data-target="#attachment" title="Working Permission">W</a></li>
                                                      </ul>
                                                  </div>
                                                    <a class="view-more text-brown" href="../LesseeProfile/LeaseInformationDetails.aspx" title="View Details">View More</a>
                                                  </div>
                                                
                                                </div>
                                              </div>
                                               <div class="col-lg-4 col-md-6 col-sm-12">
                                                <div class="card mb-4">
                                                  <div class="card-body">
                                                  <div class="d-flex justify-content-between">
                                                      <h6 class="card-title mt-0 font-weight-bold  text-brown">Mineral Information</h6>
                                                      <i class="fas fa-circle text-success"></i>
                                                      </div>
                                                      <div class="custom-scroll lessee-body">
                                                    <div class="mr-2">
                                                        <p class="card-text">
                                                            <p  class="mb-1"><span class="font-weight-bold">Mineral Name :</span> Dolomite</p>
                                                            <p  class="mb-1"><span class="font-weight-bold">Mineral Category :</span> Minor Mineral</p>
                                                            <p  class="mb-1"><span class="font-weight-bold">Minable Reserve :</span> </p>
                                                            <p  class="mb-1"><span class="font-weight-bold">Estimated Reserve :</span> </p>
                                                        </p>
                                                        </div>
                                                        </div>
                                                        <a class="view-more text-brown" href="../LesseeProfile/MineralInformation.aspx" title="View Details">View More</a>
                                                
                                                  </div>
                                                
                                                </div>
                                              </div>
                                               <div class="col-lg-4 col-md-6 col-sm-12">
                                                <div class="card mb-4">
                                                  <div class="card-body">
                                                  <div class="d-flex justify-content-between">
                                                      <h6 class="card-title mt-0 font-weight-bold  text-brown">Forest Clearence Details</h6>
                                                      <i class="fas fa-circle text-success"></i>
                                                      </div>
                                                      <div class="custom-scroll lessee-body">
                                                    <div class="mr-2">
                                                    <p class="card-text">
                                                        <p class="mb-1"><span class="font-weight-bold">Approval Date :</span> 16/03/2020</p>
                                                        <p class="mb-1"><span class="font-weight-bold">Validity :</span> No Validity found</p>
                                                    </p>
                                                    </div>
                                                    </div>
                                                    <div class="lessee-footer">
                                                     <p class="text-brown mb-2">Attachments <i class="fas fa-paperclip"></i></p>
                                                      <ul class="d-inline-flex  pl-0 list-unstyled mb-0 border">
                                                          <li class="border-right px-2"><a href="#" data-toggle="modal" data-target="#attachment" title="Forest Clearance Approval Letter">F</a></li>
                                                      </ul>
                                                  </div>
                                                  <a class="view-more text-brown" href="../LesseeProfile/ForestClearenceDetails.aspx" title="View Details">View More</a>
                                                  </div>
                                                
                                                </div>
                                              </div>
                                               <div class="col-lg-4 col-md-6 col-sm-12">
                                                <div class="card mb-4">
                                                  <div class="card-body">
                                                  <div class="d-flex justify-content-between">
                                                      <h6 class="card-title mt-0 font-weight-bold  text-brown">Mining Plan Details</h6>
                                                      <i class="fas fa-circle text-success"></i>
                                                      </div>
                                                      <div class="custom-scroll lessee-body">
                                                    <div class="mr-2">
                                                    <p class="card-text">
                                                        <p class="mb-1"><span class="font-weight-bold">Approval Date :</span> 16/03/2020</p>
                                                        <p class="mb-1"><span class="font-weight-bold">Validity :</span> 01/04/2020 to 05/05/2029</p>
                                                    </p>
                                                    </div>
                                                    </div>
                                                   <div class="lessee-footer">
                                                     <p class="text-brown mb-2">Attachments <i class="fas fa-paperclip"></i></p>
                                                      <ul class="d-inline-flex  pl-0 list-unstyled mb-0 border">
                                                          <li class="border-right px-2"><a href="#" data-toggle="modal" data-target="#attachment" title="MP/SOM Approval Letter">M</a></li>
                                                      </ul>
                                                  </div>
                                                   <a class="view-more text-brown" href="../LesseeProfile/MiningplanDetails.aspx" title="View Details">View More</a>
                                                  </div>
                                                 
                                                </div>
                                              </div>
                                               <div class="col-lg-4 col-md-6 col-sm-12">
                                                <div class="card mb-4">
                                                  <div class="card-body">
                                                  <div class="d-flex justify-content-between">
                                                      <h6 class="card-title mt-0 font-weight-bold  text-brown">Consent to Operate Details</h6>
                                                      <i class="fas fa-circle text-success"></i>
                                                      </div>
                                                      <div class="custom-scroll lessee-body">
                                                    <div class="mr-2">
                                                    <p class="card-text">
                                                     <p class="mb-1"><span class="font-weight-bold">Approval Date :</span> 16/03/2020</p>
                                                        <p class="mb-1"><span class="font-weight-bold">Validity :</span> No Validity found</p>
                                                    </p>
                                                    </div>
                                                    </div>
                                                    <div class="lessee-footer">
                                                     <p class="text-brown mb-2">Attachments <i class="fas fa-paperclip"></i></p>
                                                      <ul class="d-inline-flex  pl-0 list-unstyled mb-0 border">
                                                          <li class="border-right px-2"><a href="#" data-toggle="modal" data-target="#attachment" title="Consent to Operate Letter">O</a></li>
                                                         
                                                      </ul>
                                                  </div>
                                                  <a class="view-more text-brown" href="../LesseeProfile/ConsentToOperateDetails.aspx" title="View Details">View More</a>
                                                  </div>
                                                 
                                                </div>
                                              </div>
                                               <div class="col-lg-4 col-md-6 col-sm-12">
                                                <div class="card mb-4">
                                                  <div class="card-body">
                                                  <div class="d-flex justify-content-between">
                                                      <h6 class="card-title mt-0 font-weight-bold  text-brown">Environment Clearance Details</h6>
                                                      <i class="fas fa-circle text-success"></i>
                                                      </div>
                                                      <div class="custom-scroll lessee-body">
                                                    <div class="mr-2">
                                                    <p class="card-text">
                                                     <p class="mb-1"><span class="font-weight-bold">Approval Date :</span> 16/03/2020</p>
                                                     <p class="mb-1"><span class="font-weight-bold">Approved Quantity :</span> 2000000</p>
                                                        <p class="mb-1"><span class="font-weight-bold">Validity :</span> 01/04/2020 to 05/05/2029</p>
                                                        </p>
                                                        </div>
                                                        </div>
                                                    <div class="lessee-footer">
                                                     <p class="text-brown mb-2">Attachments <i class="fas fa-paperclip"></i></p>
                                                      <ul class="d-inline-flex  pl-0 list-unstyled mb-0 border">
                                                          <li class="border-right px-2"><a href="#" data-toggle="modal" data-target="#attachment" title="EC Approval Letter">E</a></li>
                                                         
                                                      </ul>
                                                  </div>
                                                   <a class="view-more text-brown" href="../LesseeProfile/EnvironmentClearanceDetails.aspx" title="View Details">View More</a>
                                                  </div>
                                                 
                                                </div>
                                              </div>
                                              
                                               <div class="col-lg-4 col-md-6 col-sm-12">
                                                <div class="card">
                                                  <div class="card-body">
                                                  <div class="d-flex justify-content-between">
                                                      <h6 class="card-title mt-0 font-weight-bold  text-brown">Assessment Report</h6>
                                                      <i class="fas fa-circle text-primary"></i>
                                                      </div>
                                                      <div class="custom-scroll lessee-body">
                                                    <div class="mr-2">
                                                    <p class="card-text">
                                                    <p class="mb-1"><span class="font-weight-bold">Revenue Recovery Assessment Date :</span> </p>
                                                    <p class="mb-1"><span class="font-weight-bold">Half Year Assesment Date :</span>   </p>
                                                    </p>
                                                    </div>
                                                    </div>
                                                   <a class="view-more text-brown" href="../LesseeProfile/AssessmentReport.aspx" title="View Details">View More</a>
                                                  </div>
                                               
                                                </div>
                                              </div>
                                               <div class="col-lg-4 col-md-6 col-sm-12">
                                                <div class="card mb-0">
                                                  <div class="card-body">
                                                  <div class="d-flex justify-content-between">
                                                     <h6 class="card-title mt-0 font-weight-bold  text-brown">Payment Details</h6>
                                                     <i class="fas fa-circle text-success"></i>
                                                     </div>
                                                     <div class="custom-scroll lessee-body" style="height: 170px;">
                                                    <div class="mr-2">
                                                    <p class="card-text">
                                                    <p class="mb-1"><span class="font-weight-bold">Paid Royalty :</span> 26730000.00</p>
                                                    <p class="mb-1"><span class="font-weight-bold">DMF :</span> 8019000.00</p>
                                                    <p class="mb-1"><span class="font-weight-bold">Infrastructure &amp; Development Cess :</span> 1350000.00</p>
                                                    <p class="mb-1"><span class="font-weight-bold">Environmental Cess :</span> 26730000.00</p>
                                                    <p class="mb-1"><span class="font-weight-bold">TCS :</span> 26730000.00</p>
                                                    <p class="mb-1"><span class="font-weight-bold">Infrastructure &amp; Development Cess  :</span> 26730000.00</p>
                                                    <p class="mb-0"><span class="font-weight-bold">Environmental Cess :</span> 26730000.00</p>

                                                    
                                                    </p>
                                                    </div>
                                                    </div>
                                                    
                                                  </div>
                                                </div>
                                              </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-lg-3">
                                         <div class="card shadow-sm p-2 lessee-profile-right border">
                                         <h5 class=" font-weight-bold text-center mt-0">Lessee Profile</h5>
                                             <ul class=" pl-0 list-unstyled mb-0 ">
                                                 <li class="pb-2">
                                                    <span><a href="#" class="text-dark font-weight-550">Lessee Details</a></span>
                                                    <div class="progress">
                                                        <div class="progress-bar progress-bar-striped bg-warning progress-bar-animated" role="progressbar" style="width:0%" aria-valuenow="50" aria-valuemin="0" aria-valuemax="100"></div>
                                                    </div>
                                                 </li>

                                                  <li class="pb-2">
                                                    <span><a href="#" class="text-dark font-weight-550">Application Details</a></span>
                                                    <div class="progress">
                                                        <div class="progress-bar progress-bar-striped bg-warning progress-bar-animated" role="progressbar" style="width: 100%" aria-valuenow="50" aria-valuemin="0" aria-valuemax="100">100%</div>
                                                    </div>
                                                 </li>

                                                  <li class="pb-2">
                                                    <span><a href="#" class="text-dark font-weight-550">Grant Order Details</a></span>
                                                    <div class="progress">
                                                        <div class="progress-bar progress-bar-striped bg-warning progress-bar-animated" role="progressbar" style="width: 100%" aria-valuenow="50" aria-valuemin="0" aria-valuemax="100">100%</div>
                                                    </div>
                                                 </li>

                                                  <li class="pb-2">
                                                    <span><a href="#" class="text-dark font-weight-550">Lease Area Details</a></span>
                                                    <div class="progress">
                                                        <div class="progress-bar progress-bar-striped bg-warning progress-bar-animated" role="progressbar" style="width: 100%" aria-valuenow="50" aria-valuemin="0" aria-valuemax="100">100%</div>
                                                    </div>
                                                 </li>

                                                 <li class="pb-2">
                                                    <span><a href="#" class="text-dark font-weight-550">Mineral Information</a></span>
                                                    <div class="progress">
                                                        <div class="progress-bar progress-bar-striped bg-warning progress-bar-animated" role="progressbar" style="width: 100%" aria-valuenow="50" aria-valuemin="0" aria-valuemax="100">100%</div>
                                                    </div>
                                                 </li>

                                                 <li class="pb-2">
                                                    <span><a href="#" class="text-dark font-weight-550">Mining Plan</a></span>
                                                    <div class="progress">
                                                        <div class="progress-bar progress-bar-striped bg-warning progress-bar-animated" role="progressbar" style="width: 100%" aria-valuenow="50" aria-valuemin="0" aria-valuemax="100">100%</div>
                                                    </div>
                                                 </li>

                                                 <li class="pb-2">
                                                    <span><a href="#" class="text-dark font-weight-550">Forest Clearance</a></span>
                                                    <div class="progress">
                                                        <div class="progress-bar progress-bar-striped bg-warning progress-bar-animated" role="progressbar" style="width: 100%" aria-valuenow="50" aria-valuemin="0" aria-valuemax="100">100%</div>
                                                    </div>
                                                 </li>

                                                 <li class="pb-2">
                                                    <span><a href="#" class="text-dark font-weight-550">Environment Clearance</a></span>
                                                    <div class="progress">
                                                        <div class="progress-bar progress-bar-striped bg-warning progress-bar-animated" role="progressbar" style="width: 100%" aria-valuenow="50" aria-valuemin="0" aria-valuemax="100">100%</div>
                                                    </div>
                                                 </li>

                                                 <li class="pb-2">
                                                    <span><a href="#" class="text-dark font-weight-550">Consent to Operate</a></span>
                                                    <div class="progress">
                                                        <div class="progress-bar progress-bar-striped bg-warning progress-bar-animated" role="progressbar" style="width: 100%" aria-valuenow="50" aria-valuemin="0" aria-valuemax="100">100%</div>
                                                    </div>
                                                 </li>

                                                 <li>
                                                    <span><a href="#" class="text-dark font-weight-550">Assessment Report</a></span>
                                                    <div class="progress">
                                                        <div class="progress-bar progress-bar-striped bg-warning progress-bar-animated" role="progressbar" style="width: 0%" aria-valuenow="50" aria-valuemin="0" aria-valuemax="100"></div>
                                                    </div>
                                                 </li>

                                             </ul>
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
    <!-- Attachment Modal -->
<div class="modal fade" id="attachment" tabindex="-1" role="dialog" aria-labelledby="Attachment-Title" aria-hidden="true">
  <div class="modal-dialog modal-dialog-centered" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title mt-0 text-brown" id="Attachment-Title">Attachment Title</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
        <strong class="h5">No Attachment Found</strong>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-primary  btn-sm" data-dismiss="modal">Close</button>
      </div>
    </div>
  </div>
</div>
   


    <script>
        

        $(document).ready(function () {
            loadNavigation('LesseeProfile', 'glRoleRes', 'pllesseprof', 'tl', 'Roles and Responsibity', 'Lessee Profile', ' ');
            $(function () {
                $("body").tooltip({
                    selector: '[data-toggle="tooltip"]',
                    container: 'body'
                });
            })
        });
    </script>
</body>
</html>

