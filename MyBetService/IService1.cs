using MyBetModel.Model;
using System.Collections.Generic;
using System.ServiceModel;



namespace MyBetService
{
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        bool CheckRegUser(User u);

        [OperationContract]
        int RegistrationNewUser(User user);

        [OperationContract]
        List<EventBet> GetEvent();

        [OperationContract]
        User CheckUser(User u);

        [OperationContract]
        User GetUser(User u);

        [OperationContract]
        int UpdateUser(User u);

        [OperationContract]
        int ChangeBalance(User u);

        [OperationContract]
        List<Bet> GetBet(Bet b);

        [OperationContract]
        int AcceptBet(Bet bet);

        [OperationContract]
        Bet GetBetCode(Bet b);

        [OperationContract]
        int AddResult(Result result);
        [OperationContract]
        Result GetResult(Result r);
        [OperationContract]
        int AddHistory(History history);

        [OperationContract]
        EventBet GetEventHistory(EventBet e);

        [OperationContract]
        int RemoveEvent(EventBet e);

        [OperationContract]
        EventBet GetEventCode(EventBet eb);

        [OperationContract]
        List<History> GetHistoryEvent();

    }

}
