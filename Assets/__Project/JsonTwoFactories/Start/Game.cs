using System.Collections.Generic;

namespace JsonTwoFactories
{
    public sealed class Game
    {
        public UnitListSource unitSources;

        public void Start(Starter starter)
        {
            unitSources = new DataSourceReader().ReadSource(new DataSource());

            starter.units = new Factory().CreateUnits(unitSources);
        }

    }
}
