<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddPaymentHead.aspx.cs" Inherits="Masters_AddPaymentHead" %>
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
                                            Add New Payment Head
                                        </a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" href="ViewPaymentHead.aspx">
                                            View
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
                                                <label for="inputName" class="col-sm-3 col-form-label text-left">Account Type <span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                    <div class="py-2">
                                    <asp:RadioButtonList ID="customRadio" class="custom-radio" runat="server" RepeatDirection="Horizontal" RepeatColumns="3" >
                                        <asp:ListItem Value="1" >Single Account</asp:ListItem>
                                        <asp:ListItem Value="2">District Wise Account</asp:ListItem>
                                    </asp:RadioButtonList>
                                                        </div>
                                                </div>
                                            </div>
                                        </div>
                                        </div>

                                        <div class="offset-sm-6"></div>

                                        <div class="single-account">
                                        <div class="row">

                                        <div class="col-sm-6">
                                            <div class="form-group row">
                                                <label for="inputName" class="col-sm-3 col-form-label text-left">Select Payment Type<span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                     <select class="form-control form-control-sm searchableselect">
                                                        <option value="eq">Select Payment Type</option>
                                                        <option value="neq">Annual Fees (Major)</option>
                                                        <option value="startswith">Annual Fees (Minor)</option>
                                                    </select>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-sm-6">
                                            <div class="form-group row">
                                                <label for="inputName" class="col-sm-4 col-form-label">Head Of Account <span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                     <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" ></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-sm-6">
                                            <div class="form-group row">
                                                <label for="inputName" class="col-sm-3 col-form-label text-left">SBI Scheme Code<span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                     <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" ></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-sm-6">
                                            <div class="form-group row">
                                                <label for="inputName" class="col-sm-4 col-form-label">HDFC Scheme Code<span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                     <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control" ></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-sm-6">
                                            <div class="form-group row">
                                                <label for="inputName" class="col-sm-3 col-form-label text-left">ICICI Scheme Code<span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                     <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control" ></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>

                                        </div>
                                        </div>


                                       <div class="offset-sm-6"></div>
                                       <div class="District-Account">
                                        <div class="row">
                                        
                                         <div class="col-sm-6">
                                            <div class="form-group row">
                                                <label for="inputName" class="col-sm-3 col-form-label text-left">Select Payment Type<span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                     <select class="form-control form-control-sm searchableselect">
                                                        <option value="eq">Select Payment Type</option>
                                                        <option value="neq">Annual Fees (Major)</option>
                                                        <option value="startswith">Annual Fees (Minor)</option>
                                                    </select>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="offset-sm-6"></div>
                                        <div class="col-sm-12">
                                        <table class="table   table-bordered">
                                        <div class="table-responsive">
                                <thead>
                                    <tr>
                                        <th width="40px"><asp:CheckBox ID="CheckBox1" runat="server" /></th>
                                        <th>District Name</th>
                                        <th>Head Of Account</th>
                                        <th>SBI Scheme Code</th>
                                        <th>HDFC Scheme Code</th>
                                        <th>ICICI Scheme Code</th>
                                    </tr>
                                </thead>
                                <tbody> 
                                            <tr>    
                                               
                                            <td><asp:CheckBox ID="CheckBox2" runat="server" /></td>                                
                                            <td><label for="Balod">Balod</label></td>
                                            <td> 
                                           
                                            <input name="[0].HeadOFAccount" type="text" value="">
                                             <span class="text-danger">*</span>
                                               
                                            </td>
                                            <td>
                                             <input name="[0].HeadOFAccount" type="text" value="">
                                             <span class="text-danger">*</span>
                                            </td>
                                            <td>
                                             <input name="[0].HeadOFAccount" type="text" value="">
                                             <span class="text-danger">*</span>
                                            </td>
                                            <td>
                                             <input name="[0].HeadOFAccount" type="text" value="">
                                             <span class="text-danger">*</span>
                                            </td>

                                           
                                            </tr>
                                            <tr>    
                                               
                                            <td><asp:CheckBox ID="CheckBox3" runat="server" /></td>                               
                                            <td><label for="Balodabazar-Bhatapara">Balodabazar-Bhatapara</label></td>
                                            <td>  
                                            <input name="[0].HeadOFAccount" type="text" value="">
                                             <span class="text-danger">*</span>
</ul></div>
                                            </td>
                                            <td> 
                                            <input name="[0].HeadOFAccount" type="text" value="">
                                             <span class="text-danger">*</span>
                                            </td>
                                            <td>
                                             <input name="[0].HeadOFAccount" type="text" value="">
                                             <span class="text-danger">*</span>
                                            </td>
                                            <td>
                                             <input name="[0].HeadOFAccount" type="text" value="">
                                             <span class="text-danger">*</span>
                                            </td>

                                           
                                            </tr>
                                          

                                       
                                   
                                   
                                </tbody>
                                </div>
                            </table>
                                        </div>
                                        </div>
                                        
                                         </div>


                                       
                                        <div class="row">
                                            <div class="col-sm-6 ">
                                                <a href="javascript:void(0);" class="btn btn-primary btn-md ml-0" data-toggle="modal"
                                                data-target=".alert-modal">Submit</a>
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

    <script>
        indicateMe = "yes"

        $(document).ready(function () {
            loadNavigation('AddPaymentHead', 'glTMng', 'plpaymenthead', 'tl', 'Masters', 'Payment Head',' ');
            $('.searchableselect').searchableselect();


            $(".single-account,.District-Account").hide();
            $("input[value$='1']").click(function () {
                var test = $(this).val();
                $(".single-account").show();
                $(".District-Account").hide();

            });
            $("input[value$='2']").click(function () {
                var test = $(this).val();

                $(".District-Account").show();
                $(".single-account").hide();

            });

        });
    </script>
</body>
</html>


