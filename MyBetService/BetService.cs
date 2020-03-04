using MyBetModel.Model;

namespace MyBetService
{
    public class BetService : IBetService
    {
        public void ConfirmBet(Bet bet)
        {
            using (var context = new MyDbContext())
            {
                context.Bets.Add(bet);
                context.SaveChanges();
            }
        }
    }
}
