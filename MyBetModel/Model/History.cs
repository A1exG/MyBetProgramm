using System;
using System.Runtime.Serialization;

namespace MyBetModel.Model
{
    [DataContract]
    public class History
    {
        [DataMember]
        public int HistoryId { get; set; }
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
        public string Winner { get; set; }

        [DataMember]
        public string EventEnd { get; set; }

        public History(int eventId, DateTime dateEvent, string team1, decimal team1Coef, string team2, decimal team2Coef, string winner, string eventEnd)
        {
            EventId = eventId;
            DateEvent = dateEvent;
            Team1 = team1;
            Team1Coef = team1Coef;
            Team2 = team2;
            Team2Coef = team2Coef;
            Winner = winner;
            EventEnd = eventEnd;
        }
    }
}
