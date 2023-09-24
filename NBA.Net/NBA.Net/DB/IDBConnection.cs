using Microsoft.Data.SqlClient;

namespace NBA.Net.DB {
    public interface IDBConnection {
        public SqlConnectionStringBuilder ConnectToDB();
    }
}
