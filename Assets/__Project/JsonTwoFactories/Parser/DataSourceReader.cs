using UnityEngine;

namespace JsonTwoFactories
{
    public sealed class DataSourceReader
    {
        private const string DATA_BEGIN = "{ \"root\" : ";
        private const string DATA_END = " }";

        public DataSourceReader()
        {
        }

        public UnitListSource ReadSource(DataSource dataSource)
        {
            string loadString = DATA_BEGIN + dataSource.GetText() + DATA_END;
            return JsonUtility.FromJson<UnitListSource>(loadString);
        }
    }
}
