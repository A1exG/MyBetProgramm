using MyBetModel.Model;
using System.Globalization;
using System.Linq;

namespace MyBetService
{
    public class PayService : IPayService
    {
        public int ChangeBalance(User check, string sumBet)
        {
            using (var db = new MyDbContext())
            {
                NumberFormatInfo nfi = new NumberFormatInfo() { NumberDecimalSeparator = "." };
                var user = db.Users.FirstOrDefault(c => c.UserId == check.UserId);
                if(user != null)
                {
                    if (decimal.TryParse(sumBet, NumberStyles.Number, nfi, out decimal resultElem))
                    {
                        decimal balance = user.Balance;
                        user.Balance = (balance - resultElem);
                        db.Users.Update(user);
                        db.SaveChanges();
                        return 1;
                    } 
                }
                return 0; 
            }
        }

        public int DepositBalance(int userId, decimal newBalance)
        {
            using (var db = new MyDbContext())
            {
                NumberFormatInfo nfi = new NumberFormatInfo() { NumberDecimalSeparator = "." };
                var user = db.Users.FirstOrDefault(c => c.UserId == userId);

                user.Balance = newBalance;
                db.Users.Update(user);
                db.SaveChanges();
                return 1; 
            }
        }

        public int WithdrawBalance(int userId, decimal newBalance)
        {
            using (var db = new MyDbContext())
            {
                NumberFormatInfo nfi = new NumberFormatInfo() { NumberDecimalSeparator = "." };
                var user = db.Users.FirstOrDefault(c => c.UserId == userId);

                user.Balance = newBalance;
                db.Users.Update(user);
                db.SaveChanges();
                return 1;
            }
        }
    }
}
