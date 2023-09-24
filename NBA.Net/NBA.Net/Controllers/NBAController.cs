using Microsoft.AspNetCore.Mvc;
using NBA.Net.DB;
using NBA.Net.Helpers;
using NBA.Net.Models;

namespace NBA.Net.Controllers {
    public class NBAController : ControllerBase
    {

        [HttpGet]
        [Route("GetTableInfo")]
        public List<TableDto> GetTableInfo() {
            var dbConnection = new DBConnection();
            var builder = dbConnection.ConnectToDB();

            var teamList = new List<TableDto>();

            var helper = new NBAControllerHelper();
            var nbaTeams = helper.GetNBATeams(builder);
            var teamPlayers = helper.GetTeamPlayers(builder);
            var players = helper.GetPlayers(builder);
            var games = helper.GetGames(builder);

           
            foreach(var team in nbaTeams) {
                var teamListInfo = new TableDto();
                teamListInfo.Id = team.Id;
                teamListInfo.Name = team.Name;
                teamListInfo.Stadium = team.Stadium;
                teamListInfo.Logo = team.Logo;
                teamListInfo.URL = team.URL;
                teamListInfo.Played = 0;
                teamListInfo.PlayedHome = 0;
                teamListInfo.PlayedAway = 0;
                teamList.Add(teamListInfo);
                
            }

            //games played total, played home, played away
            foreach (var team in teamList) {
                //Played Total, Home & Away
                var playedHome = games.Where(x => x.HomeTeamID == team.Id).Count();
                var playedAway = games.Where(x => x.AwayTeamID == team.Id).Count();
                team.PlayedHome = playedHome;
                team.PlayedAway = playedAway;
                team.Played = playedHome + playedAway;

                //Games won
                var gamesWonHome = games.Where(x => x.HomeScore > x.AwayScore && x.HomeTeamID == team.Id).ToList();
                var gamesWonAway = games.Where(x => x.HomeScore < x.AwayScore && x.AwayTeamID == team.Id).ToList();
                var gamesWonCount = gamesWonHome.Count + gamesWonAway.Count;
                team.Won = gamesWonCount;

                //Biggest difference win
                var gamesWon = gamesWonHome.Concat(gamesWonAway);
                var winDiferenceList = new List<KeyValuePair<int, int>>();
                foreach(var gameWon in gamesWon) {
                    var difference = gameWon.HomeScore - gameWon.AwayScore;
                    winDiferenceList.Insert(0, new KeyValuePair<int, int>(gameWon.GameID, difference));
                }
                var biggestDiffernceWin = winDiferenceList.OrderByDescending(x => x.Value).First();
                var biggestDifferenceGameWin = games.Where(x => x.GameID == biggestDiffernceWin.Key);

                var homeScoreWin = biggestDifferenceGameWin.FirstOrDefault(x => x.HomeScore == x.HomeScore);
                var awayScoreWin = biggestDifferenceGameWin.FirstOrDefault(x => x.AwayScore == x.AwayScore);

                team.BiggestWin = $"{homeScoreWin?.HomeScore} - {awayScoreWin?.AwayScore}";


                //games lost
                var gamesLostHome = games.Where(x => x.HomeScore < x.AwayScore && x.HomeTeamID == team.Id).ToList();
                var gamesLostAway = games.Where(x => x.HomeScore > x.AwayScore && x.AwayTeamID == team.Id).ToList();
                var gamesLostCount = gamesLostHome.Count + gamesLostAway.Count;
                team.Lost = gamesLostCount;

                //biggest difference loss
                var gamesLost = gamesLostHome.Concat(gamesLostAway);
                var lossDiferenceList = new List<KeyValuePair<int, int>>();
                foreach (var gameLost in gamesLost) {
                    var difference = gameLost.AwayScore - gameLost.HomeScore;
                    lossDiferenceList.Insert(0, new KeyValuePair<int, int>(gameLost.GameID, difference));
                }
                var biggestDiffernceLoss = lossDiferenceList.OrderByDescending(x => x.Value).Last();
                var biggestDifferenceGameLoss = games.Where(x => x.GameID == biggestDiffernceLoss.Key);

                var homeScoreLoss = biggestDifferenceGameLoss.FirstOrDefault(x => x.HomeScore == x.HomeScore);
                var awayScoreLoss = biggestDifferenceGameLoss.FirstOrDefault(x => x.AwayScore == x.AwayScore);

                team.BiggestLoss = $"{homeScoreLoss?.AwayScore} - {awayScoreLoss?.HomeScore}";
            }

            //Last Game Stadium, Last Game Date
            foreach (var team in teamList) {
                var gamesHome = games.Where(x => x.HomeTeamID == team.Id);
                var gamesAway = games.Where(x => x.AwayTeamID == team.Id);
                var gamesTotal = gamesHome.Concat(gamesAway);

                var dates = gamesTotal.OrderBy(x => x.GameDateTime);
                team.LastGameDate = dates.Last().GameDateTime;

                if (team.Id == dates.Last().HomeTeamID) {
                    team.LastGameStadium = team.Stadium;
                } else if (team.Id == dates.Last().AwayTeamID) {
                    var homeTeam = nbaTeams.Where(x => x.Id == dates.Last().HomeTeamID);
                    team.LastGameStadium = homeTeam.FirstOrDefault().Stadium;
                }
            }

            return teamList;

        }
    }
}
