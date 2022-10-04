﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ICICINEFTPaymentStatus
{


    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace = "https://www.techprocess.in/", ConfigurationName = "ICICINEFTPaymentStatus.StatusServiceSoap")]
    public interface StatusServiceSoap
    {

        // CODEGEN: Generating message contract since element name bank_id from namespace https://www.techprocess.in/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action = "https://www.techprocess.in/RefundStatus", ReplyAction = "*")]
        ICICINEFTPaymentStatus.RefundStatusResponse RefundStatus(ICICINEFTPaymentStatus.RefundStatusRequest request);

        [System.ServiceModel.OperationContractAttribute(Action = "https://www.techprocess.in/RefundStatus", ReplyAction = "*")]
        System.Threading.Tasks.Task<ICICINEFTPaymentStatus.RefundStatusResponse> RefundStatusAsync(ICICINEFTPaymentStatus.RefundStatusRequest request);

        // CODEGEN: Generating message contract since element name Merchant_code from namespace https://www.techprocess.in/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action = "https://www.techprocess.in/GetRefNoTrnStatus", ReplyAction = "*")]
        ICICINEFTPaymentStatus.GetRefNoTrnStatusResponse GetRefNoTrnStatus(ICICINEFTPaymentStatus.GetRefNoTrnStatusRequest request);

        [System.ServiceModel.OperationContractAttribute(Action = "https://www.techprocess.in/GetRefNoTrnStatus", ReplyAction = "*")]
        System.Threading.Tasks.Task<ICICINEFTPaymentStatus.GetRefNoTrnStatusResponse> GetRefNoTrnStatusAsync(ICICINEFTPaymentStatus.GetRefNoTrnStatusRequest request);

        // CODEGEN: Generating message contract since element name Bank_id from namespace https://www.techprocess.in/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action = "https://www.techprocess.in/GetRefNoTrnStatus_History", ReplyAction = "*")]
        ICICINEFTPaymentStatus.GetRefNoTrnStatus_HistoryResponse GetRefNoTrnStatus_History(ICICINEFTPaymentStatus.GetRefNoTrnStatus_HistoryRequest request);

        [System.ServiceModel.OperationContractAttribute(Action = "https://www.techprocess.in/GetRefNoTrnStatus_History", ReplyAction = "*")]
        System.Threading.Tasks.Task<ICICINEFTPaymentStatus.GetRefNoTrnStatus_HistoryResponse> GetRefNoTrnStatus_HistoryAsync(ICICINEFTPaymentStatus.GetRefNoTrnStatus_HistoryRequest request);

        // CODEGEN: Generating message contract since element name Bank_Code from namespace https://www.techprocess.in/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action = "https://www.techprocess.in/RTGSNEFT_Details", ReplyAction = "*")]
        ICICINEFTPaymentStatus.RTGSNEFT_DetailsResponse RTGSNEFT_Details(ICICINEFTPaymentStatus.RTGSNEFT_DetailsRequest request);

        [System.ServiceModel.OperationContractAttribute(Action = "https://www.techprocess.in/RTGSNEFT_Details", ReplyAction = "*")]
        System.Threading.Tasks.Task<ICICINEFTPaymentStatus.RTGSNEFT_DetailsResponse> RTGSNEFT_DetailsAsync(ICICINEFTPaymentStatus.RTGSNEFT_DetailsRequest request);

        // CODEGEN: Generating message contract since element name bank_id from namespace https://www.techprocess.in/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action = "https://www.techprocess.in/SettlementStatus", ReplyAction = "*")]
        ICICINEFTPaymentStatus.SettlementStatusResponse SettlementStatus(ICICINEFTPaymentStatus.SettlementStatusRequest request);

        [System.ServiceModel.OperationContractAttribute(Action = "https://www.techprocess.in/SettlementStatus", ReplyAction = "*")]
        System.Threading.Tasks.Task<ICICINEFTPaymentStatus.SettlementStatusResponse> SettlementStatusAsync(ICICINEFTPaymentStatus.SettlementStatusRequest request);
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class RefundStatusRequest
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "RefundStatus", Namespace = "https://www.techprocess.in/", Order = 0)]
        public ICICINEFTPaymentStatus.RefundStatusRequestBody Body;

        public RefundStatusRequest()
        {
        }

        public RefundStatusRequest(ICICINEFTPaymentStatus.RefundStatusRequestBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "https://www.techprocess.in/")]
    public partial class RefundStatusRequestBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 0)]
        public string bank_id;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 1)]
        public string client_code;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 2)]
        public string dept_code;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 3)]
        public string from_date;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 4)]
        public string to_date;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 5)]
        public string status;

        public RefundStatusRequestBody()
        {
        }

        public RefundStatusRequestBody(string bank_id, string client_code, string dept_code, string from_date, string to_date, string status)
        {
            this.bank_id = bank_id;
            this.client_code = client_code;
            this.dept_code = dept_code;
            this.from_date = from_date;
            this.to_date = to_date;
            this.status = status;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class RefundStatusResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "RefundStatusResponse", Namespace = "https://www.techprocess.in/", Order = 0)]
        public ICICINEFTPaymentStatus.RefundStatusResponseBody Body;

        public RefundStatusResponse()
        {
        }

        public RefundStatusResponse(ICICINEFTPaymentStatus.RefundStatusResponseBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "https://www.techprocess.in/")]
    public partial class RefundStatusResponseBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 0)]
        public string RefundStatusResult;

        public RefundStatusResponseBody()
        {
        }

        public RefundStatusResponseBody(string RefundStatusResult)
        {
            this.RefundStatusResult = RefundStatusResult;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class GetRefNoTrnStatusRequest
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "GetRefNoTrnStatus", Namespace = "https://www.techprocess.in/", Order = 0)]
        public ICICINEFTPaymentStatus.GetRefNoTrnStatusRequestBody Body;

        public GetRefNoTrnStatusRequest()
        {
        }

        public GetRefNoTrnStatusRequest(ICICINEFTPaymentStatus.GetRefNoTrnStatusRequestBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "https://www.techprocess.in/")]
    public partial class GetRefNoTrnStatusRequestBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 0)]
        public string Merchant_code;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 1)]
        public string Ref_no;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 2)]
        public string Amount;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 3)]
        public string Paymode;

        public GetRefNoTrnStatusRequestBody()
        {
        }

        public GetRefNoTrnStatusRequestBody(string Merchant_code, string Ref_no, string Amount, string Paymode)
        {
            this.Merchant_code = Merchant_code;
            this.Ref_no = Ref_no;
            this.Amount = Amount;
            this.Paymode = Paymode;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class GetRefNoTrnStatusResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "GetRefNoTrnStatusResponse", Namespace = "https://www.techprocess.in/", Order = 0)]
        public ICICINEFTPaymentStatus.GetRefNoTrnStatusResponseBody Body;

        public GetRefNoTrnStatusResponse()
        {
        }

        public GetRefNoTrnStatusResponse(ICICINEFTPaymentStatus.GetRefNoTrnStatusResponseBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "https://www.techprocess.in/")]
    public partial class GetRefNoTrnStatusResponseBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 0)]
        public string GetRefNoTrnStatusResult;

        public GetRefNoTrnStatusResponseBody()
        {
        }

        public GetRefNoTrnStatusResponseBody(string GetRefNoTrnStatusResult)
        {
            this.GetRefNoTrnStatusResult = GetRefNoTrnStatusResult;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class GetRefNoTrnStatus_HistoryRequest
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "GetRefNoTrnStatus_History", Namespace = "https://www.techprocess.in/", Order = 0)]
        public ICICINEFTPaymentStatus.GetRefNoTrnStatus_HistoryRequestBody Body;

        public GetRefNoTrnStatus_HistoryRequest()
        {
        }

        public GetRefNoTrnStatus_HistoryRequest(ICICINEFTPaymentStatus.GetRefNoTrnStatus_HistoryRequestBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "https://www.techprocess.in/")]
    public partial class GetRefNoTrnStatus_HistoryRequestBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 0)]
        public string Bank_id;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 1)]
        public string Merchant_code;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 2)]
        public string Dept_code;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 3)]
        public string Ref_no;

        public GetRefNoTrnStatus_HistoryRequestBody()
        {
        }

        public GetRefNoTrnStatus_HistoryRequestBody(string Bank_id, string Merchant_code, string Dept_code, string Ref_no)
        {
            this.Bank_id = Bank_id;
            this.Merchant_code = Merchant_code;
            this.Dept_code = Dept_code;
            this.Ref_no = Ref_no;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class GetRefNoTrnStatus_HistoryResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "GetRefNoTrnStatus_HistoryResponse", Namespace = "https://www.techprocess.in/", Order = 0)]
        public ICICINEFTPaymentStatus.GetRefNoTrnStatus_HistoryResponseBody Body;

        public GetRefNoTrnStatus_HistoryResponse()
        {
        }

        public GetRefNoTrnStatus_HistoryResponse(ICICINEFTPaymentStatus.GetRefNoTrnStatus_HistoryResponseBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "https://www.techprocess.in/")]
    public partial class GetRefNoTrnStatus_HistoryResponseBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 0)]
        public string GetRefNoTrnStatus_HistoryResult;

        public GetRefNoTrnStatus_HistoryResponseBody()
        {
        }

        public GetRefNoTrnStatus_HistoryResponseBody(string GetRefNoTrnStatus_HistoryResult)
        {
            this.GetRefNoTrnStatus_HistoryResult = GetRefNoTrnStatus_HistoryResult;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class RTGSNEFT_DetailsRequest
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "RTGSNEFT_Details", Namespace = "https://www.techprocess.in/", Order = 0)]
        public ICICINEFTPaymentStatus.RTGSNEFT_DetailsRequestBody Body;

        public RTGSNEFT_DetailsRequest()
        {
        }

        public RTGSNEFT_DetailsRequest(ICICINEFTPaymentStatus.RTGSNEFT_DetailsRequestBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "https://www.techprocess.in/")]
    public partial class RTGSNEFT_DetailsRequestBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 0)]
        public string Bank_Code;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 1)]
        public string Client_code;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 2)]
        public string Dept_Code;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 3)]
        public string From_date;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 4)]
        public string To_date;

        public RTGSNEFT_DetailsRequestBody()
        {
        }

        public RTGSNEFT_DetailsRequestBody(string Bank_Code, string Client_code, string Dept_Code, string From_date, string To_date)
        {
            this.Bank_Code = Bank_Code;
            this.Client_code = Client_code;
            this.Dept_Code = Dept_Code;
            this.From_date = From_date;
            this.To_date = To_date;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class RTGSNEFT_DetailsResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "RTGSNEFT_DetailsResponse", Namespace = "https://www.techprocess.in/", Order = 0)]
        public ICICINEFTPaymentStatus.RTGSNEFT_DetailsResponseBody Body;

        public RTGSNEFT_DetailsResponse()
        {
        }

        public RTGSNEFT_DetailsResponse(ICICINEFTPaymentStatus.RTGSNEFT_DetailsResponseBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "https://www.techprocess.in/")]
    public partial class RTGSNEFT_DetailsResponseBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 0)]
        public string RTGSNEFT_DetailsResult;

        public RTGSNEFT_DetailsResponseBody()
        {
        }

        public RTGSNEFT_DetailsResponseBody(string RTGSNEFT_DetailsResult)
        {
            this.RTGSNEFT_DetailsResult = RTGSNEFT_DetailsResult;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class SettlementStatusRequest
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "SettlementStatus", Namespace = "https://www.techprocess.in/", Order = 0)]
        public ICICINEFTPaymentStatus.SettlementStatusRequestBody Body;

        public SettlementStatusRequest()
        {
        }

        public SettlementStatusRequest(ICICINEFTPaymentStatus.SettlementStatusRequestBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "https://www.techprocess.in/")]
    public partial class SettlementStatusRequestBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 0)]
        public string bank_id;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 1)]
        public string Merchant_ID;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 2)]
        public string MerchantRefNo;

        public SettlementStatusRequestBody()
        {
        }

        public SettlementStatusRequestBody(string bank_id, string Merchant_ID, string MerchantRefNo)
        {
            this.bank_id = bank_id;
            this.Merchant_ID = Merchant_ID;
            this.MerchantRefNo = MerchantRefNo;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class SettlementStatusResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "SettlementStatusResponse", Namespace = "https://www.techprocess.in/", Order = 0)]
        public ICICINEFTPaymentStatus.SettlementStatusResponseBody Body;

        public SettlementStatusResponse()
        {
        }

        public SettlementStatusResponse(ICICINEFTPaymentStatus.SettlementStatusResponseBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "https://www.techprocess.in/")]
    public partial class SettlementStatusResponseBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 0)]
        public string SettlementStatusResult;

        public SettlementStatusResponseBody()
        {
        }

        public SettlementStatusResponseBody(string SettlementStatusResult)
        {
            this.SettlementStatusResult = SettlementStatusResult;
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface StatusServiceSoapChannel : ICICINEFTPaymentStatus.StatusServiceSoap, System.ServiceModel.IClientChannel
    {
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class StatusServiceSoapClient : System.ServiceModel.ClientBase<ICICINEFTPaymentStatus.StatusServiceSoap>, ICICINEFTPaymentStatus.StatusServiceSoap
    {

        public StatusServiceSoapClient()
        {
        }

        public StatusServiceSoapClient(string endpointConfigurationName) :
                base(endpointConfigurationName)
        {
        }

        public StatusServiceSoapClient(string endpointConfigurationName, string remoteAddress) :
                base(endpointConfigurationName, remoteAddress)
        {
        }

        public StatusServiceSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) :
                base(endpointConfigurationName, remoteAddress)
        {
        }

        public StatusServiceSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) :
                base(binding, remoteAddress)
        {
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ICICINEFTPaymentStatus.RefundStatusResponse ICICINEFTPaymentStatus.StatusServiceSoap.RefundStatus(ICICINEFTPaymentStatus.RefundStatusRequest request)
        {
            return base.Channel.RefundStatus(request);
        }

        public string RefundStatus(string bank_id, string client_code, string dept_code, string from_date, string to_date, string status)
        {
            ICICINEFTPaymentStatus.RefundStatusRequest inValue = new ICICINEFTPaymentStatus.RefundStatusRequest();
            inValue.Body = new ICICINEFTPaymentStatus.RefundStatusRequestBody();
            inValue.Body.bank_id = bank_id;
            inValue.Body.client_code = client_code;
            inValue.Body.dept_code = dept_code;
            inValue.Body.from_date = from_date;
            inValue.Body.to_date = to_date;
            inValue.Body.status = status;
            ICICINEFTPaymentStatus.RefundStatusResponse retVal = ((ICICINEFTPaymentStatus.StatusServiceSoap)(this)).RefundStatus(inValue);
            return retVal.Body.RefundStatusResult;
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ICICINEFTPaymentStatus.RefundStatusResponse> ICICINEFTPaymentStatus.StatusServiceSoap.RefundStatusAsync(ICICINEFTPaymentStatus.RefundStatusRequest request)
        {
            return base.Channel.RefundStatusAsync(request);
        }

        public System.Threading.Tasks.Task<ICICINEFTPaymentStatus.RefundStatusResponse> RefundStatusAsync(string bank_id, string client_code, string dept_code, string from_date, string to_date, string status)
        {
            ICICINEFTPaymentStatus.RefundStatusRequest inValue = new ICICINEFTPaymentStatus.RefundStatusRequest();
            inValue.Body = new ICICINEFTPaymentStatus.RefundStatusRequestBody();
            inValue.Body.bank_id = bank_id;
            inValue.Body.client_code = client_code;
            inValue.Body.dept_code = dept_code;
            inValue.Body.from_date = from_date;
            inValue.Body.to_date = to_date;
            inValue.Body.status = status;
            return ((ICICINEFTPaymentStatus.StatusServiceSoap)(this)).RefundStatusAsync(inValue);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ICICINEFTPaymentStatus.GetRefNoTrnStatusResponse ICICINEFTPaymentStatus.StatusServiceSoap.GetRefNoTrnStatus(ICICINEFTPaymentStatus.GetRefNoTrnStatusRequest request)
        {
            return base.Channel.GetRefNoTrnStatus(request);
        }

        public string GetRefNoTrnStatus(string Merchant_code, string Ref_no, string Amount, string Paymode)
        {
            ICICINEFTPaymentStatus.GetRefNoTrnStatusRequest inValue = new ICICINEFTPaymentStatus.GetRefNoTrnStatusRequest();
            inValue.Body = new ICICINEFTPaymentStatus.GetRefNoTrnStatusRequestBody();
            inValue.Body.Merchant_code = Merchant_code;
            inValue.Body.Ref_no = Ref_no;
            inValue.Body.Amount = Amount;
            inValue.Body.Paymode = Paymode;
            ICICINEFTPaymentStatus.GetRefNoTrnStatusResponse retVal = ((ICICINEFTPaymentStatus.StatusServiceSoap)(this)).GetRefNoTrnStatus(inValue);
            return retVal.Body.GetRefNoTrnStatusResult;
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ICICINEFTPaymentStatus.GetRefNoTrnStatusResponse> ICICINEFTPaymentStatus.StatusServiceSoap.GetRefNoTrnStatusAsync(ICICINEFTPaymentStatus.GetRefNoTrnStatusRequest request)
        {
            return base.Channel.GetRefNoTrnStatusAsync(request);
        }

        public System.Threading.Tasks.Task<ICICINEFTPaymentStatus.GetRefNoTrnStatusResponse> GetRefNoTrnStatusAsync(string Merchant_code, string Ref_no, string Amount, string Paymode)
        {
            ICICINEFTPaymentStatus.GetRefNoTrnStatusRequest inValue = new ICICINEFTPaymentStatus.GetRefNoTrnStatusRequest();
            inValue.Body = new ICICINEFTPaymentStatus.GetRefNoTrnStatusRequestBody();
            inValue.Body.Merchant_code = Merchant_code;
            inValue.Body.Ref_no = Ref_no;
            inValue.Body.Amount = Amount;
            inValue.Body.Paymode = Paymode;
            return ((ICICINEFTPaymentStatus.StatusServiceSoap)(this)).GetRefNoTrnStatusAsync(inValue);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ICICINEFTPaymentStatus.GetRefNoTrnStatus_HistoryResponse ICICINEFTPaymentStatus.StatusServiceSoap.GetRefNoTrnStatus_History(ICICINEFTPaymentStatus.GetRefNoTrnStatus_HistoryRequest request)
        {
            return base.Channel.GetRefNoTrnStatus_History(request);
        }

        public string GetRefNoTrnStatus_History(string Bank_id, string Merchant_code, string Dept_code, string Ref_no)
        {
            ICICINEFTPaymentStatus.GetRefNoTrnStatus_HistoryRequest inValue = new ICICINEFTPaymentStatus.GetRefNoTrnStatus_HistoryRequest();
            inValue.Body = new ICICINEFTPaymentStatus.GetRefNoTrnStatus_HistoryRequestBody();
            inValue.Body.Bank_id = Bank_id;
            inValue.Body.Merchant_code = Merchant_code;
            inValue.Body.Dept_code = Dept_code;
            inValue.Body.Ref_no = Ref_no;
            ICICINEFTPaymentStatus.GetRefNoTrnStatus_HistoryResponse retVal = ((ICICINEFTPaymentStatus.StatusServiceSoap)(this)).GetRefNoTrnStatus_History(inValue);
            return retVal.Body.GetRefNoTrnStatus_HistoryResult;
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ICICINEFTPaymentStatus.GetRefNoTrnStatus_HistoryResponse> ICICINEFTPaymentStatus.StatusServiceSoap.GetRefNoTrnStatus_HistoryAsync(ICICINEFTPaymentStatus.GetRefNoTrnStatus_HistoryRequest request)
        {
            return base.Channel.GetRefNoTrnStatus_HistoryAsync(request);
        }

        public System.Threading.Tasks.Task<ICICINEFTPaymentStatus.GetRefNoTrnStatus_HistoryResponse> GetRefNoTrnStatus_HistoryAsync(string Bank_id, string Merchant_code, string Dept_code, string Ref_no)
        {
            ICICINEFTPaymentStatus.GetRefNoTrnStatus_HistoryRequest inValue = new ICICINEFTPaymentStatus.GetRefNoTrnStatus_HistoryRequest();
            inValue.Body = new ICICINEFTPaymentStatus.GetRefNoTrnStatus_HistoryRequestBody();
            inValue.Body.Bank_id = Bank_id;
            inValue.Body.Merchant_code = Merchant_code;
            inValue.Body.Dept_code = Dept_code;
            inValue.Body.Ref_no = Ref_no;
            return ((ICICINEFTPaymentStatus.StatusServiceSoap)(this)).GetRefNoTrnStatus_HistoryAsync(inValue);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ICICINEFTPaymentStatus.RTGSNEFT_DetailsResponse ICICINEFTPaymentStatus.StatusServiceSoap.RTGSNEFT_Details(ICICINEFTPaymentStatus.RTGSNEFT_DetailsRequest request)
        {
            return base.Channel.RTGSNEFT_Details(request);
        }

        public string RTGSNEFT_Details(string Bank_Code, string Client_code, string Dept_Code, string From_date, string To_date)
        {
            ICICINEFTPaymentStatus.RTGSNEFT_DetailsRequest inValue = new ICICINEFTPaymentStatus.RTGSNEFT_DetailsRequest();
            inValue.Body = new ICICINEFTPaymentStatus.RTGSNEFT_DetailsRequestBody();
            inValue.Body.Bank_Code = Bank_Code;
            inValue.Body.Client_code = Client_code;
            inValue.Body.Dept_Code = Dept_Code;
            inValue.Body.From_date = From_date;
            inValue.Body.To_date = To_date;
            ICICINEFTPaymentStatus.RTGSNEFT_DetailsResponse retVal = ((ICICINEFTPaymentStatus.StatusServiceSoap)(this)).RTGSNEFT_Details(inValue);
            return retVal.Body.RTGSNEFT_DetailsResult;
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ICICINEFTPaymentStatus.RTGSNEFT_DetailsResponse> ICICINEFTPaymentStatus.StatusServiceSoap.RTGSNEFT_DetailsAsync(ICICINEFTPaymentStatus.RTGSNEFT_DetailsRequest request)
        {
            return base.Channel.RTGSNEFT_DetailsAsync(request);
        }

        public System.Threading.Tasks.Task<ICICINEFTPaymentStatus.RTGSNEFT_DetailsResponse> RTGSNEFT_DetailsAsync(string Bank_Code, string Client_code, string Dept_Code, string From_date, string To_date)
        {
            ICICINEFTPaymentStatus.RTGSNEFT_DetailsRequest inValue = new ICICINEFTPaymentStatus.RTGSNEFT_DetailsRequest();
            inValue.Body = new ICICINEFTPaymentStatus.RTGSNEFT_DetailsRequestBody();
            inValue.Body.Bank_Code = Bank_Code;
            inValue.Body.Client_code = Client_code;
            inValue.Body.Dept_Code = Dept_Code;
            inValue.Body.From_date = From_date;
            inValue.Body.To_date = To_date;
            return ((ICICINEFTPaymentStatus.StatusServiceSoap)(this)).RTGSNEFT_DetailsAsync(inValue);
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ICICINEFTPaymentStatus.SettlementStatusResponse ICICINEFTPaymentStatus.StatusServiceSoap.SettlementStatus(ICICINEFTPaymentStatus.SettlementStatusRequest request)
        {
            return base.Channel.SettlementStatus(request);
        }

        public string SettlementStatus(string bank_id, string Merchant_ID, string MerchantRefNo)
        {
            ICICINEFTPaymentStatus.SettlementStatusRequest inValue = new ICICINEFTPaymentStatus.SettlementStatusRequest();
            inValue.Body = new ICICINEFTPaymentStatus.SettlementStatusRequestBody();
            inValue.Body.bank_id = bank_id;
            inValue.Body.Merchant_ID = Merchant_ID;
            inValue.Body.MerchantRefNo = MerchantRefNo;
            ICICINEFTPaymentStatus.SettlementStatusResponse retVal = ((ICICINEFTPaymentStatus.StatusServiceSoap)(this)).SettlementStatus(inValue);
            return retVal.Body.SettlementStatusResult;
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ICICINEFTPaymentStatus.SettlementStatusResponse> ICICINEFTPaymentStatus.StatusServiceSoap.SettlementStatusAsync(ICICINEFTPaymentStatus.SettlementStatusRequest request)
        {
            return base.Channel.SettlementStatusAsync(request);
        }

        public System.Threading.Tasks.Task<ICICINEFTPaymentStatus.SettlementStatusResponse> SettlementStatusAsync(string bank_id, string Merchant_ID, string MerchantRefNo)
        {
            ICICINEFTPaymentStatus.SettlementStatusRequest inValue = new ICICINEFTPaymentStatus.SettlementStatusRequest();
            inValue.Body = new ICICINEFTPaymentStatus.SettlementStatusRequestBody();
            inValue.Body.bank_id = bank_id;
            inValue.Body.Merchant_ID = Merchant_ID;
            inValue.Body.MerchantRefNo = MerchantRefNo;
            return ((ICICINEFTPaymentStatus.StatusServiceSoap)(this)).SettlementStatusAsync(inValue);
        }
    }
}
