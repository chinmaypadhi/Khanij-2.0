<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="dashboard_Dashboard" %>

<%@ Register Src="~/includes/navbar.ascx" TagPrefix="uc1" TagName="navbar" %>
<%@ Register Src="~/includes/leftsider.ascx" TagPrefix="uc1" TagName="leftsider" %>
<%@ Register Src="~/includes/navigation.ascx" TagPrefix="uc1" TagName="navigation" %>
<%@ Register Src="~/includes/footer.ascx" TagPrefix="uc1" TagName="footer" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <meta http-equiv="content-type" content="text/html;charset=UTF-8" />
    <meta charset="utf-8" />
    <title>Khanij Online </title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <meta content="" name="description" />
    <meta content="" name="author" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <link rel="stylesheet" href="../css/bootstrap.min.css" media="screen" />
    <%--<link rel="stylesheet" href="../css/mdb.min.css" media="screen" />--%>
    <link rel="stylesheet" href="../css/pace-theme-flash.css" media="screen" />
    <link rel="stylesheet" href="../css/all.min.css" />
    
    <link rel="stylesheet" href="../css/perfect-scrollbar.css" />   
    <link rel="stylesheet" href="../css/style.css"  type="text/css" />
    <link rel="stylesheet" href="../css/dashboard.css"  type="text/css" />
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
                    <%--<uc1:navigation runat="server" ID="navigation" />--%>
                    <div class="bg-white imp-notice mb-3 d-flex ">
                        <span class="bg-primary text-white d-inline-block py-2 px-3 rounded-left"><i class="khanijicon-e-permit"></i> Important Notice</span>
                        <marquee onmouseover="this.stop();" onmouseout="this.start();" scrollamount="5"> 
                        <a href="#" class=" py-2 px-3 d-inline-block">All minor/storage license holder, please review your profile immediately. Anything required for updation is highlighted in red colour. Please update the required data and ensure the approval of concern district competent authority to make it effective in portal. Otherwise dispatch though portal may affect.   || Kindly pay Environmental Cess, Infrastructure &amp; Development Cess and TCS offline calculated by portal and update in Khanij Online Portal.</a>
                            </marquee>
                    </div>
                    <!-- MAIN CONTENT AREA STARTS -->
                    <div class="row">
                        <div class="col-12">
                            <div class="form-container">
                                <div class="row">
                                    <div class="col-12">
                                        <div class="bg-white rounded">
                                        <ul class="row no-gutters service-list">
                                            <li class="col">
                                                <i class="khanijicon-e-Permit fa-2x"></i>
                                                <p class="mb-0">e-Permit</p>
                                                <h5>17449</h5>
                                            </li>
                                            <li class="col">
                                                <i class="khanijicon-e-Permit fa-2x"></i>
                                                <p class="mb-0">e-RPTP</p>
                                                <h5>22246</h5>
                                            </li>
                                            <li class="col">
                                                <i class="khanijicon-e-Permit fa-2x"></i>
                                                <p class="mb-0">e-LTP Permit</p>
                                                <h5>9018</h5>
                                            </li>
                                            <li class="col">
                                                <i class="khanijicon-e-Permit fa-2x"></i>
                                                <p class="mb-0">e-RTP Permit</p>
                                                <h5>20893</h5>
                                            </li>
                                            <li class="col">
                                                <i class="khanijicon-e-TP fa-2x"></i>
                                                <p class="mb-0">e-TP</p>
                                                <h5>3387719</h5>
                                            </li>
                                            <li class="col">
                                                <i class="khanijicon-e-TP fa-2x"></i>
                                                <p class="mb-0">e-RPTP</p>
                                                <h5>1306356</h5>
                                            </li>
                                            <li class="col">
                                                <i class="khanijicon-e-TP fa-2x"></i>
                                                <p class="mb-0">e-LTP</p>
                                                <h5>1167370</h5>
                                            </li>
                                            <li class="col">
                                                <i class="khanijicon-e-TP fa-2x"></i>
                                                <p class="mb-0">e-RTP</p>
                                                <h5>23899</h5>
                                            </li>
                                            <li class="col">
                                                <i class="khanijicon-Registered-Vehicle fa-2x"></i>
                                                <p class="mb-0">Regd. Vehicle</p>
                                                <h5>60730</h5>
                                            </li>
                                        </ul>
                                       </div>
                                    </div>
                                    <div class="col-xl-9 pr-xl-1 col-lg-12">
                                           <div class="row">
                                    <div class="col-xl-6 pr-xl-1 col-lg-6 pr-lg-1 col-12">
                                        <div class="card border shadow-none">
                                            <div class="card-header border-top border-primary-dark d-flex align-items-center justify-content-between">
                                            <i class="khanijicon-Head-Wise-Revenue mr-3"></i>
                                                Head Wise Revenue <a href="#" class="ml-auto"><i class="khanijicon-refresh"></i> </a>
                                            </div>
                                            <div class="card-body">
                                                <div class="row">
                                                    <div class="col-6 pr-xl-1">
                                                        <div class="bg-primary-light custom-dropdown dropdown rounded">
                                                          <a class="d-flex align-items-center px-2 py-2 text-white" href="#" id="dropdownMenuButton" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                                            <i class="fas fa-rupee-sign pr-2"></i>
                                                               <h5 class="m-0 text-white">
                                                              <small class="d-block">Financial Year (20-21)</small>
                                                                 6.75 Lakh</h5>
                                                              <i class="fas fa-caret-down text-white ml-auto"></i>
                                                          </a>
    
                                                          <div class="dropdown-menu shadow" aria-labelledby="dropdownMenuButton">
                                                            <a class="dropdown-item" href="#">Year 2019-20</a>
                                                            <a class="dropdown-item" href="#">Year 2018-19</a>
                                                              <a class="dropdown-item" href="#">Year 2017-18</a>
                                                              <a class="dropdown-item" href="#">Year 2016-17</a>
                                                          </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-6 pl-xl-1">
                                                        <div class="bg-primary-light custom-dropdown dropdown rounded">
                                                          <a class="d-flex align-items-center justify-content-between px-2 py-2 text-white" href="#" id="dropdownMenuButton" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                                            <i class="fas fa-rupee-sign pr-2"></i>
                                                               <h5 class="m-0 text-white">
                                                              <small class="d-block"> Month (Dec)</small>
                                                                 1.00 Lakh</h5>
                                                              <i class="fas fa-caret-down text-white ml-auto"></i>
                                                          </a>
    
                                                          <div class="dropdown-menu shadow-sm" aria-labelledby="dropdownMenuButton">
                                                            <a class="dropdown-item" href="#">January</a>
                                                            <a class="dropdown-item" href="#">February</a>
                                                            <a class="dropdown-item" href="#">March</a>
                                                            <a class="dropdown-item" href="#">April</a>
                                                          </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="custom-scroll portle1 mt-3">
                                                <table class="table table-sm table-borderless mb-0">
                                                    <thead>
                                                        <tr>
                                                            <th>Heads</th>
                                                            <th class="text-right">Financial Year <br />(in Core <i class="fas fa-rupee-sign"></i>)</th>
                                                            <th class="text-right">Month<br /> (in Core <i class="fas fa-rupee-sign"></i>)</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <tr>
                                                            <td>Royalty</td>
                                                            <td class="text-right">15415671591.00	</td>
                                                            <td class="text-right">1223912662.00</td>
                                                        </tr>
                                                        <tr>
                                                            <td>DMF</td>
                                                            <td class="text-right">4447762294.00</td>
                                                            <td class="text-right">342640633.00</td>
                                                        </tr>
                                                        <tr>
                                                            <td>NMET</td>
                                                            <td class="text-right">304344387.00	</td>
                                                            <td class="text-right">24182560.00</td>
                                                        </tr>
                                                        <tr>
                                                            <td>Infrastructure & Development Cess	</td>
                                                            <td class="text-right">731311273.00	</td>
                                                            <td class="text-right">71490765.00</td>
                                                        </tr>
                                                        <tr>
                                                            <td>Environmental Cess	</td>
                                                            <td class="text-right">731291667.00</td>
                                                            <td class="text-right">71490765.00</td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                                </div>
                                                <p class="m-0 text-right more">
                                                <a href="#">View All <i class="fas fa-arrow-right"></i></a>
                                                    </p>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-xl-6 pl-xl-1 col-lg-6 pl-lg-1 col-12">
                                         <div class="card border shadow-none">
                                            <div class="card-header border-top border-primary-dark d-flex align-items-center justify-content-between">
                                            <i class="khanijicon-Head-Wise-Revenue mr-3"></i> Mineral Wise Revenue <a href="#" class="ml-auto"><i class="khanijicon-refresh"></i> </a>
                                            </div>
                                            <div class="card-body">
                                                <div class="row">
                                                    <div class="col-6 pr-xl-1">
                                                        <div class="bg-primary-light custom-dropdown dropdown rounded">
                                                          <a class="d-flex align-items-center px-2 py-2 text-white" href="#" id="dropdownMenuButton" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                                            <i class="fas fa-rupee-sign pr-2"></i>
                                                               <h5 class="m-0 text-white">
                                                              <small class="d-block">Financial Year (20-21)</small>
                                                                 6.75 Lakh</h5>
                                                              <i class="fas fa-caret-down text-white ml-auto"></i>
                                                          </a>
    
                                                          <div class="dropdown-menu shadow-sm" aria-labelledby="dropdownMenuButton">
                                                            <a class="dropdown-item" href="#">Year 2019-20</a>
                                                            <a class="dropdown-item" href="#">Year 2018-19</a>
                                                              <a class="dropdown-item" href="#">Year 2017-18</a>
                                                              <a class="dropdown-item" href="#">Year 2016-17</a>
                                                          </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-6 pl-xl-1">
                                                        <div class="bg-primary-light custom-dropdown dropdown rounded">
                                                          <a class="d-flex align-items-center justify-content-between px-2 py-2 text-white" href="#" id="dropdownMenuButton" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                                            <i class="fas fa-rupee-sign pr-2"></i>
                                                               <h5 class="m-0 text-white">
                                                              <small class="d-block"> Month (Dec)</small>
                                                                 1.00 Lakh</h5>
                                                              <i class="fas fa-caret-down text-white ml-auto"></i>
                                                          </a>
    
                                                          <div class="dropdown-menu shadow-sm" aria-labelledby="dropdownMenuButton">
                                                            <a class="dropdown-item" href="#">January</a>
                                                            <a class="dropdown-item" href="#">February</a>
                                                            <a class="dropdown-item" href="#">March</a>
                                                            <a class="dropdown-item" href="#">April</a>
                                                          </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="custom-scroll portle1 mt-3">
                                                <table class="table table-sm table-borderless  mb-0">
                                                    <thead>
                                                        <tr>
                                                            <th>Minerals</th>
                                                            <th class="text-right">Quantity</th>
                                                            <th class="text-right">Royalty</th>
                                                            <th class="text-right">DMF</th>
                                                            <th class="text-right">NMET</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <tr>
                                                            <td>Iron ore</td>
                                                            <td class="text-right">1318711.220	</td>
                                                            <td class="text-right">559003245.00</td>
                                                            <td class="text-right">167424686.00</td>
                                                            <td class="text-right">11180067.00</td>
                                                        </tr>
                                                        <tr>
                                                            <td>Coal</td>
                                                            <td class="text-right">4447762294.00</td>
                                                            <td class="text-right">342640633.00</td>
                                                            <td class="text-right">118712726.00</td>
                                                            <td class="text-right">9420838.00</td>
                                                        </tr>
                                                        <tr>
                                                            <td>Limestone</td>
                                                            <td class="text-right">304344387.00	</td>
                                                            <td class="text-right">24182560.00</td>
                                                            <td class="text-right">48152000.00</td>
                                                            <td class="text-right">3329601.00</td>
                                                        </tr>
                                                        <tr>
                                                            <td>Dolomite</td>
                                                            <td class="text-right">731311273.00	</td>
                                                            <td class="text-right">71490765.00</td>
                                                            <td class="text-right">3329601.00</td>
                                                            <td class="text-right">0.00</td>
                                                        </tr>
                                                        <tr>
                                                            <td>Bauxite</td>
                                                            <td class="text-right">731291667.00</td>
                                                            <td class="text-right">71490765.00</td>
                                                            <td class="text-right">3780823.00</td>
                                                            <td class="text-right">252054.00</td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                                </div>
                                                <p class="m-0 text-right more">
                                                <a href="#">View All <i class="fas fa-arrow-right"></i></a>
                                                    </p>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-xl-6 pr-xl-1 col-lg-6 pr-lg-1 col-12">
                                        <div class="card border shadow-none">
                                            <div class="card-header border-top border-khaki d-flex align-items-center justify-content-between">
                                            <i class="khanijicon-DMF mr-3"></i>
                                                DMF <a href="#" class="ml-auto"><i class="khanijicon-refresh"></i> </a>
                                            </div>
                                            <div class="card-body">
                                                <div class="row">
                                                    <div class="col-6 pr-xl-1">
                                                        <div class="amber darken-2 custom-dropdown dropdown rounded">
                                                          <a class="d-flex align-items-center px-2 py-2 text-white" href="#" id="dropdownMenuButton" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                                            <i class="fas fa-rupee-sign pr-2"></i>
                                                               <h5 class="m-0 text-white">
                                                              <small class="d-block">Financial Year (20-21)</small>
                                                                 6.75 Lakh</h5>
                                                              <i class="fas fa-caret-down text-white ml-auto"></i>
                                                          </a>
    
                                                          <div class="dropdown-menu shadow-sm" aria-labelledby="dropdownMenuButton">
                                                            <a class="dropdown-item" href="#">Year 2019-20</a>
                                                            <a class="dropdown-item" href="#">Year 2018-19</a>
                                                              <a class="dropdown-item" href="#">Year 2017-18</a>
                                                              <a class="dropdown-item" href="#">Year 2016-17</a>
                                                          </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-6 pl-xl-1">
                                                        <div class="amber darken-2 custom-dropdown dropdown rounded">
                                                          <a class="d-flex align-items-center justify-content-between px-2 py-2 text-white" href="#" id="dropdownMenuButton" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                                            <i class="fas fa-rupee-sign pr-2"></i>
                                                               <h5 class="m-0 text-white">
                                                              <small class="d-block"> Month (Dec)</small>
                                                                 1.00 Lakh</h5>
                                                              <i class="fas fa-caret-down text-white ml-auto"></i>
                                                          </a>
    
                                                          <div class="dropdown-menu shadow-sm" aria-labelledby="dropdownMenuButton">
                                                            <a class="dropdown-item" href="#">January</a>
                                                            <a class="dropdown-item" href="#">February</a>
                                                            <a class="dropdown-item" href="#">March</a>
                                                            <a class="dropdown-item" href="#">April</a>
                                                          </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="custom-scroll portle2 mt-3">
                                                <table class="table table-sm table-borderless mb-0">
                                                    <thead>
                                                        <tr>
                                                            <th>District</th>
                                                            <th class="text-right">Total Amount (<i class="fas fa-rupee-sign"></i>)</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <tr>
                                                            <td>Dantewada (Dakshin Bastar)</td>
                                                            <td class="text-right">15415671591.00	</td>
                                                        </tr>
                                                        <tr>
                                                            <td>Korba</td>
                                                            <td class="text-right">4447762294.00</td>
                                                        </tr>
                                                        <tr>
                                                            <td>Balodabazar-Bhatapara</td>
                                                            <td class="text-right">304344387.00	</td>
                                                        </tr>
                                                        <tr>
                                                            <td>Raigarh</td>
                                                            <td class="text-right">731311273.00	</td>
                                                        </tr>
                                                        <tr>
                                                            <td>Kanker (Uttar Bastar)</td>
                                                            <td class="text-right">731291667.00</td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                                </div>
                                                <p class="m-0 text-right more">
                                                <a href="#">View All <i class="fas fa-arrow-right"></i></a>
                                                    </p>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-xl-6 pl-xl-1 col-lg-6 pl-lg-1 col-12">
                                         <div class="card border shadow-none">
                                            
                                             <div class="card-header border-top border-brown d-flex align-items-center justify-content-between">
                                            <i class="khanijicon-Pendency mr-3"></i>
                                                Pendency <span class="text-warning ml-auto mr-3">Total - 0329</span> <a href="#"><i class="khanijicon-refresh"></i> </a>
                                            </div>
                                           <div class="card-body">
                                            <div class=" portle3">
                                                <div class="row">
                                                    <div class="col-4">
                                                       <div class="text-center pt-3 pendency-section">
                                                        <i class="khanijicon-Lessee-profile-request circle-box-icon bg-info text-white p-2 rounded-pill"></i>
                                                          <p class="mb-0 mt-3"> Lessee Profile Request</p>
                                                          <h5 class="mb-0 mt-1 font-weight-bold">133</h5>
                                                        </div>
                                                        </div>
                                                    <div class="col-4">
                                                       <div class="text-center pt-3 pendency-section">
                                                        <i class="khanijicon-Lessee-profile-request circle-box-icon bg-purple darken-1 text-white p-2 rounded-pill"></i>
                                                          <p class="mb-0 mt-3"> Licensee Profile Request</p>
                                                          <h5 class="mb-0 mt-1 font-weight-bold">195</h5>
                                                        </div>
                                                    </div>
                                                <div class="col-4">
                                                       <div class="text-center pt-3 pendency-section">
                                                        <i class="khanijicon-Lessee-profile-request circle-box-icon  bg-brown text-white p-2 rounded-pill"></i>
                                                         <a href="../EndUserProfileRequest/NewRequrest.aspx"><p class="mb-0 mt-3"> End User Profile Request</p></a> 
                                                          <h5 class="mb-0 mt-1 font-weight-bold">18</h5>
                                                        </div>
                                                    </div>
                                                </div>
                                                <h6 class="mt-4 border-bottom pb-1">License Application</h6>
                                               <div class="row no-gutters">
                                                   <div class="col-lg-6">
                                                       <div class="applicationicon-box d-flex align-items-center">
                                                           <i class="khanijicon-Through-licensee mr-3 text-info"></i>
                                                           <h5>
                                                               <small class="d-block text-info">New<br class="d-none d-lg-block" /> Application</small>
                                                               0
                                                           </h5>
                                                        </div>
                                                   </div>
                                                    <div class="col-lg-6">
                                                       <div class="applicationicon-box d-flex align-items-center">
                                                           <i class="khanijicon-Through-licensee mr-3 text-warning"></i>
                                                           <h5>
                                                               <small class="d-block text-info">Acknowledgement <br class="d-none d-lg-block" />Issued</small>
                                                               1
                                                           </h5>
                                                        </div>
                                                   </div>
                                                <div class="col-lg-6">
                                                       <div class="applicationicon-box d-flex align-items-center">
                                                           <i class="khanijicon-Through-licensee text-secondary mr-3"></i>
                                                           <h5>
                                                               <small class="d-block text-info">Grant<br class="d-none d-lg-block" /> Order Issued</small>
                                                               0
                                                           </h5>
                                                        </div>
                                                   </div>
                                                    <div class="col-lg-6">
                                                       <div class="applicationicon-box d-flex align-items-center">
                                                           <i class="khanijicon-Through-licensee text-brown mr-3"></i>
                                                           <h5>
                                                               <small class="d-block text-info">Security<br class="d-none d-lg-block" /> Deposit Received</small>
                                                               0
                                                           </h5>
                                                        </div>
                                                   </div>
                                               </div>
                                            </div>

                                         </div>
                                        </div>
                                    </div>
                                               <div class="col-xl-12 pr-xl-3 col-lg-12 pr-lg-1">
                                         <div class="card border shadow-none">
                                            
                                             <div class="card-header d-flex align-items-center justify-content-between">
                                            <i class="khanijicon-lessee mr-3"></i>
                                                Lessee <a href="#" class="ml-auto"><i class="khanijicon-refresh"></i> </a>
                                            </div>
                                           <div class="card-body">
                                            <ul class="row no-gutters lessee-list mb-0">
                                            <li class="col">
                                            <div class="blue darken-3 cont-box text-center text-white rounded slideup-hvr">
                                                <i class="khanijicon-Lessee-Working fa-2x"></i>
                                                <p class="mb-0">Working</p>
                                                <h4> 1888</h4>
                                                <a href="#"></a>
                                                <div class="slideup-hvr-overlay"></div>
                                            </div>
                                            </li>
                                            <li class="col">
                                                <div class="indigo accent-3 cont-box text-center text-white rounded slideup-hvr">
                                                <i class="khanijicon-Lessee-Working fa-2x"></i>
                                                <p class="mb-0">Non Producing	</p>
                                                <h4>60</h4>
                                                    <a href="#"></a>
                                                    <div class="slideup-hvr-overlay"></div>
                                                    </div>
                                            </li>
                                            <li class="col">
                                                <div class=" blue darken-1 cont-box text-center text-white rounded slideup-hvr">
                                                <i class="khanijicon-Lessee-Working fa-2x"></i>
                                                <p class="mb-0">Temporary Working For Dispatch	</p>
                                                <h4>6966</h4>
                                                    <a href="#"></a>
                                                    <div class="slideup-hvr-overlay"></div>
                                                    </div>
                                            </li>
                                            <li class="col">
                                                <div class="amber accent-4 cont-box text-center text-white rounded slideup-hvr">
                                                <i class="khanijicon-Lessee-Working fa-2x"></i>
                                                <p class="mb-0">Suspended</p>
                                                <h4>6966</h4>
                                                    <a href="#"></a>
                                                    <div class="slideup-hvr-overlay"></div>
                                                    </div>
                                            </li>
                                            <li class="col">
                                                <div class="amber cont-box text-center text-white rounded slideup-hvr">
                                                <i class="khanijicon-Lessee-Working fa-2x"></i>
                                                <p class="mb-0">Surrendered</p>
                                                <h4>6966</h4>
                                                    <a href="#"></a>
                                                    <div class="slideup-hvr-overlay"></div>
                                                    </div>
                                            </li>
                                            <li class="col">
                                                <div class="bg-danger cont-box text-center text-white rounded slideup-hvr">
                                                <i class="khanijicon-Lessee-Working fa-2x"></i>
                                                <p class="mb-0">Cancelled</p>
                                                <h4>6966</h4>
                                                    <a href="#"></a>
                                                    <div class="slideup-hvr-overlay"></div>
                                                    </div>
                                            </li>
                                            
                                        </ul>

                                         </div>
                                        </div>
                                    </div>
                                               <div class="col-lg-6 col-12 pr-lg-1">
                                         <div class="card border shadow-none">
                                            <div class="card-header d-flex justify-content-between align-items-center">
                                            <i class="khanijicon-Through-licensee mr-2"></i>
                                                Through Licensee (<span class="text-primary">e-Transit Pass</span>) <a href="#" class="ml-auto"><i class="khanijicon-refresh"></i> </a>
                                            </div>
                                           <div class="card-body">
