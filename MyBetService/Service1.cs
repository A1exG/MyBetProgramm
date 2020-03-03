using MyBetModel.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace MyBetService
{
    public class Service : IService
    {
        public bool CheckRegUser(User u)
        {
            using (var db = new MyDbContext())
            {
                List<User> userL =
                    db.Users
                    .Where(b => b.UserLogin == u.UserLogin || b.UserPass == u.UserPass)
                    .ToList();
                if(userL.Count > 1)
                {
                    return true;
                }
                return false;
            }
        }

        public int RegistrationNewUser(User user)
        {
            throw new NotImplementedException();
        }

        public List<EventBet> GetEvent()
        {
            using (var db = new MyDbContext())
            {
                List<EventBet> eventBetL =
                    db.EventBets.ToList();
                    return eventBetL;
            }
        }

        public User CheckUser(User u)
        {
            throw new NotImplementedException();
        }

        public User GetUser(User u)
        {
            throw new NotImplementedException();
        }

        public int UpdateUser(User u)
        {
            throw new NotImplementedException();
        }

        public int ChangeBalance(User u)
        {
            throw new NotImplementedException();
        }

        public List<Bet> GetBet(Bet b)
        {
            throw new NotImplementedException();
        }

        public int AcceptBet(Bet bet)
        {
            throw new NotImplementedException();
        }

        public Bet GetBetCode(Bet b)
        {
            throw new NotImplementedException();
        }

        public int AddResult(Result result)
        {
            throw new NotImplementedException();
        }

        public Result GetResult(Result r)
        {
            throw new NotImplementedException();
        }

        public int AddHistory(History history)
        {
            throw new NotImplementedException();
        }

        public EventBet GetEventHistory(EventBet e)
        {
            throw new NotImplementedException();
        }

        public int RemoveEvent(EventBet e)
        {
            throw new NotImplementedException();
        }

        public EventBet GetEventCode(EventBet eb)
        {
            throw new NotImplementedException();
        }

        public List<History> GetHistoryEvent()
        {
            throw new NotImplementedException();
        }
    }
}
