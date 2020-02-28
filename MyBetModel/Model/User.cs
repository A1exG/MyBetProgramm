using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MyBetModel.Model
{
    [DataContract]
    public class User
    {
        [DataMember]
        public int UserId { get; set; }
        [DataMember]
        public string SurName { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string SecondName { get; set; }
        [DataMember]
        public DateTime Birthday { get; set; }
        [DataMember]
        public decimal Balance { get; set; }
        [DataMember]
        public string UserLogin { get; set; }
        [DataMember]
        public string UserPass { get; set; }
        [DataMember]
        internal virtual ICollection<Bet> Bets { get; set; }
    }
}
