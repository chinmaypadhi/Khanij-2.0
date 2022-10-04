<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddComplaintRegistrationForm.aspx.cs" Inherits="Grievance_AddComplaintRegistrationForm" %>

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
                    <!-- MAIN CONTENT AREA STARTS -->
                    <div class="row">
                        <div class="col-12">
                            <div class="main-tab">
                                
                              
                                <uc1:util runat="server" ID="util" />
                            </div>

                            <section class="box form-container">
                                <div class="content-body">

                                    <div class="row">
                                    <div class="col-sm-12">
                                            <div class="form-group row">
                                            <h4>1) Details of the complainer</h4>
                                            </div>
                                            </div>
                                       <%-- <div class="col-sm-6">
                                            <div class="form-group row">
                                                <label for="inputLoginId" class="col-sm-4 col-form-label">Mineral Category  <span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                    <asp:DropDownList Class="form-control searchableselect" ID="DropDownList4" runat="server">
                                                        <asp:ListItem>Select Mineral Category</asp:ListItem>
                                                        <asp:ListItem>Major Mineral</asp:ListItem>
                                                        <asp:ListItem>Minor Mineral</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>--%>
                                         <div class="col-sm-6">
                                            <div class="form-group row">
                                                <label for="dropdownDepart" class="col-sm-4 col-form-label">User Code of Complainer</label>
                                                <div class="col-sm-7">
                                                    <asp:TextBox ID="TextBox1" CssClass="form-control" Text="3230000181" runat="server"></asp:TextBox>                                                    
                                                </div>
                                            </div>
                                        </div>
                                         <div class="col-sm-6">
                                            <div class="form-group row">
                                                <label for="dropdownDepart" class="col-sm-4 col-form-label">Name of Complainer  <span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                    <asp:TextBox ID="TextBox2" Text="RAMA UDYOG PVT. LTD." CssClass="form-control" runat="server"></asp:TextBox>                                                    
                                                </div>
                                            </div>
                                        </div> 
                                         <div class="col-sm-6">
                                            <div class="form-group row">
                                                <label for="inputLoginId" class="col-sm-4 col-form-label">State <span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                 
                                                    <select name="District" Class="form-control searchableselect" id="Select2">
                                                    <option value="0">Select</option>
  <option value="1">Andaman Nicobar</option>
<option value="2">Andhra Pradesh </option>
<option value="3">Arunanchal Pradesh </option>
<option value="4">Assam</option>
<option value="5">Bihar</option>
<option value="6">Chandigarh </option>
<option selected="selected" value="7">Chhattisgarh </option>
<option value="8">Dadar &amp; Nagar Haveli</option>
<option value="9">Daman &amp; Diu</option>
<option value="10">Delhi </option>
<option value="11">Goa</option>
<option value="12">Gujarat</option>
<option value="13">Haryana</option>
<option value="14">Himachal Pradesh</option>
<option value="15">Jammu &amp; Kashmir</option>
<option value="16">Jharkhand</option>
<option value="17">Karnataka</option>
<option value="18">Kerala</option>
<option value="19">Lakshadweep </option>
<option value="20">Madhya Pradesh</option>
<option value="21">Maharashtra</option>
<option value="22">Manipur</option>
<option value="23">Meghalaya</option>
<option value="24">Mizoram</option>
<option value="25">Nagaland </option>
<option value="26">Odisha</option>
<option value="27">Puducherry</option>
<option value="28">Punjab</option>
<option value="29">Rajasthan</option>
<option value="30">Sikkim</option>
<option value="31">Tamil Nadu</option>
<option value="32">Telengana</option>
<option value="33">Tripura</option>
<option value="34">Uttarakhand</option>
<option value="35">Uttar Pradesh</option>
<option value="36">West Bengal</option>
<option value="37">Telangana</option>
                                                  </select>
                                                </div>
                                            </div>
                                        </div> 
                                        
                                         
                                         <div class="col-sm-6">
                                            <div class="form-group row">
                                                <label for="dropdownDepart" class="col-sm-4 col-form-label">Mobile Number of Complainer <span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                    <asp:TextBox ID="TextBox4" CssClass="form-control" Text="9516011041" runat="server"></asp:TextBox>                                                    
                                                </div>
                                            </div>
                                        </div>  
                                        <div class="col-sm-6">
                                            <div class="form-group row">
                                                <label for="inputLoginId" class="col-sm-4 col-form-label">District <span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                 
                                                    <select name="District" Class="form-control searchableselect" id="DId">
                                                    <option value="0">Select</option>
                                                        <option value="1">Balod</option>
