<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Adde-TransitPassTP.aspx.cs" Inherits="ETransitPass_Adde_TransitPassTP" %>

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
<%--    <link rel="stylesheet" href="../css/mdb.min.css" media="screen" />--%>
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
                                           Add Transit Pass-TP
                                        </a>
                                    </li>
                                    
                                </ul>
                                <uc1:util runat="server" ID="util" />
                            </div>

                            <section class="box form-container">
                                <div class="content-body">

                                    <div class="row">
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label  class="col-sm-4 col-form-label font-weight-bolder">E-Permit No.</label>
                                                <div class="col-sm-7">
                                                   <select class="form-control form-control-sm searchableselect">
                                                            <option>Select</option>
                                                            <option></option>
                                                       </select> 
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label for="inputName" class="col-sm-4 col-form-label font-weight-bolder">Purchaser Type<span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                    <div class="py-2">
                                                      <div class="custom-control custom-radio custom-control-inline">
                                                        <input type="radio" class="custom-control-input" id="radio7" name="radio-iRequirement" value="1">
                                                        <label class="custom-control-label" for="radio7">Registered</label>
                                                      </div>
                                                      <div class="custom-control custom-radio custom-control-inline">
                                                        <input type="radio" class="custom-control-input" id="radio8" name="radio-iRequirement" value="2">
                                                        <label class="custom-control-label" for="radio8">Un-registered</label>
                                                      </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                         <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label for="inputName" class="col-sm-4 col-form-label font-weight-bolder">Purchaser Type<span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                    <div class="py-2">
                                                      <div class="custom-control custom-radio custom-control-inline">
                                                        <input type="radio" class="custom-control-input" id="radio1" name="radio-iRequirement" value="1">
                                                        <label class="custom-control-label" for="radio1">Govt. Work</label>
                                                      </div>
                                                      <div class="custom-control custom-radio custom-control-inline">
                                                        <input type="radio" class="custom-control-input" id="radio2" name="radio-iRequirement" value="2">
                                                        <label class="custom-control-label" for="radio2">Private Work</label>
                                                      </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label for="dropdownUserType" class="col-sm-4 col-form-label font-weight-bolder">District</label>
                                                <div class="col-sm-7">
                                                    <input type="text" class="form-control">
                                                </div>
                                            </div>
                                        </div>
                                         <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label for="dropdownUserType" class="col-sm-4 col-form-label font-weight-bolder">Purchaser/Consignee Name<span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                    <input type="text" class="form-control">
                                                </div>
                                            </div>
                                        </div>
                                         <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label for="dropdownUserType" class="col-sm-4 col-form-label font-weight-bolder">Purchaser/Consignee Mobile Number<span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                    <input type="text" class="form-control">
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label for="dropdownUserType" class="col-sm-4 col-form-label font-weight-bolder">Lessee/Licensee Name</label>
                                                <div class="col-sm-7">
                                                    <input type="text" class="form-control">
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label for="dropdownDepart" class="col-sm-4 col-form-label font-weight-bolder">Tehsil/Forest Division</label>
                                                <div class="col-sm-7">
                                                   <input type="text" class="form-control">                                                    
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label for="inputMobile" class="col-sm-4 col-form-label font-weight-bolder">Area(Hect.)<span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                        <input type="text" class="form-control">  
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label for="inputPassword" class="col-sm-4 col-form-label font-weight-bolder">Village</label>
                                                <div class="col-sm-7">
                                                   <input type="text" class="form-control"> 
                                                </div>
                                            </div>
                                        </div>
                                      <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label for="inputMail" class="col-sm-4 col-form-label font-weight-bolder">Lease Validity From</label>
                                                <div class="col-sm-7">
                                                    <div class="input-group">
                                                      <input type="text" class="form-control datepicker" id="inputDate1">
                                                      <div class="input-group-prepend">
                                                        <label class="input-group-text" for="inputDate1"><i class="far fa-calendar"></i></label>
                                                      </div>
                                                 </div>  
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label for="inputMail" class="col-sm-4 col-form-label font-weight-bolder">Lease Validity To</label>
                                                <div class="col-sm-7">
                                                  <div class="input-group">
                                                      <input type="text" class="form-control datepicker" id="inputDate2">
                                                      <div class="input-group-prepend">
                                                        <label class="input-group-text" for="inputDate2"><i class="far fa-calendar"></i></label>
                                                      </div>
                                                 </div> 
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label for="dropdownDist" class="col-sm-4 col-form-label font-weight-bolder">Mineral Name</label>
                                                <div class="col-sm-7">
                                                     <input type="text" class="form-control">                                                  
                                                </div>
                                            </div>
                                        </div>
                                        
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label for="inputMail" class="col-sm-4 col-form-label font-weight-bolder">Sale value of the Mineral (In Rs per)</label>
                                                <div class="col-sm-7">
                                                      <input type="text" class="form-control">   
                                                </div>
                                            </div>
                                        </div>
                                         <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label for="inputMail" class="col-sm-4 col-form-label font-weight-bolder">Mineral Grade </label>
                                                <div class="col-sm-7">
                                                   <input type="text" class="form-control">  
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label for="inputMail" class="col-sm-4 col-form-label font-weight-bolder">Vehicle Number<span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                   <input type="text" class="form-control validate-msg" id="myInput">

                                                    <small class="text-danger">You will need to enter minimum 4 Character</small>
                                                </div>
                                            </div>
                                        </div>
                                         <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label for="inputMail" class="col-sm-4 col-form-label font-weight-bolder">Mineral Date Of Dispatch</label>
                                                <div class="col-sm-7">
                                                    <div class="input-group">
                                                      <input type="text" class="form-control datepicker" id="inputDate3">
                                                      <div class="input-group-prepend">
                                                        <label class="input-group-text" for="inputDate3"><i class="far fa-calendar"></i></label>
                                                      </div>
                                                 </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label for="inputMail" class="col-sm-4 col-form-label font-weight-bolder">Mineral User Name</label>
                                                <div class="col-sm-7">
                                                    <input type="text" class="form-control"> 
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label for="inputMail" class="col-sm-4 col-form-label font-weight-bolder">Destination District<span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                   <select class="form-control form-control-sm searchableselect">
                                                            <option>Select</option>
                                                            <option></option>
                                                       </select>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label for="inputMail" class="col-sm-4 col-form-label font-weight-bolder">Destination Block<span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                   <select class="form-control form-control-sm searchableselect">
                                                            <option>Select</option>
                                                            <option></option>
                                                       </select>
                                                </div>
                                            </div>
                                        </div>
                                          <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label for="inputMail" class="col-sm-4 col-form-label font-weight-bolder">Vehicle Owner<span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                   <select class="form-control form-control-sm searchableselect">
                                                            <option>Select</option>
                                                            <option></option>
                                                       </select>
                                                </div>
                                            </div>
                                        </div>
                                         <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label for="inputMail" class="col-sm-4 col-form-label font-weight-bolder">Mineral Purchaser Name<span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                      <input type="text" class="form-control"> 
                                                </div>
                                            </div>
                                        </div>
                                       
                                        
                                       
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label for="inputMail" class="col-sm-4 col-form-label font-weight-bolder">Vehicle Type<span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                     <input type="text" class="form-control">  
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label for="inputMail" class="col-sm-4 col-form-label font-weight-bolder">Mineral Destination<span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                     <textarea class="form-control" rows="2"></textarea>  
                                                     <small class="text-danger">Maxmimum 200 Characters only</small>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label for="inputMail" class="col-sm-4 col-form-label font-weight-bolder">Driver Name<span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                      <input type="text" class="form-control">  
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label for="inputMail" class="col-sm-4 col-form-label font-weight-bolder">Driver Contact Number<span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                     <input type="number" class="form-control">   
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label for="inputMail" class="col-sm-4 col-form-label font-weight-bolder">Mineral Destination<span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                     <textarea class="form-control" rows="2"></textarea>
                                                     <small class="text-danger">Maxmimum 200 Characters only</small>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label for="inputMail" class="col-sm-4 col-form-label font-weight-bolder">Tare Weight(Ton/Cubic Meter)<span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                     <input type="text" class="form-control">  
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label for="inputMail" class="col-sm-4 col-form-label font-weight-bolder">Route<span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                     <input type="text" class="form-control">  
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label for="inputMail" class="col-sm-4 col-form-label font-weight-bolder">Gross Weight(Ton/Cubic Meter)<span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                    <input type="text" class="form-control">   
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label for="inputMail" class="col-sm-4 col-form-label font-weight-bolder">D.O Number(If Applicable)<span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                     <input type="text" class="form-control">    
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label for="inputMail" class="col-sm-4 col-form-label font-weight-bolder">Net Weight(Ton/Cubic Meter)<span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                     <input type="text" class="form-control">  
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label for="inputMail" class="col-sm-4 col-form-label font-weight-bolder">Other (Remarks)<span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                    <textarea class="form-control" rows="2"></textarea> 
                                                    <small class="text-danger">Maxmimum 200 Characters only</small>
                                                </div>
                                            </div>
                                        </div>
                                        
                                       
                                            <div class="col-lg-6 offset-lg-2 offset-md-4">
                                                <a href="Viewe-TransitPassTP.aspx" class="btn btn-primary btn-md ml-0">Generate E-Transit Pass</a>
                                                <a href="#" class="btn btn-danger btn-md">Reset</a>
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
    <link href="../css/autocomplete.min.css" rel="stylesheet">
    <script src="../js/autocomplete.js"></script> 
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
        var countries = ["RJ02GB6428, Trailer, Kishore Kumar Agarwal", "MP20HB6428 ,Truck, Prabhajot Singh Khurana"];

        autocomplete(document.getElementById("myInput"), countries);
</script>
    <script>
        indicateMe = "yes"

        $(document).ready(function () {
            loadNavigation('Adde-TransitPassTP', 'gletransitpass', 'pletrapas', 'tl', 'E-Transit pass', 'E-Transit Pass - TP', '');

            $('.searchableselect').searchableselect();

            $(".show-toast").click(function () {
                $("#myToast").toast({ autohide: false });
                $("#myToast").toast('show');
            });

            $(".alert-modal").modal({
                show: false,
                backdrop: 'static'
            });
        });
    </script>
</body>
</html>



