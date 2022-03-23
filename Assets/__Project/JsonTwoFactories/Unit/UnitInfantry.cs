using System;

namespace JsonTwoFactories
{
    [Serializable]
    public sealed class UnitInfantry : Unit
    {
        public UnitInfantry(int health) : base (UnitType.Infantry, health) { }
        public UnitInfantry() : base () { }
    }
}
