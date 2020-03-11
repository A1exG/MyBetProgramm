using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MyBetModel.Model
{
    [DataContract]
    public class EventBet
    {
        [DataMember]
        public int EventId { get; set; }
        [DataMember]
        public DateTime DateEvent { get; set; }

        [DataMember]
        public string Team1 { get; set; }

        [DataMember]
        public decimal Team1Coef { get; set; }

        [DataMember]
        public string Team2 { get; set; }

        [DataMember]
        public decimal Team2Coef { get; set; }

        [DataMember]
        internal virtual ICollection<Bet> Bets { get; set; }

        [DataMember]
        internal virtual ICollection<Result> Results { get; set; }

        public EventBet(DateTime dateEvent, string team1, decimal team1Coef, string team2, decimal team2Coef)
        {
            DateEvent = dateEvent;
            Team1 = team1;
            Team1Coef = team1Coef;
            Team2 = team2;
            Team2Coef = team2Coef;
        }
        public EventBet()
        {

        }
    }
}
