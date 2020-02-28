using System;
using System.Runtime.Serialization;


namespace MyBetModel.Model
{
    [DataContract]
    public class Bet
    {
        [DataMember]
        public int BetId { get; set; }

        [DataMember]
        public DateTime DateBet { get; set; }

        [DataMember]
        public decimal SumBet { get; set; }

        [DataMember]
        public decimal CoefBet { get; set; }

        [DataMember]
        public decimal SumWinBet { get; set; }
        [DataMember]
        public int UserId { get; set; }
        [DataMember]
        internal virtual User User { get; set; }

        [DataMember]
        public int EventId { get; set; }
        [DataMember]
        internal virtual EventBet Event { get; set; }

        [DataMember]
        public string Team { get; set; }
    }
}
