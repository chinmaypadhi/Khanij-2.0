<%@ Page Language="C#" AutoEventWireup="true" CodeFile="multiselect.aspx.cs" Inherits="Dashboard_multiselect" %>


    <%@ Register Src="~/includes/navbar.ascx" TagPrefix="uc1" TagName="navbar" %>
        <%@ Register Src="~/includes/leftsider.ascx" TagPrefix="uc1" TagName="leftsider" %>
            <%@ Register Src="~/includes/navigation.ascx" TagPrefix="uc1" TagName="navigation" %>
                <%@ Register Src="~/includes/util.ascx" TagPrefix="uc1" TagName="util" %>
                    <%@ Register Src="~/includes/footer.ascx" TagPrefix="uc1" TagName="footer" %>

                        <!DOCTYPE html>
                        <html lang="en">

                        <head id="Head1" runat="server">
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
                                                               
                                                            </ul>
                                                            <uc1:util runat="server" ID="util" />
                                                        </div>

                                                        <section class="box form-container">
                                                            <div class="content-body">
                                                            <div class="form-group" data-select2-id="400">
									<label>Multiple select</label>
									<select multiple="" class="form-control select select2-hidden-accessible" data-fouc="" data-select2-id="25" tabindex="-1" aria-hidden="true">
										<optgroup label="Mountain Time Zone" data-select2-id="403">
											<option value="AZ" selected="" data-select2-id="27">Arizona</option>
											<option value="CO" data-select2-id="404">Colorado</option>
											<option value="ID" data-select2-id="405">Idaho</option>
											<option value="WY" data-select2-id="406">Wyoming</option>
										</optgroup>
										<optgroup label="Central Time Zone" data-select2-id="407">
											<option value="AL" data-select2-id="408">Alabama</option>
											<option value="IA" selected="" data-select2-id="28">Iowa</option>
											<option value="KS" selected="" data-select2-id="29">Kansas</option>
											<option value="KY" data-select2-id="409">Kentucky</option>
										</optgroup>
									</select><span class="select2 select2-container select2-container--default select2-container--below select2-container--focus" dir="ltr" data-select2-id="26" style="width: 100%;"><span class="selection"><span class="select2-selection select2-selection--multiple" role="combobox" aria-haspopup="true" aria-expanded="false" tabindex="-1" aria-disabled="false"><ul class="select2-selection__rendered"><li class="select2-selection__choice" title="Arizona" data-select2-id="412"><span class="select2-selection__choice__remove" role="presentation">×</span>Arizona</li><li class="select2-selection__choice" title="Colorado" data-select2-id="413"><span class="select2-selection__choice__remove" role="presentation">×</span>Colorado</li><li class="select2-selection__choice" title="Iowa" data-select2-id="414"><span class="select2-selection__choice__remove" role="presentation">×</span>Iowa</li><li class="select2-selection__choice" title="Kansas" data-select2-id="415"><span class="select2-selection__choice__remove" role="presentation">×</span>Kansas</li><li class="select2-search select2-search--inline"><input class="select2-search__field" type="search" tabindex="0" autocomplete="off" autocorrect="off" autocapitalize="none" spellcheck="false" role="searchbox" aria-autocomplete="list" placeholder="" style="width: 0.75em;"></li></ul></span></span><span class="dropdown-wrapper" aria-hidden="true"></span></span>
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
                            <script type="text/javascript" src="../js/select2.min.js"></script>
                            <script type="text/javascript" src="../js/form_select2.js"></script>
                            <script type="text/javascript" src="../js/interactions.min.js"></script>

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
