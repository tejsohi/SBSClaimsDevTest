using Microsoft.Data.SqlClient;
using NBA.Net.Models;

namespace NBA.Net.Helpers {
    public class NBAControllerHelper {


        public List<NBATeamDto> GetNBATeams(SqlConnectionStringBuilder builder) {
            var NBATeamsList = new List<NBATeamDto>();
            using (SqlConnection connection = new SqlConnection(builder.ConnectionString)) {

                connection.Open();
                string NBATeamsQuery = "SELECT * FROM [NBA].[dbo].[Teams]";

                using (SqlCommand command = new SqlCommand(NBATeamsQuery, connection)) {
                    using (SqlDataReader reader = command.ExecuteReader()) {
                        while (reader.Read()) {
                            var nbaTeam = new NBATeamDto();
                            nbaTeam.Id = reader.GetInt32(0);
                            nbaTeam.Name = reader.GetString(1);
                            nbaTeam.Stadium = reader.GetString(2);
                            nbaTeam.Logo = reader.GetString(3);
                            nbaTeam.URL = reader.GetString(4);

                            NBATeamsList.Add(nbaTeam);
                        }
                    }
                }
            }
            return NBATeamsList;
        }

        public List<TeamPlayerDto> GetTeamPlayers(SqlConnectionStringBuilder builder) {
            var TeamPlayersList = new List<TeamPlayerDto>();

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString)) {
                connection.Open();
                string NBATeamPlayerQuery = "SELECT * FROM [NBA].[dbo].[Team_Player]";

                using (SqlCommand command = new SqlCommand(NBATeamPlayerQuery, connection)) {
                    using (SqlDataReader reader = command.ExecuteReader()) {
                        while (reader.Read()) {
                            var teamPlayer = new TeamPlayerDto();
                            teamPlayer.TeamID = reader.GetInt32(0);
                            teamPlayer.PlayerID = reader.GetInt32(1);
                            TeamPlayersList.Add(teamPlayer);
                        }
                    }
                }
            }
            return TeamPlayersList;
        }

        public List<PlayersDto> GetPlayers(SqlConnectionStringBuilder builder) {
            var PlayersList = new List<PlayersDto>();

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString)) {
                connection.Open();
                string NBATeamPlayerQuery = "SELECT * FROM [NBA].[dbo].[Players]";

                using (SqlCommand command = new SqlCommand(NBATeamPlayerQuery, connection)) {
                    using (SqlDataReader reader = command.ExecuteReader()) {
                        while (reader.Read()) {
                            var teamPlayer = new PlayersDto();
                            teamPlayer.PlayerID = reader.GetInt32(0);
                            teamPlayer.PlayerName = reader.GetString(1);
                            PlayersList.Add(teamPlayer);
                        }
                    }
                }
            }
            return PlayersList;
        }

        public List<GamesDto> GetGames(SqlConnectionStringBuilder builder) {
            var GamesList = new List<GamesDto>();

            using (SqlConnection connection = new SqlConnection(builder.ConnectionString)) {
                connection.Open();
                string NBATeamPlayerQuery = "SELECT * FROM [NBA].[dbo].[Games]";

                using (SqlCommand command = new SqlCommand(NBATeamPlayerQuery, connection)) {
                    using (SqlDataReader reader = command.ExecuteReader()) {
                        while (reader.Read()) {
                            var teamPlayer = new GamesDto();
                            teamPlayer.GameID = reader.GetInt32(0);
                            teamPlayer.HomeTeamID = reader.GetInt32(1);
                            teamPlayer.AwayTeamID = reader.GetInt32(2);
                            teamPlayer.GameDateTime = reader.GetDateTime(3);
                            teamPlayer.HomeScore = reader.GetInt32(4);
                            teamPlayer.AwayScore = reader.GetInt32(5);
                            teamPlayer.MVPPlayerId = reader.GetInt32(6);
                            GamesList.Add(teamPlayer);
                        }
                    }
                }
            }
            return GamesList;
        }
    }
}
