<%@ Page Language="C#" AutoEventWireup="true" CodeFile="IrregularityCases.aspx.cs"
    Inherits="Checkpost_IrregularityCases" %>

<%@ Register Src="~/includes/navbar.ascx" TagPrefix="uc1" TagName="navbar" %>
<%@ Register Src="~/includes/leftsider.ascx" TagPrefix="uc1" TagName="leftsider" %>
<%@ Register Src="~/includes/navigation.ascx" TagPrefix="uc1" TagName="navigation" %>
<%@ Register Src="~/includes/util.ascx" TagPrefix="uc1" TagName="util" %>
<%@ Register Src="~/includes/footer.ascx" TagPrefix="uc1" TagName="footer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
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
    <link rel="stylesheet" href="../css/bootstrap-datetimepicker.min.css" type="text/css" />
    <style>
    .font-height-set
    {
        font-size: 4.9em;
    }

    .custom-input
    {
        width: 100%;
        font-size: 3em;
        height: 70px;
    }

    .TextBoxAsLabel
    {
        border: none;
        background-color: #fff;
        background: transparent;
    }

    .panel-title
    {
        font-size: 15px;
    }

    .k-textbox
    {
        width: 250px;
    }
</style>
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
           <div class="row">
            <div class="col-md-3">
                <div class="panel panel-default" style="height: 120px; background-color: #E54C3B">
                    <h3 class="panel-title" style="color: white; padding: 10px 10px;">Excess Mineral Quantity</h3>
                    <div class="panel-body">
                        <div class="col-sm-4">
                            <span id="ExCount" class="lead" style="font-weight: bold; color: white; margin-left: 20px; font-size: 36px; cursor: pointer">0</span>
                        </div>
                        <div class="col-sm-8">
                            <button type="button" id="ExQty" style="border: none; background: none">
                                <span class="font-awsomecolor">
                                    <img style="width: 47px; height: 47px; margin-left:100px" src="../img/CheckpostIcons/excess materials.svg"/>
                                </span>
                            </button>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="panel panel-default" style="height: 120px; background-color: #2E8AC5">
                    <h3 class="panel-title" style="color: white; padding: 10px 10px;">Without Transit Pass</h3>

                    <div class="panel-body">
                        <button type="button" id="NoPass" style="border: none; background: none">
                            <span class="font-awsomecolor" style="font-size: 0.8em;">
                                <img style="width: 80px; height: 47px; margin-top: 0px; margin-left:155px" src="../img/CheckpostIcons/pass.svg"/></span>
                        </button>
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="panel panel-default" style="height: 120px; background-color: #F0C318">
                    <h2 class="panel-title" style="color: white; padding: 10px 10px;">Invalid Transit Pass & Other Condition</h2>

                    <div class="panel-body">
                        <button type="button" id="InvPass" style="border: none; background: none">
                            <span class="font-awsomecolor" style="font-size: 0.8em;">
                                <img style="width: 80px; height: 47px; margin-top: 0px; margin-left:155px"" src="../img/CheckpostIcons/invalid pass.svg"/>
                                </span>
                                </button>
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="panel panel-default" style="height: 120px; background-color: #26B798">
                    <h3 class="panel-title" style="color: white; padding: 10px 10px;">Transit Pass No</h3>
                    <div class="panel-body">
                            <div class="col-xs-9">
                                <input type="text" class="TextBoxAsLabel" style="height: 50px; width: 100%; border-bottom: 3px solid white; color: white" id="Transit_Pass_No" placeholder="Transit Pass No" autofocus="autofocus"/>
                            </div>
                            <div class="col-xs-3">
                                <button type="button" id="btnGet" style="border: none; background: none">
                                    <span class="font-awsomecolor" style="font-size: 0.8em;">
                                        <img style="width: 25px; height: 25px; margin-top: 20px" src="../img/CheckpostIcons/get.svg"/></span>
                                </button>
                            </div>
                    </div>
                </div>
            </div>

           </div>  
           <div class="container-fluid">
            <div class="row" id="ExQuantity" style="display: none">
                <div class="content-body pt-0">
                        <div class="row">
                            <div class="col-sm-12">
                                <div class="table-responsive" id="viewtable">
                                    <table id="datatable" class="table table-sm table-bordered">
                                        <thead>
                                            <tr>
                                                <th width="30"> Sl#</th>
                                                <th>
                                                   Type
                                                </th>
                                                <th>
                                                    Transit Pass No
                                                </th>
                                                <th>
                                                    Check Post Name
                                                </th>
                                                <th>
                                                    Check Time
                                                </th>
                                                <th>
                                                    PermitHolder
                                                </th>
                                                 <th>
                                                   NameOfMineral
                                                </th>
                                                 <th>
                                                    Gross Weight
                                                </th>
                                                <th>Check Post Weight</th>
                                                <th>Difference Weight</th>
                                                <th>Sale Valueof Mineral</th>
                                                <th>Date Of Dispatch</th>
                                                <th>Vehicle No</th>
                                                <th>Vehicle Type</th>
                                                <th>Transporter Name</th>
                                                <th>Driver Name</th>
                                                <th>Purchaser Name</th>
                                                <th>Destination</th>
                                                <th>Remark</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                         <tr>
                                              <td>1</td>
                                              <td>abc</td>
                                              <td>abc</td>
                                              <td>abc</td>
                                              <td>abc</td>
                                              <td>abc</td>  
                                               <td>abc</td>
                                              <td>abc</td>
                                              <td>abc</td>
                                              <td>abc</td>
                                              <td>abc</td>
                                              <td>abc</td> 
                                               <td>abc</td>
                                              <td>abc</td>
                                              <td>abc</td>
                                              <td>abc</td>
                                              <td>abc</td>
                                              <td>abc</td> 
                                               <td>abc</td>
                                              
                                            </tr>
                                            <tr>
                                                <td>2</td>
                                              <td>def</td>
                                             <td>def</td>
                                              <td>def</td>
                                             <td>def</td>
                                              <td>def</td>
                                            <td>def</td>
                                               <td>def</td>
                                             <td>def</td>
                                              <td>def</td>
                                             <td>def</td>
                                              <td>def</td>
                                            <td>def</td>
                                                <td>def</td>
                                             <td>def</td>
                                              <td>def</td>
                                             <td>def</td>
                                              <td>def</td>
                                            <td>def</td>
                                                
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
            </div>
            </div>
             <div class="container-fluid">
            <div class="col-xs-12" id="NPass" style="display: none;">                         
                        <div class="panel-heading" style="background-color: #F68C43; border: 2px; border-style: solid; border-color: lightgray;">
                            <h3 class="panel-title" style="color: white">Without Transit Pass Infomation</h3>
                        </div>
                        <div class="panel-body" style="border: 2px; border-style: solid; border-color: lightgray;">
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="col-md-5 default-form-control-style">
                                    <label for="inputName" class="col-sm-4 col-form-label">Name of Check Post <span class="text-danger">*</span></label>
                                    </div>
                                    <div class="col-md-2 default-form-control-style">
                                       <input type="text" class="form-control" />
                                    </div>
                                </div>
                                   <div class="col-md-5">
                                    <div class="col-md-5 default-form-control-style">
                                    <label for="inputName" class="col-sm-4 col-form-label">Current Weight <span class="text-danger">*</span></label>
                                    </div>
                                    <div class="col-md-2 default-form-control-style">
                                       <input type="text" class="form-control" />
                                    </div>
                                </div>
                               
                            </div>

                            <div class="row">
                                 <div class="col-md-6">
                                    <div class="col-md-6 default-form-control-style">
                                    <label for="inputName" class="col-sm-4 col-form-label">Lessee/License <span class="text-danger">*</span></label>
                                        <span class="text-danger">*</span>
                                    </div>
                                    <div class="col-md-1 default-form-control-style">
                                        <input type="text" class="form-control" />
                                    </div>
                                </div>
                                <div class="col-md-5">
                                    <div class="col-md-6 default-form-control-style">
                                    <label for="inputName" class="col-sm-4 col-form-label">License/Mining Area Details <span class="text-danger">*</span></label>
                                    </div>
                                    <div class="col-md-1 default-form-control-style">
                                       <input type="text" class="form-control" />
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                 <div class="col-md-6">
                                    <div class="col-md-6 default-form-control-style">
                                    <label for="inputName" class="col-sm-4 col-form-label">Name of Mineral <span class="text-danger">*</span></label>
                                        <span class="text-danger">*</span>
                                    </div>
                                    <div class="col-md-1 default-form-control-style">
                                        <input type="text" class="form-control" />
                                    </div>
                                </div>
                                <div class="col-md-5">
                                    <div class="col-md-6 default-form-control-style">
                                    <label for="inputName" class="col-sm-4 col-form-label">Date of Dispatch <span class="text-danger">*</span></label>
                                    </div>
                                    <div class="col-md-1 default-form-control-style">
                                      <asp:TextBox ID="TextBox1" CssClass="form-control datetime" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-6">
                                    <div class="col-md-5 default-form-control-style">
                                    <label for="inputName" class="col-sm-4 col-form-label">Unit <span class="text-danger">*</span></label>                                       
                                    </div>
                                    <div class="col-md-2 default-form-control-style">
                                       <input type="text" class="form-control" />
                                    </div>
                                </div>
                                <div class="col-md-5">
                                    <div class="col-md-6 default-form-control-style">
                                    <label for="inputName" class="col-sm-4 col-form-label">Previous Gross Weight <span class="text-danger">*</span></label>
                                    </div>
                                    <div class="col-md-1 default-form-control-style">
                                        <input type="text" class="form-control" />
                                    </div>
                                </div>
                            </div>
                      
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="col-md-5 default-form-control-style">
                                    <label for="inputName" class="col-sm-4 col-form-label">Vehicle No <span class="text-danger">*</span></label> 
                                    </div>
                                    <div class="col-md-2 default-form-control-style">
                                       <input type="text" class="form-control" />
                                    </div>
                                </div>
                                <div class="col-md-5">
                                    <div class="col-md-6 default-form-control-style">
                                    <label for="inputName" class="col-sm-4 col-form-label">Vehicle Type <span class="text-danger">*</span></label> 
                                    </div>
                                    <div class="col-md-1 default-form-control-style">
                                       <input type="text" class="form-control" />
                                    </div>
                                </div>
                            </div>


                            <div class="row">
                                <div class="col-md-6">
                                    <div class="col-md-5 default-form-control-style">
                                    <label for="inputName" class="col-sm-4 col-form-label">Vehicle Owner <span class="text-danger">*</span></label> 
                                    </div>
                                    <div class="col-md-2 default-form-control-style">
                                         <input type="text" class="form-control" />
                                    </div>
                                </div>
                                <div class="col-md-5">
                                    <div class="col-md-6 default-form-control-style">
                                    <label for="inputName" class="col-sm-4 col-form-label">Driver Name <span class="text-danger">*</span></label> 
                                    </div>
                                    <div class="col-md-1 default-form-control-style">
                                        <input type="text" class="form-control" />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                              <div class="col-md-6">
                                    <div class="col-md-6 default-form-control-style">
                                    <label for="inputName" class="col-sm-4 col-form-label">Mineral Destination <span class="text-danger">*</span></label> 
                                    </div>
                                    <div class="col-md-1 default-form-control-style">
                                       <input type="text" class="form-control" />
                                    </div>
                                </div>
                                <div class="col-md-5">
                                    <div class="col-md-5 default-form-control-style">
                                     <label for="inputName" class="col-sm-4 col-form-label">Purchaser/Consignee Name <span class="text-danger">*</span></label> 
                                    </div>
                                    <div class="col-md-2 default-form-control-style">
                                       <input type="text" class="form-control" />
                                    </div>
                                </div>
                               
                            </div>

                            <div class="row">
                                <div class="col-md-6">
                                    <div class="col-md-5 default-form-control-style">
                                     <label for="inputName" class="col-sm-4 col-form-label">Route <span class="text-danger">*</span></label> 
                                    </div>
                                    <div class="col-md-2 default-form-control-style">
                                        <input type="text" class="form-control" />
                                    </div>
                                </div>
                                <div class="col-md-5">
                                    <div class="col-md-6 default-form-control-style">
                                    <label for="inputName" class="col-sm-4 col-form-label">Other Details <span class="text-danger">*</span></label> 
                                    </div>
                                    <div class="col-md-1 default-form-control-style">
                                        <input type="text" class="form-control" />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="col-md-5 default-form-control-style">
                                     <label for="inputName" class="col-sm-4 col-form-label">Attachment/Bayan <span class="text-danger">*</span></label> 
                                    </div>
                                    <div class="col-md-2 default-form-control-style">
                                        <input type="file" id="myFile" name="filename">
                                    </div>
                                </div>
                               
                            </div>
                            <div class="row">
                                <div class="col-md-offset-5 col-md-7 col-xs-12">
                                    <input type="submit" value="Save" id="SaveManualTP" class="k-button k-button-icontext k-primary k-grid-update" style="width: 100px; background-color: #F68C43; color: white" />
                                    <input type="button" value="Cancel" id="CancelManualTP" class="k-button k-button-icontext k-primary k-grid-update" style="width: 100px; background-color: #F68C43; color: white" />
                                </div>
                            </div>
                        </div>                 
                        </div>
                        </div>
                          <div class="container-fluid">
                <div style="display: none" id="InValidPass" class="col-xs-12">
                        <div class="panel-heading" style="background-color: #F68C43; border: 2px; border-style: solid; border-color: lightgray;">
                            <h3 class="panel-title" style="color: white">Invalid Transit Pass & Other Condition Information</h3>
                        </div>
                        <div class="panel-body" style="border: 2px; border-style: solid; border-color: lightgray;">                         
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="col-md-3 default-form-control-style">
                                    <label for="inputName" class="col-sm-4 col-form-label">Name of Check Post <span class="text-danger">*</span></label>
                                    </div>
                                    <div class="col-md-3 default-form-control-style">
                                       <input type="text" class="form-control" />
                                    </div>
                                </div>
                                  <div class="col-md-5">
                                    <div class="col-md-5 default-form-control-style">
                                    <label for="inputName" class="col-sm-4 col-form-label">Transit Pass No <span class="text-danger">*</span></label>
                                    </div>
                                    <div class="col-md-2 default-form-control-style">
                                       <input type="text" class="form-control" />
                                    </div>
                                </div>
                             
                            </div>

                            <div class="row">
                               <div class="col-md-6">
                                    <div class="col-md-6 default-form-control-style">
                                    <label for="inputName" class="col-sm-4 col-form-label">Lessee/License Name <span class="text-danger">*</span></label>
                                        <span class="text-danger">*</span>
                                    </div>
                                    <div class="col-md-1 default-form-control-style">
                                        <input type="text" class="form-control" />
                                    </div>
                                </div>
                              
                                <div class="col-md-5">
                                    <div class="col-md-6 default-form-control-style">
                                    <label for="inputName" class="col-sm-4 col-form-label">License/Mining Area Details <span class="text-danger">*</span></label>
                                    </div>
                                    <div class="col-md-1 default-form-control-style">
                                       <input type="text" class="form-control" />
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                 <div class="col-md-6">
                                    <div class="col-md-5 default-form-control-style">
                                    <label for="inputName" class="col-sm-4 col-form-label">Name of Mineral <span class="text-danger">*</span></label>
                                    </div>
                                    <div class="col-md-2 default-form-control-style">
                                         <input type="text" class="form-control" />
                                    </div>
                                </div>
                                <div class="col-md-5">
                                    <div class="col-md-6 default-form-control-style">
                                    <label for="inputName" class="col-sm-4 col-form-label">Previous Gross Weight <span class="text-danger">*</span></label>
                                    </div>
                                    <div class="col-md-1 default-form-control-style">
                                        <input type="text" class="form-control" />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="col-md-5 default-form-control-style">
                                    <label for="inputName" class="col-sm-4 col-form-label">Current gross Weight <span class="text-danger">*</span></label>
                                        <span class="text-danger">*</span>
                                    </div>
                                    <div class="col-md-2 default-form-control-style">
                                       <input type="text" class="form-control" />
                                    </div>
                                </div>
                                <div class="col-md-5">
                                    <div class="col-md-6 default-form-control-style">
                                    <label for="inputName" class="col-sm-4 col-form-label">Difference Weight <span class="text-danger">*</span></label>                                     
                                    </div>
                                    <div class="col-md-1 default-form-control-style">
                                        <input type="text" class="form-control" />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="col-md-5 default-form-control-style">
                                    <label for="inputName" class="col-sm-4 col-form-label">Sale Value of Mineral <span class="text-danger">*</span></label> 
                                    </div>
                                    <div class="col-md-2 default-form-control-style">
                                        <input type="text" class="form-control" />
                                    </div>
                                </div>
                                <div class="col-md-5">
                                    <div class="col-md-6 default-form-control-style">
                                    <label for="inputName" class="col-sm-4 col-form-label">Date Of Mineral Dispatched <span class="text-danger">*</span></label> 
                                    </div>
                                    <div class="col-md-1 default-form-control-style">
                                    <asp:TextBox ID="txtMineraldispatched" CssClass="form-control datetime" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="col-md-5 default-form-control-style">
                                    <label for="inputName" class="col-sm-4 col-form-label">Vehicle No <span class="text-danger">*</span></label> 
                                    </div>
                                    <div class="col-md-2 default-form-control-style">
                                       <input type="text" class="form-control" />
                                    </div>
                                </div>
                                <div class="col-md-5">
                                    <div class="col-md-6 default-form-control-style">
                                    <label for="inputName" class="col-sm-4 col-form-label">Vehicle Type <span class="text-danger">*</span></label> 
                                    </div>
                                    <div class="col-md-1 default-form-control-style">
                                       <input type="text" class="form-control" />
                                    </div>
                                </div>
                            </div>


                            <div class="row">
                                <div class="col-md-6">
                                    <div class="col-md-5 default-form-control-style">
                                    <label for="inputName" class="col-sm-4 col-form-label">Vehicle Owner <span class="text-danger">*</span></label> 
                                    </div>
                                    <div class="col-md-2 default-form-control-style">
                                         <input type="text" class="form-control" />
                                    </div>
                                </div>
                                <div class="col-md-5">
                                    <div class="col-md-6 default-form-control-style">
                                    <label for="inputName" class="col-sm-4 col-form-label">Driver Name <span class="text-danger">*</span></label> 
                                    </div>
                                    <div class="col-md-1 default-form-control-style">
                                        <input type="text" class="form-control" />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="col-md-5 default-form-control-style">
                                     <label for="inputName" class="col-sm-4 col-form-label">Purchaser/Consignee Name <span class="text-danger">*</span></label> 
                                    </div>
                                    <div class="col-md-2 default-form-control-style">
                                       <input type="text" class="form-control" />
                                    </div>
                                </div>
                                <div class="col-md-5">
                                    <div class="col-md-6 default-form-control-style">
                                        <label for="inputName" class="col-sm-4 col-form-label">DO Number (If Applicable) <span class="text-danger">*</span></label> 
                                    </div>
                                    <div class="col-md-1 default-form-control-style">
                                       <input type="text" class="form-control" />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="col-md-5 default-form-control-style">
                                        <label for="inputName" class="col-sm-4 col-form-label">DO Date (If Applicable) <span class="text-danger">*</span></label> 
                                    </div>
                                    <div class="col-md-2 default-form-control-style">
                                      <asp:TextBox ID="txtDOD" CssClass="form-control datetime" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-5">
                                    <div class="col-md-6 default-form-control-style">
                                    <label for="inputName" class="col-sm-4 col-form-label">Mineral Destination <span class="text-danger">*</span></label> 
                                    </div>
                                    <div class="col-md-1 default-form-control-style">
                                       <input type="text" class="form-control" />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="col-md-5 default-form-control-style">
                                     <label for="inputName" class="col-sm-4 col-form-label">Route <span class="text-danger">*</span></label> 
                                    </div>
                                    <div class="col-md-2 default-form-control-style">
                                        <input type="text" class="form-control" />
                                    </div>
                                </div>
                                <div class="col-md-5">
                                    <div class="col-md-6 default-form-control-style">
                                    <label for="inputName" class="col-sm-4 col-form-label">Other Details <span class="text-danger">*</span></label> 
                                    </div>
                                    <div class="col-md-1 default-form-control-style">
                                        <input type="text" class="form-control" />
                                    </div>
                                </div>
                            </div>
                             <div class="row">
                                <div class="col-md-6">
                                    <div class="col-md-5 default-form-control-style">
                                     <label for="inputName" class="col-sm-4 col-form-label">Attachment/Bayan </label> 
                                     <input type="file" class="form-control" />
                                    </div>
                               
                                </div>
                              
                            </div>
                            <div class="row">
                                <div class="col-md-offset-5 col-md-7 col-xs-12">
                                    <input type="submit" value="Save" id="Submit1" class="k-button k-button-icontext k-primary k-grid-update" style="width: 100px; background-color: #F68C43; color: white" />
                                    <input type="button" value="Cancel" id="Button1" class="k-button k-button-icontext k-primary k-grid-update" style="width: 100px; background-color: #F68C43; color: white" />
                                </div>
                            </div>
                        </div>
                    </div>
            </div>
          </section>
            <uc1:footer runat="server" ID="footer" />
        </div>
        <!-- END CONTENT -->
    </div>
    <!-- END CONTAINER -->
    </form>
    <link rel="stylesheet" href="../css/searchable-select.min.css">
    <script src="../js/jquery.min.js"></script>
    <script src="../js/searchable-select.min.js"></script>
    <link rel="stylesheet" href="../css/dataTables.bootstrap4.min.css">
    <script src="../js/jquery.dataTables.min.js"></script>
    <script src="../js/dataTables.bootstrap4.min.js"></script>
    <script src="../js/moment.min.js"></script>
    <script src="../js/bootstrap-datetimepicker.min.js"></script>
    <script>
        excelMe = "yes"
        pdfMe = "yes"
        printMe = "yes"
        $(document).ready(function () {
            loadNavigation('IrregularityCases', 'glTMng', 'plmineral', 'tl', 'Checkpost', 'Case of Irregularity', '');

            $('.searchableselect').searchableselect();

            $('#datatable').DataTable();

            $('.shorting-lnk').click(function () {
                $('.shorting-lnk i').toggleClass('fa-sort-amount-up-alt fa-sort-amount-down-alt ');
            });
            $('.filter-dropdown').hide();
            $('.filter-lnk').click(function () {
                $(this).toggleClass('active');
                $(this).siblings('.filter-dropdown').slideToggle();
            });
            $('.filter-btn').click(function () {
                $(this).parent('.shorting-cell .filter-dropdown').slideUp();
                if ($(this).parent().parent('.shorting-cell').find('.filter-lnk').hasClass('active')) {
                    $(this).parent().siblings('.filter-lnk').removeClass('active');
                }

            });
            $('#TransitPassNo').keydown(function (e) {
                if (e.keyCode == 13) {
                    $('#btnGet').trigger('click');
                    e.preventDefault();
                }
            });
        });
        $("#ExCount").click(function () {
            $("#NPass").hide();
            $("#InValidPass").hide();

            $("#EpassInfo").hide();
            $("#EpassInfoRPTP").hide();
            $("#EpassInfoLTP").hide();
            $("#ExQuantity").show();
            $("#LabGrid").height(400);
        });
        $("#NoPass").click(function () {

            $("#EpassInfo").hide();
            $("#NPass").hide();
            $("#InValidPass").hide();
            $("#ExQuantity").hide();
            $("#NPass").show();
            $("#CaseIrregularity_Id4").val(2);

        });
        $("#InvPass").click(function () {

            $("#EpassInfo").hide();
            $("#NPass").hide();
            $("#InValidPass").hide();
            $("#ExQuantity").hide();
            $("#InValidPass").show();
        });
        $('.datetime').datetimepicker({
            format: "DD/MM/YYYY"
        });
    </script>
</body>
</html>
