using MyBetModel.Model;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyBetService
{

    public class GetDataService : IGetDataService
    {
        Logger logger = LogManager.GetCurrentClassLogger();
        public IList<EventBet> GetEvent()
        {
            try
            {
                using (var db = new MyDbContext())
                {
                    List<EventBet> eventBetL =
                        db.EventBets.ToList();
                    return eventBetL;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Ошибка");
                return null;
            }
        }

        public IList<EventBet> GetEventData(int Id)
        {
            try
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
            catch (Exception ex)
            {
                logger.Error(ex, "Ошибка");
                return null;
            }
        }

        public IList<Bet> GetBets(User user)
        {
            try
            {
                using (var db = new MyDbContext())
                {
                    List<Bet> betL =
                        db.Bets
                        .Where(b => b.UserId == user.UserId)
                        .ToList();
                    return betL;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Ошибка");
                return null;
            }
        }

        public IList<Bet> GetBetId(int betId)
        {
            try
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
            catch (Exception ex)
            {
                logger.Error(ex, "Ошибка");
                return null;
            }
        }

        public IList<History> GetHistories()
        {
            try
            {
                using (var db = new MyDbContext())
                {
                    List<History> historyL =
                        db.Histories.ToList();
                    return historyL;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Ошибка");
                return null;
            }
        }
    }
}
