<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ApplicationStatusCheck.aspx.cs" Inherits="ApplicationStatusCheck" %>
<%@ Register Src="~/includes/logindoctype.ascx" TagPrefix="uc1" TagName="logindoctype" %>
<%@ Register Src="~/includes/loginheader.ascx" TagPrefix="uc1" TagName="loginheader" %>
<%@ Register Src="~/includes/loginfooter.ascx" TagPrefix="uc1" TagName="loginfooter" %>

<uc1:logindoctype runat="server" ID="logindoctype" />
</head>
<div class="inner-naviagtion">
    <div class="container">
        <div class="pt-lg-5 pt-md-4 pt-3">
            <nav aria-label="breadcrumb mb-0">
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item"><a href="default.aspx" class="text-white"><span class="fas fa-home"></span></a></li>
                        <li class="breadcrumb-item text-white" aria-current="page">User &amp; Vehicle Owner</li>
                        <li class="breadcrumb-item text-white" aria-current="page">Application Status Check</li>
                    </ol>
             </nav>
        </div>
    </div>
</div>
<body class="landing-screen">
<form id="form1" runat="server">
    <uc1:loginheader runat="server" ID="loginheader" />
            <div class="main-content py-3 login-content">
                <div class="container">
                <div class="text-dark ">
                <span class="text-danger float-right">(*) indicates mandatory</span>
                <div class="clearfix"></div>
                <h4 class="text-dark font-weight-bold my-4 text-uppercase">Application Status Check </h4>
                    
                    
                    <div class="row">
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label class="col-sm-5 col-form-label font-weight-bolder">Registration Type<span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                   <select class="form-control form-control-sm searchableselect">
                                                          <option>Select Registration Type</option>
                                                          <option>Industry</option>
                                                          <option>Trader Outside Chhattisgarh</option>
                                                          <option>Storage Depot Outside Chhattisgarh</option>
                                                      </select>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label for="inputMail" class="col-sm-5 col-form-label font-weight-bolder">Registration Number <span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                    <input type="text" class="form-control">
                                                </div>
                                            </div>
                                        </div>
                                       
                                      
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label for="inputMail" class="col-sm-5 col-form-label font-weight-bolder">Enter Captcha<span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                    <input type="text" class="form-control">
                                                </div>
                                            </div>
                                        </div>

                                         <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                            <div class="col-sm-4">
                                               <div class="input-group">
                                                        <img id="Img1" alt="Captcha" class="form-control" src="img/captcha.png">
                                                      <div class="input-group-prepend">
                                                        <label class="input-group-text" for="inputDate1"> <a href="#"><i class="fas fa-sync-alt"></i></a> </label>
                                                      </div>
                                                 </div>
                                              </div>
                                                
                                            </div>
                                        </div>

                                         <div class="col-sm-3 form-group">
                                                <a href="javascript:void(0);" class="btn btn-primary btn-md ml-0 waves-effect waves-light rounded-0">Check status</a>
                                          </div>
                                        
                                        
                                         
                                       <div class="row">
                                        <div class="col-sm-12">
                                            <ul class="mb-0 pl-4">
                                            <li><strong>Note : Select appropriate registration type to know the status of your application.</strong></li>
                                                <li><strong>Tailing Dam :</strong> Enter your Tailing Dam / Ashdyke / Mud pond Registration Number to know your Application Status for Tailing Dam / Ashdyke / Mud pond Registration.</li>
                                                <li><strong>User :</strong> Enter your User Registration Number to know your Application Status for User Registration.</li>
                                            </ul>
                                        </div>
                                       </div>

                                       
                                       
                                           
                                        </div>
                   
                 </div>
                </div>
            </div>
            <uc1:loginfooter runat="server" ID="loginfooter" />   
    </form>
     <style type="text/css">
        .main-content {background-image: none;}
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            $('.applicationstatchech').addClass('active');
        }) 
    </script> 
</body>
</html>

