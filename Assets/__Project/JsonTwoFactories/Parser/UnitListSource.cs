using System;
using System.Collections.Generic;

namespace JsonTwoFactories
{
    [Serializable]
    public sealed class UnitListSource
    {
        public List<UnitSource> root;

        public UnitListSource()
        {
            root = new List<UnitSource>();
        }
    }

}

