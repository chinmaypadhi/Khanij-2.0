﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LicenseApplication.aspx.cs" Inherits="LicenseApplication" %>
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
                        <li class="breadcrumb-item text-white" aria-current="page">New Application</li>
                        <li class="breadcrumb-item text-white" aria-current="page">License Application</li>
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
                <h4 class="text-dark font-weight-bold my-4 text-uppercase">Application Details</h4>
                <div class="row">      
                  <div class="col-lg-6 col-md-12 col-sm-12">
                        <div class="form-group row">
                            <label class="col-sm-5 col-form-label font-weight-bolder">Application For District<span class="text-danger">*</span></label>
                            <div class="col-sm-7">
                                <select class="form-control form-control-sm searchableselect">
                                        <option>Select District</option>
                                        <option>Industry</option>
                                        <option>Trader Outside Chhattisgarh</option>
                                        <option>Storage Depot Outside Chhattisgarh</option>
                                    </select>
                            </div>
                        </div>
                  </div> 
                  <div class="col-lg-6 col-md-12 col-sm-12">
                        <div class="form-group row">
                            <label class="col-sm-5 col-form-label font-weight-bolder">License Type<span class="text-danger">*</span></label>
                            <div class="col-sm-7">
                                <select class="form-control form-control-sm searchableselect">
                                        <option>Select District</option>
                                        <option>Industry</option>
                                        <option>Trader Outside Chhattisgarh</option>
                                        <option>Storage Depot Outside Chhattisgarh</option>
                                    </select>
                            </div>
                        </div>
                  </div> 
                  <div class="col-lg-6 col-md-12 col-sm-12">
                        <div class="form-group row">
                            <label class="col-sm-5 col-form-label font-weight-bolder">Mineral Type<span class="text-danger">*</span></label>
                            <div class="col-sm-7">
                                <select class="form-control form-control-sm searchableselect">
                                        <option>Select District</option>
                                        <option>Industry</option>
                                        <option>Trader Outside Chhattisgarh</option>
                                        <option>Storage Depot Outside Chhattisgarh</option>
                                    </select>
                            </div>
                        </div>
                  </div>
                  <div class="col-lg-6 col-md-12 col-sm-12">
                        <div class="form-group row">
                            <label for="dropdownState"   class="col-sm-5 col-form-label font-weight-bolder">Mineral Name <span class="text-danger">*</span></label>
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
                        <label for="dropdownState"   class=" col-sm-5 col-form-label font-weight-bolder">Mineral Form <span class="text-danger">*</span></label>
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
                        <label for="dropdownState"   class=" col-sm-5 col-form-label font-weight-bolder">Mineral Grade  <span class="text-danger">*</span></label>
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
                            <label class="col-sm-5 col-form-label font-weight-bolder">Application For<span class="text-danger">*</span></label>
                            <div class="col-sm-7">
                                <select class="form-control form-control-sm searchableselect">
                                        <option>Select District</option>
                                        <option>Industry</option>
                                        <option>Trader Outside Chhattisgarh</option>
                                        <option>Storage Depot Outside Chhattisgarh</option>
                                    </select>
                            </div>
                        </div>
                  </div>
                  <div class="col-lg-6 col-md-12 col-sm-12">
                  <div class="form-group row">
                        <label for="dropdownDepart" class="col-sm-5 col-form-label font-weight-bolder">Period<span class="text-danger">*</span></label>
                        <div class="col-sm-7">
                            <input type="text" class="form-control">                                                    
                        </div>
                  </div>
                  </div>
                  <div class="col-lg-6 col-md-12 col-sm-12">
                   <div class="form-group row">
                        <label for="dropdownDepart" class="col-sm-5 col-form-label font-weight-bolder">Place<span class="text-danger">*</span></label>
                        <div class="col-sm-7">
                            <input type="text" class="form-control">                                                    
                        </div>
                  </div>
                  </div>
                  </div>
                 
                  <h4 class="text-dark font-weight-bold my-4  text-uppercase">Applicant Details & Documents</h4>

                  <div class="row"> 
                  <div class="col-lg-6 col-md-12 col-sm-12">
                   <div class="form-group row">
                        <label for="dropdownDepart" class="col-sm-5 col-form-label font-weight-bolder">Name of Applicant<span class="text-danger">*</span></label>
                        <div class="col-sm-7">
                            <input type="text" class="form-control">                                                    
                        </div>
                  </div>
                  </div>
                  <div class="col-lg-6 col-md-12 col-sm-12">
                   <div class="form-group row">
                        <label for="dropdownDepart" class="col-sm-5 col-form-label font-weight-bolder">Mobile Number<span class="text-danger">*</span></label>
                        <div class="col-sm-7">
                            <input type="text" class="form-control">                                                    
                        </div>
                  </div>
                  </div>
                  <div class="col-lg-6 col-md-12 col-sm-12">
                   <div class="form-group row">
                        <label for="dropdownDepart" class="col-sm-5 col-form-label font-weight-bolder">Email Address<span class="text-danger">*</span></label>
                        <div class="col-sm-7">
                            <input type="text" class="form-control">                                                    
                        </div>
                  </div>
                  </div>
                  <div class="col-lg-6 col-md-12 col-sm-12">
                   <div class="form-group row">
                        <label for="dropdownDepart" class="col-sm-5 col-form-label font-weight-bolder">Complete Address<span class="text-danger">*</span></label>
                        <div class="col-sm-7">
                           <textarea class="form-control" rows="1"></textarea>
                                                   <small class="text-danger">Maximum <strong>500</strong> characters</small>                                                  
                        </div>
                  </div>
                  </div>
                  <div class="col-lg-6 col-md-12 col-sm-12">
                        <div class="form-group row">
                            <label class="col-sm-5 col-form-label font-weight-bolder">District<span class="text-danger">*</span></label>
                            <div class="col-sm-7">
                                <select class="form-control form-control-sm searchableselect">
                                        <option>Select District</option>
                                        <option></option>
                                        <option></option>
                                        <option></option>
                                    </select>
                            </div>
                        </div>
                  </div>
                  <div class="col-lg-6 col-md-12 col-sm-12">
                        <div class="form-group row">
                            <label class="col-sm-5 col-form-label font-weight-bolder">Tehsil<span class="text-danger">*</span></label>
                            <div class="col-sm-7">
                                <select class="form-control form-control-sm searchableselect">
                                        <option>Select Tehsil</option>
                                        <option></option>
                                        <option></option>
                                        <option></option>
                                    </select>
                            </div>
                        </div>
                  </div>
                  <div class="col-lg-6 col-md-12 col-sm-12">
                        <div class="form-group row">
                            <label class="col-sm-5 col-form-label font-weight-bolder">Village<span class="text-danger">*</span></label>
                            <div class="col-sm-7">
                                <select class="form-control form-control-sm searchableselect">
                                        <option>Select Village</option>
                                        <option></option>
                                        <option></option>
                                        <option></option>
                                    </select>
                            </div>
                        </div>
                  </div>
                  <div class="col-lg-6 col-md-12 col-sm-12">
                        <div class="form-group row">
                            <label class="col-sm-5 col-form-label font-weight-bolder">Applicant is<span class="text-danger">*</span></label>
                            <div class="col-sm-7">
                                <select class="form-control form-control-sm searchableselect">
                                        <option>Select</option>
                                        <option></option>
                                        <option></option>
                                        <option></option>
                                    </select>
                            </div>
                        </div>
                  </div>
                  <div class="col-lg-6 col-md-12 col-sm-12">
                        <div class="form-group row">
                            <label class="col-sm-5 col-form-label font-weight-bolder">Profession or nature of business<span class="text-danger">*</span></label>
                            <div class="col-sm-7">
                               <input type="text" class="form-control">
                            </div>
                        </div>
                  </div>
                  <div class="col-lg-6 col-md-12 col-sm-12">
                        <div class="form-group row">
                            <label class="col-sm-5 col-form-label font-weight-bolder">Police Station<span class="text-danger">*</span></label>
                            <div class="col-sm-7">
                                <input type="text" class="form-control">
                            </div>
                        </div>
                  </div>
                  <div class="col-lg-6 col-md-12 col-sm-12">
                        <div class="form-group row">
                            <label class="col-sm-5 col-form-label font-weight-bolder">Panchayat<span class="text-danger">*</span></label>
                            <div class="col-sm-7">
                                <input type="text" class="form-control">
                            </div>
                        </div>
                  </div>
                  <div class="col-lg-6 col-md-12 col-sm-12"></div>
                  <div class="col-lg-6 col-md-12 col-sm-12">
                        <div class="form-group">
                            <label class="col-form-label font-weight-bolder">1. If your company is not in the list please concern with your District office and add your company,then only you will be able to apply for the license application<span class="text-danger">*</span></label>
                            
                                <select class="form-control">
                                        <option>Select company</option>
                                        <option></option>
                                        <option></option>
                                        <option></option>
                                    </select>
                                   

                           
                        </div>
                  </div>
                  <div class="col-lg-6 col-md-12 col-sm-12">
                        <div class="form-group">
                            <label class=" col-form-label font-weight-bolder">2. No Mining Due Certificate <span class="text-danger">*</span></label>                   
                                 <div class="custom-file">
                                   <input type="file" class="custom-file-input" id="File5" name="filename">
                                   <label class="custom-file-label" for="customFile">Choose Files</label>
                              <small class="text-danger">Only <strong> jpg, jpeg, png, pdf, tif</strong> file types with size less than <strong>2 MB </strong> are allowed.</small>
                           
                        </div>
                  </div>
                 </div>
                  <div class="col-lg-6 col-md-12 col-sm-12">
                        <div class="form-group">
                            <label class=" col-form-label font-weight-bolder">3. If on the date of application,the applicant does not hold any mineral concession/license in the state furnish an affadavit for the same<span class="text-danger">*</span></label>                   
                                 <div class="custom-file">
                                   <input type="file" class="custom-file-input" id="File1" name="filename">
                                   <label class="custom-file-label" for="customFile">Choose Files</label>
                              <small class="text-danger">Only <strong> jpg, jpeg, png, pdf, tif</strong> file types with size less than <strong>2 MB </strong> are allowed.</small>
                           
                        </div>
                  </div>
                                     
                 </div>
                  <div class="col-lg-6 col-md-12 col-sm-12">
                        <div class="form-group">
                            <label class=" col-form-label font-weight-bolder">4. Mineral/Ore or its product for which the applicant intend to hold a permit<span class="text-danger">*</span></label>                   
                                 <div class="custom-file">
                                   <input type="file" class="custom-file-input" id="File2" name="filename">
                                   <label class="custom-file-label" for="customFile">Choose Files</label>
                              <small class="text-danger">Only <strong> jpg, jpeg, png, pdf, tif</strong> file types with size less than <strong>2 MB </strong> are allowed.</small>
                           
                        </div>
                  </div>
                                     
                 </div>
                  <div class="col-lg-6 col-md-12 col-sm-12">
                        <div class="form-group">
                            <label class=" col-form-label font-weight-bolder">5. Affidavit showing the mineral concession/licenses held or being held by other person/persons jointly with the applicant<span class="text-danger">*</span></label>                   
                                 <div class="custom-file">
                                   <input type="file" class="custom-file-input" id="File3" name="filename">
                                   <label class="custom-file-label" for="customFile">Choose Files</label>
                              <small class="text-danger">Only <strong> jpg, jpeg, png, pdf, tif</strong> file types with size less than <strong>2 MB </strong> are allowed.</small>
                           
                        </div>
                  </div>
                                     
                 </div>
                  <div class="col-lg-6 col-md-12 col-sm-12">
                        <div class="form-group">
                            <label class=" col-form-label font-weight-bolder">5.1. Certified copy of the map<span class="text-danger">*</span></label>                   
                                 <div class="custom-file">
                                   <input type="file" class="custom-file-input" id="File4" name="filename">
                                   <label class="custom-file-label" for="customFile">Choose Files</label>
                              <small class="text-danger">Only <strong> jpg, jpeg, png, pdf, tif</strong> file types with size less than <strong>2 MB </strong> are allowed.</small>
                           
                        </div>
                  </div>
                                     
                 </div>
                  <div class="col-lg-6 col-md-12 col-sm-12">
                        <div class="form-group">
                            <label class=" col-form-label font-weight-bolder">5.2. Latest revenue record of the land intended to be used for storing mineral or its products<span class="text-danger">*</span></label>                   
                                 <div class="custom-file">
                                   <input type="file" class="custom-file-input" id="File6" name="filename">
                                   <label class="custom-file-label" for="customFile">Choose Files</label>
                              <small class="text-danger">Only <strong> jpg, jpeg, png, pdf, tif</strong> file types with size less than <strong>2 MB </strong> are allowed.</small>
                           
                        </div>
                  </div>
                                     
                 </div>
                  <div class="col-lg-6 col-md-12 col-sm-12">
                        <div class="form-group">
                            <label class=" col-form-label font-weight-bolder">5.3.Affidavit showing the surface rights/consent of the owner of the land, in case the applicant is not the owner of the land<span class="text-danger">*</span></label>                   
                                 <div class="custom-file">
                                   <input type="file" class="custom-file-input" id="File7" name="filename">
                                   <label class="custom-file-label" for="customFile">Choose Files</label>
                              <small class="text-danger">Only <strong> jpg, jpeg, png, pdf, tif</strong> file types with size less than <strong>2 MB </strong> are allowed.</small>
                           
                        </div>
                  </div>
                                     
                 </div>
                  <div class="col-lg-6 col-md-12 col-sm-12">
                        <div class="form-group">
                            <label class=" col-form-label font-weight-bolder">6. Any other details the applicant wants to provide 
                            (NOC from PCB etc)<span class="text-danger">*</span></label>                   
                                 <div class="custom-file">
                                   <input type="file" class="custom-file-input" id="File8" name="filename">
                                   <label class="custom-file-label" for="customFile">Choose Files</label>
                              <small class="text-danger">Only <strong> jpg, jpeg, png, pdf, tif</strong> file types with size less than <strong>2 MB </strong> are allowed.</small>
                           
                        </div>
                  </div>
                                     
                 </div>
                  <div class="col-sm-12 ">
                 <a href="javascript:void(0);" class="btn btn-success btn-md ml-0 mb-2  waves-effect waves-light rounded-0">Submit</a>
                <a class="btn btn-danger btn-md  mb-2  waves-effect waves-light rounded-0">Reset</a>
                                               
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
             $('.newapplication').addClass('active');
         }) 
    </script> 
</body>
</html>


