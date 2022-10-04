<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserRegistration.aspx.cs" Inherits="UserRegistration" %>
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
                        <li class="breadcrumb-item text-white" aria-current="page">User Registration</li>
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
                <div class="text-dark">
                <span class="text-danger float-right">(*) indicates mandatory</span>
                <div class="clearfix"></div>
                <h4 class="text-dark font-weight-bold my-4 text-uppercase">User Registration</h4>
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
                                                <label class="col-sm-5 col-form-label font-weight-bolder">Industry Type<span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                   <select class="form-control form-control-sm searchableselect">
                                                          <option>Select Industry Type</option>
                                                          <option>Alumina Plant</option>
                                                          <option>Cement plant</option>
                                                          <option>Others</option>
                                                      </select>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label for="dropdownDepart" class="col-sm-5 col-form-label font-weight-bolder">Other<span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                   <input type="text" class="form-control">                                                    
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label for="inputName" class="col-sm-5 col-form-label font-weight-bolder">User Type<span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                    <div class="py-2">
                                                      <div class="custom-control custom-radio custom-control-inline">
                                                        <input type="radio" class="custom-control-input" id="radio1" name="radio-iRequirement" value="1">
                                                        <label class="custom-control-label" for="radio1">Individual/Proprietor</label>
                                                      </div>
                                                      <div class="custom-control custom-radio custom-control-inline">
                                                        <input type="radio" class="custom-control-input" id="radio2" name="radio-iRequirement" value="2">
                                                        <label class="custom-control-label" for="radio2">Firm</label>
                                                      </div>
                                                       <div class="custom-control custom-radio custom-control-inline">
                                                        <input type="radio" class="custom-control-input" id="radio3" name="radio-iRequirement" value="2">
                                                        <label class="custom-control-label" for="radio3">Association</label>
                                                      </div>
                                                       <div class="custom-control custom-radio custom-control-inline">
                                                        <input type="radio" class="custom-control-input" id="radio4" name="radio-iRequirement" value="2">
                                                        <label class="custom-control-label" for="radio4">Company</label>
                                                      </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label for="inputName" class="col-sm-5 col-form-label font-weight-bolder">Firm as<span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                    <div class="py-2">
                                                      <div class="custom-control custom-radio custom-control-inline">
                                                        <input type="radio" class="custom-control-input" id="radiop" name="radio-iRequirement" value="1">
                                                        <label class="custom-control-label" for="radiop">Partnership</label>
                                                      </div>
                                                      <div class="custom-control custom-radio custom-control-inline">
                                                        <input type="radio" class="custom-control-input" id="radiopro" name="radio-iRequirement" value="2">
                                                        <label class="custom-control-label" for="radiopro">Proprietary</label>
                                                      </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label for="inputName" class="col-sm-5 col-form-label font-weight-bolder">Company as<span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                    <div class="py-2">
                                                      <div class="custom-control custom-radio custom-control-inline">
                                                        <input type="radio" class="custom-control-input" id="radio1a" name="radio-iRequirement" value="1">
                                                        <label class="custom-control-label" for="radio1a">Private</label>
                                                      </div>
                                                      <div class="custom-control custom-radio custom-control-inline">
                                                        <input type="radio" class="custom-control-input" id="radio1b" name="radio-iRequirement" value="2">
                                                        <label class="custom-control-label" for="radio1b">Public Limited</label>
                                                      </div>
                                                      <div class="custom-control custom-radio custom-control-inline">
                                                        <input type="radio" class="custom-control-input" id="radio1c" name="radio-iRequirement" value="2">
                                                        <label class="custom-control-label" for="radio1c">PSU</label>
                                                      </div>
                                                      <div class="custom-control custom-radio custom-control-inline">
                                                        <input type="radio" class="custom-control-input" id="radio1d" name="radio-iRequirement" value="2">
                                                        <label class="custom-control-label" for="radio1d">Joint Venture</label>
                                                      </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label for="dropdownUserType" class="col-sm-5 col-form-label font-weight-bolder">Applicant's Name<span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                    <input type="text" class="form-control">
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label for="dropdownDepart" class="col-sm-5 col-form-label font-weight-bolder">E-mail ID<span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                   <input type="text" class="form-control">                                                    
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label for="dropdownDesign" class="col-sm-5 col-form-label font-weight-bolder">Mobile Number<span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                     <input type="text" class="form-control">                                                    
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label for="inputPassword" class="col-sm-5 col-form-label font-weight-bolder">Designation<span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                    <input type="text" class="form-control">
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label for="dropdownState" class="col-sm-5 col-form-label font-weight-bolder">Mineral Name <span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                            <select multiple data-style="bg-white" class="selectpicker form-control" >
                                                <option>Industry</option>
                                                <option>Gold</option>
                                              </select>                                                   
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label for="dropdownDist" class="col-sm-5 col-form-label font-weight-bolder">Mineral Form <span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                    <select multiple data-style="bg-white" class="selectpicker form-control" >
                                                <option>Industry</option>
                                                <option>Gold</option>
                                              </select>                                                   
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label for="inputMobile" class="col-sm-5 col-form-label font-weight-bolder"> Mineral Grade <span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                       <select multiple data-style="bg-white" class="selectpicker form-control" >
                                                <option>Industry</option>
                                                <option>Gold</option>
                                              </select>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label for="inputMail" class="col-sm-5 col-form-label font-weight-bolder"> Purpose <span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                    <select class="form-control form-control-sm searchableselect">
                                                          <option>Select</option>
                                                      </select>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label for="inputMail" class="col-sm-5 col-form-label font-weight-bolder">Aadhaar Card Number <span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                    <input type="text" class="form-control" >
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label for="inputMail" class="col-sm-5 col-form-label font-weight-bolder"> Upload Aadhaar Card <span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                    <div class="custom-file">
                                                        <input type="file" class="custom-file-input" id="customFile" name="filename">
                                                        <label class="custom-file-label" for="customFile">Choose Files</label>
                                                    </div>
                                                     <small class="text-danger">Only <strong> jpg, jpeg, png, pdf, tif</strong> file types with size less than <strong>2 MB </strong> are allowed.</small>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label for="inputMail" class="col-sm-5 col-form-label font-weight-bolder">PAN Card Number<span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                    <input type="text" class="form-control" >
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label for="inputMail" class="col-sm-5 col-form-label font-weight-bolder">Upload PAN Card<span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                    <div class="custom-file">
                                                        <input type="file" class="custom-file-input" id="File1" name="filename">
                                                        <label class="custom-file-label" for="customFile">Choose Files</label>
                                                    </div>
                                                    <small class="text-danger">Only <strong> jpg, jpeg, png, pdf, tif</strong> file types with size less than <strong>2 MB </strong> are allowed.</small>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label for="inputMail" class="col-sm-5 col-form-label font-weight-bolder">Tin Number<span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                    <input type="text" class="form-control" >
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label for="inputMail" class="col-sm-5 col-form-label font-weight-bolder">Upload Document for Tin<span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                    <div class="custom-file">
                                                        <input type="file" class="custom-file-input" id="File2" name="filename">
                                                        <label class="custom-file-label" for="customFile">Choose Files</label>
                                                    </div>
                                                    <small class="text-danger">Only <strong> jpg, jpeg, png, pdf, tif</strong> file types with size less than <strong>2 MB </strong> are allowed.</small>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label for="inputMail" class="col-sm-5 col-form-label font-weight-bolder">GST Number<span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                    <input type="text" class="form-control" >
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label for="inputMail" class="col-sm-5 col-form-label font-weight-bolder">Upload Document for GST<span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                    <div class="custom-file">
                                                        <input type="file" class="custom-file-input" id="File3" name="filename">
                                                        <label class="custom-file-label" for="customFile">Choose Files</label>
                                                    </div>
                                                    <small class="text-danger">Only <strong> jpg, jpeg, png, pdf, tif</strong> file types with size less than <strong>2 MB </strong> are allowed.</small>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label for="inputMail" class="col-sm-5 col-form-label font-weight-bolder">Electricity Bill of last 3 months<span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                    <div class="custom-file">
                                                        <input type="file" class="custom-file-input" id="File4" name="filename">
                                                        <label class="custom-file-label" for="customFile">Choose Files</label>
                                                    </div>
                                                   <small class="text-danger">Only <strong> jpg, jpeg, png, pdf, tif</strong> file types with size less than <strong>2 MB </strong> are allowed.</small>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label for="inputMail" class="col-sm-5 col-form-label font-weight-bolder">CTO (Consent To Operate) Letter<span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                    <div class="custom-file">
                                                        <input type="file" class="custom-file-input" id="File5" name="filename">
                                                        <label class="custom-file-label" for="customFile">Choose Files</label>
                                                    </div>
                                                   <small class="text-danger">Only <strong> jpg, jpeg, png, pdf, tif</strong> file types with size less than <strong>2 MB </strong> are allowed.</small>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label for="inputMail" class="col-sm-5 col-form-label font-weight-bolder">CTO Approval Number<span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                    <input type="text" class="form-control">
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label for="inputMail" class="col-sm-5 col-form-label font-weight-bolder">CTO Order Date<span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                    <div class="input-group">
                                                      <input type="text" class="form-control datepicker" id="inputDate1">
                                                      <div class="input-group-prepend">
                                                        <label class="input-group-text" for="inputDate1"><i class="far fa-calendar"></i></label>
                                                      </div>
                                                 </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label for="inputMail" class="col-sm-5 col-form-label font-weight-bolder">CTO Validity From<span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                   <div class="input-group">
                                                      <input type="text" class="form-control datepicker" id="inputDate2">
                                                      <div class="input-group-prepend">
                                                        <label class="input-group-text" for="inputDate2"><i class="far fa-calendar"></i></label>
                                                      </div>
                                                 </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label for="inputMail" class="col-sm-5 col-form-label font-weight-bolder">CTO Validity To<span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                   <div class="input-group">
                                                      <input type="text" class="form-control datepicker" id="inputDate3">
                                                      <div class="input-group-prepend">
                                                        <label class="input-group-text" for="inputDate3"><i class="far fa-calendar"></i></label>
                                                      </div>
                                                 </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label for="inputMail" class="col-sm-5 col-form-label font-weight-bolder">IBM Registration No.<span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                   <input type="text" class="form-control">
                                                </div>
                                            </div>
                                        </div>
                                     </div>

                                     <h4 class="text-dark font-weight-bold   my-4 text-uppercase">Industry Details</h4>
                                     <div class="row">
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label for="inputMail" class="col-sm-5 col-form-label font-weight-bolder">Address<span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                   <textarea class="form-control" rows="1"></textarea>
                                                   <small class="text-danger">Maximum <strong>500</strong> characters</small>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label for="inputMail" class="col-sm-5 col-form-label font-weight-bolder">State<span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                   <select class="form-control form-control-sm searchableselect">
                                                          <option>select</option>
                                                      </select>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label for="inputMail" class="col-sm-5 col-form-label font-weight-bolder">District<span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                   <select class="form-control form-control-sm searchableselect">
                                                          <option>select</option>
                                                          <option>option1</option>   
                                                      </select>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label for="inputMail" class="col-sm-5 col-form-label font-weight-bolder">Pincode<span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                   <input type="text" class="form-control">
                                                </div>
                                            </div>
                                        </div>
                                     </div>
                                        
                                    <h4 class="text-dark font-weight-bold   my-4 text-uppercase">Office Details</h4>
                                    <div class="row">
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label for="inputMail" class="col-sm-5 col-form-label font-weight-bolder">Address<span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                   <textarea class="form-control" rows="1"></textarea>
                                                   <small class="text-danger">Maximum <strong>500</strong> characters</small>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label for="inputMail" class="col-sm-5 col-form-label font-weight-bolder">State<span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                   <select class="form-control form-control-sm searchableselect">
                                                          <option>select</option>
                                                      </select>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label for="inputMail" class="col-sm-5 col-form-label font-weight-bolder">District<span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                   <select class="form-control form-control-sm searchableselect">
                                                          <option>select</option>
                                                      </select>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label for="inputMail" class="col-sm-5 col-form-label font-weight-bolder">Pincode<span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                   <input type="text" class="form-control">
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label for="inputMail" class="col-sm-5 col-form-label font-weight-bolder">Security Question<span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                   <select class="form-control">
                                                          <option>select</option>
                                                      </select>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label for="inputMail" class="col-sm-5 col-form-label font-weight-bolder">Answer<span class="text-danger">*</span></label>
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
                                                        <label class="input-group-text" for="inputDate1"> <a href="#"><i class="fas fa-sync-alt"></i></a> </label>
                                                      </div>
                                                 </div>
                                                 </div>
                                           
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                            <div class="form-group row">
                                                <label for="inputMail" class="col-sm-5 col-form-label font-weight-bolder">Enter OTP<span class="text-danger">*</span></label>
                                                <div class="col-sm-7">
                                                    <input type="text" class="form-control">
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-md-12 col-sm-12">
                                                <a href="javascript:void(0);" class="btn btn-primary btn-md ml-0 waves-effect waves-light rounded-0">Send OTP</a>
                                               
                                            </div>
                                        <div class="col-sm-12">
                                            <div class="form-group row">
                                                <div class="custom-control custom-checkbox  mt-2">
                                                         <input type="checkbox" class="custom-control-input" id="customCheck1">
                                                         <label class="custom-control-label" for="customCheck1">
                                                         Declaration - I declare that all the information given above is true as per my knowledge and belief.
                                                         I am aware that if any of the above information is found to be false or untrue, there may be penalty / penalty under the appropriate rules.
The Mineral                                              Resources Department will not be responsible for authenticating any of the above information.</label>
                                                </div>
                                                
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
            $('.userregistration').addClass('active');
        }) 
    </script>   
</body>
</html>