<option value="2">Balodabazar-Bhatapara</option>
<option value="3">Balrampur-Ramanujganj</option>
<option value="4">Bastar(Jagdalpur)</option>
<option value="5">Bemetara</option>
<option value="6">Bijapur (Chhattisgarh)</option>
<option value="7">Bilaspur</option>
<option value="8">Dantewada (Dakshin Bastar)</option>
<option value="9">Dhamtari</option>
<option value="10">Durg</option>
<option value="11">Gariabandh</option>
<option value="12">Janjgir - Champa</option>
<option value="13">Jashpur</option>
<option value="14">Kabirdham</option>
<option value="15">Kanker (Uttar Bastar)</option>
<option value="16">Kondagaon</option>
<option value="17">Korba</option>
<option value="18">Korea</option>
<option value="19">Mahasamund</option>
<option value="20">Mungeli</option>
<option value="21">Narayanpur</option>
<option value="22">Raigarh</option>
<option selected="selected" value="23">Raipur</option>
<option value="24">Rajnandgoan</option>
<option value="25">Sukma</option>
<option value="26">Surajpur</option>
<option value="27">Surguja</option>
                                                  </select>
                                                </div>
                                            </div>
                                        </div> 
                                        <div class="col-sm-6">
                                            <div class="form-group row">
                                                <label for="dropdownDepart" class="col-sm-4 col-form-label"> Complete Address <span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                    <asp:TextBox ID="TextBox5" CssClass="form-control" Text="18th MILE STONE, PHASE-II, SILTARA INDUSTRIAL AREA, RAIPUR C.G." TextMode="MultiLine" runat="server"></asp:TextBox>                                                    
                                                </div>
                                            </div>
                                        </div>  
                                        <div class="col-sm-6">
                                            <div class="form-group row">
                                                <label for="dropdownDepart" class="col-sm-4 col-form-label"> Pincode <span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                    <asp:TextBox ID="TextBox6" CssClass="form-control" Text="493111"  runat="server"></asp:TextBox>                                                    
                                                </div>
                                            </div>
                                        </div> 
                                         <div class="col-sm-6">
                                            <div class="form-group row">
                                                <label for="dropdownDepart" class="col-sm-4 col-form-label">Email-Id of Complainer  <span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                    <asp:TextBox ID="TextBox3" CssClass="form-control" Text="rawmaterial@ramaudyog.co.in" runat="server"></asp:TextBox>                                                    
                                                </div>
                                            </div>
                                        </div>                        
                                        <%--<div class="col-sm-6">
                                            <div class="form-group row">
                                                <label for="inputName" class="col-sm-4 col-form-label">Status <span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                    <div class="py-2">
                                    <asp:RadioButtonList ID="customRadio" class="custom-radio" runat="server" RepeatDirection="Horizontal" RepeatColumns="3" >
                                        <asp:ListItem Value="1" Selected="True">Active</asp:ListItem>
                                        <asp:ListItem Value="2">Inactive</asp:ListItem>
                                    </asp:RadioButtonList>
                                                        </div>
                                                </div>
                                            </div>
                                        </div>--%>
                                          <div class="col-sm-12">
                                            <div class="form-group row">
                                           <h4>2) Details of Complain</h4>
                                            </div>
                                            </div>

                                        <div class="col-sm-6">
                                            <div class="form-group row">
                                                <label for="inputLoginId" class="col-sm-4 col-form-label">Subject of Complaint  <span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                    <asp:DropDownList Class="form-control searchableselect" ID="DropDownList1" runat="server">
                                                        <asp:ListItem>Select</asp:ListItem>
                                                        <asp:ListItem>Illigal Mining</asp:ListItem>
                                                        <asp:ListItem selected="selected">Illigal Transportation</asp:ListItem>
                                                           <asp:ListItem>Illigal Storage</asp:ListItem>
                                                        
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div> 
                                        <div class="col-sm-6">
                                            <div class="form-group row">
                                                <label for="dropdownDepart" class="col-sm-4 col-form-label"> Complaint In Brief <span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                    <asp:TextBox ID="TextBox7" CssClass="form-control" Text="HAS BEEN SUBMITTED AT MINING OFFICE, RAIPUR C.G. IN PERSON FOR CLOUSER OF FAKE ID. 
