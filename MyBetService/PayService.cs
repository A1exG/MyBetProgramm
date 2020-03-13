using MyBetModel.Model;
using NLog;
using System;
using System.Globalization;
using System.Linq;

namespace MyBetService
{
    public class PayService : IPayService
    {
        Logger logger = LogManager.GetCurrentClassLogger();
        public int ChangeBalance(User check, string sumBet)
        {
            try
            {
                using (var db = new MyDbContext())
                {
                    NumberFormatInfo nfi = new NumberFormatInfo() { NumberDecimalSeparator = "." };
                    var user = db.Users.FirstOrDefault(c => c.UserId == check.UserId);
                    if (user != null)
                    {
                        if (decimal.TryParse(sumBet, NumberStyles.Number, nfi, out decimal resultElem))
                        {
                            decimal balance = user.Balance;
                            user.Balance = (balance - resultElem);
                            db.Users.Update(user);
                            db.SaveChanges();
                            logger.Info($"Изменен баланс пользователя {check.UserLogin}");
                            return 1;
                        }
                    }
                    return 0;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Ошибка");
                return 0;
            }
        }

        public int DepositBalance(int userId, decimal newBalance)
        {
            try
            {
                using (var db = new MyDbContext())
                {
                    NumberFormatInfo nfi = new NumberFormatInfo() { NumberDecimalSeparator = "." };
                    var user = db.Users.FirstOrDefault(c => c.UserId == userId);

                    user.Balance = newBalance;
                    db.Users.Update(user);
                    db.SaveChanges();
                    logger.Info($"Пополнен баланс пользователя {userId}");
                    return 1;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Ошибка");
                return 0;
            }
        }
        public int WithdrawBalance(int userId, decimal newBalance)
        {
            try
            {
                using (var db = new MyDbContext())
                {
                    NumberFormatInfo nfi = new NumberFormatInfo() { NumberDecimalSeparator = "." };
                    var user = db.Users.FirstOrDefault(c => c.UserId == userId);

                    user.Balance = newBalance;
                    db.Users.Update(user);
                    db.SaveChanges();
                    logger.Info($"Снятие с баланса пользователя {userId}");
                    return 1;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Ошибка");
                return 0;
            }
        }
    }
}
