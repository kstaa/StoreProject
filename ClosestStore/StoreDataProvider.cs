using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace ClosestStore
{
    public class StoreDataProvider : IStoreData
    {

        private readonly List<StoreLocation> _storeData = new List<StoreLocation>();

        public StoreDataProvider()
        {
            using (NpgsqlConnection conn =
                new NpgsqlConnection(
                    "Server=localhost;Port=5432;UserId=TestAcct;Password=Test1;Database=StoreFinder;"))
            {
                conn.Open();

                var command = new NpgsqlCommand("select \"StoreNumber\", \"Latitude\", \"Longitude\"" +
                                                "from \"StoreZip\" a, \"USZip\" b where a.\"StoreZipCode\" = b.\"Zip\"",
                    conn);

                using (NpgsqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var storeNum = dr.GetDecimal(0);
                        Decimal latitude = dr.GetDecimal(1);
                        Decimal longitude = dr.GetDecimal(2);
                        var spoint = new StoreLocation(storeNum, latitude, longitude);
                        _storeData.Add(spoint);
                    }
                }
            }
        }

        //The implementation method returning StoreLocation objects
        public List<StoreLocation> GetStores()
        {
            return _storeData;
        }

    }
}
