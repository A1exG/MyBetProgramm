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
    public interface IGetDataService
    {
        [OperationContract]
        IList<EventBet> GetEvent();
        
        [OperationContract]
        IList<EventBet> GetEventData(int Id);
        
        [OperationContract]
        IList<Bet> GetBets(User user);

        [OperationContract]
        IList<Bet> GetBetId(int betId);

        IList<History> GetHistories();
    }
}
