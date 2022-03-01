namespace JsonTwoFactories
{
    public sealed class DataSource
    {
        private const string DATA_TEXT = "[ { \"unit\": { \"type\": \"mag\", \"health\": \"100\" }}, { \"unit\": { \"type\": \"infantry\", \"health\": \"150\" }}, { \"unit\": { \"type\": \"mag\", \"health\": \"50\" } } ]";

        public string GetText()
        {
            return DATA_TEXT;
        }
    }
}
