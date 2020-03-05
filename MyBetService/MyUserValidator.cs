using MyBetModel.Model;
using System.Collections.Generic;
using System.Linq;

namespace MyBetService
{
    public class MyUserValidator : IUserValidator
    {
        public IList<User> CheckRegUser(User u)
        {
            using (var db = new MyDbContext())
            {
                List<User> userL =
                    db.Users
                    .Where(b => b.UserLogin == u.UserLogin || b.UserPass == u.UserPass)
                    .ToList();
                return userL;
            }
        }
        public int RegistrationNewUser(User user)
        {
            using (var context = new MyDbContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
                return 1;
            }
        }

        public void UpdateUser(User u)
        {
            using (var context = new MyDbContext())
            {
                context.Users.Update(u);
                context.SaveChanges();
            }
        }
    }
}
