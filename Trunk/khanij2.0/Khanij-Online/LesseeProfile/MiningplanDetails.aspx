<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LeaseInformationDetails.aspx.cs" Inherits="LesseeProfile_LeaseInformationDetails" %>
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
                                        Mining Plan
                                        </a>
                                    </li>
                                </ul>
                                <uc1:util runat="server" ID="util" />
                            </div>

                            <section class="box form-container">
                                <div class="content-body">

                                <ul class="nav nav-tabs progressbar border-0" id="myTab" role="tablist">
  <li class="startstep activestep1">
    <a class="active" id="Mining-tab" data-toggle="tab" href="#Mining" role="tab" aria-controls="Mining" aria-selected="true">Mining Plan</a>
  </li>
  <li >
    <a  id="Scheme-tab" data-toggle="tab" href="#Scheme" role="tab" aria-controls="Scheme" aria-selected="false">Scheme of Mine</a>
  </li>
 
</ul>
<div class="tab-content" id="myTabContent">
  <div class="tab-pane fade show active" id="Mining" role="tabpanel" aria-labelledby="Mining-tab">
 <h5 class="text-brown font-weight-bold ">Mining Plan</h5>
                                        <div class="row">
                                            <div class="col-lg-4 col-md-6 col-sm-12 form-group">
                                               <label class="col-form-label font-weight-bolder">Mining Plan Approval Date<span class="text-danger">*</span></label>
                                                <div class="input-group">
                                                      <input type="text" class="form-control datepicker" id="Text3">
                                                      <div class="input-group-prepend">
                                                        <label class="input-group-text" for="inputDate1"><i class="far fa-calendar"></i></label>
                                                      </div>
                                                 </div>
                                            </div>
                                            <div class="col-lg-4 col-md-6 col-sm-12 form-group">
                                                 <label  class="col-form-label font-weight-bolder">Mining Plan Approval Number<span class="text-danger">*</span></label>
                                                 <input type="text" class="form-control">
                                            </div>
                                             <div class="col-lg-4 col-md-6 col-sm-12 form-group">
                                                <label class="col-form-label font-weight-bolder">Mining Plan Valid From<span class="text-danger">*</span></label>
                                                <div class="input-group">
                                                      <input type="text" class="form-control datepicker" id="Text4">
                                                      <div class="input-group-prepend">
                                                        <label class="input-group-text" for="inputDate1"><i class="far fa-calendar"></i></label>
                                                      </div>
                                                 </div>
                                            </div>
                                       
                                            <div class="col-lg-4 col-md-6 col-sm-12 form-group">
                                                <label  class="col-form-label font-weight-bolder">Mining Plan Valid To <span class="text-danger">*</span></label>
                                                <div class="input-group">
                                                      <input type="text" class="form-control datepicker" id="Text5">
                                                      <div class="input-group-prepend">
                                                        <label class="input-group-text" for="inputDate1"><i class="far fa-calendar"></i></label>
                                                      </div>
                                                 </div>
                                            </div>
                                            <div class="col-lg-4 col-md-6 col-sm-12 form-group">
                                                 <label for="inputLoginId" class="col-form-label font-weight-bolder">MP/SOM Approval Letter With Approved Table <span class="text-danger">*</span></label>
                                                 <div class="custom-file">
                                                    <input type="file" class="custom-file-input" id="File30" name="filename">
                                                    <label class="custom-file-label" for="customFile">Choose Files</label>
                                                </div>
                                            </div>
                                             <div class="col-lg-4 col-md-6 col-sm-12 form-group">
                                                <label for="inputLoginId" class="col-form-label font-weight-bolder">Remarks<span class="text-danger">*</span></label>
                                                <textarea name="textAddress" rows="1" cols="20" id="Textarea1" class="form-control"></textarea>
                                            </div>
                                       </div>
                                        <div class="row mt-3">
                                        <div class="col-sm-12 text-center">
                                            <a class="btn btn-danger btn-md ml-0 waves-effect waves-light">Reset</a>
                                            <a class="btn btn-primary btn-md ml-0 waves-effect waves-light btnNext">Next</a>
                                        </div>
                                     </div>

                                      
  </div>
  <div class="tab-pane fade" id="Scheme" role="tabpanel" aria-labelledby="Scheme-tab">
       <h5 class="text-brown font-weight-bold ">Scheme of Mine</h5>                             
                                    
                                    
                                   
                                        <div class="form-group row pt-3">
                                        <div class="col-sm-6">
                                        <div class="table-responsive">
                                              <table class="table table-sm table-bordered mb-0" id="insert">
                                              <thead>
                                               <tr>
                                                   <th width="40px" class="font-weight-bolder">Sl#</th>
                                                   <th>Year</th> 
                                                   <th>Approved Quantity</th>
                                                   <th width="130px" class="font-weight-bolder">Actions</th>
                                               </tr>
                                            </thead>
                                            <tbody>
                                                <tr>
                                                    <td id="t1">
                                                       <input type="text" readonly class="form-control-plaintext" id="staticEmail" value="1"> 
                                                    </td>

                                                    <td id="t2">
                                                    <select class="form-control">
                                                        <option value="Select">Select</option>
                                                    </select>
                                                    </td>

                                                    <td id="t3"><input type="text" class="form-control"></td> 
                               
                                                    <td>
                                                         <a href="#" class="btn btn-success btn-md add-btn waves-effect waves-light" data-toggle="tooltip" data-placement="top" title="Add Row"><i class="fa fa-plus" aria-hidden="true"></i></a>
                                                    </td>

                                                </tr>
                                            </tbody>
                                        </table>  
                                        </div>
                                        </div>
                                        </div>
                                       

                                    <div class="row mt-3">
                                        <div class="col-sm-12 ">
                                            <a  class="btn btn-dark btn-md ml-0 waves-effect waves-light btnPrevious">Previous</a>
                                            <a class="btn btn-danger btn-md ml-0 waves-effect waves-light">Reset</a>
                                            <a class="btn btn-success btn-md ml-0 waves-effect waves-light">Save & Update</a> 
                                             <a href="#" class="btn btn-warning text-dark btn-md waves-effect waves-light ml-0">Forward to DD</a>
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
            loadNavigation('MiningplanDetails', 'glRoleRes', 'pllesseprof', 'tl', 'Roles and Responsibity', 'Lessee Profile', ' ');
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
         var add = '<tr> <td id="t1"><input type="text" readonly class="form-control-plaintext" id="staticEmail" value="1"></td><td id="t2"><select class="form-control"><option value="Select">Select</option></select></td><td id="t3"><input type="text" class="form-control"></td><td><button class="btn btn-danger btn-md remove  m-0 mr-1"><i class="fa fa-times" aria-hidden="true" data-toggle="tooltip" data-placement="top" title="Remove Row"></i></button><a href="#" class="btn btn-success btn-md add-btn  m-0 mr-1" data-toggle="tooltip" data-placement="top" title="Add Row"><i class="fa fa-plus" aria-hidden="true"></i></a></td></tr>;'

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



