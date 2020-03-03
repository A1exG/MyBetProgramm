using MyBetModel.Model;
using System.Collections.Generic;
using System.Linq;

namespace MyBetService
{
    public class GetDataService : IService
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
    }
}
