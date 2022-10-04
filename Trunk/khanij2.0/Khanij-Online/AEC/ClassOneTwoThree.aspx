<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ClassOneTwoThree.aspx.cs" Inherits="AEC_ClassOneTwoThree" %>
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
                                        <a class="nav-link active" href="ClassOneTwoThree.aspx">
                                          Class 1,2,3
                                        </a>
                                    </li>
                                     <li class="nav-item">
                                        <a class="nav-link" href="ClassThree.aspx">
                                          Class III
                                        </a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" href="ClassFour.aspx">
                                          Class IV
                                        </a>
                                    </li>
                                     <li class="nav-item">
                                        <a class="nav-link" href="Driver.aspx">
                                          Driver
                                        </a>
                                    </li>
                                </ul>
                                <uc1:util runat="server" ID="util" />
                            </div>

                            <section class="box form-container">
                                <div class="content-body">
                                <div id="viewtable">
                                    
                                    <div class="col-lg-12 col-md-12 col-sm-12">
                                    <h6 class="text-dark font-weight-bold mt-0 text-center">izi= & rhu</h6>
                                   <h5 class="text-brown font-weight-bold mt-0 text-center">izFke Js.kh] f}rh; Js.kh ,oa dk;Zikfyd r`rh; Js.kh vf/kdkjh dk xksiuh; izfrosnu</h5>
                                   </div>
                                   <table class="table table-borderless mb-0">
                                         <tbody>
                                                <tr>
                                                    <td class="font-weight-bolder pb-0">o"kZ ----------------------- dks lekIr gksus okyh vof/k</td>
                                                </tr>
                                                 
                                                <tr>
                                                    <td class="font-weight-bolder text-brown pb-0">Hkkx & ,d</td>
                                                    
                                                </tr>
                                                 <tr>
                                                    <td class="font-weight-bolder pb-0">1. vf/kdkjh dk uke</td>
                                                    <td >Dummy Text</td>
                                                    
                                                </tr>
                                                 <tr>
                                                    
                                                    <td class="font-weight-bolder">2. inuke</td>
                                                    <td >Dummy Text</td>
                                                    
                                                </tr>
                                                 <tr>
                                                    
                                                    <td class="font-weight-bolder">3. fu;kstu dk izdkj</td>
                                                    <td >Dummy Text</td>
                                                  
                                                </tr>
                                                 <tr>
                                                   
                                                    <td class="font-weight-bolder">4. inLFkkiuk</td>
                                                    <td >Dummy Text</td>
                                                </tr>
                                                
                                              
                                                
                                         </tbody>
                                   </table>
                                   <div class="col-lg-12 col-md-12 col-sm-12">
                                   <h5 class="text-brown font-weight-bold mt-0 text-center">izfrosfnr vf/kdkjh Onkjk Hkjk tk,½</h5>
                                   </div>

                                  
                                            <div style="margin-bottom:17px;">
                                                <span class="font-weight-bolder d-block">1. dk;Z dk laf{kIr fooj.k :</span>
                                                <span>Lorem Ipsum is simply dummy 
                                                text of the printing and typesetting industry. 
                                                Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, 
                                                when an unknown printer took a galley of type and scrambled it to make a type 
                                                specimen book.</span>
                                            </div>
                                   
                                     
                                            <div style="margin-bottom:17px;">
                                                <span class="font-weight-bolder d-block">2. d`i;k vkids fy;s fu/kkZfjr xq.kkRed@HkkSfrd@foRrh; y{;ksa dks izkFkfedrk Øe esa vkSj 
                                                    izR;sd y{; ds fo:) miyfC/k dk mYys[k djsa A:</span>
                                                <span>Lorem Ipsum is simply dummy 
                                                text of the printing and typesetting industry. 
                                                Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, 
                                                when an unknown printer took a galley of type and scrambled it to make a type 
                                                specimen book.</span>
                                            </div>
                                          
                                          <div class="clearfix mb-4">
                                            <div  class="float-left">
                                                <span class="font-weight-bolder">vf/kdkjh ds gLrk{kj :</span>
                                                <span style="border-bottom:2px dotted #ddd;">Dummy Text Dummy Text</span>
                                            </div>
                                            
                                            <div  class="float-right">
                                                <span class="font-weight-bolder">inuke :</span>
                                                 <span style="border-bottom:2px dotted #ddd;">Dummy Text Dummy Text</span>
                                            </div>
                                           </div>
                                     
                                   
                                    
                                            <div>
                                                <span class="font-weight-bolder">3.(a) d`i;k dkye 2 ds lanHkZ esa y{;ksa@mn~ns';ksa dh iwfrZ esa deh dk laf{kIr fooj.k nsa A rkfd y{;ksa dh iwfrZ 
                                                    esa dksbZ dfBukbZ ¼ck/kk½ vkbZ gks rks mldks Hkh crk;sa& :</span>
                                                <span style="border-bottom:2px dotted #ddd;">Lorem Ipsum is simply dummy 
                                                text of the printing and typesetting industry. 
                                                Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, 
                                                when an unknown printer took a galley of type and scrambled it to make a type 
                                                specimen book.</span>
                                            </div>
                                   
                                    
                                            <div>
                                                <span class="font-weight-bolder">3.(b) d`i;k dkye 2 ds lanHkZ esa y{;ksa@mn~ns';ksa dh iwfrZ esa deh dk laf{kIr fooj.k nsa A rkfd y{;ksa dh iwfrZ 
                                                    esa dksbZ dfBukbZ ¼ck/kk½ vkbZ gks rks mldks Hkh crk;sa& :</span>
                                                <span style="border-bottom:2px dotted #ddd;">Lorem Ipsum is simply dummy 
                                                text of the printing and typesetting industry. 
                                                Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, 
                                                when an unknown printer took a galley of type and scrambled it to make a type 
                                                specimen book.</span>
                                            </div>
                                 
                                     
                                      
                                       <div>
                                           <div style="text-align:right;">
                                                <span class="font-weight-bolder">vf/kdkjh ds gLrk{kj</span>
                                            </div>
                                            <div style="text-align:right;">
                                                <span class="font-weight-bolder">vf/kdkjh ds gLrk{kj :</span>
                                                <span style="border-bottom:2px dotted #ddd;">Dummy Text Dummy Text</span>
                                            </div>
                                            <div style="text-align:right;">
                                                <span class="font-weight-bolder">inuke :</span>
                                                 <span style="border-bottom:2px dotted #ddd;">Dummy Text Dummy Text</span>
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
        printMe = "yes"

        $(document).ready(function () {
            loadNavigation('LeaveApplicationAll', 'glholiday', 'plleaveapp', 'tl', 'Leave', 'Apply Application ', ' ');
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





