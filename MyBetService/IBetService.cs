using MyBetModel.Model;
using System.ServiceModel;

namespace MyBetService
{
    [ServiceContract]
    public interface IBetService
    {
        [OperationContract]
        int ConfirmBet(Bet bet);

        [OperationContract]
        bool AddEventInHistory(EventBet eventBet, string winner);

        [OperationContract]
        bool AddResultEvent(EventBet eventBet, string winner);

        [OperationContract]
        bool DeleteEvent(EventBet eventBet);
    }


}
