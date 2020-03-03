﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyBetView.ServiceReference2 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference2.IUserValidator")]
    public interface IUserValidator {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserValidator/CheckRegUser", ReplyAction="http://tempuri.org/IUserValidator/CheckRegUserResponse")]
        int CheckRegUser(MyBetModel.Model.User u);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserValidator/CheckRegUser", ReplyAction="http://tempuri.org/IUserValidator/CheckRegUserResponse")]
        System.Threading.Tasks.Task<int> CheckRegUserAsync(MyBetModel.Model.User u);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserValidator/RegistrationNewUser", ReplyAction="http://tempuri.org/IUserValidator/RegistrationNewUserResponse")]
        void RegistrationNewUser(MyBetModel.Model.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserValidator/RegistrationNewUser", ReplyAction="http://tempuri.org/IUserValidator/RegistrationNewUserResponse")]
        System.Threading.Tasks.Task RegistrationNewUserAsync(MyBetModel.Model.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserValidator/UpdateUser", ReplyAction="http://tempuri.org/IUserValidator/UpdateUserResponse")]
        void UpdateUser(MyBetModel.Model.User u);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserValidator/UpdateUser", ReplyAction="http://tempuri.org/IUserValidator/UpdateUserResponse")]
        System.Threading.Tasks.Task UpdateUserAsync(MyBetModel.Model.User u);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IUserValidatorChannel : MyBetView.ServiceReference2.IUserValidator, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UserValidatorClient : System.ServiceModel.ClientBase<MyBetView.ServiceReference2.IUserValidator>, MyBetView.ServiceReference2.IUserValidator {
        
        public UserValidatorClient() {
        }
        
        public UserValidatorClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public UserValidatorClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserValidatorClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserValidatorClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int CheckRegUser(MyBetModel.Model.User u) {
            return base.Channel.CheckRegUser(u);
        }
        
        public System.Threading.Tasks.Task<int> CheckRegUserAsync(MyBetModel.Model.User u) {
            return base.Channel.CheckRegUserAsync(u);
        }
        
        public void RegistrationNewUser(MyBetModel.Model.User user) {
            base.Channel.RegistrationNewUser(user);
        }
        
        public System.Threading.Tasks.Task RegistrationNewUserAsync(MyBetModel.Model.User user) {
            return base.Channel.RegistrationNewUserAsync(user);
        }
        
        public void UpdateUser(MyBetModel.Model.User u) {
            base.Channel.UpdateUser(u);
        }
        
        public System.Threading.Tasks.Task UpdateUserAsync(MyBetModel.Model.User u) {
            return base.Channel.UpdateUserAsync(u);
        }
    }
}