SO YOUR ARE REQUESTED TO CLOSE THE FAKE ID.NO. 32300001447 IMMEDIATELY. " TextMode="MultiLine" runat="server"></asp:TextBox>                                                    
                                                </div>
                                            </div>
                                        </div> 
                                          <div class="col-sm-6">
                                            <div class="form-group row">
                                                <label for="dropdownDepart" class="col-sm-4 col-form-label"> Complain related to Person / Area / Vehicle No. <span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                    <asp:TextBox ID="TextBox8" CssClass="form-control" Text="N.A." TextMode="MultiLine" runat="server"></asp:TextBox>                                                    
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-6">
                                        </div>   
                                         <div class="col-sm-6">
                                            <div class="form-group row">
                                                <label for="inputLoginId" class="col-sm-4 col-form-label">Complaint to District<span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                    <select name="District" Class="form-control searchableselect" id="Select1">
                                                    <option value="0">Select</option>
                                                        <option value="1">Balod</option>
<option value="2">Balodabazar-Bhatapara</option>
<option value="3">Balrampur-Ramanujganj</option>
<option value="4">Bastar(Jagdalpur)</option>
<option value="5">Bemetara</option>
<option value="6">Bijapur (Chhattisgarh)</option>
<option value="7">Bilaspur</option>
<option value="8">Dantewada (Dakshin Bastar)</option>
<option value="9">Dhamtari</option>
<option value="10">Durg</option>
<option value="11">Gariabandh</option>
<option value="12">Janjgir - Champa</option>
<option value="13">Jashpur</option>
<option value="14">Kabirdham</option>
<option value="15">Kanker (Uttar Bastar)</option>
<option value="16">Kondagaon</option>
<option value="17">Korba</option>
<option value="18">Korea</option>
<option value="19">Mahasamund</option>
<option value="20">Mungeli</option>
<option value="21">Narayanpur</option>
<option value="22">Raigarh</option>
<option selected="selected" value="23">Raipur</option>
<option value="24">Rajnandgoan</option>
<option value="25">Sukma</option>
<option value="26">Surajpur</option>
<option value="27">Surguja</option>
                                                  </select>
                                                </div>
                                            </div>
                                        </div> 
                                        <div class="col-sm-6">
                                            <div class="form-group row">
                                                <label for="dropdownDepart" class="col-sm-4 col-form-label"> Action Required  <span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                    <asp:TextBox ID="TextBox9" CssClass="form-control" Text="Yes"  runat="server"></asp:TextBox>                                                    
                                                </div>
                                            </div>
                                        </div> 
                                        <div class="col-sm-6">
                                            <div class="form-group row">
                                                <label for="dropdownDepart" class="col-sm-4 col-form-label"> Attachment <span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                
                                                     <a  title="Edit">LETTER FOR CLOUSER OF FAKE ID.pdf</a>                                                 
                                                </div>
                                            </div>
                                        </div>
                                         <div class="col-sm-6">
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
    <link rel="stylesheet" href="../css/searchable-select.min.css">
    <script src="../js/searchable-select.min.js"></script>
    <!-- alert 1-->
    <div class="modal fade alert-modal" tabindex="-1" role="dialog" aria-labelledby="alertModal"
        aria-hidden="true">
        <div class="modal-dialog modal-md" role="document">
            <div class="modal-content">
                <div class="modal-body text-center">
                    <h5 class="p-2 ">
                        <i class="fas fa-check fa-2x mb-3 text-success"></i>
                        <br>
                        Your Form has been submitted Successfully.</h5>
                    <a class="btn btn-primary btn-md" href="javascrip:;" data-dismiss="modal">Ok</a>
                </div>
            </div>
        </div>
    </div>
    <script>
        indicateMe = "yes"

        $(document).ready(function () {
            loadNavigation('AddMineralForm', 'glTMng', 'plmineralform', 'tl', 'Grievance', ' Add Grievance', '');

            $('.searchableselect').searchableselect();


        });
    </script>
</body>
</html>
