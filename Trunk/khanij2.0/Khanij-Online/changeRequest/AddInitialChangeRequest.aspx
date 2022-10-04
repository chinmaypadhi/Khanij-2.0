<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddInitialChangeRequest.aspx.cs" Inherits="changeRequest_AddInitialChangeRequest" %>
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
                                        <a class="nav-link active" href="AddInitialChangeRequest.aspx">
                                           Add Initial Change Request
                                        </a>
                                    </li>
                                     <li class="nav-item">
                                        <a class="nav-link" href="ViewInitialChangeRequest.aspx">
                                           View Initial Change Request
                                        </a>
                                    </li>
                                </ul>
                                <uc1:util runat="server" ID="util" />
                            </div>

                            <section class="box form-container">
                                <div class="content-body">

                                    <div class="row">
                                    <div class="col-sm-6">
                                            <div class="form-group row">
                                                <label for="dropdownDist" class="col-sm-4 col-form-label font-weight-bolder">Change Criticality <span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                    <select class="form-control form-control-sm searchableselect" ><%--disabled--%>
                                                          <option>select</option>
                                                        <option>High</option>
                                                        <option>medium</option>
                                                        <option>Low</option>
                                                        
                                                      </select>                                                    
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-6">
                                            <div class="form-group row">
                                                <label  class="col-sm-4 col-form-label font-weight-bolder">Change Urgency<span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                    <div class="py-2">
                                                      <div class="custom-control custom-radio custom-control-inline">
                                                        <input type="radio" class="custom-control-input" id="radiop" name="radio-iRequirement" value="1">
                                                        <label class="custom-control-label" for="radiop">Emergency</label>
                                                      </div>
                                                      <div class="custom-control custom-radio custom-control-inline">
                                                        <input type="radio" class="custom-control-input" id="radiopro" name="radio-iRequirement" value="2">
                                                        <label class="custom-control-label" for="radiopro">Normal</label>
                                                      </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                         <div class="col-sm-6">
                                            <div class="form-group row">
                                                <label for="inputName" class="col-sm-4 col-form-label font-weight-bolder">Requesting Date<span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                   <div class="input-group" >
                                                      <input type="text" class="form-control datepicker" id="inputDate1" ><%--disabled--%>
                                                      <div class="input-group-prepend">
                                                        <label class="input-group-text" for="inputDate1"><i class="far fa-calendar"></i></label>
                                                      </div>
                                                 </div>
                                                </div>
                                            </div>
                                        </div>
                                         <div class="col-sm-6">
                                            <div class="form-group row">
                                                <label class="col-sm-4 col-form-label font-weight-bolder">Request Type<span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                    <div class="py-2">
                                                      <div class="custom-control custom-checkbox  custom-control-inline">
                                                        <input type="checkbox"  class="custom-control-input" id="radio1" name="radio-iRequirement" value="1"/>
                                                        <label class="custom-control-label" for="radio1">New</label>
                                                      </div>
                                                      <div class="custom-control custom-checkbox custom-control-inline">
                                                        <input type="checkbox" class="custom-control-input" id="radio2" name="radio-iRequirement" value="2"/>
                                                        <label class="custom-control-label" for="radio2">Update</label>
                                                      </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                     <%--  <div class="col-sm-6">
                                            <div class="form-group row">
                                                <label for="dropdownDist" class="col-sm-4 col-form-label font-weight-bolder">Request Person<span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                    <select class="form-control form-control-sm searchableselect" >
                                                          <option>select</option>
                                                      </select>                                                    
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-6">
                                            <div class="form-group row">
                                                <label for="dropdownDist" class="col-sm-4 col-form-label font-weight-bolder">Request Department<span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                    <select class="form-control form-control-sm searchableselect" >
                                                          <option>select</option>
                                                      </select>                                                    
                                                </div>
                                            </div>
                                        </div>--%>
                                        <div class="col-sm-6">
                                            <div class="form-group row">
                                                <label class="col-sm-4 col-form-label font-weight-bolder">Request Change<span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                    <div class="py-2">
                                                      <div class="custom-control custom-checkbox  custom-control-inline">
                                                        <input type="checkbox"  class="custom-control-input" id="radio3" name="radio-iRequirement" value="1"/>
                                                        <label class="custom-control-label" for="radio3">SD</label>
                                                      </div>
                                                      <div class="custom-control custom-checkbox custom-control-inline">
                                                        <input type="checkbox" class="custom-control-input" id="radio4" name="radio-iRequirement" value="2"/>
                                                        <label class="custom-control-label" for="radio4">Code</label>
                                                      </div>
                                                       <div class="custom-control custom-checkbox custom-control-inline">
                                                        <input type="checkbox" class="custom-control-input" id="radio5" name="radio-iRequirement" value="2"/>
                                                        <label class="custom-control-label" for="radio5">Config</label>
                                                      </div>
                                                       <div class="custom-control custom-checkbox custom-control-inline">
                                                        <input type="checkbox" class="custom-control-input" id="radio6" name="radio-iRequirement" value="2"/>
                                                        <label class="custom-control-label" for="radio6">DLL</label>
                                                      </div>
                                                       <div class="custom-control custom-checkbox custom-control-inline">
                                                        <input type="checkbox" class="custom-control-input" id="radio7" name="radio-iRequirement" value="2"/>
                                                        <label class="custom-control-label" for="radio7">Table</label>
                                                      </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                       <%-- <div class="col-sm-6">
                                            <div class="form-group row">
                                                <label for="dropdownDist" class="col-sm-4 col-form-label font-weight-bolder">Department<span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                    <select class="form-control form-control-sm searchableselect" >
                                                          <option>select</option>
                                                      </select>                                                    
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-6">
                                            <div class="form-group row">
                                                <label for="dropdownDist" class="col-sm-4 col-form-label font-weight-bolder">User<span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                    <select class="form-control form-control-sm searchableselect" >
                                                          <option>select</option>
                                                      </select>                                                    
                                                </div>
                                            </div>
                                        </div>--%>
                                        <div class="col-sm-6">
                                            <div class="form-group row">
                                                <label for="dropdownDist" class="col-sm-4 col-form-label font-weight-bolder">Remark <span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                       <textarea class="form-control" rows="1"></textarea>
                                               <small class="text-danger">Maximum <strong>500</strong> characters</small>                                            
                                                </div>
                                            </div>
                                        </div>
                                       
                                       
                                        


                                        
                                          <div class="col-sm-12"> 
                                            
                                            <h6 class="text-brown font-weight-bold mt-0">Request Description</h6>
                                           </div>
                                          <div class="col-xl-12">
                                        <div class="bg-light p-2 form-group border">
                                       <div class="row">
                                      
                                     <div class="col-lg-3 col-md-6 col-sm-12">
                                               <label class="col-form-label font-weight-bolder pt-0">Existing System<span class="text-danger">*</span></label>
                                               <textarea class="form-control" rows="1" ></textarea>
                                     </div>
                                     <div class="col-lg-3 col-md-6 col-sm-12">
                                               <label class="col-form-label font-weight-bolder pt-0">Problem in System<span class="text-danger">*</span></label>
                                                <textarea class="form-control" rows="1" ></textarea>
                                     </div>
                                     <div class="col-lg-3 col-md-6 col-sm-12">
                                               <label class="col-form-label font-weight-bolder pt-0">Business Requirement<span class="text-danger">*</span></label>
                                               <textarea class="form-control" rows="1" ></textarea>
                                     </div>
                                      <div class="col-lg-3 col-md-6 col-sm-12">
                                               <label class="col-form-label font-weight-bolder pt-0">Propose Solution<span class="text-danger">*</span></label>
                                          <textarea class="form-control" rows="1" ></textarea>    
                                          <%--<select class="form-control form-control-sm searchableselect" >
                                                          <option>select</option>
                                                      </select>--%> 
                                     </div>
                                      <div class="col-lg-3 col-md-6 col-sm-12">
                                               <label class="col-form-label font-weight-bolder pt-0">P	CR Module<span class="text-danger">*</span></label>
                                                <textarea class="form-control" rows="1" ></textarea>
                                     </div>
                                      <div class="col-lg-3 col-md-6 col-sm-12">
                                               <label class="col-form-label font-weight-bolder pt-0">Impact<span class="text-danger">*</span></label>
                                                <textarea class="form-control" rows="1" ></textarea>
                                     </div>
                                      <div class="col-lg-3 col-md-6 col-sm-12">
                                               <label class="col-form-label font-weight-bolder pt-0">Risk<span class="text-danger">*</span></label>
                                                <textarea class="form-control" rows="1" ></textarea>
                                     </div>
                                    
                                     </div>
                                       </div>
                                  </div>
                                         <div class="col-sm-4 mb-3">
                                               <label class="col-form-label font-weight-bolder pt-0">Upload Document </label>
                                                <div class="custom-file">
                                                    <input type="file" class="custom-file-input" id="customFile" name="filename" >
                                                    <label class="custom-file-label" for="customFile">Choose Files</label>
                                                </div>
                                            </div>
                                           
                                           
                                          <%--<div class="col-sm-12"> 
                                            
                                            <h6 class="text-brown font-weight-bold mt-0">Total Effect</h6>
                                           </div>
                                            <div class="col-sm-6">
                                                  <div class="table-responsive">
                                              <table class="table table-sm border">
                                              <thead>
                                               <tr>
                                               <th  class="font-weight-bolder" width="40px">Sl#</th> 
                                               <th  class="font-weight-bolder">Functionality</th> 
                                                <th class="font-weight-bolder">Date</th> 
                                                <th width="130px" class="font-weight-bolder">Actions</th>
                                               </tr>
                                            </thead>
                                            <tbody>
                                                <tr>
                                                   
                                                    <td >
                                                      1
                                                    </td>
                                                    <td>
                                                        <input type="text" class="form-control">
                                                    </td>
                                                     <td>
                                                        <div class="input-group">
                                                      <input type="text" class="form-control datepicker" id="Text1">
                                                      <div class="input-group-prepend">
                                                        <label class="input-group-text" for="Text1"><i class="far fa-calendar"></i></label>
                                                      </div>
                                                 </div>
                                                    </td>
                                                    <td>
                                                         <a href="#" class="btn btn-success btn-md add-btn waves-effect waves-light" data-toggle="tooltip" data-placement="top" title="Add Row"><i class="fa fa-plus" aria-hidden="true"></i></a>
                                                    </td>

                                                </tr>
                                            </tbody>
                                        </table>  
                                        </div>
                                            </div>
                                          --%>
                                        
                                        <div class="col-sm-6"></div>
                                            <div class="col-sm-6">
                                                 <a href="ViewInitialChangeRequest.aspx"  class="btn btn-primary btn-md ml-0">Submit</a>
                                                <a href="#" class="btn btn-danger btn-md">Reset</a>
                                               <%-- <a href="javascript:void(0);" class="btn btn-primary btn-md ml-0">Approve</a>
                                                <a href="#" class="btn btn-danger btn-md">Reject</a>
                                                 <a href="#" class="btn btn-warning text-dark btn-md">Forward</a>--%>
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


<!-- alert 1-->
    <div class="modal fade alert-modal" tabindex="-1" role="dialog" aria-labelledby="alertModal" aria-hidden="true">
        <div class="modal-dialog modal-md modal-dialog-centered" role="document">
            <div class="modal-content">
                <div class="modal-body text-center">
                    <h5 class="p-2 ">
                    <i class="fas fa-check fa-2x mb-3 text-success"></i><br>
                    Request Number : <span class="text-primary font-weight-bold">457857896545788</span>
                      </h5>
                    <a class="btn btn-primary btn-md" href="javascrip:;" data-dismiss="modal">Ok</a>
                </div>
               
            </div>
        </div>
    </div>




    <script>
        indicateMe = "yes"

        $(document).ready(function () {
            loadNavigation('AddInitialChangeRequest', 'glchangerequest', 'pladdintcr', 'tl', 'Change Request', 'Initial Change Request', ' ');
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

