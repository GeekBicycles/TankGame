using System;

namespace JsonTwoFactories
{
    [Serializable]
    public sealed class UnitMag : Unit
    {
        public UnitMag(int health) : base(UnitType.Mag, health) { }
        public UnitMag() : base() { }
    }
}
