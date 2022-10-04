<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RaiseTicket.aspx.cs" Inherits="HelpDesk_RaiseTicket" %>
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
                                           Raise Ticket
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
                                                <label  class="col-sm-4 col-form-label font-weight-bolder">State</label>
                                                <div class="col-sm-7">
                                                  <asp:DropDownList ID="DropDownList1" runat="server" class="form-control" Readonly="true">
                                                  <asp:ListItem value="0" Text="--Select--"></asp:ListItem>
                                                   <asp:ListItem value="1" Text="Odisha" Selected="True"></asp:ListItem>
                                                  </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-6">
                                            <div class="form-group row">
                                                <label for="inputName" class="col-sm-4 col-form-label font-weight-bolder">District</label>
                                                <div class="col-sm-7">
                                                   <asp:DropDownList ID="DropDownList2" runat="server" class="form-control" Readonly="true">
                                                  <asp:ListItem value="0" Text="--Select--"></asp:ListItem>
                                                   <asp:ListItem value="0" Text="Chhatisgarh" Selected="True"></asp:ListItem>
                                                  </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-6">
                                            <div class="form-group row">
                                                <label for="dropdownUserType" class="col-sm-4 col-form-label font-weight-bolder">Complainer Name</label>
                                                <div class="col-sm-7">
                                                     <input type="text" value="Suroj Kumar Pradhan" class="form-control" disabled />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-6">
                                            <div class="form-group row">
                                                <label for="dropdownDepart" class="col-sm-4 col-form-label font-weight-bolder">Complainer Mobile Number</label>
                                                <div class="col-sm-7">
                                                   <input type="text" value="9853150842" class="form-control" disabled />                                     
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-6">
                                            <div class="form-group row">
                                                <label for="dropdownDesign" class="col-sm-4 col-form-label font-weight-bolder">Complainer Email-ID </label>
                                                <div class="col-sm-7">
                                                    <input type="text" value="Suman@gmail.com" class="form-control" disabled />                                                  
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-6">
                                            <div class="form-group row">
                                                <label for="inputPassword" class="col-sm-4 col-form-label font-weight-bolder">User Name</label>
                                                <div class="col-sm-7">
                                                    <input type="text" value="Suroj Kumar" class="form-control" disabled />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-6">
                                            <div class="form-group row">
                                                <label for="dropdownState" class="col-sm-4 col-form-label font-weight-bolder">Module <span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                    <asp:DropDownList ID="DropDownList3" runat="server" class="form-control">
                                                  <asp:ListItem value="0" Text="--Select--"></asp:ListItem>
                                                   <asp:ListItem value="1" Text="E-Permit"></asp:ListItem>
                                                  </asp:DropDownList>                                           
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-6">
                                            <div class="form-group row">
                                                <label for="dropdownDist" class="col-sm-4 col-form-label font-weight-bolder">Priority  <span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                   <asp:DropDownList ID="DropDownList4" runat="server" class="form-control">
                                                  <asp:ListItem value="0" Text="--Select--"></asp:ListItem>
                                                   <asp:ListItem value="1" Text="High"></asp:ListItem>
                                                   <asp:ListItem value="1" Text="Medium"></asp:ListItem>
                                                   <asp:ListItem value="1" Text="Low"></asp:ListItem>
                                                  </asp:DropDownList>                                                       
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-6">
                                            <div class="form-group row">
                                                <label for="inputMobile" class="col-sm-4 col-form-label font-weight-bolder">Problem Description <span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                       <textarea class="form-control"  rows="2"></textarea>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-6">
                                            <div class="form-group row">
                                                <label for="inputMail" class="col-sm-4 col-form-label font-weight-bolder">Supporting Documents <span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                    <div class="custom-file">
                                                        <input type="file" class="custom-file-input" id="customFile" name="filename">
                                                        <label class="custom-file-label" for="customFile">Choose Files</label>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        
                                       
                                            <div class="col-sm-6 offset-sm-2">
                                               <asp:Button ID="Button1" class="btn btn-primary btn-md ml-0" runat="server" 
                                                    Text="Submit" onclick="Button1_Click"></asp:Button>
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

<!-- alert 1-->
    <div class="modal fade alert-modal" tabindex="-1" role="dialog" aria-labelledby="alertModal" aria-hidden="true">
        <div class="modal-dialog modal-md" role="document">
            <div class="modal-content">
                <div class="modal-body text-center">
                    <h5 class="p-2 "><i class="fas fa-check fa-2x mb-3 text-success"></i><br> Your Form has been submitted
                        Successfully.</h5>
                    <a class="btn btn-primary btn-md" href="javascrip:;" data-dismiss="modal">Ok</a>
                </div>
               
            </div>
        </div>
    </div>

<!-- alert 2-->
<div class="outer-toast" aria-live="polite" aria-atomic="true">
<div class="toast hide" id="myToast" role="alert" aria-live="assertive" aria-atomic="true" data-autohide="false" style="position: fixed; top: 10%; right: 25%; transform: translate(-50%, 0px); min-width: 400px; z-index:9990" >
  <div class="toast-body bg-white text-center p-5">
   <h6 class="mb-4"> Do you want to Submit This Form?</h6>
      <a href="javascript:;" class=" btn btn-md btn-info" data-dismiss="toast" aria-label="Close">
      <span aria-hidden="true">Ok</span>
    </a>
  </div>
</div>
</div>



    <script>
        indicateMe = "yes"

        $(document).ready(function () {
            loadNavigation('RaiseTicket', 'glhelpdesk', 'plraiseticket', 'tl', 'Help Desk', 'Raise Ticket', ' ');

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

