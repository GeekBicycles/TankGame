using UnityEngine;

namespace JsonTwoFactories
{
    public sealed class UnitFactory<T> where T : Unit, new()
    {
        private readonly string typeString;
        private readonly UnitType unitType;
        

        public UnitFactory(string typeString, UnitType unitType)
        {
            this.typeString = typeString;
            this.unitType = unitType;
        }

        public bool CanCreate(string typeString)
        {
            return string.Equals(this.typeString, typeString, System.StringComparison.OrdinalIgnoreCase);
        }

        public T Create(UnitInfoSource unitInfoSource)
        {
            if (!CanCreate(unitInfoSource.type)) return null;

            int.TryParse(unitInfoSource.health, out int health);

            T result =  new T();
            result.health = health;
            result.type = unitType;

            return result;
        }
    }
}
