<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewDemo.aspx.cs" Inherits="dashboard_ViewDemo" %>

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
                                        <a class="nav-link" href="AddDemo.aspx">
                                            Add
                                        </a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link active" href="javascript:void(0);">
                                            View
                                        </a>
                                    </li>
                                </ul>
                                <uc1:util runat="server" ID="util" />
                            </div>

                            <section class="box form-container">
                                <div class="search-box">
                                    <div class="searchform px-3 pt-3">
                                        <div class="row">
                                            <div class="col-sm-6">
                                                <div class="form-group row">
                                                    <label for="inputText" class="col-sm-5 col-form-label">Text
                                                        Input</label>
                                                    <div class="col-sm-7">
                                                        <input type="text" class="form-control" id="v">
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-sm-6">
                                                <div class="form-group row">
                                                    <label for="inputText" class="col-sm-5 col-form-label">Text
                                                        Input</label>
                                                    <div class="col-sm-7">
                                                        <input type="text" class="form-control" id="v">
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-sm-6">
                                                <div class="form-group row">
                                                    <label for="inputText" class="col-sm-5 col-form-label">Text
                                                        Input</label>
                                                    <div class="col-sm-7">
                                                        <input type="text" class="form-control" id="v">
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-sm-6">
                                                <div class="form-group row">
                                                    <label for="inputText" class="col-sm-5 col-form-label">Text
                                                        Input</label>
                                                    <div class="col-sm-7">
                                                        <input type="text" class="form-control" id="v">
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="text-center"><a href="#"
                                            class="btn btn-sm shadow-sm searchbtn rounded-0"><i
                                                class="fas fa-chevron-up"></i> <span>Hide</span></a> </div>
                                </div>
                                <div class="content-body">
                                    <div class="row">
                                        <div class="col-sm-12">
                                          <div class="legend-box">
                                          <ul class="d-flex mb-1 justify-content-end list-unstyled">
                                              <li><span class="bg-success"></span> Active</li>
                                              <li><span class="bg-warning"></span> Inactive</li>
                                            </ul>
                                          </div>
                                            <div class="table-responsive" id="viewtable">
                                                <table class="table table-sm table-bordered">
                                                    <thead>
                                                        <tr>
                                                            <th width="40">Sl#</th>
                                                            <th width="30">
                                                                <div class="custom-control custom-checkbox">
                                                                    <input type="checkbox" class="custom-control-input"
                                                                        id="checkbox1">
                                                                    <label class="custom-control-label"
                                                                        for="checkbox1"></label>
                                                                </div>
                                                            </th>
                                                            <th>Complaint Type</th>
                                                            <th>Description</th>
                                                            <th>Have Category</th>
                                                            <th width="80">Edit</th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <tr class="inactive-row">
                                                            <td>1</td>
                                                            <td>
                                                                <div class="custom-control custom-checkbox">
                                                                    <input type="checkbox" class="custom-control-input"
                                                                        id="checkbox2">
                                                                    <label class="custom-control-label"
                                                                        for="checkbox2"></label>
                                                                </div>
                                                            </td>
                                                            <td>Complaints</td>
                                                            <td>-</td>
                                                            <td>Yes</td>
                                                            <td ><a href="AddDemo.aspx"
                                                                    class="btn-floating btn-outline-primary btn-sm"
                                                                    title="Edit"><i class="fas fa-pencil-alt"></i></a>
                                                            </td>
                                                        </tr>
                                                        <tr class="active-row">
                                                            <td>2</td>
                                                            <td>
                                                                <div class="custom-control custom-checkbox">
                                                                    <input type="checkbox" class="custom-control-input"
                                                                        id="checkbox3">
                                                                    <label class="custom-control-label"
                                                                        for="checkbox3"></label>
                                                                </div>
                                                            </td>
                                                            <td>Complaints</td>
                                                            <td>-</td>
                                                            <td>Yes</td>
                                                            <td><a href="AddDemo.aspx"
                                                                    class="btn-floating btn-outline-primary btn-sm"
                                                                    title="Edit"><i class="fas fa-pencil-alt"></i></a>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </div>
                                            <nav aria-label="Page navigation ">
                                                <ul class="pagination pg-blue float-right">
                                                    <li class="page-item disabled">
                                                        <span class="page-link">Prev</span>
                                                    </li>
                                                    <li class="page-item"><a class="page-link">1</a></li>
                                                    <li class="page-item active">
                                                        <span class="page-link">
                                                            2
                                                            <span class="sr-only">(current)</span>
                                                        </span>
                                                    </li>
                                                    <li class="page-item"><a class="page-link">3</a></li>
                                                    <li class="page-item">
                                                        <a class="page-link">Next </a>
                                                    </li>
                                                </ul>
                                                <div class="clearfix"></div>
                                            </nav>
                                            <!-- Button trigger modal -->
                                            <a href="javascript:void(0);" class="btn btn-secondary btn-md" data-toggle="modal"
                                                data-target="#basicExampleModal">
                                                Demo modal </a>
                                            <a href="javascript:void(0);" class="btn btn-primary btn-md" data-toggle="modal"
                                                data-target="#conformModal">Confirm Modal</a>
                                            <a href="javascript:void(0);" class="btn btn-success btn-md" data-toggle="modal"
                                                data-target="#successModal">Success Message</a>

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

