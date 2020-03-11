using System.Runtime.Serialization;


namespace MyBetModel.Model
{
    [DataContract]
    public class Result
    {
        [DataMember]
        public int ResultId { get; set; }
        [DataMember]
        public int EventId { get; set; }
        [DataMember]
        internal virtual EventBet Event { get; set; }
        [DataMember]
        public string WinnerTeam { get; set; }

        public Result(int eventId, string winnerTeam)
        {
            EventId = eventId;
            WinnerTeam = winnerTeam;
        }
    }
}
