using FDS.CRM.CrossCuttingConcerns.Helper;

namespace FDS.CRM.CrossCuttingConcerns.Cache.RedisCache
{
    public static class RedisConnection
    {
        public static readonly string conn = ConnectionHelper.RedisConn;
        public static readonly int databaseIndex = Convert.ToInt16(ConnectionHelper.RedisDbIndex);
        private static RedisCacheClient _securityDatabase;

        public static ICacheClient Connection
        {
            get
            {
                if (_securityDatabase == null)
                {
                    _securityDatabase = new RedisCacheClient(conn, null, databaseIndex);
                }
                return _securityDatabase;
            }
        }
    }

}
