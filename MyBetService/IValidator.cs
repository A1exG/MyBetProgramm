using MyBetModel.Model;
using System.Collections.Generic;
using System.ServiceModel;

namespace MyBetService
{
    [ServiceContract]
    public interface IUserValidator
    {
        [OperationContract]
        IList<User> CheckRegUser(User u);

        [OperationContract]
        int RegistrationNewUser(User user);

        [OperationContract]
        void UpdateUser(User user);
        [OperationContract]
        IList<User> GetUserData(User user);
    }
}
