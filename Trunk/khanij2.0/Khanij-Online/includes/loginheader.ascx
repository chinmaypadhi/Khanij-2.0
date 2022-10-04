<%@ Control Language="C#" AutoEventWireup="true" CodeFile="loginheader.ascx.cs" Inherits="includes_loginheader" %>
<header class="head-sec fixed-top bg-white">
         <div class="container">
             <div class="header">
                    <nav class="navbar">
                     <a class="navbar-brand" href="Default.aspx">
                            <img src="img/govt-logo.png" class="login-logo" alt="Logo" />
                            <h1 class="mb-1">Mineral Resources Department
                            <small class="d-block">Government of Chhattisgarh</small>
                                </h1>
                        </a>
                      <div class="ml-lg-auto contact-culm">
                          <a href="javascript:void(0);" class="toplnk-mobile d-block d-lg-none"><i class="fas fa-ellipsis-v"></i> </a>
                            <ul class="top-link mb-2">
                               <li class="font-increase-decrease ">
                                    <a href="javascript:decreaseFontSize();" class="fontresize" title="Decrease Font Size">A<sup>-</sup></a>
                                    <a href="javascript:reSetFontSize();" class="fontresize" title="Normal Font Size">A</a>
                                    <a href="javascript:increaseFontSize();" class="fontresize" title="Increase Font Size">A<sup>+</sup></a>
                               </li>
                               <li>
                                    <a href="javascript:void(0)" onclick="chooseStyle('none', 60);" title="Normal View" class="white-theme"></a>
                                    <a href="javascript:void(0)" onclick="chooseStyle('black', 60);" title="Contrast View" class="dark-theme  mr-2"></a>
                               </li>
                                <li>
                                    <a href="javascript:void(0);">RTI</a>
                                </li>
                                <%--<li>
                                    <a href="javascript:void(0);">Feedback</a>
                                </li>--%>
                                <li>
                                    <a  href="javascript:void(0);">Contact Us</a>
                                </li>
                            </ul>
                            <div class="border-bottom mb-2"></div>
                          <ul class="contact-dtls mb-0 align-items-sm-center">
                                <li>
                                    <i class="icon-call mr-2"></i>
                                        <h6 class="mb-0">
                                        <small class="d-block">Call Us</small>
                                        <a href="tel:1800 233 3767">1800 233 3767</a> </h6>
                                </li>
                                <li>
                                    <i class="icon-mail mr-2"></i>
                                        <h6 class="mb-0">
                                        <small class="d-block">Mail Us</small>
                                        <a href="mailto:khanijonline@gmail.com">khanijonline@gmail.com</a></h6>
                                </li>
                                
                            </ul>
                      </div>
                    </nav>
                </div>
         </div>
         <nav class="navbar navbar-expand-lg navbar-dark menu-bar shadow-sm">
  <div class="container">
      <a class="navbar-toggler" href="javascript:void(0);" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
        <i class="fas fa-bars"></i> <span>Menu</span>
      </a>

      <div class="collapse navbar-collapse" id="navbarSupportedContent">
        <ul class="navbar-nav align-items-lg-center mr-auto">
          <li class="nav-item">
            <a class="nav-link" href="Default.aspx" title="home"><span class="fas fa-home"></span><span class="sr-only">(current)</span></a>
          </li>
         <%-- <li class="nav-item">
            <a class="nav-link" href="#">Notification</a>
          </li>--%>
        <li class="nav-item">
            <a class="nav-link" href="#">User Manual</a>
          </li>
          <li class="nav-item dropdown">
            <a class="nav-link dropdown-toggle userregistration vehicleownerreg applicationstatchech" href="#" id="navbarDropdown" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
              User & Vehicle Owner
            </a>
            <div class="dropdown-menu" aria-labelledby="navbarDropdown">
              <a class="dropdown-item userregistration" href="UserRegistration.aspx">User Registration</a>
              <a class="dropdown-item vehicleownerreg" href="vehicleownerRegistraion.aspx">Vehicle Owner Registration</a>
              <a class="dropdown-item" href="#">Tailing Dam, Ashdyke, Mud Pond etc. Registration</a>
                <a class="dropdown-item applicationstatchech" href="ApplicationStatusCheck.aspx">Application Status Check</a>
            </div>
          </li>
        <li class="nav-item dropdown">
            <a class="nav-link dropdown-toggle newapplication" href="#" id="navbarDropdown" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
              New Application  
            </a>
            <div class="dropdown-menu" aria-labelledby="navbarDropdown">
              <a class="dropdown-item newapplication" href="LicenseApplication.aspx">License Application</a>
            </div>
          </li>
          <li class="nav-item">
            <a class="nav-link" href="#">Digital Signature</a>
          </li>
            <li class="nav-item">
            <a class="nav-link" href="#">Grievance</a>
          </li>
            <li class="nav-item">
            <a class="nav-link" href="#">e-TP Verification</a>
          </li>
            <%--<li class="nav-item">
            <a class="nav-link" href="#">Testimonial</a>
          </li>--%>
        
        </ul>
          
      </div>
      <ul class="khanij-online d-flex list-type-none">
              <li>
                   <a href="default.aspx" title="Web based mines & minerals management system"><img src="img/khanijonline22.png" alt="Khanij Online" class="mr-4" /></a>
                   <span class="web-based-title">Web based mines &amp; minerals <br /> management system</span></a>
              </li>
              <li>
                    <a href="#" title="MRD Dealing" class="text-uppercase text-white mrd-btn"><i class="icon-mrd_dealing mr-2"></i> mrd dealing</a>
              </li>
       </ul>
  </div>
</nav>     
</header>