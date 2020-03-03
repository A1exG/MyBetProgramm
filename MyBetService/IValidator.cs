using MyBetModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MyBetService
{
    [ServiceContract]
    public interface IUserValidator
    {
        [OperationContract]
        IList<User> CheckRegUser(User u);

        [OperationContract]
        void RegistrationNewUser(User user);

        [OperationContract]
        void UpdateUser(User u);
    }
}
