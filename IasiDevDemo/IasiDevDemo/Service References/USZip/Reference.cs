﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IasiDevDemo.USZip {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://www.webserviceX.NET", ConfigurationName="USZip.USZipSoap")]
    public interface USZipSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.webserviceX.NET/GetInfoByZIP", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Xml.XmlNode GetInfoByZIP(string USZip);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.webserviceX.NET/GetInfoByZIP", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Xml.XmlNode> GetInfoByZIPAsync(string USZip);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.webserviceX.NET/GetInfoByCity", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Xml.XmlNode GetInfoByCity(string USCity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.webserviceX.NET/GetInfoByCity", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Xml.XmlNode> GetInfoByCityAsync(string USCity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.webserviceX.NET/GetInfoByState", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Xml.XmlNode GetInfoByState(string USState);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.webserviceX.NET/GetInfoByState", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Xml.XmlNode> GetInfoByStateAsync(string USState);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.webserviceX.NET/GetInfoByAreaCode", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Xml.XmlNode GetInfoByAreaCode(string USAreaCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.webserviceX.NET/GetInfoByAreaCode", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Xml.XmlNode> GetInfoByAreaCodeAsync(string USAreaCode);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface USZipSoapChannel : IasiDevDemo.USZip.USZipSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class USZipSoapClient : System.ServiceModel.ClientBase<IasiDevDemo.USZip.USZipSoap>, IasiDevDemo.USZip.USZipSoap {
        
        public USZipSoapClient() {
        }
        
        public USZipSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public USZipSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public USZipSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public USZipSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Xml.XmlNode GetInfoByZIP(string USZip) {
            return base.Channel.GetInfoByZIP(USZip);
        }
        
        public System.Threading.Tasks.Task<System.Xml.XmlNode> GetInfoByZIPAsync(string USZip) {
            return base.Channel.GetInfoByZIPAsync(USZip);
        }
        
        public System.Xml.XmlNode GetInfoByCity(string USCity) {
            return base.Channel.GetInfoByCity(USCity);
        }
        
        public System.Threading.Tasks.Task<System.Xml.XmlNode> GetInfoByCityAsync(string USCity) {
            return base.Channel.GetInfoByCityAsync(USCity);
        }
        
        public System.Xml.XmlNode GetInfoByState(string USState) {
            return base.Channel.GetInfoByState(USState);
        }
        
        public System.Threading.Tasks.Task<System.Xml.XmlNode> GetInfoByStateAsync(string USState) {
            return base.Channel.GetInfoByStateAsync(USState);
        }
        
        public System.Xml.XmlNode GetInfoByAreaCode(string USAreaCode) {
            return base.Channel.GetInfoByAreaCode(USAreaCode);
        }
        
        public System.Threading.Tasks.Task<System.Xml.XmlNode> GetInfoByAreaCodeAsync(string USAreaCode) {
            return base.Channel.GetInfoByAreaCodeAsync(USAreaCode);
        }
    }
}
