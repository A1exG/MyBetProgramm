using MyBetModel.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MyBetService
{
    public class Service : IService
    {
        public Service()
        {
            connectToDb();
        }
        #region const
        SqlConnection conn;
        SqlCommand comm;
        SqlConnectionStringBuilder connStringBuilder;
        #endregion
        void connectToDb()
        {
            connStringBuilder = new SqlConnectionStringBuilder();
            connStringBuilder.DataSource = @"TECH-COMP3\SQLEXPRESS";
            connStringBuilder.InitialCatalog = "DbTestTask";
            connStringBuilder.ConnectTimeout = 30;
            connStringBuilder.AsynchronousProcessing = true;
            connStringBuilder.MultipleActiveResultSets = true;
            connStringBuilder.IntegratedSecurity = true;

            conn = new SqlConnection(connStringBuilder.ToString());
            comm = conn.CreateCommand();
        }

        #region USER
        // Регистрация нового пользователя
        public int RegistrationNewUser(User user)
        {
            try
            {
                comm.CommandText = "INSERT INTO Users Values(@SurName, @Name, @SecondName, @Birthday, @Balance, @UserLogin, @UserPass)";
                comm.Parameters.AddWithValue("SurName", user.SurName);
                comm.Parameters.AddWithValue("Name", user.Name);
                comm.Parameters.AddWithValue("SecondName", user.SecondName);
                comm.Parameters.AddWithValue("Birthday", user.Birthday);
                comm.Parameters.AddWithValue("Balance", user.Balance);
                comm.Parameters.AddWithValue("UserLogin", user.UserLogin);
                comm.Parameters.AddWithValue("UserPass", user.UserPass);
                comm.CommandType = CommandType.Text;
                conn.Open();

                return comm.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
        // Проверка пользователя для авторизации в программе
        public User CheckUser(User u)
        {
            User user = new User();
            try
            {
                comm.CommandText = "SELECT * FROM Users WHERE (UserLogin=@UserLogin) AND (UserPass=@UserPass)";
                comm.Parameters.AddWithValue("UserLogin", u.UserLogin);
                comm.Parameters.AddWithValue("UserPass", u.UserPass);
                comm.CommandType = CommandType.Text;

                conn.Open();

                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    user.UserId = Convert.ToInt32(reader[0]);
                    user.SurName = reader[1].ToString();
                    user.Name = reader[2].ToString();
                    user.SecondName = reader[3].ToString();
                    user.Birthday = Convert.ToDateTime(reader[4]);
                    user.Balance = Convert.ToDecimal(reader[5]);
                    user.UserLogin = reader[6].ToString();
                    user.UserPass = reader[7].ToString();
                }
                return user;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
        // Получение данных пользователя по ID пользователя
        public User GetUser(User u)
        {
            User user = new User();
            try
            {
                comm.CommandText = "SELECT * FROM Users WHERE UserId=@UserId";
                comm.Parameters.AddWithValue("UserId", u.UserId);
                comm.CommandType = CommandType.Text;

                conn.Open();

                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    user.UserId = Convert.ToInt32(reader[0]);
                    user.SurName = reader[1].ToString();
                    user.Name = reader[2].ToString();
                    user.SecondName = reader[3].ToString();
                    user.Birthday = Convert.ToDateTime(reader[4]);
                    user.Balance = Convert.ToDecimal(reader[5]);
                    user.UserLogin = reader[6].ToString();
                    user.UserPass = reader[7].ToString();
                }
                return user;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
        // Изменение данных пользователя
        public int UpdateUser(User u)
        {
            try
            {
                comm.CommandText = "UPDATE Users SET SurName=@SurName, Name=@Name, SecondName=@SecondName, Birthday=@Birthday, UserLogin=@UserLogin, UserPass=@UserPass WHERE UserId=@UserId ";
                comm.Parameters.AddWithValue("UserId", u.UserId);
                comm.Parameters.AddWithValue("SurName", u.SurName);
                comm.Parameters.AddWithValue("Name", u.Name);
                comm.Parameters.AddWithValue("SecondName", u.SecondName);
                comm.Parameters.AddWithValue("Birthday", u.Birthday);
                comm.Parameters.AddWithValue("UserLogin", u.UserLogin);
                comm.Parameters.AddWithValue("UserPass", u.UserPass);
                comm.CommandType = CommandType.Text;
                conn.Open();

                return comm.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
        // Изменение баланса пользователя
        public int ChangeBalance(User u)
        {
            try
            {
                comm.CommandText = "UPDATE Users SET Balance=@Balance WHERE UserId=@UserId ";
                comm.Parameters.AddWithValue("UserId", u.UserId);
                comm.Parameters.AddWithValue("Balance", u.Balance);
                comm.CommandType = CommandType.Text;
                conn.Open();

                return comm.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
        // Проверка пользователя при регистрации на одинаковый логин
        public int CheckRegUser(User u)
        {
            try
            {
                comm.CommandText = "SELECT COUNT(*) FROM Users WHERE UserLogin=@UserLogin";
                comm.Parameters.AddWithValue("UserLogin", u.UserLogin);

                comm.CommandType = CommandType.Text;
                conn.Open();

                var t = comm.ExecuteScalar();

                return (int)comm.ExecuteScalar(); ;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
        #endregion

        #region BET
        // Получение всех событий
        public List<EventBet> GetEvent()
        {
            List<EventBet> eventL = new List<EventBet>();
            try
            {
                comm.CommandText = "SELECT * FROM Events";
                comm.CommandType = CommandType.Text;
                conn.Open();

                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    EventBet evet = new EventBet()
                    {
                        EventId = Convert.ToInt32(reader[0]),
                        DateEvent = Convert.ToDateTime(reader[1]),
                        Team1 = reader[2].ToString(),
                        Team1Coef = Convert.ToDecimal(reader[3]),
                        Team2 = reader[4].ToString(),
                        Team2Coef = Convert.ToDecimal(reader[5])
                    };
                    eventL.Add(evet);
                }
                return eventL;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
        // Поиск события по коду
        public EventBet GetEventCode(EventBet eb)
        {
            EventBet eeventBet = new EventBet();
            try
            {
                comm.CommandText = "SELECT * FROM Events WHERE EventId=@EventId";
                comm.Parameters.AddWithValue("EventId", eb.EventId);
                comm.CommandType = CommandType.Text;

                conn.Open();

                SqlDataReader reader = comm.ExecuteReader();

                while (reader.Read())
                {
                    eeventBet.EventId = Convert.ToInt32(reader[0]);
                    eeventBet.DateEvent = Convert.ToDateTime(reader[1]);
                    eeventBet.Team1 = reader[2].ToString();
                    eeventBet.Team1Coef = Convert.ToDecimal(reader[3]);
                    eeventBet.Team2 = reader[4].ToString();
                    eeventBet.Team2Coef = Convert.ToDecimal(reader[5]);
                }
                return eeventBet;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        // Принятие ставки 
        public int AcceptBet(Bet bet)
        {
            try
            {
                comm.CommandText = "INSERT INTO Bets Values(@DateBet, @SumBet, @CoefBet, @SumWinBet, @UserId, @EventId, @Team)";
                comm.Parameters.AddWithValue("DateBet", bet.DateBet);
                comm.Parameters.AddWithValue("SumBet", bet.SumBet);
                comm.Parameters.AddWithValue("CoefBet", bet.CoefBet);
                comm.Parameters.AddWithValue("SumWinBet", bet.SumWinBet);
                comm.Parameters.AddWithValue("UserId", bet.UserId);
                comm.Parameters.AddWithValue("EventId", bet.EventId);
                comm.Parameters.AddWithValue("Team", bet.Team);


                comm.CommandType = CommandType.Text;
                conn.Open();

                return comm.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
        // Поиск ставки по коду
        public Bet GetBetCode(Bet b)
        {
            Bet bet = new Bet();
            try
            {
                comm.CommandText = "SELECT * FROM Bets WHERE BetId=@BetId";
                comm.Parameters.AddWithValue("BetId", b.BetId);
                comm.CommandType = CommandType.Text;

                conn.Open();

                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    bet.DateBet = Convert.ToDateTime(reader[1]);
                    bet.SumBet = Convert.ToDecimal(reader[2]);
                    bet.CoefBet = Convert.ToDecimal(reader[3]);
                    bet.SumWinBet = Convert.ToDecimal(reader[4]);
                    bet.UserId = Convert.ToInt32(reader[5]);
                    bet.EventId = Convert.ToInt32(reader[6]);
                    bet.Team = reader[7].ToString();
                }
                return bet;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
        // Получение списка ставок пользователя
        public List<Bet> GetBet(Bet b)
        {
            List<Bet> betL = new List<Bet>();

            try
            {
                comm.CommandText = "SELECT * FROM Bets WHERE UserId=@UserId";
                comm.Parameters.AddWithValue("UserId", b.UserId);
                comm.CommandType = CommandType.Text;

                conn.Open();

                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    Bet bett = new Bet()
                    {
                        BetId = Convert.ToInt32(reader[0]),
                        DateBet = Convert.ToDateTime(reader[1]),
                        SumBet = Convert.ToDecimal(reader[2]),
                        CoefBet = Convert.ToDecimal(reader[3]),
                        SumWinBet = Convert.ToDecimal(reader[4]),
                        UserId = Convert.ToInt32(reader[5]),
                        EventId = Convert.ToInt32(reader[6]),
                        Team = reader[7].ToString()
                    };
                    betL.Add(bett);
                }

                return betL;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
        // Получение события для записи в Историю
        public EventBet GetEventHistory(EventBet e)
        {
            EventBet eventb = new EventBet();
            try
            {
                comm.CommandText = "SELECT * FROM Events WHERE EventId=@EventId";
                comm.Parameters.AddWithValue("EventId", e.EventId);
                comm.CommandType = CommandType.Text;

                conn.Open();

                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    eventb.EventId = Convert.ToInt32(reader[0]);
                    eventb.DateEvent = Convert.ToDateTime(reader[1]);
                    eventb.Team1 = reader[2].ToString();
                    eventb.Team1Coef = Convert.ToDecimal(reader[3]);
                    eventb.Team2 = reader[4].ToString();
                    eventb.Team2Coef = Convert.ToDecimal(reader[5]);
                }
                return eventb;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
        #endregion


        #region RESULT
        // Добавить результат события
        public int AddResult(Result result)
        {
            try
            {
                comm.CommandText = "INSERT INTO Results Values(@EventId, @WinnerTeam)";
                comm.Parameters.AddWithValue("EventId", result.EventId);
                comm.Parameters.AddWithValue("WinnerTeam", result.WinnerTeam);

                comm.CommandType = CommandType.Text;
                conn.Open();

                return comm.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
        // Получение результата события
        public Result GetResult(Result r)
        {
            Result result = new Result();
            try
            {
                comm.CommandText = "SELECT * FROM Results WHERE EventId=@EventId";
                comm.Parameters.AddWithValue("EventId", r.EventId);
                comm.CommandType = CommandType.Text;

                conn.Open();

                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    result.ResultId = Convert.ToInt32(reader[0]);
                    result.WinnerTeam = (reader[2]).ToString();
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }





        }
        // Добавление события в историю
        public int AddHistory(History history)
        {
            try
            {
                comm.CommandText = "INSERT INTO History Values(@EventId, @DateEvent, @Team1, @Team1Coef, @Team2, @Team2Coef, @Winner, @EventEnd)";
                comm.Parameters.AddWithValue("EventId", history.EventId);
                comm.Parameters.AddWithValue("DateEvent", history.DateEvent);
                comm.Parameters.AddWithValue("Team1", history.Team1);
                comm.Parameters.AddWithValue("Team1Coef", history.Team1Coef);
                comm.Parameters.AddWithValue("Team2", history.Team2);
                comm.Parameters.AddWithValue("Team2Coef", history.Team2Coef);
                comm.Parameters.AddWithValue("Winner", history.Winner);
                comm.Parameters.AddWithValue("EventEnd", history.EventEnd);

                comm.CommandType = CommandType.Text;
                conn.Open();

                return comm.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
        // Удаление события из таблицы
        public int RemoveEvent(EventBet e)
        {
            try
            {
                comm.CommandText = "DELETE Events WHERE @EventId=EventId";
                comm.Parameters.AddWithValue("EventId", e.EventId);

                comm.CommandType = CommandType.Text;
                conn.Open();

                return comm.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        // Получение истории закрытых событий
        public List<History> GetHistoryEvent()
        {
            List<History> eventL = new List<History>();
            try
            {
                comm.CommandText = "SELECT * FROM History";
                comm.CommandType = CommandType.Text;
                conn.Open();

                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    History history = new History()
                    {
                        EventId = Convert.ToInt32(reader[0]),
                        DateEvent = Convert.ToDateTime(reader[1]),
                        Team1 = reader[2].ToString(),
                        Team1Coef = Convert.ToDecimal(reader[3]),
                        Team2 = reader[4].ToString(),
                        Team2Coef = Convert.ToDecimal(reader[5]),
                        Winner = reader[6].ToString(),
                        EventEnd = reader[7].ToString()
                    };
                    eventL.Add(history);
                }
                return eventL;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
        #endregion
    }
}
