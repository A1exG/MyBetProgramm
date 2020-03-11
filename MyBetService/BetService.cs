using MyBetModel.Model;
using System.Linq;

namespace MyBetService
{
    public class BetService : IBetService
    {
        public int ConfirmBet(Bet bet)
        {
            using (var context = new MyDbContext())
            {
                context.Bets.Add(bet);
                context.SaveChanges();
                return 1;
            }
        }

        public bool AddEventInHistory(EventBet eventBet, string winner)
        {
            using (var context = new MyDbContext())
            {
                History history = new History(eventBet.EventId
                    , eventBet.DateEvent, eventBet.Team1
                    , eventBet.Team1Coef, eventBet.Team2
                    , eventBet.Team2Coef, winner, "Закрыто");
                context.Histories.Add(history);
                context.SaveChanges();
                return true;
            }
        }

        public bool AddResultEvent(EventBet eventBet, string winner)
        {
            using (var context = new MyDbContext())
            {
                Result result = new Result(eventBet.EventId, winner);
                context.Results.Add(result);
                context.SaveChanges();
                return true;
            }
        }

        public bool DeleteEvent(EventBet eventBet)
        {
            using (var context = new MyDbContext())
            {
                var us = context.EventBets.FirstOrDefault(c => c.EventId == eventBet.EventId);
                context.EventBets.Remove(us);
                context.SaveChanges();
                return true;
            }
        }

        public bool AddNewEvent(EventBet eventBet)
        {
            using (var context = new MyDbContext())
            {
                context.EventBets.Add(eventBet);
                context.SaveChanges();
                return true;
            }
        }
    }
}