<!-- Demo Modal -->
    <div class="modal fade" id="basicExampleModal" tabindex="-1" role="dialog" aria-labelledby="basicExampleModal"
        aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title mt-0" id="exampleModalLabel">Modal title</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    Modal content
                </div>
                <div class="modal-footer">
                    <button class="btn btn-danger btn-md" type="button" data-dismiss="modal">Cancel</button>
                    <a class="btn btn-success btn-md" href="#" data-dismiss="modal">Ok</a>
                </div>
            </div>
        </div>
    </div>
    <!-- Confirm Modal -->
    <div class="modal fade" id="conformModal" tabindex="-1" role="dialog" aria-labelledby="conformModal"
        aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-body text-center">
                    <h4 class="text-warning p-4 "><i class="fas fa-check fa-2x mb-3"></i><br> Are you want to submitt
                        the form?</h4>
                </div>
                <div class="modal-footer">
                    <button class="btn btn-danger btn-md" type="button" data-dismiss="modal">No</button>
                    <a class="btn btn-success btn-md" href="#" data-dismiss="modal">Yes</a>
                </div>
            </div>
        </div>
    </div>
    <!-- success Modal -->
    <div class="modal fade" id="successModal" tabindex="-1" role="dialog" aria-labelledby="successModal"
        aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-body text-center">
                    <h4 class="text-success p-4 "><i class="fas fa-check fa-2x mb-3"></i><br> You have submitted
                        Successfully.</h4>
                </div>
                <div class="modal-footer">
                    <button class="btn btn-danger btn-md" type="button" data-dismiss="modal">Cancel</button>
                    <a class="btn btn-success btn-md" href="#">Ok</a>
                </div>
            </div>
        </div>
    </div>
        </form>
<script src="../js/moment.min.js" type="text/javascript"></script>
    <script src="../js/bootstrap-datetimepicker.min.js"></script>
    <link rel="stylesheet" type="text/css" href="../css/searchable-select.min.css">
<script type="text/javascript" src="../js/searchable-select.min.js"></script>

    <script>
        printMe = "yes"
        backMe = "yes"
        deleteMe = "yes"
        downloadMe = "yes"
        excelMe = "yes"
        pdfMe = "yes"
        activetMe = "yes"
        inactivetMe = "yes"
        refreshMe = "yes"

    $(document).ready(function() {
        loadNavigation('ViewDemo', 'glLink', 'plLnk', 'Demo', '', '', 'Add Demo ','');
    });
    </script>
</body>
</html>
