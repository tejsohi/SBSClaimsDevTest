namespace NBA.Net.Models {
    public class GamesDto {
        public int GameID { get; set; }
        public int? HomeTeamID { get; set; }
        public int AwayTeamID { get; set; }
        public DateTime GameDateTime { get; set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set;}
        public int? MVPPlayerId { get; set; }
        public string MVP { get; set; }
    }
}
