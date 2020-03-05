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
    public interface IPayService
    {
        [OperationContract]
        int ChangeBalance(User check, string sumBet);
        [OperationContract]
        int DepositBalance(int userId, decimal newBalance);
        [OperationContract]
        int WithdrawBalance(int userId, decimal newBalance);

    }
}
