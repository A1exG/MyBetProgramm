using MyBetModel.Model;
using NLog;
using System;
using System.Linq;

namespace MyBetService
{
    public class BetService : IBetService
    {
        Logger logger = LogManager.GetCurrentClassLogger();
        public int ConfirmBet(Bet bet)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    context.Bets.Add(bet);
                    context.SaveChanges();
                    logger.Info($"Ставка принята. ID = {bet.BetId}");
                    return 1;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Ошибка");
                return 0;
            }
        }

        public bool AddEventInHistory(EventBet eventBet, string winner)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    History history = new History(eventBet.EventId
                    , eventBet.DateEvent, eventBet.Team1
                    , eventBet.Team1Coef, eventBet.Team2
                    , eventBet.Team2Coef, winner, "Закрыто");
                    context.Histories.Add(history);
                    context.SaveChanges();
                    logger.Info($"Событие {eventBet.EventId} перенесено в историю.");
                    return true;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Ошибка");
                return false;
            }

        }
        public bool AddResultEvent(EventBet eventBet, string winner)
        {
            try
            {
                using (var context = new MyDbContext())
                {

                    Result result = new Result(eventBet.EventId, winner);
                    context.Results.Add(result);
                    context.SaveChanges();
                    logger.Info($"Добавлен результат события {eventBet.EventId}");
                    return true;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Ошибка");
                return false;
            }
        }

        public bool DeleteEvent(EventBet eventBet)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    var us = context.EventBets.FirstOrDefault(c => c.EventId == eventBet.EventId);
                    context.EventBets.Remove(us);
                    context.SaveChanges();
                    logger.Info($"Событие {eventBet.EventId} удалено");
                    return true;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Ошибка");
                return false;
            }
        }

        public bool AddNewEvent(EventBet eventBet)
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    context.EventBets.Add(eventBet);
                    context.SaveChanges();
                    logger.Info($"Событие {eventBet.EventId} создано");
                    return true;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Ошибка");
                return false;
            } 
        }
    }
}
