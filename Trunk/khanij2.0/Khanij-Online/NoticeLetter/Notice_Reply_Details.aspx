<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Notice_Reply_Details.aspx.cs" Inherits="NoticeLetter_Notice_Reply_Details" %>

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
                <asp:scriptmanager runat="server"></asp:scriptmanager>
                <asp:UpdatePanel ID="up1" runat="server">
                    <ContentTemplate>

                    
                <section class="wrapper main-wrapper row">
                    <div class="col-12">
                        <uc1:navigation runat="server" ID="navigation" />
                        <!-- MAIN CONTENT AREA STARTS -->
                        <div class="row">
                            <div class="col-12">
                                <div class="main-tab">
                                    <ul class="nav nav-tabs">
                                        <li class="nav-item">
                                            <a class="nav-link active" href="javascript:void(0);">Notice/Letter
                                            </a>
                                        </li>
                                    </ul>
                                    <uc1:util runat="server" ID="util" />
                                </div>

                                <section class="box form-container">
                                    <div class="content-body">


                                        <div class="form-group row">
                                            <div class="col-sm-12">
                                                <label class="col-form-label font-weight-bolder pt-0">Subject</label>
                                                <textarea name="textAddress" rows="1" cols="20" id="textAddress" class="form-control" readonly="readonly">Mail by GDM</textarea>
                                            </div>
                                        </div>

                                        <div class="form-group row">
                                            <div class="col-sm-12">
                                                <label class="col-form-label font-weight-bolder">Message</label>
                                                <textarea name="textAddress" rows="5" cols="20" id="textAddress" class="form-control" readonly="readonly">This mail is send by GDM for testing purpose.</textarea>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <div class="col-sm-12">
                                                <label class="col-form-label font-weight-bolder">Attachemnt</label>
                                                <a href="#" class="form-control-file">testmail.pdf</a>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <div class="col-sm-4">
                                                <label class="col-form-label font-weight-bolder pt-0">Status</label>
                                                <asp:DropDownList runat="server" ID="ddlStatus" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged" CssClass="form-control" AutoPostBack="true">
                                                    <asp:ListItem value="0">Select Status</asp:ListItem>
                                                    <asp:ListItem value="1">Satisfactory</asp:ListItem>
                                                    <asp:ListItem value="2">Penalty</asp:ListItem>
                                                    <asp:ListItem value="3">Termination of Lease</asp:ListItem>
                                                    <asp:ListItem value="4">Suspension of Lease</asp:ListItem>

                                                </asp:DropDownList>
                                               
                                            </div>
                                        </div>
                                        <div  id="divPenalty" visible="false" runat="server">
                                        <div class="form-group row">
                                            <div class="col-sm-4">
                                                <label class="col-form-label font-weight-bolder pt-0">Penalty Amount</label>
                                                <input type="text" class="form-control" />
                                            </div>
                                            <div class="col-sm-4">
                                                <label class="col-form-label font-weight-bolder pt-0">Penalty Date</label>
                                                <input type="text" class="form-control" />
                                            </div>

                                        </div>
                                        <div class="form-group row" >
                                            <div class="col-sm-4">
                                                <label class="col-form-label font-weight-bolder">Penalty Copy</label>
                                                <div class="custom-file">
                                                    <input type="file" class="custom-file-input" id="customFile" name="filename">
                                                    <label class="custom-file-label" for="customFile">Choose Files</label>
                                                </div>
                                            </div>
                                        </div>
                                            </div>
                                        <div class="form-group row">
                                            <div class="col-sm-12">
                                                <a href="javascript:void(0);" class="btn btn-primary btn-md ml-0" data-toggle="modal"
                                                    data-target=".alert-modal">Send</a>

                                            </div>
                                        </div>


                                    </div>
                                </section>
                            </div>
                        </div>
                    </div>
                    <!-- MAIN CONTENT AREA ENDS -->
                </section>
                        </ContentTemplate>
                </asp:UpdatePanel>
                <uc1:footer runat="server" ID="footer" />
            </div>
            <!-- END CONTENT -->
        </div>
        <!-- END CONTAINER -->
    </form>
    <link rel="stylesheet" type="text/css" href="../css/bootstrap-select.min.css">
    <script type="text/javascript" src="../js/bootstrap-select.min.js"></script>

    <script>
        indicateMe = "yes"
        $(document).ready(function () {
            loadNavigation('SendNoticeLetter', 'glnoticeletter', 'plsendnot', 'tl', 'Notice Letter', 'Send Notice/Letter', ' ');
            $('.selectpicker').selectpicker();
        });
    </script>



</body>
</html>

