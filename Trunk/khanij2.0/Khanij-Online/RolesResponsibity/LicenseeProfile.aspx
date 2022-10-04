<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LicenseeProfile.aspx.cs" Inherits="RolesResponsibity_LicenseeProfile" %>
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
                                <div class=" mb-2">
                                    <div class="col bg-light px-3 py-2 mb-2">
                                        <div class="row">
                                          <div class="col-lg-8">
                                           <div class="row">
                                            <div class="col">
                                                 <p class="mb-3 "><span class="font-weight-bold">Customer Id :</span> <span class="badge badge-info font-weight-bold" style="font-size:16px;">4022097701</span></p>
                                             </div>
                                             <div class="col">
                                                <p class="mb-3"><span class="font-weight-bold">Status :</span> <span class="text-danger" style="font-size:15px;">In force</span></p>
                                             </div>
                                             </div>
                                             <div class="row">
                                             <div class="col">
                                                <p class="mb-0"><span class="font-weight-bold">Mobile Number :</span> 9300310271</p>
                                             </div>
                                             <div class="col">
                                                <p class="mb-0"><span class="font-weight-bold">Email Id :</span> hemantagrawal1000@gmail.com</p>
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
                                                            <h6 class="card-title mt-0 font-weight-bold  text-brown">Licensee Application Details</h6>
                                                            <i class="fas fa-circle text-success"></i>
                                                      </div>
                                                      
                                                     <div class="custom-scroll lessee-body">
                                                    <div class="mr-2">
                                                    <p class="card-text mb-0">
                                                        <p  class="mb-1"><span class="font-weight-bold">Name :</span> India Coal Beneficiation</p>
                                                        <p class="mb-1"><span class="font-weight-bold">Type :</span> Storage Depot</p>
                                                        <p class="mb-1"><span class="font-weight-bold">Address :</span> Village-Bachhera, Tehsil-Simga, Dist- Balodabazar- Bhatapara C.G.</p>
                                                        <p class="mb-0"><span class="font-weight-bold">Storage Capacity :</span> Tonne</p>
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
                                                   <a class="view-more text-brown"  href="../LicenseeProfile/LicenseeApplicationDetails.aspx" title="View Details">View More</a>
                                                  </div>
                                                  
                                               
                                                </div>
                                                
                                              </div>
                                              <div class="col-lg-4 col-md-6 col-sm-12">
                                                <div class="card mb-4">
                                                  <div class="card-body">
                                                  <div class="d-flex justify-content-between">
                                                     <h6 class="card-title m-0 font-weight-bold  text-brown">Grant Order Details</h6>
                                                     <i class="fas fa-circle text-success"></i>
                                                     </div>
                                                     <div class="custom-scroll lessee-body">
                                                    <div class="mr-2">
                                                     <p class="card-text">
                                                        <p class="mb-1"><span class="font-weight-bold">Order No :</span> 3264</p>
                                                        <p class="mb-1"><span class="font-weight-bold">Order Date :</span> 28/02/2020</p>
                                                        <p class="mb-1"><span class="font-weight-bold">Licensee period(Years) :</span> 10</p>
                                                        <p class="mb-0"><span class="font-weight-bold">Validity :</span> 06/05/1959 to 05/05/2029</p>
                                                     </p>
                                                     </div>
                                                     </div>
                                                   <div class="lessee-footer">
                                                     <p class="text-brown mb-2">Attachments <i class="fas fa-paperclip"></i></p>
                                                      <ul class="d-inline-flex  pl-0 list-unstyled mb-0 border">
                                                          <li class="border-right px-2"><a href="#" data-toggle="modal" data-target="#attachment" title="Grant Order Copy">G</a></li>
                                                      </ul>
                                                  </div>
                                                  <a class="view-more text-brown" href="../LicenseeProfile/GrantOrderDetails.aspx" title="View Details">View More</a>
                                                  </div>
                                                
                                                </div>
                                              </div>
                                              <div class="col-lg-4 col-md-6 col-sm-12">
                                                <div class="card mb-4">
                                                  <div class="card-body">
                                                  <div class="d-flex justify-content-between">
                                                      <h6 class="card-title m-0 font-weight-bold  text-brown">Licensee Area Details</h6>
                                                      <i class="fas fa-circle text-success"></i>
                                                      </div>
                                                      <div class="custom-scroll lessee-body">
                                                    <div class="mr-2">
                                                    <p class="card-text">
                                                    <p class="mb-1"><span class="font-weight-bold">Village :</span> BACHHERA | District : Balodabazar-Bhatapara</p>
                                                        <p class="mb-1"><span class="font-weight-bold">State :</span> Chhattisgarh</p>
                                                        <p class="mb-1"><span class="font-weight-bold">Pin Code :</span> </p>
                                                        <p class="mb-1"><span class="font-weight-bold">Type Of Land :</span> </p>
                                                        <p class="mb-1"><span class="font-weight-bold">Area (Hect) :</span> 3.800</p>
                                                        <p class="mb-0"><span class="font-weight-bold">Toposheet No. :</span> </p>
                                                    </p>
                                                    </div>
                                                    </div>
                                                    <div class="lessee-footer">
                                                     <p class="text-brown mb-2">Attachments <i class="fas fa-paperclip"></i></p>
                                                      <ul class="d-inline-flex  pl-0 list-unstyled mb-0 border">
                                                          <li class="border-right px-2"><a href="#" data-toggle="modal" data-target="#attachment" title="Demarcation Report">D</a></li>
                                                         
                                                      </ul>
                                                  </div>
                                                    <a class="view-more text-brown" href="../LicenseeProfile/LicenseAreaDetails.aspx" title="View Details">View More</a>
                                                  </div>
                                                
                                                </div>
                                              </div>
                                               <div class="col-lg-4 col-md-6 col-sm-12">
                                                <div class="card mb-4">
                                                  <div class="card-body">
                                                  <div class="d-flex justify-content-between">
                                                      <h6 class="card-title m-0 font-weight-bold  text-brown">IBM Details</h6>
                                                      <i class="fas fa-circle text-success"></i>
                                                      </div>
                                                      <div class="custom-scroll lessee-body">
                                                    <div class="mr-2">
                                                        <p class="card-text">
                                                            <p  class="mb-1"><span class="font-weight-bold">IBM Code :</span> </p>
                                                            <p  class="mb-1"><span class="font-weight-bold">IBM Registration Date :</span> </p>
                                                        </p>
                                                        </div>
                                                        </div>
                                                         <div class="lessee-footer">
                                                     <p class="text-brown mb-2">Attachments <i class="fas fa-paperclip"></i></p>
                                                      <ul class="d-inline-flex  pl-0 list-unstyled mb-0 border">
                                                          <li class="border-right px-2"><a href="#" data-toggle="modal" data-target="#attachment" title="IBM Registration Form - M">I</a></li>
                                                         
                                                      </ul>
                                                  </div>
                                                        <a class="view-more text-brown" href="../LicenseeProfile/IBMDetails.aspx" title="View Details">View More</a>
                                                
                                                  </div>
                                                
                                                </div>
                                              </div>
                                               <div class="col-lg-4 col-md-6 col-sm-12">
                                                <div class="card mb-4">
                                                  <div class="card-body">
                                                  <div class="d-flex justify-content-between">
                                                      <h6 class="card-title m-0 font-weight-bold  text-brown">Environment Clearance Details</h6>
                                                      <i class="fas fa-circle text-success"></i>
                                                      </div>
                                                      <div class="custom-scroll lessee-body">
                                                    <div class="mr-2">
                                                    <p class="card-text">
                                                     <p class="mb-1"><span class="font-weight-bold">Order No. :</span> </p>
                                                     <p class="mb-1"><span class="font-weight-bold">Approval Date :</span> 10/12/2020</p>
                                                        <p class="mb-1"><span class="font-weight-bold">Validity :</span> No Validity found</p>
                                                        </p>
                                                        </div>
                                                        </div>
                                                    <div class="lessee-footer">
                                                     <p class="text-brown mb-2">Attachments <i class="fas fa-paperclip"></i></p>
                                                      <ul class="d-inline-flex  pl-0 list-unstyled mb-0 border">
                                                          <li class="border-right px-2"><a href="#" data-toggle="modal" data-target="#attachment" title="EC Clearance Letter">E</a></li>
                                                         
                                                      </ul>
                                                  </div>
                                                   <a class="view-more text-brown" href="../LicenseeProfile/EnvironmentClearanceDetails.aspx" title="View Details">View More</a>
                                                  </div>
                                                 
                                                </div>
                                              </div>
                                               <div class="col-lg-4 col-md-6 col-sm-12">
                                                <div class="card mb-4">
                                                  <div class="card-body">
                                                  <div class="d-flex justify-content-between">
                                                      <h6 class="card-title m-0 font-weight-bold  text-brown">Consent to Establish Details</h6>
                                                      <i class="fas fa-circle text-success"></i>
                                                      </div>
                                                      <div class="custom-scroll lessee-body">
                                                    <div class="mr-2">
                                                    <p class="card-text">
                                                     <p class="mb-1"><span class="font-weight-bold">Order No. :</span> </p>
                                                     <p class="mb-1"><span class="font-weight-bold">Approval Date :</span> 10/12/2020</p>
                                                        <p class="mb-1"><span class="font-weight-bold">Validity :</span> No Validity found</p>
                                                        </p>
                                                    </div>
                                                    </div>
                                                    <div class="lessee-footer">
                                                     <p class="text-brown mb-2">Attachments <i class="fas fa-paperclip"></i></p>
                                                      <ul class="d-inline-flex  pl-0 list-unstyled mb-0 border">
                                                          <li class="border-right px-2"><a href="#" data-toggle="modal" data-target="#attachment" title="Consent to Establish">E</a></li>
                                                         
                                                      </ul>
                                                  </div>
                                                  <a class="view-more text-brown" href="../LicenseeProfile/ConsenttoEstablishDetails.aspx" title="View Details">View More</a>
                                                  </div>
                                                 
                                                </div>
                                              </div>
                                              <div class="col-lg-4 col-md-6 col-sm-12">
                                                <div class="card mb-4">
                                                  <div class="card-body">
                                                  <div class="d-flex justify-content-between">
                                                      <h6 class="card-title m-0 font-weight-bold  text-brown">Minerals Details</h6>
                                                      <i class="fas fa-circle text-success"></i>
                                                      </div>
                                                      <div class="custom-scroll lessee-body" style="height:150px;">
                                                    <div class="mr-2">
                                                    <p class="card-text">
                                                        <p class="mb-1"><span class="font-weight-bold">Mineral Name :</span> Coal (Metric Tonne)</p>
                                                        <p class="mb-1"><span class="font-weight-bold">Mineral Nature :</span> Non Coking-ROM , Non Coking-Slack , Non Coking-Steam</p>
                                                        <p class="mb-1"><span class="font-weight-bold">Mineral Grade :</span> ROM - G7 (Above 5201 to 5500 GCV/Killo Calories) , ROM- G10 (Above 4301 to 4600 GCV/Killo Calories) , ROM- G11 (Above 4001 to 4300 GCV/Killo Calories) , ROM- G12 (Above 3701 to 4000 GCV/Killo Calories) , ROM- G13 (Above 3401 to 3700 GCV/Killo Calories) , ROM- G14 (Above 3101 to 3400 GCV/Killo Calories) , ROM- G15 (Above 2801 to 3100 GCV/Killo Calories) , ROM- G16 (Above 2501 to 2800 GCV/Killo Calories) , ROM- G17 (Above2201 to 2500 GCV/Killo Calories) , ROM- G4 (Above 6101 to 6400 GCV/Killo Calories) , ROM- G5 (Above 5801 to 6100 GCV/Killo Calories) , ROM- G6 (Above 5501 to 5800 GCV/Killo Calories) , ROM- G8 (Above 4901 to 5200 GCV/Killo Calories) , ROM- G9 (Above 4601 to 4900 GCV/Killo Calories) , Slack- G10 (Above 4301 to 4600 GCV/Killo Calories) , Slack- G11 (Above 4001 to 4300 GCV/Killo Calories) , Slack- G12 (Above 3701 to 4000 GCV/Killo Calories) , Slack- G13 (Above 3401 to 3700 GCV/Killo Calories) , Slack- G14 (Above 3101 to 3400 GCV/Killo Calories) , Slack- G15 (Above 2801 to 3100 GCV/Killo Calories) , Slack- G16 (Above 2501 to 2800 GCV/Killo Calories) , Slack- G17 (Above2201 to 2500 GCV/Killo Calories) , Slack- G4 (Above 6101 to 6400 GCV/Killo Calories) , Slack- G5 (Above 5801 to 6100 GCV/Killo Calories) , Slack- G6 (Above 5501 to 5800 GCV/Killo Calories) , Slack- G7 (Above 5201 to 5500 GCV/Killo Calories) , Slack- G8 (Above 4901 to 5200 GCV/Killo Calories) , Slack- G9 (Above 4601 to 4900 GCV/Killo Calories) , Steam- G10 (Above 4301 to 4600 GCV/Killo Calories) , Steam- G11 (Above 4001 to 4300 GCV/Killo Calories) , Steam- G12 (Above 3701 to 4000 GCV/Killo Calories) , Steam- G13 (Above 3401 to 3700 GCV/Killo Calories) , Steam- G14 (Above 3101 to 3400 GCV/Killo Calories) , Steam- G15 (Above 2801 to 3100 GCV/Killo Calories) , Steam- G16 (Above 2501 to 2800 GCV/Killo Calories) , Steam- G17 (Above2201 to 2500 GCV/Killo Calories) , Steam- G4 (Above 6101 to 6400 GCV/Killo Calories) , Steam- G5 (Above 5801 to 6100 GCV/Killo Calories) , Steam- G6 (Above 5501 to 5800 GCV/Killo Calories) , Steam- G7 (Above 5201 to 5500 GCV/Killo Calories) , Steam- G8 (Above 4901 to 5200 GCV/Killo Calories) , Steam- G9 (Above 4601 to 4900 GCV/Killo Calories)</p>
                                                        <p class="mb-1"><span class="font-weight-bold">EC Quantity :</span> 20000.000</p>
                                                    </p>
                                                    </div>
                                                    </div>
                                                   
                                                  </div>
                                                
                                                </div>
                                              </div>
                                               <div class="col-lg-4 col-md-6 col-sm-12">
                                                <div class="card mb-4">
                                                  <div class="card-body">
                                                  <div class="d-flex justify-content-between">
                                                      <h6 class="card-title m-0 font-weight-bold  text-brown">Consent to Operate Details</h6>
                                                      <i class="fas fa-circle text-success"></i>
                                                      </div>
                                                      <div class="custom-scroll lessee-body">
                                                    <div class="mr-2">
                                                    <p class="card-text">
                                                     <p class="mb-1"><span class="font-weight-bold">Order No. :</span> 4995,4996/RO/TS/CECB/2020</p>
                                                        <p class="mb-1"><span class="font-weight-bold">Approval Date :</span> 10/12/2020</p>
                                                        <p class="mb-1"><span class="font-weight-bold">Validity :</span> No validity found</p>
                                                    </p>
                                                    </div>
                                                    </div>
                                                    <div class="lessee-footer">
                                                     <p class="text-brown mb-2">Attachments <i class="fas fa-paperclip"></i></p>
                                                      <ul class="d-inline-flex  pl-0 list-unstyled mb-0 border">
                                                          <li class="border-right px-2"><a href="#" data-toggle="modal" data-target="#attachment" title="Consent to Operate">O</a></li>
                                                         
                                                      </ul>
                                                  </div>
                                                  <a class="view-more text-brown" href="../LicenseeProfile/ConsentOperateDetails.aspx" title="View Details">View More</a>
                                                  </div>
                                                 
                                                </div>
                                              </div>
                                               
                                              
                                              
                                              
                                              
                                               
                                              
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-lg-3">
                                         <div class="card shadow-sm p-2 lessee-profile-right border">
                                         <h5 class=" font-weight-bold text-center mt-0 ">Licensee Profile</h5>
                                             <ul class=" pl-0 list-unstyled mb-0 ">
                                                 <li class="pb-2">
                                                    <span><a href="#" class="text-dark font-weight-550">Licensee Details</a></span>
                                                    <div class="progress">
                                                        <div class="progress-bar progress-bar-striped bg-warning progress-bar-animated" role="progressbar" style="width:100%" aria-valuenow="50" aria-valuemin="0" aria-valuemax="100">100%</div>
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
                                                    <span><a href="#" class="text-dark font-weight-550">Licensee Area Details</a></span>
                                                    <div class="progress">
                                                        <div class="progress-bar progress-bar-striped bg-warning progress-bar-animated" role="progressbar" style="width: 100%" aria-valuenow="50" aria-valuemin="0" aria-valuemax="100">100%</div>
                                                    </div>
                                                 </li>

                                                 <li class="pb-2">
                                                    <span><a href="#" class="text-dark font-weight-550">IBM Details</a></span>
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
                                                    <span><a href="#" class="text-dark font-weight-550">Consent to  Establish</a></span>
                                                    <div class="progress">
                                                        <div class="progress-bar progress-bar-striped bg-warning progress-bar-animated" role="progressbar" style="width: 100%" aria-valuenow="50" aria-valuemin="0" aria-valuemax="100">100%</div>
                                                    </div>
                                                 </li>

                                                 <li>
                                                    <span><a href="#" class="text-dark font-weight-550">Consent to Operate</a></span>
                                                    <div class="progress">
                                                        <div class="progress-bar progress-bar-striped bg-warning progress-bar-animated" role="progressbar" style="width: 100%" aria-valuenow="50" aria-valuemin="0" aria-valuemax="100">100%</div>
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
            loadNavigation('LicenseeProfile', 'glRoleRes', 'pllicenprof', 'tl', 'Roles and Responsibity', ' Licensee Profile', ' ');
        });
    </script>
</body>
</html>