<div>
                                                <div class="row">
                                                    <div class="col-4">
                                                       <div class="text-center pt-3 pendency-section">
                                                        <i class="khanijicon-e-permit circle-box-icon blue darken-1 text-white p-2 rounded-pill"></i>
                                                          <p class="mb-0 mt-3"> TP</p>
                                                          <h5 class="mb-0 mt-1 font-weight-bold">191513</h5>
                                                        </div>
                                                        </div>
                                                    <div class="col-4">
                                                       <div class="text-center pt-3 pendency-section">
                                                        <i class="khanijicon-e-permit circle-box-icon blue darken-1 text-white p-2 rounded-pill"></i>
                                                          <p class="mb-0 mt-3"> RPTP</p>
                                                          <h5 class="mb-0 mt-1 font-weight-bold">22</h5>
                                                        </div>
                                                    </div>
                                                <div class="col-4">
                                                       <div class="text-center pt-3 pendency-section">
                                                        <i class="khanijicon-e-permit circle-box-icon  blue darken-1 text-white p-2 rounded-pill"></i>
                                                          <p class="mb-0 mt-3"> RTP</p>
                                                          <h5 class="mb-0 mt-1 font-weight-bold">33</h5>
                                                        </div>
                                                    </div>
                                                </div>

                                            </div>

                                         </div>
                                        </div>
                                    </div>
                                               <div class="col-lg-6 col-12 pl-lg-1">
                                         <div class="card border shadow-none">
                                            <div class="card-header d-flex justify-content-between align-items-center ">
                                            <i class="khanijicon-Through-licensee mr-2"></i>
                                                Licensee <a href="#" class="ml-auto"><i class="khanijicon-refresh"></i> </a>
                                            </div>
                                           <div class="card-body">
