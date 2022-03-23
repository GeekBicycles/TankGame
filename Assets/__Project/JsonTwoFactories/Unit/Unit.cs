using System;

namespace JsonTwoFactories
{
    [Serializable]
    public class Unit
    {
        public UnitType type;
        public int health;

        public Unit(UnitType type, int health)
        {
            this.type = type;
            this.health = health;
        }

        public Unit()
        {

        }
    }
}
