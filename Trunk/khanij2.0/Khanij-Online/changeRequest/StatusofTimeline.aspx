<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StatusofTimeline.aspx.cs" Inherits="changeRequest_StatusofTimeline" %>
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
                                           Status of  Timeline
                                        </a>
                                    </li>
                                    
                                </ul>
                                <uc1:util runat="server" ID="util" />
                            </div>

                            <section class="box form-container">
                                <div class="content-body">

                                    <div class="col-lg-12 col-md-12 col-sm-12">
                                    <div class="row">
                                               <label class="col-lg-2 col-md-3 col-sm-12 col-form-label font-weight-bolder">CR Number <span class="text-danger">*</span></label>
                                               <div class="col-lg-3 col-md-6 col-sm-12">
                                              <select class="form-control form-control-sm searchableselect" 
                                                          <option>select</option>
                                                      </select>
                                               </div>
                                               </div>
                                     </div>
                                     
                                        <table class="table table-sm table-bordered mt-3">
                                             <tbody>
                                             <tr>
                                                <th  class="font-weight-bolder">Life Cycle</th>
                                                <th  class="font-weight-bolder">Start Date</th>
                                                <th  class="font-weight-bolder">End Date</th>
                                                <th  class="font-weight-bolder text-center">Days</th>
                                                <th  class="font-weight-bolder">Actual Start Date</th>
                                                <th  class="font-weight-bolder">Actual End Date</th>
                                                <th  class="font-weight-bolder">Status</th>
                                                <th  class="font-weight-bolder">Upload</th>
                                                <th  class="font-weight-bolder">Delay Days</th>
                                                <th  class="font-weight-bolder">Action</th>
                                            </tr>
                                             
                                            <tr>
                                            <td class="font-weight-bolder">Initation</td>
                                            <td>
                                            <input type="text" class="form-control" disabled>
                                            </td>
                                            <td>
                                                <input type="text" class="form-control"  disabled>
                                            </td>
                                            <td>
                                                <label class="form-control-plaintext text-center"  disabled>2</label>
                                            </td>
                                             <td>
                                                <input type="text" class="form-control"  disabled>
                                            </td>
                                             <td>
                                                <input type="text" class="form-control " disabled>
                                            </td>
                                             <td>
                                                <input type="text" class="form-control"  disabled>
                                            </td>
                                             <td>
                                                <input type="text" class="form-control"  disabled>
                                            </td>
                                             <td>
                                                <label class="form-control-plaintext text-center"  disabled>2</label>
                                            </td>
                                             <td>
                                                <a href="javascript:void(0);" class="btn btn-primary btn-md ml-0 waves-effect waves-light">Submit</a>
                                            </td>
                                            </tr>
                                            <tr>
                                            <td class="font-weight-bolder">Planning</td>
                                            <td><input type="text" class="form-control"></td>
                                            <td><input type="text" class="form-control"></td>
                                            <td><label class="form-control-plaintext text-center">2</label></td>
                                            <td>
                                            <div class="input-group">
                                                      <input type="text" class="form-control datepicker" id="Text2">
                                                      <div class="input-group-prepend">
                                                        <label class="input-group-text" for="inputDate1"><i class="far fa-calendar"></i></label>
                                                      </div>
                                                 </div>
                                            </td>
                                            <td>
                                                <div class="input-group">
                                                      <input type="text" class="form-control datepicker" id="Text3">
                                                      <div class="input-group-prepend">
                                                        <label class="input-group-text" for="inputDate1"><i class="far fa-calendar"></i></label>
                                                      </div>
                                                 </div>
                                            </td>
                                            <td><select class="form-control form-control-sm searchableselect" >
                                                          <option>select</option>
                                                      </select> </td>
                                            <td>
                                            <div class="custom-file">
                                                    <input type="file" class="custom-file-input" id="customFile" name="filename">
                                                    <label class="custom-file-label" for="customFile">Choose Files</label>
                                                </div>
                                            </td>
                                            <td><label class="form-control-plaintext text-center">2</label></td>
                                            <td>
                                            <a href="javascript:void(0);" class="btn btn-primary btn-md ml-0 waves-effect waves-light">Submit</a>
                                            </td>
                                            </tr> 
                                            <tr>
                                            <td class="font-weight-bolder">SRS</td>
                                            <td><input type="text" class="form-control"></td>
                                            <td><input type="text" class="form-control"></td>
                                            <td><label class="form-control-plaintext text-center">2</label></td>
                                            <td>
                                            <div class="input-group">
                                                      <input type="text" class="form-control datepicker" id="Text1">
                                                      <div class="input-group-prepend">
                                                        <label class="input-group-text" for="inputDate1"><i class="far fa-calendar"></i></label>
                                                      </div>
                                                 </div>
                                            </td>
                                            <td>
                                                <div class="input-group">
                                                      <input type="text" class="form-control datepicker" id="Text4">
                                                      <div class="input-group-prepend">
                                                        <label class="input-group-text" for="inputDate1"><i class="far fa-calendar"></i></label>
                                                      </div>
                                                 </div>
                                            </td>
                                            <td><select class="form-control form-control-sm searchableselect" >
                                                          <option>select</option>
                                                      </select> </td>
                                            <td>
                                            <div class="custom-file">
                                                    <input type="file" class="custom-file-input" id="File1" name="filename">
                                                    <label class="custom-file-label" for="customFile">Choose Files</label>
                                                </div>
                                            </td>
                                            <td><label class="form-control-plaintext text-center">2</label></td>
                                            <td>
                                            <a href="javascript:void(0);" class="btn btn-primary btn-md ml-0 waves-effect waves-light">Submit</a>
                                            </td>
                                            </tr> 
                                            <tr>
                                            <td class="font-weight-bolder">Designing</td>
                                            <td><input type="text" class="form-control"></td>
                                            <td><input type="text" class="form-control"></td>
                                            <td><label class="form-control-plaintext text-center">2</label></td>
                                            <td>
                                            <div class="input-group">
                                                      <input type="text" class="form-control datepicker" id="Text9">
                                                      <div class="input-group-prepend">
                                                        <label class="input-group-text" for="inputDate1"><i class="far fa-calendar"></i></label>
                                                      </div>
                                                 </div>
                                            </td>
                                            <td>
                                                <div class="input-group">
                                                      <input type="text" class="form-control datepicker" id="Text10">
                                                      <div class="input-group-prepend">
                                                        <label class="input-group-text" for="inputDate1"><i class="far fa-calendar"></i></label>
                                                      </div>
                                                 </div>
                                            </td>
                                            <td><select class="form-control form-control-sm searchableselect" >
                                                          <option>select</option>
                                                      </select> </td>
                                            <td>
                                            <div class="custom-file">
                                                    <input type="file" class="custom-file-input" id="File4" name="filename">
                                                    <label class="custom-file-label" for="customFile">Choose Files</label>
                                                </div>
                                            </td>
                                            <td><label class="form-control-plaintext text-center">2</label></td>
                                            <td>
                                            <a href="javascript:void(0);" class="btn btn-primary btn-md ml-0 waves-effect waves-light">Submit</a>
                                            </td>
                                            </tr>
                                            <tr>
                                            <td class="font-weight-bolder">Development</td>
                                            <td><input type="text" class="form-control"></td>
                                            <td><input type="text" class="form-control"></td>
                                            <td><label class="form-control-plaintext text-center">2</label></td>
                                            <td>
                                            <div class="input-group">
                                                      <input type="text" class="form-control datepicker" id="Text5">
                                                      <div class="input-group-prepend">
                                                        <label class="input-group-text" for="inputDate1"><i class="far fa-calendar"></i></label>
                                                      </div>
                                                 </div>
                                            </td>
                                            <td>
                                                <div class="input-group">
                                                      <input type="text" class="form-control datepicker" id="Text6">
                                                      <div class="input-group-prepend">
                                                        <label class="input-group-text" for="inputDate1"><i class="far fa-calendar"></i></label>
                                                      </div>
                                                 </div>
                                            </td>
                                            <td><select class="form-control form-control-sm searchableselect" >
                                                          <option>select</option>
                                                      </select> </td>
                                            <td>
                                            <div class="custom-file">
                                                    <input type="file" class="custom-file-input" id="File2" name="filename">
                                                    <label class="custom-file-label" for="customFile">Choose Files</label>
                                                </div>
                                            </td>
                                            <td><label class="form-control-plaintext text-center">2</label></td>
                                            <td>
                                            <a href="javascript:void(0);" class="btn btn-primary btn-md ml-0 waves-effect waves-light">Submit</a>
                                            </td>
                                            </tr>
                                            <tr>
                                            <td class="font-weight-bolder">Testing</td>
                                           <td><input type="text" class="form-control"></td>
                                            <td><input type="text" class="form-control"></td>
                                            <td><label class="form-control-plaintext text-center">2</label></td>
                                            <td>
                                            <div class="input-group">
                                                      <input type="text" class="form-control datepicker" id="Text7">
                                                      <div class="input-group-prepend">
                                                        <label class="input-group-text" for="inputDate1"><i class="far fa-calendar"></i></label>
                                                      </div>
                                                 </div>
                                            </td>
                                            <td>
                                                <div class="input-group">
                                                      <input type="text" class="form-control datepicker" id="Text8">
                                                      <div class="input-group-prepend">
                                                        <label class="input-group-text" for="inputDate1"><i class="far fa-calendar"></i></label>
                                                      </div>
                                                 </div>
                                            </td>
                                            <td><select class="form-control form-control-sm searchableselect" >
                                                          <option>select</option>
                                                      </select> </td>
                                            <td>
                                            <div class="custom-file">
                                                    <input type="file" class="custom-file-input" id="File3" name="filename">
                                                    <label class="custom-file-label" for="customFile">Choose Files</label>
                                                </div>
                                            </td>
                                            <td><label class="form-control-plaintext text-center">2</label></td>
                                            <td>
                                            <a href="javascript:void(0);" class="btn btn-primary btn-md ml-0 waves-effect waves-light">Submit</a>
                                            </td>
                                            </tr>                                  
                                            </tbody>
                                        </table>
                                     
                                       
                                           
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
            loadNavigation('StatusofTimeline', 'glchangerequest', 'plstaotim', 'tl', 'Change Request', 'Status of Timeline', ' ');
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




