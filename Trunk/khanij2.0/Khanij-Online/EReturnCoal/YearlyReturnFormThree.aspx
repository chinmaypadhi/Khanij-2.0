<%@ Page Language="C#" AutoEventWireup="true" CodeFile="YearlyReturnFormThree.aspx.cs" Inherits="EReturnCoal_YearlyReturnFormThree" %>

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
                                        <a class="nav-link active" href="MontlyReturnpartone.aspx">
                                         Form III
                                        </a>
                                    </li>
                                    
                                </ul>
                                <uc1:util runat="server" ID="util" />
                            </div>

                            <section class="box form-container">
                                <div class="content-body">
                                <div class="text-center text-dark">
                                <h6 class="font-weight-bold">First Schedule</h6>
                                <p class="font-weight-normal mb-0">Form III</p>
                                </div>
                                
                                
                                
                                <ul class="ereturncoalyear nav nav-tabs progressbar border-0" id="myTab" role="tablist">
                                  <li class="startstep activestep1">
                                    <a class="active" id="first-tab" data-toggle="tab" href="#first" role="tab" aria-controls="first" aria-selected="true">Details of Mine</a>
                                  </li>
                                  <li >
                                    <a  id="second-tab" data-toggle="tab" href="#second" role="tab" aria-controls="second" aria-selected="false">Table A</a>
                                  </li>
                                  <li >
                                    <a  id="third-tab" data-toggle="tab" href="#third" role="tab" aria-controls="third" aria-selected="false">Table B</a>
                                  </li>
                                   <li >
                                    <a  id="four-tab" data-toggle="tab" href="#four" role="tab" aria-controls="four" aria-selected="false">Table C</a>
                                  </li>
                                   <li >
                                    <a  id="five-tab" data-toggle="tab" href="#five" role="tab" aria-controls="five" aria-selected="false">Table D</a>
                                  </li>
                                  <li >
                                    <a  id="six-tab" data-toggle="tab" href="#six" role="tab" aria-controls="six" aria-selected="false">Table E (a) For Coal</a>
                                  </li>
                                  <li >
                                    <a  id="seven-tab" data-toggle="tab" href="#seven" role="tab" aria-controls="seven" aria-selected="false">Table E (b) For Coke</a>
                                  </li>
                                </ul>
                                <div class="tab-content" id="myTabContent">
                                  <div class="tab-pane fade show active" id="first" role="tabpanel" aria-labelledby="first-tab">
                                
                                       
                                        <div class="form-group row">
                                         <div class="col-lg-3 col-md-6 col-sm-12">
                                                <label  class="col-form-label font-weight-bolder">Name of Mine</label>
                                                <input type="text" class="form-control">
                                            </div>
                                            <div class="col-lg-3 col-md-6 col-sm-12">
                                               <label class="col-form-label font-weight-bolder">Postal address of mine</label>
                                                 <textarea name="textAddress" rows="1" cols="20" id="Textarea1" class="form-control"></textarea>
                                                 <small class="text-danger">Maximum <strong>500</strong> characters</small>
                                            </div>
                                            <div class="col-lg-3 col-md-6 col-sm-12">
                                                 <label  class="col-form-label font-weight-bolder">Date of opening</label>
                                                  <div class="input-group">
                                                      <input type="text" class="form-control datepicker" id="Text1">
                                                      <div class="input-group-prepend">
                                                        <label class="input-group-text" for="inputDate1"><i class="far fa-calendar"></i></label>
                                                      </div>
                                                 </div>
                                            </div>
                                             <div class="col-lg-3 col-md-6 col-sm-12">
                                                <label class="col-form-label font-weight-bolder">Date of closing (if closed)</label>
                                                <div class="input-group">
                                                      <input type="text" class="form-control datepicker" id="Text2">
                                                      <div class="input-group-prepend">
                                                        <label class="input-group-text" for="inputDate1"><i class="far fa-calendar"></i></label>
                                                      </div>
                                                 </div>
                                            </div>
                                           
                                       </div>

                                        <div class="form-group row">
                                            
                                            <div class="col-lg-3 col-md-6 col-sm-12">
                                                 <label for="inputLoginId" class="col-form-label font-weight-bolder">State</label>
                                                 <input type="text" class="form-control">
                                            </div>
                                           
                                            <div class="col-lg-3 col-md-6 col-sm-12">
                                                <label  class="col-form-label font-weight-bolder">Situation of mine District</label>
                                                <input type="text" class="form-control">
                                            </div>
                                            <div class="col-lg-3 col-md-6 col-sm-12">
                                                 <label class="col-form-label font-weight-bolder">Name of Owner</label>
                                                <input type="text" class="form-control">
                                            </div>
                                             <div class="col-lg-3 col-md-6 col-sm-12">
                                                <label for="inputLoginId" class="col-form-label font-weight-bolder">Postal address of owner</label>
                                               
                                                 <textarea name="textAddress" rows="1" cols="20" id="Textarea2" class="form-control"></textarea>
                                                 <small class="text-danger">Maximum <strong>500</strong> characters</small>
                                            </div>
                                             
                                       </div>

                                      

                                        <div class="form-group row">
                                           
                                            <div class="col-lg-3 col-md-6 col-sm-12">
                                                <label class="col-form-label font-weight-bolder">Name of managing agents, if any</label>
                                                 <textarea name="textAddress" rows="1" cols="20" id="Textarea3" class="form-control"></textarea>
                                                 <small class="text-danger">Maximum <strong>500</strong> characters</small>
                                            </div>
                                            <div class="col-lg-3 col-md-6 col-sm-12">
                                                <label class="col-form-label font-weight-bolder">Postal address of managing agents</label>
                                                 <textarea name="textAddress" rows="1" cols="20" id="Textarea4" class="form-control"></textarea>
                                                 <small class="text-danger">Maximum <strong>500</strong> characters</small>
                                            </div>
                                            <div class="col-lg-3 col-md-6 col-sm-12">
                                                <label class="col-form-label font-weight-bolder">Name of Agent (if any) as defined in section 2(c) of the Mines Act, 1952</label>
                                                <input type="text" class="form-control">
                                            </div>
                                            <div class="col-lg-3 col-md-6 col-sm-12">
                                                <label class="col-form-label font-weight-bolder">Postal address agents</label>
                                                 <textarea name="textAddress" rows="1" cols="20" id="Textarea5" class="form-control"></textarea>
                                                 <small class="text-danger">Maximum <strong>500</strong> characters</small>
                                            </div>
                                            
                                       </div>

                                       

                                       <div class="form-group row">
                                       <div class="col-lg-3 col-md-6 col-sm-12">
                                                <label class="col-form-label font-weight-bolder">Name of manager<span class="text-danger">*</span></label>
                                                 <input type="number" class="form-control">
                                            </div>
                                            <div class="col-lg-3 col-md-6 col-sm-12">
                                                <label class="col-form-label font-weight-bolder ">Postal address of manager<span class="text-danger">*</span></label>
                                               <textarea name="textAddress" rows="1" cols="20" id="Textarea6" class="form-control"></textarea>
                                                 <small class="text-danger">Maximum <strong>500</strong> characters</small>
                                            </div>
                                            
                                            
                                            
                                            
                                       </div>

                                       

                                        <div class=" row">
                                       <div class="col-lg-6 col-md-12 col-sm-12">
                                                  <div class="table-responsive">
                                              <table class="table table-sm table-bordered" id="insert">
                                              <thead>
                                               <tr>
                                                   <th class="font-weight-bolder" width="30px">Sl#</th>
                                                   <th class="font-weight-bolder">Designations</th>
                                                   <th class="font-weight-bolder" width="300px">Numbers Employed</th> 
                                                   <th width="130px" class="font-weight-bolder">Actions</th>
                                               </tr>
                                            </thead>
                                            <tbody>
                                                <tr>
                                                    <td id="td1">
                                                        1
                                                    </td>
                                                    <td id="td2">
                                                        <input type="text" class="form-control">
                                                    </td>
                                                    <td id="td3">
                                                       <input type="number" class="form-control">
                                                    </td>
                                                    <td>
                                                         <a href="#" class="btn btn-success btn-md add-btn waves-effect waves-light" data-toggle="tooltip" data-placement="top" title="Add Row"><i class="fa fa-plus" aria-hidden="true"></i></a>
                                                    </td>

                                                </tr>
                                            </tbody>
                                        </table>  
                                        </div>
                                            </div>
                                            <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                            <div class="col-lg-4 col-md-12 col-sm-12">
                                                <label  class="col-form-label font-weight-bolder">Whether machinery is used</label>
                                                <input type="text" class="form-control">
                                            </div>
                                            <div class="col-lg-8 col-md-12 col-sm-12">
                                               <label class="col-form-label font-weight-bolder">Nature of power used, if any (eg, electricity, steam, compressed air, etc)</label>
                                                  <input type="text" class="form-control">
                                            </div>
                                            </div>
                                            </div>
                                             
                                            </div>


                                       <div class="row">
                                             <div class="col-sm-12">
                                                <div class="custom-control custom-checkbox">
                                                         <input type="checkbox" class="custom-control-input" id="customCheck1">
                                                         <label class="custom-control-label" for="customCheck1">
                                                        Certified that the information given above and in Tables A to C below is correct to the best of my knowledge</label>
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
                                  <div class="tab-pane fade" id="second" role="tabpanel" aria-labelledby="second-tab">
                                  <h5 class="text-brown font-weight-bold text-center">Table A - employment</h5>
                                  <h5 class="text-brown font-weight-bold text-center">Maximum number of persons employed on any one day during the month</h5>
                                     <div class="row">

                                    <div class="col-xl-6">
                                        <div class="bg-light p-2 form-group border">
                                            <div class="row">
                                            <div class="col-sm-7">
                                               <label class="col-form-label font-weight-bolder">In workings below ground on<span class="text-danger">*</span></label>
                                                <div class="input-group">
                                                      <input type="text" class="form-control datepicker" id="Text3">
                                                      <div class="input-group-prepend">
                                                        <label class="input-group-text" for="inputDate1"><i class="far fa-calendar"></i></label>
                                                      </div>
                                                 </div>
                                            </div>
                                            <div class="col-sm-5">
                                                 <label class="col-form-label font-weight-bolder">No. of employee<span class="text-danger">*</span></label>
                                                  <input type="number" class="form-control">
                                            </div>
                                           
                                       </div>
                                       </div>
                                        </div>
                                        <div class="col-xl-6">
                                        <div class="bg-light p-2 form-group border">
                                            <div class="row">
                                             <div class="col-sm-7">
                                                <label class="col-form-label font-weight-bolder">In all in the mine on<span class="text-danger">*</span></label>
                                                <div class="input-group">
                                                      <input type="text" class="form-control datepicker" id="Text4">
                                                      <div class="input-group-prepend">
                                                        <label class="input-group-text" for="inputDate2"><i class="far fa-calendar"></i></label>
                                                      </div>
                                                 </div>
                                            </div>
                                            <div class="col-sm-5">
                                                <label class="col-form-label font-weight-bolder">No. of employee<span class="text-danger">*</span></label>
                                                <input type="number" class="form-control">
                                            </div>
                                           
                                       </div>
                                       </div>
                                        </div>
                                            
                                            
                                       </div>

                                 
                                       <span class="font-weight-bold text-danger">Instructions</span>
                                           <ul class="pl-3">
                                               <li  class=" text-danger"> Give day of the week and the date and month.</li>
                                               <li class=" text-danger"> Obtained by adding the daily attendance for the whole year.</li>
                                               <li class=" text-danger"> Obtained by dividing the number of man-days worked by the number of working days. The total shown in column (4D) should agree with the quotient obtained by dividing the total 
                                          shown in column (2C) by the number of working days shown in column (3)</li> 
                                          <li class=" text-danger">Includes all cash payments including bonuses. Employer’s contributions to provident funds, welfare activities, etc., and concessions in kind should not be included. (e) Persons employed in the removal of overburden should be included among “Others” and not among “Miners and Loaders”.</li>    
                                           </ul> 
                                           
                                     

                                       <div class="table-responsive">
                                            <table class="table table-sm table-bordered mb-0">
                                            <tbody>
                                            <tr>
                                                <th  class="font-weight-bold">Classification</th>
                                                <th colspan="3" class="text-center font-weight-bold">Total number of mandays worked during the year (b)</th>
                                                <th  class="text-center font-weight-bold">Number of days worked during the year</th>
                                                <th colspan="4" class="text-center font-weight-bold">Average daily number of persons employed (c)</th>
                                                <th  class="text-center font-weight-bold">Total wages or salary bill for the year(d)</th>
                                                
                                            </tr>
                                            <tr>
                                                <th class=" font-weight-bold">1</th>
                                                <th class="text-center font-weight-bold">2A</th>
                                                <th class="text-center font-weight-bold">2B</th>
                                                <th class="text-center font-weight-bold">2C</th>
                                                <th class="text-center font-weight-bold">3</th>
                                                <th class="text-center font-weight-bold">4A</th>
                                                <th class="text-center font-weight-bold">4B</th>
                                                <th class="text-center font-weight-bold">4C</th>
                                                <th class="text-center font-weight-bold">4D</th>
                                                <th class="text-center font-weight-bold">5</th>
                                                
                                            </tr>
                                            
                                            <tr>
                                                <td class="font-weight-bold">Below ground:(i) Overman & Sirdars</td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                               <td><input class="form-control" type="number"></td>
                                               <td><input class="form-control" type="number"></td>
                                               <td><input class="form-control" type="number"></td>
                                               
                                               
                                            </tr>
                                            <tr>
                                                <td class="font-weight-bold">Below ground:(ii) Miners & Loaders</td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                               <td><input class="form-control" type="number"></td>
                                               <td><input class="form-control" type="number"></td>
                                               <td><input class="form-control" type="number"></td>
                                              
                                                
                                            </tr>
                                            <tr>
                                                <td class="font-weight-bold">Below ground:(iii) Others</td>
                                               <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                               <td><input class="form-control" type="number"></td>
                                               <td><input class="form-control" type="number"></td>
                                               <td><input class="form-control" type="number"></td>
                                               
                                               
                                            </tr>
                                            <tr>
                                                <td class="font-weight-bold">Opencast Working :(i) Overman & Sirdars</td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                               <td><input class="form-control" type="number"></td>
                                               <td><input class="form-control" type="number"></td>
                                               <td><input class="form-control" type="number"></td>
                                              
                                                
                                            </tr>
                                             <tr>
                                                <td class="font-weight-bold">Opencast Working :(ii) Miners & Loaders</td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                               <td><input class="form-control" type="number"></td>
                                               <td><input class="form-control" type="number"></td>
                                               <td><input class="form-control" type="number"></td>
                                              
                                                
                                            </tr>
                                           
                                            <tr>
                                                <td class="font-weight-bold"> Opencast Working :(iii) Others</td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                               <td><input class="form-control" type="number"></td>
                                               <td><input class="form-control" type="number"></td>
                                               <td><input class="form-control" type="number"></td>
                                               
                                                
                                            </tr>
                                             <tr>
                                                <td class="font-weight-bold">Above ground :(i) Clerical and Supervisory staff (excluding the superior supervisory staff )</td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                               <td><input class="form-control" type="number"></td>
                                               <td><input class="form-control" type="number"></td>
                                               <td><input class="form-control" type="number"></td>
                                              
                                                
                                            </tr>
                                             <tr>
                                                <td class="font-weight-bold">Above ground :(ii) Workers in any attached factory, workshop or mineral dressing plant.</td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                               <td><input class="form-control" type="number"></td>
                                               <td><input class="form-control" type="number"></td>
                                               <td><input class="form-control" type="number"></td>
                                              
                                                
                                            </tr>
                                             <tr>
                                                <td class="font-weight-bold">Above ground :(iii) Others.</td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                               <td><input class="form-control" type="number"></td>
                                               <td><input class="form-control" type="number"></td>
                                               <td><input class="form-control" type="number"></td>
                                              
                                                
                                            </tr>
                                             <tr>
                                                <td class="font-weight-bold">Total</td>
                                                <td><input class="form-control" type="number" readonly></td>
                                                <td><input class="form-control" type="number" readonly></td>
                                                <td><input class="form-control" type="number" readonly></td>
                                                <td><input class="form-control" type="number" readonly></td>
                                                <td><input class="form-control" type="number" readonly></td>
                                                <td><input class="form-control" type="number" readonly></td>
                                               <td><input class="form-control" type="number" readonly></td>
                                               <td><input class="form-control" type="number" readonly></td>
                                               <td><input class="form-control" type="number" readonly></td>
                                               
                                               
                                            </tr>
                                        </tbody>
                                        </table>
                                        </div>
                                         <div class="row mt-3">
                                        <div class="col-sm-12 text-center">
                                            <a  class="btn btn-dark btn-md ml-0 waves-effect waves-light btnPrevious">Previous</a>
                                            <a class="btn btn-danger btn-md ml-0 waves-effect waves-light">Reset</a>
                                            <a  class="btn btn-primary btn-md ml-0 waves-effect waves-light btnNext">Next</a> 
                                        </div>
                                     </div>
                                    
                                  </div>
                                  <div class="tab-pane fade" id="third" role="tabpanel" aria-labelledby="third-tab">
                                  <h5 class="text-brown font-weight-bold text-center">Table B – Type and agregate horse-power of electrical appartatus</h5>
                                       <h6 class="text-brown font-weight-bold">1. Electricity generated, purchased or received otherwise (in kwh)</h6>
                                       <div class="row">
                                       <div class="col-xl-6">
                                        <div class="bg-light p-2 form-group border">
                                        <label class="col-form-label font-weight-bolder pt-0">(a) For own use<span class="text-danger">*</span></label>
                                            <div class="row">
                                             
                                            <div class="col-sm-6">
                                              <input type="number" class="form-control" placeholder="Generated">
                                            </div>
                                            <div class="col-sm-6">
                                              <input type="number" class="form-control" placeholder="Purchased or received">
                                            </div>
                                            
                                           
                                       </div>
                                       </div>
                                        </div>
                                        <div class="col-xl-6">
                                        <div class="bg-light p-2 form-group border">
                                        <label class="col-form-label font-weight-bolder pt-0">(b) For Sale<span class="text-danger">*</span></label>
                                            <div class="row">
                                             
                                            <div class="col-sm-6">
                                              <input type="number" class="form-control" placeholder="Generated">
                                            </div>
                                            <div class="col-sm-6">
                                              <input type="number" class="form-control" placeholder="Purchased or received">
                                            </div>
                                            
                                           
                                       </div>
                                       </div>
                                        </div>
                                       </div>
                                       <h6 class="text-brown font-weight-bold">2. System of supply (whether direct current or alternating current</h6>
                                       <div class="row">
                                       <div class="col-xl-4">
                                        <div class="bg-light p-2 form-group border">
                                        <label class="col-form-label font-weight-bolder pt-0">(a) Voltage of supply<span class="text-danger">*</span></label>
                                            <div class="row">
                                             
                                            <div class="col-sm-6">
                                              <input type="number" class="form-control">
                                            </div>
                                           
                                       </div>
                                       </div>
                                        </div>
                                        <div class="col-xl-4">
                                        <div class="bg-light p-2 form-group border">
                                        <label class="col-form-label font-weight-bolder pt-0">(b) Periodicity<span class="text-danger">*</span></label>
                                            <div class="row">
                                             
                                            <div class="col-sm-6">
                                              <input type="number" class="form-control">
                                            </div>
                                           
                                            
                                           
                                       </div>
                                       </div>
                                        </div>
                                        <div class="col-xl-4">
                                        <div class="bg-light p-2 form-group border">
                                        <label class="col-form-label font-weight-bolder pt-0">(c) Source of supply<span class="text-danger">*</span></label>
                                            <div class="row">
                                             
                                            <div class="col-sm-6">
                                              <input type="number" class="form-control" >
                                            </div>
                                          
                                            
                                           
                                       </div>
                                       </div>
                                        </div>
                                       </div>
                                       <h6 class="text-brown font-weight-bold">3. Voltage at which current is used for</h6>
                                       <div class="row">
                                       <div class="col-xl-6">
                                        <div class="bg-light p-2 form-group border">
                                        <label class="col-form-label font-weight-bolder pt-0">(a) Lighting<span class="text-danger">*</span></label>
                                            <div class="row">
                                             
                                            <div class="col-sm-6">
                                              <input type="number" class="form-control" placeholder="Above ground">
                                            </div>
                                            <div class="col-sm-6">
                                              <input type="number" class="form-control" placeholder="Below ground">
                                            </div>
                                           
                                       </div>
                                       </div>
                                        </div>
                                        <div class="col-xl-6">
                                        <div class="bg-light p-2 form-group border">
                                        <label class="col-form-label font-weight-bolder pt-0">(b) Power<span class="text-danger">*</span></label>
                                            <div class="row">
                                             
                                           <div class="col-sm-6">
                                              <input type="number" class="form-control" placeholder="Above ground">
                                            </div>
                                            <div class="col-sm-6">
                                              <input type="number" class="form-control" placeholder="Below ground">
                                            </div>
                                           
                                            
                                           
                                       </div>
                                       </div>
                                        </div>
                                        
                                       </div>
                                        <h6 class="text-brown font-weight-bold">4.Length of cables (in metres)</h6>
                                       <div class="row">
                                       <div class="col-xl-6">
                                        <div class="bg-light p-2 form-group border">
                                        <label class="col-form-label font-weight-bolder pt-0">(a) High pressure<span class="text-danger">*</span></label>
                                            <div class="row">
                                             
                                            <div class="col-sm-6">
                                              <input type="number" class="form-control">
                                            </div>
                                           
                                       </div>
                                       </div>
                                        </div>
                                        <div class="col-xl-6">
                                        <div class="bg-light p-2 form-group border">
                                        <label class="col-form-label font-weight-bolder pt-0">(b) Medium pressure<span class="text-danger">*</span></label>
                                            <div class="row">
                                             
                                            <div class="col-sm-6">
                                              <input type="number" class="form-control">
                                            </div>
                                           
                                            
                                           
                                       </div>
                                       </div>
                                        </div>
                                        
                                       </div>
                                       <h6 class="text-brown font-weight-bold">5. Total number and aggregate horse-power of motors</h6>
                                       <div class="table-responsive">
                                            <table class="table table-sm table-bordered">
                                            <tbody>
                                            <tr>
                                                <th rowspan="2" class="font-weight-bold">(a) Installed above ground for :</th>
                                                <th colspan="2" class="text-center font-weight-bold">In use</th>
                                                <th colspan="2" class="text-center font-weight-bold">In reserve</th>
                                            </tr>
                                            <tr>
                                                <th class="text-center font-weight-bold">Number of units</th>
                                                <th class="text-center font-weight-bold">Total h.p.</th>
                                                <th class="text-center font-weight-bold">Number of units</th>
                                                <th class="text-center font-weight-bold">Total h.p.</th>
                                                
                                            </tr>
                                            
                                            <tr>
                                                <td>(i) Winding<span class="text-danger">*</span></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                               
                                            </tr>
                                            <tr>
                                                <td>(ii) Ventilation<span class="text-danger">*</span></td>
                                                 <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                            </tr>
                                            <tr>
                                                <td>(iii) Haulage<span class="text-danger">*</span></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                            </tr>
                                             <tr>
                                                <td>(iv) Pumping<span class="text-danger">*</span></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                            </tr>
                                             <tr>
                                                <td>(v) Coal washing, screening or handling plants<span class="text-danger">*</span></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                            </tr>
                                            <tr>
                                                <td>(vi) Workshops including foundry, smithy etc.<span class="text-danger">*</span></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                            </tr>
                                             <tr>
                                                <td><input class="form-control" type="text" placeholder="(vii) Miscellaneous (specify)"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                            </tr>
                                            <tr>
                                                <td class="font-weight-bold">Total</td>
                                                <td><input class="form-control" readonly="readonly" type="text"></td>
                                                <td><input class="form-control" readonly="readonly" type="text"></td>
                                                <td><input class="form-control" readonly="readonly" type="text"></td>
                                                <td><input class="form-control" readonly="readonly" type="text"></td>
                                                
                                            </tr>
                                        </tbody>
                                        </table>
                                        <table class="table table-sm table-bordered">
                                            <tbody>
                                            <tr>
                                                <th rowspan="2" class="font-weight-bold">(a) Installed above ground for :</th>
                                                <th colspan="2" class="text-center font-weight-bold">In use</th>
                                                <th colspan="2" class="text-center font-weight-bold">In reserve</th>
                                            </tr>
                                            <tr>
                                                <th class="text-center font-weight-bold">Number of units</th>
                                                <th class="text-center font-weight-bold">Total h.p.</th>
                                                <th class="text-center font-weight-bold">Number of units</th>
                                                <th class="text-center font-weight-bold">Total h.p.</th>
                                                
                                            </tr>
                                            
                                            <tr>
                                                <td>(i) Winding<span class="text-danger">*</span></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                               
                                            </tr>
                                            <tr>
                                                <td>(ii) Ventilation<span class="text-danger">*</span></td>
                                                 <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                            </tr>
                                            <tr>
                                                <td>(iii) Haulage<span class="text-danger">*</span></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                            </tr>
                                             <tr>
                                                <td>(iv) Pumping<span class="text-danger">*</span></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                            </tr>
                                             <tr>
                                                <td>(v) Other portable machines (drill, etc.)<span class="text-danger">*</span></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                            </tr>
                                            <tr>
                                                <td>(vi) Conveyors, loaders, scrapers, etc.<span class="text-danger">*</span></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                            </tr>
                                             <tr>
                                                <td>(vii) Electric traction (locomotives, etc.)<span class="text-danger">*</span></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                            </tr>
                                             <tr>
                                                <td><input class="form-control" type="text" placeholder="(vii) Miscellaneous (specify)"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                            </tr>
                                            <tr>
                                                <td class="font-weight-bold">Total</td>
                                                <td><input class="form-control" readonly="readonly" type="text"></td>
                                                <td><input class="form-control" readonly="readonly" type="text"></td>
                                                <td><input class="form-control" readonly="readonly" type="text"></td>
                                                <td><input class="form-control" readonly="readonly" type="text"></td>
                                                
                                            </tr>
                                        </tbody>
                                        </table>
                                        <table class="table table-sm table-bordered">
                                            <tbody>
                                            <tr>
                                                <th rowspan="2" class="font-weight-bold">(a) Installed above ground for :</th>
                                                <th colspan="2" class="text-center font-weight-bold">In use</th>
                                                <th colspan="2" class="text-center font-weight-bold">In reserve</th>
                                            </tr>
                                            <tr>
                                                <th class="text-center font-weight-bold">Number of units</th>
                                                <th class="text-center font-weight-bold">Total h.p.</th>
                                                <th class="text-center font-weight-bold">Number of units</th>
                                                <th class="text-center font-weight-bold">Total h.p.</th>
                                                
                                            </tr>
                                             <tr>
                                                <td>(i) Haulage<span class="text-danger">*</span></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                            </tr>
                                           
                                            <tr>
                                                <td>(ii) Ventilation<span class="text-danger">*</span></td>
                                                 <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                            </tr>
                                           
                                             <tr>
                                                <td>(iii) Pumping<span class="text-danger">*</span></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                            </tr>
                                             <tr>
                                                <td>(iv) Coal-cutting machine<span class="text-danger">*</span></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                            </tr>
                                            <tr>
                                                <td>(v) Other portable machines (drill, etc.)<span class="text-danger">*</span></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                            </tr>
                                             <tr>
                                                <td>(v) Conveyors, loaders, scrapers, etc.<span class="text-danger">*</span></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                            </tr>
                                             <tr>
                                                <td>(vii) Electric traction (locomotives, etc.)<span class="text-danger">*</span></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                            </tr>
                                             <tr>
                                                <td><input class="form-control" type="text" placeholder="(vii) Miscellaneous (specify)"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                            </tr>
                                            <tr>
                                                <td class="font-weight-bold">Total</td>
                                                <td><input class="form-control" readonly="readonly" type="text"></td>
                                                <td><input class="form-control" readonly="readonly" type="text"></td>
                                                <td><input class="form-control" readonly="readonly" type="text"></td>
                                                <td><input class="form-control" readonly="readonly" type="text"></td>
                                                
                                            </tr>
                                        </tbody>
                                        </table>
                                        </div>
                                     <div class="row">
                                        <div class="col-sm-12 text-center">
                                            <a  class="btn btn-dark btn-md ml-0 waves-effect waves-light btnPrevious">Previous</a>
                                            <a class="btn btn-danger btn-md ml-0 waves-effect waves-light">Reset</a>
                                            <a  class="btn btn-primary btn-md ml-0 waves-effect waves-light btnNext">Next</a> 
                                        </div>
                                     </div>
                                  </div>
                                  <div class="tab-pane fade" id="four" role="tabpanel" aria-labelledby="four-tab">
                                   
                                     <h5 class="text-brown font-weight-bold text-center">Table C- Type and aggregate horse-power of machinery and equipment (other than electrical apparatus)</h5>
                                     <div class="table-responsive">
                                            <table class="table table-sm table-bordered">
                                            <tbody>
                                            <tr>
                                                <th rowspan="2" class="font-weight-bold">(a) Power generators :</th>
                                                <th colspan="2" class="text-center font-weight-bold">In use</th>
                                                <th colspan="2" class="text-center font-weight-bold">In reserve</th>
                                            </tr>
                                            <tr>
                                                <th class="text-center font-weight-bold">Number of units</th>
                                                <th class="text-center font-weight-bold">Total h.p.</th>
                                                <th class="text-center font-weight-bold">Number of units</th>
                                                <th class="text-center font-weight-bold">Total h.p.</th>
                                                
                                            </tr>
                                            
                                            <tr>
                                                <td>(i)Boilers<span class="text-danger">*</span></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                               
                                            </tr>
                                            <tr>
                                                <td>(ii) Steam Turbines<span class="text-danger">*</span></td>
                                                 <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                            </tr>
                                            <tr>
                                                <td>(iii)Diesel Engines<span class="text-danger">*</span></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                            </tr>
                                             <tr>
                                                <td>(iv) Gasoline, Gas or Oil Engines other than Diesel Engines<span class="text-danger">*</span></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                            </tr>
                                             <tr>
                                                <td>(v) Hydraulic Turbines or Water Wheels<span class="text-danger">*</span></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                            </tr>
                                            <tr>
                                                <td>(vi) Air Compressors<span class="text-danger">*</span></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                            </tr>
                                            
                                            <tr>
                                                <td class="font-weight-bold">Total</td>
                                                <td><input class="form-control" readonly="readonly" type="text"></td>
                                                <td><input class="form-control" readonly="readonly" type="text"></td>
                                                <td><input class="form-control" readonly="readonly" type="text"></td>
                                                <td><input class="form-control" readonly="readonly" type="text"></td>
                                                
                                            </tr>
                                        </tbody>
                                        </table>
                                        <table class="table table-sm table-bordered">
                                            <tbody>
                                            <tr>
                                                <th rowspan="2" class="font-weight-bold">(a) Machinery Installed above ground for :</th>
                                                <th colspan="2" class="text-center font-weight-bold">In use</th>
                                                <th colspan="2" class="text-center font-weight-bold">In reserve</th>
                                            </tr>
                                            <tr>
                                                <th class="text-center font-weight-bold">Number of units</th>
                                                <th class="text-center font-weight-bold">Total h.p.</th>
                                                <th class="text-center font-weight-bold">Number of units</th>
                                                <th class="text-center font-weight-bold">Total h.p.</th>
                                                
                                            </tr>
                                            
                                            <tr>
                                                <td>(i) Winding<span class="text-danger">*</span></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                               
                                            </tr>
                                            <tr>
                                                <td>(ii) Ventilation<span class="text-danger">*</span></td>
                                                 <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                            </tr>
                                            <tr>
                                                <td>(iii) Haulage<span class="text-danger">*</span></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                            </tr>
                                             <tr>
                                                <td>(iv) Pumping<span class="text-danger">*</span></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                            </tr>
                                             <tr>
                                                <td>(v) Mineral dressing plants<span class="text-danger">*</span></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                            </tr>
                                            <tr>
                                                <td>(vi)Workshops including foundry, smithy etc.<span class="text-danger">*</span></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                            </tr>
                                            
                                             <tr>
                                                <td><input class="form-control" type="text" placeholder="(vii) Miscellaneous (specify)"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                            </tr>
                                            <tr>
                                                <td class="font-weight-bold">Total</td>
                                                <td><input class="form-control" readonly="readonly" type="text"></td>
                                                <td><input class="form-control" readonly="readonly" type="text"></td>
                                                <td><input class="form-control" readonly="readonly" type="text"></td>
                                                <td><input class="form-control" readonly="readonly" type="text"></td>
                                                
                                            </tr>
                                        </tbody>
                                        </table>
                                        <table class="table table-sm table-bordered mb-0">
                                            <tbody>
                                            <tr>
                                                <th rowspan="2" class="font-weight-bold">(a) Installed above ground for :</th>
                                                <th colspan="2" class="text-center font-weight-bold">In use</th>
                                                <th colspan="2" class="text-center font-weight-bold">In reserve</th>
                                            </tr>
                                            <tr>
                                                <th class="text-center font-weight-bold">Number of units</th>
                                                <th class="text-center font-weight-bold">Total h.p.</th>
                                                <th class="text-center font-weight-bold">Number of units</th>
                                                <th class="text-center font-weight-bold">Total h.p.</th>
                                                
                                            </tr>
                                             <tr>
                                                <td>(i) Haulage<span class="text-danger">*</span></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                            </tr>
                                           
                                            <tr>
                                                <td>(ii) Ventilation<span class="text-danger">*</span></td>
                                                 <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                            </tr>
                                           
                                             <tr>
                                                <td>(iii) Pumping<span class="text-danger">*</span></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                            </tr>
                                             <tr>
                                                <td>(iv) locomotives, etc.<span class="text-danger">*</span></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                            </tr>
                                           
                                             <tr>
                                                <td><input class="form-control" type="text" placeholder="(v) Miscellaneous (specify)"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                                <td><input class="form-control" type="number"></td>
                                            </tr>
                                            <tr>
                                                <td class="font-weight-bold">Total</td>
                                                <td><input class="form-control" readonly="readonly" type="text"></td>
                                                <td><input class="form-control" readonly="readonly" type="text"></td>
                                                <td><input class="form-control" readonly="readonly" type="text"></td>
                                                <td><input class="form-control" readonly="readonly" type="text"></td>
                                                
                                            </tr>
                                        </tbody>
                                        </table>
                                        </div>

                                        <div class="row mt-3">
                                        <div class="col-sm-12 text-center">
                                            <a  class="btn btn-dark btn-md ml-0 waves-effect waves-light btnPrevious">Previous</a>
                                            <a class="btn btn-danger btn-md ml-0 waves-effect waves-light">Reset</a>
                                            <a  class="btn btn-primary btn-md ml-0 waves-effect waves-light btnNext">Next</a> 
                                        </div>
                                     </div>
                                   </div>
                                  <div class="tab-pane fade" id="five" role="tabpanel" aria-labelledby="five-tab">
                                   <h5 class="text-brown font-weight-bold text-center">Table D – explosives, safety lamps, rock drills and mechanical ventilators
Ventilators</h5>
                                  <h6 class="text-brown font-weight-bold">1 Explosives</h6>
                                        <div class="table-responsive">
                                         <table class="table table-sm table-bordered">
                                             <tbody>
                                             <tr>
                                                            <th rowspan="2"  class="font-weight-bolder">Name of explosive<span class="text-danger">*</span></td>
                                                            <th rowspan="2"  class="font-weight-bolder">Quantity used (in kgm)<span class="text-danger">*</span></td>
                                                            <th colspan="2"  class="font-weight-bolder text-center">Number of detonators used<span class="text-danger">*</span></td>
                                                        </tr>
                                                        <tr>
                                                            <th class="font-weight-bolder text-center">Electric</th>
                                                            <th class="font-weight-bolder text-center">Ordinary</th>
                                                        </tr>
                                                        <tr>
                                                            <td><input class="form-control" type="number"></td>
                                                            <td><input class="form-control" type="text"></td>
                                                            <td><input class="form-control" type="number"></td>
                                                            <td><input class="form-control" type="number"></td>
                                                        </tr>
                                                    </tbody></table>
                                        
                                       </div>
                                        <h6 class="text-brown font-weight-bold">2 Safety Lamps</h6>
                                      
                                       <div class="table-responsive">
                                         <table class="table table-sm table-bordered">
                                             <tbody>
                                             <tr>
                                                            <th rowspan="2"  class="font-weight-bolder">Name and type of safety lamps<span class="text-danger">*</span></td>
                                                            <th colspan="3"  class="font-weight-bolder text-center">Number of safety lamps according to method of locking<span class="text-danger">*</span></td>
                                                            
                                                        </tr>
                                                        <tr>
                                                            <th class="font-weight-bolder text-center">Lead rivet</th>
                                                            <th class="font-weight-bolder text-center">Magnetic</th>
                                                            <th class="font-weight-bolder text-center">Other</th>
                                                        </tr>
                                                        <tr>
                                                        <td>
                                                        <input class="form-control" type="text"></td>
                                                            <td><input class="form-control" type="number"></td>
                                                            
                                                            <td><input class="form-control" type="number"></td>
                                                            <td><input class="form-control" type="number"></td>
                                                        </tr>
                                                    </tbody></table>
                                        
                                       </div>
                                        <h6 class="text-brown font-weight-bold">3 Mechanical Ventilators</h6>
                                       <div class="table-responsive">
                                         <table class="table table-sm table-bordered mb-0">
                                             <tbody>
                                             <tr>
                                                            <th class="font-weight-bolder">Name and size of Mechanical Ventilator<span class="text-danger">*</span></td>
                                                            <th class="font-weight-bolder">Position where installed<span class="text-danger">*</span></td>
                                                            <th class="font-weight-bolder">Average total quantity of air delivered per minute<span class="text-danger">*</span></td>
                                                             <th class="font-weight-bolder">Water gauge obtained (in centimeters)<span class="text-danger">*</span></td>
                                                        </tr>
                                                       
                                                        <tr>
                                                            <td><input class="form-control" type="text"></td>
                                                            <td><input class="form-control" type="text"></td>
                                                            <td><input class="form-control" type="number"></td>
                                                            <td><input class="form-control" type="number"></td>
                                                        </tr>
                                                    </tbody></table>
                                        
                                       </div>
                                        <div class="row mt-3">
                                        <div class="col-sm-12 text-center">
                                            <a  class="btn btn-dark btn-md ml-0 waves-effect waves-light btnPrevious">Previous</a>
                                            <a class="btn btn-danger btn-md ml-0 waves-effect waves-light">Reset</a>
                                            <a  class="btn btn-primary btn-md ml-0 waves-effect waves-light btnNext">Next</a> 
                                        </div>
                                     </div>
                                     
                                   </div>
                                   <div class="tab-pane fade" id="six" role="tabpanel" aria-labelledby="six-tab">
                                    <h5 class="text-brown font-weight-bold text-center">Table E – explosives, safety lamps, rock drills and mechanical ventilators
(a) for coal (including rubble and slack)</h5>
                                  <div class="row">
                                    <div class="col-sm-12 mt-3">
                                            <div class="table-responsive">
                                                <table id="datatable3" class="table table-sm table-bordered">
                                                    <thead>
                                                        <tr>
                                                           
                                                            <th>Grade</th>
                                                            <th>Opening Stocks</th>
                                                            <th >Coal Raised</th>
                                                            <th>Total Value of Raising(b)</th>
                                                            <th>Total of columns 2 and 3 (c)</th>
                                                            <th >coal Despatched</th>
                                                            <th >Colliery Consumption</th>
                                                            <th >Coal used for coking</th>
                                                            <th >Shortage due to causes</th>
                                                            <th >Closing stocks</th>
                                                            <th >Total of columns 6,7,8,9,10</th>
                                                            <th class="noprint" >Actions</th>
                                                        </tr>
                                                       
                                                      
                                                      
                                                    </thead>
                                                    <tbody>
                                                        <tr>
                                                            
                                                            
                                                           
                                                            <td>xxx</td>
                                                           <td>xxx</td>
                                                           <td>xxx</td>
                                                           <td>xxx</td>
                                                           <td>xxx</td>
                                                           <td>xxx</td>
                                                           <td>xxx</td>
                                                           <td>xxx</td>
                                                           <td>xxx</td>
                                                           <td>xxx</td>
                                                           <td>xxx</td>
                                                            <td class="noprint"><a data-toggle="modal"
                                                data-target=".alert-modal"
                                                                    class="btn-floating btn-outline-primary btn-sm"
                                                                    data-toggle="tooltip" data-placement="top" title="Edit"><i class="fas fa-pencil-alt"></i></a>
                                                                <a href="javascript:void(0);"
                                                                    class="btn-floating btn-outline-danger btn-sm"
                                                                    data-toggle="tooltip" data-placement="top" title="Delete"><i class="far fa-trash-alt"></i></a>
                                                                    <a href="javascript:void(0);"
                                                                    class="btn-floating btn-outline-success btn-sm"
                                                                     data-toggle="modal"
                                                data-target=".alert-modal" data-toggle="tooltip" data-placement="top" title="Add New"><i class="fas fa-plus"></i></a>
                                                            </td>
                                                        </tr>
                                                        
                                                    </tbody>
                                                </table>
                                            </div>
                                            
                                            
                                        </div>    
                                    </div>
                                      <div class="row">
                                        <div class="col-sm-12 text-center">
                                            <a  class="btn btn-dark btn-md ml-0 waves-effect waves-light btnPrevious">Previous</a>
                                            <a class="btn btn-danger btn-md ml-0 waves-effect waves-light">Reset</a>
                                            <a  class="btn btn-primary btn-md ml-0 waves-effect waves-light btnNext">Next</a> 
                                        </div>
                                     </div>  
                                    
                                   </div>
                                   <div class="tab-pane fade" id="seven" role="tabpanel" aria-labelledby="seven-tab">
                                  <h5 class="text-brown font-weight-bold text-center">Table E – explosives, safety lamps, rock drills and mechanical ventilators
(b) for coke</h5>
                                        <div class="table-responsive">
                                         <table class="table table-sm table-bordered">
                                             <tbody>
                                             <tr>
                                                            <th  class="font-weight-bolder" width="200px">Type of coke</td>
                                                            <th  class="font-weight-bolder">Opening stocks on 1st January</td>
                                                            <th  class="font-weight-bolder">Coke manufactured</td>
                                                             <th  class="font-weight-bolder">Total value of coke made (a) (in Rupees)</td>
                                                              <th  class="font-weight-bolder">Total of columns 2 and 3 (b)</td>
                                                               <th  class="font-weight-bolder">Coke despatched</td>
                                                                <th  class="font-weight-bolder">Colliery consumption</td>
                                                                 <th  class="font-weight-bolder">Shortage, if any</td>
                                                                  <th  class="font-weight-bolder">Closing stocks on 31st December</td>
                                                                   <th  class="font-weight-bolder">Total of columns 6,7,8,9 (b)</td>
                                                        </tr>
                                                       
                                                        <tr>
                                                        <td class="font-weight-bolder">Coke (hard)</td>
                                                            <td><input class="form-control" type="number"></td>
                                                            <td><input class="form-control" type="number"></td>
                                                            <td><input class="form-control" type="number"></td>
                                                            <td><input class="form-control" type="number" readonly></td>
                                                            <td><input class="form-control" type="number" ></td>
                                                            <td><input class="form-control" type="number"></td>
                                                            <td><input class="form-control" type="number"></td>
                                                            <td><input class="form-control" type="number" readonly></td>
                                                             <td><input class="form-control" type="number" readonly></td>
                                                        </tr>
                                                        
                                                        <tr>
                                                        <td class="font-weight-bolder">Coke (soft)</td>
                                                            <td><input class="form-control" type="number"></td>
                                                            <td><input class="form-control" type="number"></td>
                                                            <td><input class="form-control" type="number"></td>
                                                            <td><input class="form-control" type="number" readonly></td>
                                                            <td><input class="form-control" type="number" ></td>
                                                            <td><input class="form-control" type="number"></td>
                                                            <td><input class="form-control" type="number"></td>
                                                            <td><input class="form-control" type="number" readonly></td>
                                                             <td><input class="form-control" type="number" readonly></td>
                                                        </tr>
                                                    </tbody></table>
                                        
                                       </div>
                                        
                                     <div class="row">
                                        <div class="col-sm-12 text-center">
                                            <a  class="btn btn-dark btn-md ml-0 waves-effect waves-light btnPrevious">Previous</a>
                                            <a class="btn btn-danger btn-md ml-0 waves-effect waves-light">Reset</a>
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
    <!-- alert 1-->
    <div class="modal fade alert-modal" tabindex="-1" role="dialog" aria-labelledby="alertModal" aria-hidden="true">
        <div class="modal-dialog modal-xl" role="document">
            <div class="modal-content">
             <div class="modal-header p-3">
        <h5 class="modal-title m-0">Add New for Table E</h5>
        <a class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </a>
      </div>
                <div class="modal-body">
                      <div class="row">
                         <div class="col-sm-6">
                             <div class="form-group row">
                                <label class="col-sm-5 col-form-label font-weight-bolder">Mineral Grade</label>
                                 <div class="col-sm-7">
                                      <select class="form-control form-control-sm searchableselect">
                                        <option>Select</option>
                                        <option></option>
                                     </select>
                                 </div>
                              </div>
                         </div>
                          <div class="col-sm-6">
                             <div class="form-group row">
                                <label class="col-sm-5 col-form-label font-weight-bolder">Opening stocks on 1st January</label>
                                 <div class="col-sm-7">
                                      <input class="form-control" type="text" readonly>
                                 </div>
                              </div>
                         </div>
                          <div class="col-sm-6">
                             <div class="form-group row">
                                <label class="col-sm-5 col-form-label font-weight-bolder">Coal raised (includin g colliery consumption and coalused for coke making)<span class="text-danger">*</span></label>
                                 <div class="col-sm-7">
                                     <input class="form-control" type="number">
                                 </div>
                              </div>
                         </div>
                         <div class="col-sm-6">
                             <div class="form-group row">
                                <label class="col-sm-5 col-form-label font-weight-bolder">Total value of rasing (b) (in Rupees)<span class="text-danger">*</span></label>
                                 <div class="col-sm-7">
                                      <input class="form-control" type="number">
                                 </div>
                              </div>
                         </div>
                         <div class="col-sm-6">
                             <div class="form-group row">
                                <label class="col-sm-5 col-form-label font-weight-bolder">Total of columns 2 and 3(c)</label>
                                 <div class="col-sm-7">
                                      <input class="form-control" type="number" readonly>
                                 </div>
                              </div>
                         </div>
                         <div class="col-sm-6">
                             <div class="form-group row">
                                <label class="col-sm-5 col-form-label font-weight-bolder">Coal despatched (including coal despatched to coke factories which should be indicated separately)</label>
                                 <div class="col-sm-7">
                                      <input class="form-control" type="text" readonly>
                                 </div>
                              </div>
                         </div>
                         <div class="col-sm-6">
                             <div class="form-group row">
                                <label class="col-sm-5 col-form-label font-weight-bolder">Consumption (exclusive of coal used for coke making)<span class="text-danger">*</span></label>
                                 <div class="col-sm-7">
                                      <input class="form-control" type="number">
                                 </div>
                              </div>
                         </div>
                         <div class="col-sm-6">
                             <div class="form-group row">
                                <label class="col-sm-5 col-form-label font-weight-bolder">Coal used for coking, if any, on colliery<span class="text-danger">*</span></label>
                                 <div class="col-sm-7">
                                      <input class="form-control" type="number">
                                 </div>
                              </div>
                         </div>
                         <div class="col-sm-6">
                             <div class="form-group row">
                                <label class="col-sm-5 col-form-label font-weight-bolder">Shortage due to fire,rains and other causes<span class="text-danger">*</span></label>
                                 <div class="col-sm-7">
                                     <input class="form-control" type="number">
                                 </div>
                              </div>
                         </div>
                         <div class="col-sm-6">
                             <div class="form-group row">
                                <label class="col-sm-5 col-form-label font-weight-bolder">Closing stocks</label>
                                 <div class="col-sm-7">
                                      <input class="form-control" type="text" readonly>
                                 </div>
                              </div>
                         </div>
                         <div class="col-sm-6">
                             <div class="form-group row">
                                <label class="col-sm-5 col-form-label font-weight-bolder">Total</label>
                                 <div class="col-sm-7">
                                       <input class="form-control" type="text" readonly>
                                 </div>
                              </div>
                         </div>
                         
                         
                        
                         
                      </div>
               
                 
                 
                
                    <a class="btn btn-primary btn-md m-0" href="#">Submit</a>
                    <a class="btn btn-danger btn-md m-0" href="#">Reset</a>
                    
                </div>
               
            </div>
        </div>
    </div>
   
    <link rel="stylesheet" href="../css/searchable-select.min.css">
    <script src="../js/searchable-select.min.js"></script>
     <link rel="stylesheet" href="../css/dataTables.bootstrap4.min.css">
    <script src="../js/jquery.dataTables.min.js"></script>
    <script src="../js/dataTables.bootstrap4.min.js"></script>
     <link href="../css/bootstrap-datetimepicker.min.css" rel="stylesheet">
    <script src="../js/moment.min.js"></script> 
    <script src="../js/bootstrap-datetimepicker.min.js"></script>
    
    <script>


        $(document).ready(function () {
            loadNavigation('YearlyReturnFormThree', 'glereturncoal', 'plyearetcoal', 'tl', 'E-Return Coal', 'Yearly Return', ' ');

            $('.searchableselect').searchableselect();
           
            $('#datatable3').DataTable();
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
         var add = '<tr> <td id="t1">2</td> <td id="t2"><input type="text" class="form-control"></td><td id="t3"><input type="number" class="form-control"></td><td><button class="btn btn-danger btn-md remove  m-0 mr-1" data-toggle="tooltip" data-placement="top" title="Remove Row"><i class="fa fa-times" aria-hidden="true"></i></button><a href="#" class="btn btn-success btn-md add-btn  m-0 mr-1" data-toggle="tooltip" data-placement="top" title="Add Row"><i class="fa fa-plus" aria-hidden="true"></i></a></td></tr>;'

         $(document).ready(function () {
             $(document).on('click', '.add-btn', function () {
                 $("#insert").find('tbody').append(add);
             });

             $("#insert").on('click', '.remove', function () {
                 $(this).parents('tr').remove();
             });


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



