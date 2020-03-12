using MyBetModel.Model;
using System.Collections.Generic;
using System.Linq;

namespace MyBetService
{
    public class GetDataService : IGetDataService
    {
        public IList<EventBet> GetEvent()
        {
            using (var db = new MyDbContext())
            {
                List<EventBet> eventBetL =
                    db.EventBets.ToList();
                return eventBetL;
            }
        }

        public IList<EventBet> GetEventData(int Id)
        {
            using (var db = new MyDbContext())
            {
                List<EventBet> betL =
                    db.EventBets
                    .Where(b => b.EventId == Id)
                    .ToList();
                return betL;
            }
        }

        public IList<Bet> GetBets(User user)
        {
            using (var db = new MyDbContext())
            {
                List<Bet> betL =
                    db.Bets
                    .Where(b => b.UserId == user.UserId )
                    .ToList();
                return betL;
            }
        }

        public IList<Bet> GetBetId(int betId)
        {
            using (var db = new MyDbContext())
            {
                List<Bet> betL = 
                    db.Bets
                    .Where(b => b.BetId == betId)
                    .ToList();
                return betL;
            }
        }

        public IList<History> GetHistories()
        {
            using (var db = new MyDbContext())
            {
                List<History> historyL =
                    db.Histories.ToList();
                return historyL;
            }
        }
    }
}
