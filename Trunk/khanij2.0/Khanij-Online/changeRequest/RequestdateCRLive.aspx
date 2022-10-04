<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RequestdateCRLive.aspx.cs" Inherits="changeRequest_RequestdateCRLive" %>
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
                                        <a class="nav-link active" href="#">
                                         Request date CR in Live
                                        </a>
                                    </li>
                                    
                                </ul>
                                <uc1:util runat="server" ID="util" />
                            </div>

                            <section class="box form-container">
                                <div class="content-body">

                                   
                                     <div class="row">
                                 <div class="col-lg-3 col-md-6 col-sm-12">
                                               <label class="col-form-label font-weight-bolder">Change Request Number <span class="text-danger">*</span></label>
                                               <input type="text" class="form-control">
                                     </div>
                                    
                                     <div class="col-lg-3 col-md-6 col-sm-12">
                                               <label class="col-form-label font-weight-bolder">Change criticality <span class="text-danger">*</span></label>
                                               <select class="form-control">
                                                    <option value="Select">Select</option>
                                                </select>
                                     </div>
                                     <div class="col-lg-3 col-md-6 col-sm-12">
                                               <label class="col-form-label font-weight-bolder">Change urgency <span class="text-danger">*</span></label>
                                               <select class="form-control">
                                                    <option value="Select">Select</option>
                                                </select>
                                     </div>
                                     <div class="col-lg-3 col-md-6 col-sm-12">
                                               <label class="col-form-label font-weight-bolder">Reason <span class="text-danger">*</span></label>
                                              <textarea class="form-control" rows="1"></textarea>
                                               <small class="text-danger">Maximum <strong>500</strong> characters</small>
                                     </div>
                                     <div class="col-lg-3 col-md-6 col-sm-12">
                                               <label class="col-form-label font-weight-bolder">Requesting department <span class="text-danger">*</span></label>
                                              <select class="form-control">
                                                    <option value="Select">Select</option>
                                                </select>
                                     </div>
                                    
                                     <div class="col-lg-3 col-md-6 col-sm-12">
                                               <label class="col-form-label font-weight-bolder">Requesting Date <span class="text-danger">*</span></label>
                                               <div class="input-group">
                                                      <input type="text" class="form-control datepicker" id="inputDate3">
                                                      <div class="input-group-prepend">
                                                        <label class="input-group-text" for="inputDate3"><i class="far fa-calendar"></i></label>
                                                      </div>
                                                 </div>
                                     </div>
                                   
                                     
                                     
                                     
                                     <div class="col-lg-3 col-md-6 col-sm-12">
                                               <label class="col-form-label font-weight-bolder">Request comment<span class="text-danger">*</span></label>
                                               <textarea class="form-control" rows="1"></textarea>
                                               <small class="text-danger">Maximum <strong>500</strong> characters</small>
                                     </div>
                                      <div class="col-lg-3 col-md-6 col-sm-12">
                                               <label class="col-form-label font-weight-bolder">Implementation Plan<span class="text-danger">*</span></label>
                                               <textarea class="form-control" rows="1"></textarea>
                                               <small class="text-danger">Maximum <strong>500</strong> characters</small>
                                     </div>
                                      <div class="col-lg-3 col-md-6 col-sm-12">
                                               <label class="col-form-label font-weight-bolder">Implementation Duration<span class="text-danger">*</span></label>
                                              <div class="row">
                                               <div class="col">
                                               <input type="text" class="form-control" placeholder="Hours">
                                               </div>
                                                <div class="col">
                                                <input type="text" class="form-control" placeholder="Minutes">
                                                </div>
                                                </div>
                                     </div>
                                      <div class="col-lg-3 col-md-6 col-sm-12">
                                               <label class="col-form-label font-weight-bolder">Rollback Date Time<span class="text-danger">*</span></label>
                                              <div class="input-group">
                                                      <input type="text" class="form-control datetimepicker" id="inputDate7">
                                                      <div class="input-group-prepend">
                                                        <label class="input-group-text" for="inputDate7"><i class="far fa-calendar"></i></label>
                                                      </div>
                                                 </div>
                                     </div>
                                     <div class="col-lg-6 col-md-6 col-sm-12">
                                               <label class="col-form-label font-weight-bolder">Rollback Duration<span class="text-danger">*</span></label>
                                              <div class="row">
                                               <div class="col">
                                               <input type="text" class="form-control" placeholder="Hours">
                                               </div>
                                                <div class="col">
                                                <input type="text" class="form-control" placeholder="Minutes">
                                                </div>
                                                </div>
                                     </div>
                                       
                                     <div class="col-xl-12 my-3">
                                     
                                     <div class="bg-light p-2  border">
                                      <div class="row">
                                     <div class="col-lg-3 col-md-6 col-sm-12">
                                                <label class="col-form-label font-weight-bolder ">Request Type<span class="text-danger">*</span></label>
                                               <div class="py-2">
                                               <div class="form-check form-check-inline">
                                  <input class="form-check-input" type="checkbox" id="inlineCheckbox1" value="option1">
                                  <label class="form-check-label" for="option1">New</label>
                                </div>
                                <div class="form-check form-check-inline">
                                  <input class="form-check-input" type="checkbox" id="inlineCheckbox2" value="option2">
                                  <label class="form-check-label" for="option2">Update</label>
                                </div>
                                                      
                                                      
                                                    </div>
                                     </div>
                                      <div class="col-lg-6 col-md-6 col-sm-12">
                                                <label class="col-form-label font-weight-bolder ">Change Type<span class="text-danger">*</span></label>
                                               <div class="py-2">
                                                <div class="form-check form-check-inline">
                                  <input class="form-check-input" type="checkbox" id="Checkbox3" value="option3">
                                  <label class="form-check-label" for="option3">SP</label>
                                </div>
                                <div class="form-check form-check-inline">
                                  <input class="form-check-input" type="checkbox" id="Checkbox4" value="option4">
                                  <label class="form-check-label" for="option4">Table</label>
                                </div>
                                 <div class="form-check form-check-inline">
                                  <input class="form-check-input" type="checkbox" id="Checkbox5" value="option5">
                                  <label class="form-check-label" for="option5">Code</label>
                                </div>
                                <div class="form-check form-check-inline">
                                  <input class="form-check-input" type="checkbox" id="Checkbox6" value="option6">
                                  <label class="form-check-label" for="option6">DLL</label>
                                </div>
                                                     
                                                    </div>
                                     </div>
                                     </div>
                                     </div>
                                     </div>
                                   
                                           <div class="col-lg-6 col-md-12 col-sm-12">
                                            <label class="col-form-label font-weight-bolder ">
                                           Implement Description</label>
                                                  <div class="table-responsive">
                                              <table class="table table-sm border" id="insert">
                                              <thead>
                                               <tr>
                                                   <th class="font-weight-bolder">Implement Name</th>
                                                   <th class="font-weight-bolder">Implement Contact Number</th>
                                                   <th width="130px" class="font-weight-bolder">Actions</th>
                                               </tr>
                                            </thead>
                                            <tbody>
                                                <tr>
                                                    <td id="t1">
                                                        <input type="number" class="form-control">
                                                    </td>
                                                   
                                                    <td id="t2" width="250px">
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
                                            
                                            <div class="col-sm-6">
                                            <label class="col-form-label font-weight-bolder">
                                           Change Request Description</label>
                                                  <div class="table-responsive">
                                              <table class="table table-sm border" id="Table1">
                                              <thead>
                                               <tr>
                                                   <th class="font-weight-bolder">CR for Mobile</th>
                                                   <th class="font-weight-bolder">Description of CR</th> 
                                                   <th class="font-weight-bolder">Reason for changes</th> 
                                                    
                                                   <th width="130px" class="font-weight-bolder">Actions</th>
                                               </tr>
                                            </thead>
                                            <tbody>
                                                <tr>
                                                    <td id="Td1">
                                                        <select class="form-control">
                                                          <option>select</option>
                                                      </select>
                                                    </td>
                                                    <td id="Td2">
                                                        <textarea class="form-control" rows="1"></textarea>
                                                    </td>
                                                    <td id="t3" "="">
                                                        <textarea class="form-control" rows="1"></textarea>
                                                    </td>
                                                   
                                                    <td>
                                                         <a href="#" class="btn btn-success btn-md add-btn waves-effect waves-light" data-toggle="tooltip" data-placement="top" title="Add Row"><i class="fa fa-plus" aria-hidden="true"></i></a>
                                                    </td>

                                                </tr>
                                            </tbody>
                                        </table>  
                                        </div>
                                            </div>

                                            <div class="col-lg-2 col-md-6 col-sm-12">
                                                <label class="col-form-label font-weight-bolder ">SLA Impact<span class="text-danger">*</span></label>
                                               <div class="py-2">
                                                      <div class="custom-control custom-radio custom-control-inline">
                                                        <input type="radio" class="custom-control-input" id="radio5" name="radio-iRequirement" value="1">
                                                        <label class="custom-control-label" for="radio5">Yes</label>
                                                      </div>
                                                      <div class="custom-control custom-radio custom-control-inline">
                                                        <input type="radio" class="custom-control-input" id="radio6" name="radio-iRequirement" value="2">
                                                        <label class="custom-control-label" for="radio6">No</label>
                                                      </div>
                                                      
                                                    </div>
                                     </div>
                                     <div class="col-lg-3 col-md-6 col-sm-12">
                                               <label class="col-form-label font-weight-bolder">If yes specify the details<span class="text-danger">*</span></label>
                                               <textarea class="form-control" rows="1"></textarea>
                                               <small class="text-danger">Maximum <strong>500</strong> characters</small>
                                     </div>
                                     <div class="col-lg-3 col-md-6 col-sm-12">
                                                <label class="col-form-label font-weight-bolder">Any Changes Request in DR Site<span class="text-danger">*</span></label>
                                               <div class="py-2">
                                                      <div class="custom-control custom-radio custom-control-inline">
                                                        <input type="radio" class="custom-control-input" id="radio7" name="radio-iRequirement" value="1">
                                                        <label class="custom-control-label" for="radio7">Yes</label>
                                                      </div>
                                                      <div class="custom-control custom-radio custom-control-inline">
                                                        <input type="radio" class="custom-control-input" id="radio8" name="radio-iRequirement" value="2">
                                                        <label class="custom-control-label" for="radio8">No</label>
                                                      </div>
                                                      
                                                    </div>
                                     </div>
                                     <div class="col-lg-3 col-md-6 col-sm-12">
                                               <label class="col-form-label font-weight-bolder">If yes specify the details<span class="text-danger">*</span></label>
                                               <textarea class="form-control" rows="1"></textarea>
                                               <small class="text-danger">Maximum <strong>500</strong> characters</small>
                                     </div>
                                      <div class="col-lg-2 col-md-6 col-sm-12">
                                                <label class="col-form-label font-weight-bolder ">Down Time Request<span class="text-danger">*</span></label>
                                               <div class="py-2">
                                                      <div class="custom-control custom-radio custom-control-inline">
                                                        <input type="radio" class="custom-control-input" id="radio9" name="radio-iRequirement" value="1">
                                                        <label class="custom-control-label" for="radio9">Yes</label>
                                                      </div>
                                                      <div class="custom-control custom-radio custom-control-inline">
                                                        <input type="radio" class="custom-control-input" id="radio10" name="radio-iRequirement" value="2">
                                                        <label class="custom-control-label" for="radio10">No</label>
                                                      </div>
                                                      
                                                    </div>
                                     </div>
                                     <div class="col-lg-3 col-md-6 col-sm-12">
                                               <label class="col-form-label font-weight-bolder">If yes Down Time from date time<span class="text-danger">*</span></label>
                                              <div class="input-group">
                                                      <input type="text" class="form-control datetimepicker" id="inputDate12">
                                                      <div class="input-group-prepend">
                                                        <label class="input-group-text" for="inputDate12"><i class="far fa-calendar"></i></label>
                                                      </div>
                                                 </div>
                                     </div>
                                     <div class="col-lg-3 col-md-6 col-sm-12">
                                               <label class="col-form-label font-weight-bolder">If yes Down Time to date time<span class="text-danger">*</span></label>
                                              <div class="input-group">
                                                      <input type="text" class="form-control datetimepicker" id="inputDate13">
                                                      <div class="input-group-prepend">
                                                        <label class="input-group-text" for="inputDate13"><i class="far fa-calendar"></i></label>
                                                      </div>
                                                 </div>
                                     </div>


                                    
                                     
                                    
                                   
                                    

                                     

                                       <div class="col-sm-12 mt-3">
                                                <a href="javascript:void(0);" class="btn btn-primary btn-md ml-0">Submit</a>
                                                <a href="#" class="btn btn-danger btn-md">Reset</a>
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
            loadNavigation('RequestdateCRLive', 'glchangerequest', 'plreqdatliv', 'tl', 'Change Request', 'Request date CR in Live', ' ');
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
        $('.datetimepicker').datetimepicker({
		format: 'DD-MM-YYYY LT',	
		daysOfWeekDisabled: [0, 6],
		//viewMode: 'years',
	});	
    });
    </script>
</body>
</html>





