using System;
using System.Runtime.Serialization;

namespace MyBetModel.Model
{
    [DataContract]
    public class History
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
        public string Winner { get; set; }

        [DataMember]
        public string EventEnd { get; set; }
    }
}
