<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddDemo.aspx.cs" Inherits="dashboard_AddDemo" %>

    <%@ Register Src="~/includes/navbar.ascx" TagPrefix="uc1" TagName="navbar" %>
        <%@ Register Src="~/includes/leftsider.ascx" TagPrefix="uc1" TagName="leftsider" %>
            <%@ Register Src="~/includes/navigation.ascx" TagPrefix="uc1" TagName="navigation" %>
                <%@ Register Src="~/includes/util.ascx" TagPrefix="uc1" TagName="util" %>
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
                            <link rel="stylesheet" href="../css/mdb.min.css" media="screen" />
                            <link rel="stylesheet" href="../css/pace-theme-flash.css" media="screen" />
                            <link rel="stylesheet" href="../css/all.min.css" />
                            <link rel="stylesheet" href="../css/perfect-scrollbar.css" />
                            <link rel="stylesheet" href="../css/style.css" type="text/css" />
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
                                                <div class="button-links text-right">
                                                    <a href="#" class="btn btn-primary btn-sm">Button Link</a>
                                                    <a href="#" class="btn btn-primary btn-sm">Button Link</a>
                                                    <a href="#" class="btn btn-primary btn-sm">Button Link</a>
                                                    <a href="#" class="btn btn-primary btn-sm">Button Link</a>
                                                </div>
                                                <!-- MAIN CONTENT AREA STARTS -->
                                                <div class="row">
                                                    <div class="col-12">
                                                        <div class="main-tab">
                                                            <ul class="nav nav-tabs">
                                                                <li class="nav-item">
                                                                    <a class="nav-link active" href="javascript:void(0);">
                                            Add
                                        </a>
                                                                </li>
                                                                <li class="nav-item">
                                                                    <a class="nav-link" href="ViewDemo.aspx">
                                            View
                                        </a>
                                                                </li>
                                                            </ul>
                                                            <uc1:util runat="server" ID="util" />
                                                        </div>

                                                        <section class="box form-container">
                                                            <div class="content-body">

                                                                <div class="row">
                                                                    <div class="col-sm-12">
                                                                        <div class="form-group row">
                                                                            <label for="validationServer03" class="col-sm-3 col-form-label">Invalid Input</label>
                                                                            <div class="col-sm-4">
                                                                                <input type="text" class="form-control is-invalid" id="validationServer03" required>
                                                                                <div class="invalid-feedback">
                                                                                    Please provide a valid Data.
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-sm-12">
                                                                        <div class="form-group row">
                                                                            <label for="inputJTitle" class="col-sm-3 col-form-label">Text Input
                                                        <span class="text-danger">*</span> </label>
                                                                            <div class="col-sm-4">
                                                                                <div class="input-effect effect-19">
                                                                                    <input class="form-control" type="text" placeholder="">
                                                                                    <label>First Name</label>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-sm-12">
                                                                        <div class="form-group row">
                                                                            <label for="inputPSTrade" class="col-sm-3 col-form-label">Dropdown
                                                        <span class="text-danger">*</span></label>
                                                                            <div class="col-sm-4">
                                                                                <select class="form-control" id="inputPSTrade">
                                                            <option>Select Option</option>
                                                            <option>Option 1</option>
                                                        </select>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-sm-12">
                                                                        <div class="form-group row">
                                                                            <label for="inputPSTrade" class="col-sm-3 col-form-label">Searchable Dropdown 2 <span class="text-danger">*</span></label>
                                                                            <div class="col-sm-4">
                                                                                <select class="searchableselect form-control" data-live-search="true">
	                            <option>Select</option> 
	                            <option>Car</option> 
	                            <option>Bike</option> 
	                            <option>Scooter</option> 
	                            <option>Cycle</option> 
	                            <option>Horse</option> 
	                        </select>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-sm-12">
                                                                        <div class="form-group row">
                                                                            <label for="txtareaJDesc" class="col-sm-3 col-form-label">Text
                                                        Area</label>
                                                                            <div class="col-sm-4">
                                                                                <div class="input-effect effect-19">
                                                                                    <textarea class="form-control" id="txtareaJDesc" rows="2"></textarea>
                                                                                    <label>Text Area</label>
                                                                                </div>
                                                                                <small class="text-danger">Maximum <strong>500</strong>
                                                            characters</small>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-sm-12">
                                                                        <div class="form-group row">
                                                                            <label for="txtareaJDesc" class="col-sm-3 col-form-label">Upload
                                                        input</label>
                                                                            <div class="col-sm-4">

                                                                                <div class="input-group">
                                                                                    <div class="custom-file">
                                                                                        <input type="file" class="custom-file-input" id="inputGroupFile01" aria-describedby="inputGroupFileAddon01">
                                                                                        <label class="custom-file-label" for="inputGroupFile01">Choose file</label>
                                                                                    </div>

                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-sm-12">
                                                                        <div class="form-group row">
                                                                            <label for="inputDate" class="col-sm-3 col-form-label">Date
                                                        Input</label>
                                                                            <div class="col-sm-4">
                                                                                <div class="input-group">
                                                                                    <input type="text" class="form-control datepicker" id="inputDate" value="">
                                                                                    <div class="input-group-prepend">

                                                                                        <label class="input-group-text" for="inputDate"><i
                                                                        class="far fa-calendar"></i></label>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-sm-12">
                                                                        <div class="form-group row">
                                                                            <label for="inputDate1" class="col-sm-3 col-form-label">Date
                                                        Input</label>
                                                                            <div class="col-sm-4">
                                                                                <div class="input-group">
                                                                                    <input type="text" class="form-control datepicker" id="inputDate1">
                                                                                    <div class="input-group-prepend">

                                                                                        <label class="input-group-text" for="inputDate1"><i
                                                                        class="far fa-calendar"></i></label>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-sm-12">
                                                                        <div class="form-group row">
                                                                            <label for="inputTime" class="col-sm-3 col-form-label">Time
                                                        Input</label>
                                                                            <div class="col-sm-4">
                                                                                <div class="input-group">
                                                                                    <input type="text" class="form-control timepicker" id="inputTime">
                                                                                    <div class="input-group-prepend">

                                                                                        <label class="input-group-text" for="inputTime"><i
                                                                        class="far fa-clock"></i></label>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-sm-12">
                                                                        <div class="form-group row">
                                                                            <label for="inputDateTime" class="col-sm-3 col-form-label">Date &
                                                        Time
                                                        Input</label>
                                                                            <div class="col-sm-4">
                                                                                <div class="input-group">
                                                                                    <input type="text" class="form-control datetimepicker" id="inputDateTime">
                                                                                    <div class="input-group-prepend">

                                                                                        <label class="input-group-text" for="inputDateTime"><i
                                                                        class="far fa-calendar-check"></i></label>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-sm-12">
                                                                        <div class="form-group row">
                                                                            <label for="inputPassword" class="col-sm-3 col-form-label">Radio
                                                        Input
                                                        with show hide div</label>
                                                                            <div class="col-sm-4">
                                                                                <div class="py-2">
                                                                                    <div class="custom-control custom-radio custom-control-inline">
                                                                                        <input type="radio" class="custom-control-input" id="radioIRYes" name="radio-iRequirement" value="1">
                                                                                        <label class="custom-control-label" for="radioIRYes">Yes</label>
                                                                                    </div>
                                                                                    <div class="custom-control custom-radio custom-control-inline">
                                                                                        <input type="radio" class="custom-control-input" id="radioIRNo" name="radio-iRequirement" value="2">
                                                                                        <label class="custom-control-label" for="radioIRNo">No</label>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-sm-12 ownerinfo" id="OwnerInfo1">
                                                                        <div class="form-group row">
                                                                            <label for="inputCampusDrive" class="col-sm-3 col-form-label">Text
                                                        Input</label>
                                                                            <div class="col-sm-4">
                                                                                <input type="text" class="form-control" id="inputCampusDrive">
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-sm-12">
                                                                        <div class="form-group row">
                                                                            <label for="inputCampusDrive" class="col-sm-3 col-form-label">Text
                                                        Input</label>
                                                                            <div class="col-sm-8">
                                                                                <div class="py-2">
                                                                                    <div class="custom-control custom-checkbox custom-control-inline">
                                                                                        <input type="checkbox" class="custom-control-input" id="customControlAutosizing">
                                                                                        <label class="custom-control-label" for="customControlAutosizing">1</label>
                                                                                    </div>
                                                                                    <div class="custom-control custom-checkbox custom-control-inline">
                                                                                        <input type="checkbox" class="custom-control-input" id="customControlAutosizing1">
                                                                                        <label class="custom-control-label" for="customControlAutosizing1">2</label>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-sm-6 offset-sm-3">
                                                                        <a href="#" class="btn btn-success btn-md">Submit</a>
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
                            <script src="../js/moment.min.js" type="text/javascript"></script>
                            <script src="../js/bootstrap-datetimepicker.min.js"></script>
                            <link rel="stylesheet" type="text/css" href="../css/searchable-select.min.css">
                            <script type="text/javascript" src="../js/searchable-select.min.js"></script>

                            <script>
                                indicateMe = "yes"

                                $(document).ready(function() {
                                    loadNavigation('AddDemo', 'glLink', 'plLnk', 'tl', 'Demo', '', ' ');

                                    $('.searchableselect').searchableselect();

                                    $("input[name$='radio-differently']").click(function() {
                                        var test = $(this).val();
                                        $("div.differently-abled").hide();
                                        $("#differentlyAbled" + test).show();
                                    });


                                    // date funtion

                                    $('.datepicker').datetimepicker({
                                        format: 'LT',
                                        format: 'DD-MM-YYYY',
                                        daysOfWeekDisabled: [0, 6],
                                    });
                                    $('.timepicker').datetimepicker({
                                        format: 'LT',
                                        daysOfWeekDisabled: [0, 6],
                                    });
                                    $('.datetimepicker').datetimepicker({
                                        format: 'DD-MM-YYYY LT',
                                        daysOfWeekDisabled: [0, 6],
                                        //viewMode: 'years',
                                    });
                                    // date clear funtion
                                    $('.reset-date').click(function() {
                                        $(this).parent().siblings('.datepicker,.timepicker,.datetimepicker').val("");
                                    })


                                    //Radio Show Hide	  
                                    $(".ownerinfo").hide();
                                    $("input[name$='radio-iRequirement']").click(function() {
                                        var test = $(this).val();
                                        $(".ownerinfo").hide();
                                        $("#OwnerInfo" + test).show();
                                    });


                                });
                            </script>
                        </body>

                        </html>