<div >
                                                <div class="row">
                                                    <div class="col-4">
                                                       <div class="text-center pt-3 pendency-section">
                                                        <i class="khanijicon-e-permit circle-box-icon bg-brown text-white p-2 rounded-pill"></i>
                                                          <p class="mb-0 mt-3"> In Force</p>
                                                          <h5 class="mb-0 mt-1 font-weight-bold">811</h5>
                                                        </div>
                                                        </div>
                                                    <div class="col-4">
                                                       <div class="text-center pt-3 pendency-section">
                                                        <i class="khanijicon-e-permit circle-box-icon bg-danger text-white p-2 rounded-pill"></i>
                                                          <p class="mb-0 mt-3"> Lapsed</p>
                                                          <h5 class="mb-0 mt-1 font-weight-bold">3</h5>
                                                        </div>
                                                    </div>
                                                <div class="col-4">
                                                       <div class="text-center pt-3 pendency-section">
                                                        <i class="khanijicon-e-permit circle-box-icon amber accent-3 text-white p-2 rounded-pill"></i>
                                                          <p class="mb-0 mt-3"> Suspended</p>
                                                          <h5 class="mb-0 mt-1 font-weight-bold">11</h5>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                         </div>
                                        </div>
                                    </div>
<div class="col-md-12">
                                         <div class="card border payment-tabe shadow-none">
                                            <div class="card-header bg-info text-white d-flex align-items-center">
                                            Payments to be made through challan 
                                                <div class="ml-auto d-flex align-items-center">
                                                  
                                                    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control form-control-sm rounded mr-2">
                                                        <asp:ListItem>Select Year</asp:ListItem>
                                                        <asp:ListItem>2020-21</asp:ListItem>
                                                        <asp:ListItem>2019-20</asp:ListItem>
                                                        <asp:ListItem>2018-19</asp:ListItem>
                                                        <asp:ListItem>2017-18</asp:ListItem>
                                                    </asp:DropDownList>
                                                      
                                                    <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control form-control-sm rounded mr-3">
                                                        <asp:ListItem>Select Month</asp:ListItem>
                                                        <asp:ListItem>January</asp:ListItem>
                                                        <asp:ListItem>February</asp:ListItem>
                                                        <asp:ListItem>March</asp:ListItem>
                                                        <asp:ListItem>April</asp:ListItem>
                                                        <asp:ListItem>May</asp:ListItem>
                                                        <asp:ListItem>June</asp:ListItem>
                                                        <asp:ListItem>July</asp:ListItem>
                                                        <asp:ListItem>August</asp:ListItem>
                                                    </asp:DropDownList>
                                                  
                                                <a href="#"><i class="khanijicon-refresh"></i> </a>
                                                      
                                                </div>
                                            </div>
                                           <div class="table-responsive ">
                                                <table class="table mb-lg-0">
                                                    <thead>
                                                        <tr>
                                                            <th>Payment Type</th>
                                                            <th class="text-right">Total Amount <br />(in <i class="fas fa-rupee-sign"></i>)</th>
                                                            <th class="text-right">Paid Amount <br />(in <i class="fas fa-rupee-sign"></i>)</th>
                                                            <th class="text-right">Paid But Pending <br />for Verification</th>
                                                            <th class="text-right">Balance <br />(in <i class="fas fa-rupee-sign"></i>)</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <tr>
                                                            <td>TCS (Demand Note)</td>
                                                            <td class="text-right"><a href="javascript:void(0);"> 1200634.00</a></td>
                                                            <td class="text-right"><a href="javascript:void(0);">900.00</a></td>
                                                            <td class="text-right"><a href="javascript:void(0);">546840.00</a></td>
                                                            <td class="text-right"><a href="javascript:void(0);">21458494.00</a></td>
                                                        </tr>
                                                        <tr>
                                                            <td>TCS</td>
                                                            <td class="text-right"><a href="javascript:void(0);"> 2006202.00</a></td>
                                                            <td class="text-right"><a href="javascript:void(0);">900.00</a></td>
                                                            <td class="text-right"><a href="javascript:void(0);">514840.00</a></td>
                                                            <td class="text-right"><a href="javascript:void(0);">12458494.00</a></td>
                                                        </tr>
                                                        <tr>
                                                            <td>TCS </td>
                                                            <td class="text-right"><a href="javascript:void(0);">12458494.00</a></td>
                                                            <td class="text-right"><a href="javascript:void(0);">900.00</a></td>
                                                            <td class="text-right"><a href="javascript:void(0);">546840.00</a></td>
                                                            <td class="text-right"><a href="javascript:void(0);">214512.00</a></td>
                                                        </tr>
                                                        <tr>
                                                            <td>TCS (Demand Note)</td>
                                                            <td class="text-right"><a href="javascript:void(0);"> 220062004.00</a></td>
                                                            <td class="text-right"><a href="javascript:void(0);">900.00</a></td>
                                                            <td class="text-right"><a href="javascript:void(0);">546840.00</a></td>
                                                            <td class="text-right"><a href="javascript:void(0);">12458494.00</a></td>
                                                        </tr>
                                                        <tr>
                                                            <td>TCS</td>
                                                            <td class="text-right"><a href="javascript:void(0);"> 22004523.00</a></td>
                                                            <td class="text-right"><a href="javascript:void(0);">900.00</a></td>
                                                            <td class="text-right"><a href="javascript:void(0);">546840.00</a></td>
                                                            <td class="text-right"><a href="javascript:void(0);">21458494.00</a></td>
                                                        </tr>
                                                        <tr>
                                                            <td>TCS</td>
                                                            <td class="text-right"><a href="javascript:void(0);"> 3006234.00</a></td>
                                                            <td class="text-right"><a href="javascript:void(0);">900.00</a></td>
                                                            <td class="text-right"><a href="javascript:void(0);">546840.00</a></td>
                                                            <td class="text-right"><a href="javascript:void(0);">21458494.00</a></td>
                                                        </tr>
                                                        <tr>
                                                            <td>TCS (Demand Note)</td>
                                                            <td class="text-right"><a href="javascript:void(0);">25006234.00</a></td>
                                                            <td class="text-right"><a href="javascript:void(0);">900.00</a></td>
                                                            <td class="text-right"><a href="javascript:void(0);">546840.00</a></td>
                                                            <td class="text-right"><a href="javascript:void(0);">21458494.00</a></td>
                                                        </tr>
                                                        <tr>
                                                            <td>TCS</td>
                                                            <td class="text-right"><a href="javascript:void(0);"> 3006234.00</a></td>
                                                            <td class="text-right"><a href="javascript:void(0);">900.00</a></td>
                                                            <td class="text-right"><a href="javascript:void(0);">546840.00</a></td>
                                                            <td class="text-right"><a href="javascript:void(0);">21458494.00</a></td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                         </div>
                                        </div>
                                    </div>
                                               </div>
                                       </div>
                                    <div class="col-xl-3 pl-xl-1 col-lg-12">
                                                <div class="bg-white card-body reptlnk-section rounded">
                                                    <h5 class="mt-0"><i class="khanijicon-MIS-reports"></i> MIS Report</h5>
                                                    
                                                    <div class="card card-toggle border shadow-none mb-3">
                                                    <div class="card-header border-top border-info d-flex justify-content-between">
                                                    Royalty 
                                                     <div class="actions panel_actions float-right">
                                                        <a class="box_toggle fa fa-chevron-up"></a>
                                                    </div>
                                                    </div>
                                                    <div class="card-body">
                                                        <ul>
                                                            <li>
                                                                <a href="../Report/RoyaltyCreator.aspx">Royalty Creator</a>
                                                            </li>
                                                            <li>
                                                                <a href="#">Royalty Approval</a>
                                                            </li>
                                                        </ul>
                                                    </div>
                                                </div>
                                                    <div class="card card-toggle border shadow-none ">
                                                    <div class="card-header border-top border-info d-flex justify-content-between">
                                                    User Information 
                                                     <div class="actions panel_actions float-right">
                                                        <a class="box_toggle fa fa-chevron-up"></a>
                                                    </div>
                                                    </div>
                                                    <div class="card-body">
                                                        <ul>
                                                            <li>
                                                            <a href="#">Lesseev</a></li>
                                                            <li>
                                                            <a href="#">Licensee</a>
                                                            
                                                            <li>
                                                            <a href="#">End User</a>
                                                            </li>
                                                            <li>
                                                            <a href="#">Vehicle Owner</a>
                                                            </li>
                                                            <li>
                                                            <a href="#">Vehicles</a>
                                                            </li>
                                                            <li>
                                                            <a href="#">Lessee/Licensee On Board Status</a>
                                                            </li>
                                                            <li>
                                                            <a href="#">Mineral Wise On Board Status</a>
                                                            </li>
                                                            <li>
                                                            <a href="#">Change Status User List</a>
                                                            </li>
                                                            <li>
                                                            <a href="#">Captive Mine Report</a>
                                                            </li>
                                                        </ul>
                                                    </div>
                                                </div>
                                                    <div class="card card-toggle border shadow-none ">
                                                    <div class="card-header border-top border-info d-flex justify-content-between">
                                                    e-Permit & Pass 
                                                     <div class="actions panel_actions float-right">
                                                        <a class="box_toggle fa fa-chevron-up"></a>
                                                    </div>
                                                    </div>
                                                    <div class="card-body">
                                                        <ul>
                                                            <li>
                                                                <a href="#">Generated e-Permit Details</a>
                                                            </li>
                                                            <li>
                                                                <a href="#">Ready for e-Permit Details</a>
                                                            </li>
                                                            <li>
                                                                <a href="#">Applied for e-Permit Details</a>
                                                            </li>
                                                            <li>
                                                                <a href="#">Generated RPTP-Permit Details</a>
                                                            </li>
                                                            <li>
                                                                <a href="#">Generated LTP-Permit Details</a>
                                                            </li>
                                                            <li>
                                                                <a href="#">Generated RTP-Permit Details</a>
                                                            </li>
                                                            <li>
                                                                <a href="#">e-Transit Pass Royalty Details</a>
                                                            </li>
                                                            <li>
                                                                <a href="#">Transit Pass Details Report</a>
                                                            </li>
                                                            <li>
                                                                <a href="#">Royalty Paid Transit Pass Details Report</a>
                                                            </li>
                                                            <li>
                                                                <a href="#">Railway Transit Pass Details Report</a>
                                                            </li>
                                                            <li>
                                                                <a href="#">Local Transit Pass Details Report</a>
                                                            </li>
                                                            <li>
                                                                <a href="#">Vehicle Running In Trip Report</a>
                                                            </li>
                                                            <li>
                                                                <a href="#">Conveyor Belt Transit Pass Details Report</a>
                                                            </li>
                                                            <li>
                                                                <a href="#">MGR Transit Pass Details Report</a>
                                                            </li>
                                                            <li>
                                                                <a href="#">Ropeway Transit Pass Details Report</a>
                                                            </li>
                                                            <li>
                                                                <a href="#">End Use Plant inside the Lease Area Transit Pass Details Report</a>
                                                            </li>
                                                            <li>
                                                                <a href="#">Outside Mineral Receive Report</a>
                                                            </li>
                                                            <li>
                                                                <a href="#">Pending TP Offline</a>
                                                            </li>
                                                            <li>
                                                                <a href="#">Updated Offline TP</a>
                                                            </li>
                                                            <li>
                                                                <a href="#">TP Stop/Start Report</a>
                                                            </li>
                                                            <li>
                                                                <a href="#">Demand/Credit Note</a>
                                                            </li>
                                                        </ul>
                                                    </div>
                                                </div>
                                                    <div class="card card-toggle border shadow-none ">
                                                    <div class="card-header border-top border-info d-flex justify-content-between">
                                                    Payment Information 
                                                     <div class="actions panel_actions float-right">
                                                        <a class="box_toggle fa fa-chevron-up"></a>
                                                    </div>
                                                    </div>
                                                    <div class="card-body">
                                                        <ul>
                                                            <li>
                                                                <a href="#">Pending Bank Push Transaction Report</a>
                                                            </li>
                                                            <li>
                                                                <a href="#">Online Payment Report</a>
                                                            </li>
                                                            <li>
                                                                <a href="#">Online Payment Report For DMF</a>
                                                            </li>
                                                            <li>
                                                                <a href="#">Online Payment Report For NMET</a>
                                                            </li>
                                                            <li>
                                                                <a href="#">Online Payment Report For Payable Royalty</a>
                                                            </li>
                                                            <li>
                                                                <a href="#">District Wise Revenue Collection</a>
                                                            </li>
                                                            <li>
                                                                <a href="#">Mineral Wise Revenue Collection</a>
                                                            </li>
                                                            <li>
                                                                <a href="#">Lessee Wise Revenue Collection</a>
                                                            </li>
                                                        </ul>
                                                    </div>
                                                </div>
                                                    <div class="card card-toggle border shadow-none ">
                                                    <div class="card-header border-top border-info d-flex justify-content-between">
                                                    Summary 
                                                     <div class="actions panel_actions float-right">
                                                        <a class="box_toggle fa fa-chevron-up"></a>
                                                    </div>
                                                    </div>
                                                    <div class="card-body">
                                                        <ul>
                                                            <li>
                                                                <a href="#">Grievance Summary</a>
                                                            </li>
                                                            <li>
                                                                <a href="#">Inspection Summary</a>
                                                            </li>
                                                            <li>
                                                                <a href="#">Financial Year Wise Dispatch</a>
                                                            </li>
                                                        </ul>
                                                    </div>
                                                </div>
                                                    <div class="card card-toggle border shadow-none mb-0 ">
                                                    <div class="card-header border-top border-info d-flex justify-content-between">
                                                    License Application 
                                                     <div class="actions panel_actions float-right">
                                                        <a class="box_toggle fa fa-chevron-up"></a>
                                                    </div>
                                                    </div>
                                                    <div class="card-body">
                                                        <ul>
                                                            <li>
                                                                <a href="#">Submitted Application</a>
                                                            </li>
                                                        </ul>
                                                    </div>
                                                </div>
                                                </div>

                                            </div>
                               </div>
                            </div>
                        </div>
                    </div>

                    <!-- MAIN CONTENT AREA ENDS -->
                </div>
            </section>
            <uc1:footer runat="server" ID="footer" />
            <!-- END CONTENT -->
        </div>
        <!-- END CONTAINER -->
        </div>
    </form>
<script>
    $(document).ready(function() {
        loadNavigation('Dashboard', 'gldashboard', 'plLnk', 'tl', 'Dashboard', '', '');
    });
</script>
</body>
</html>
