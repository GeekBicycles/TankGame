using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JsonTwoFactories
{
    public sealed class Factory
    {
        private UnitFactory<UnitMag> magFactory;
        private UnitFactory<UnitInfantry> infantryFactory;

        public Factory()
        {
            magFactory = new UnitFactory<UnitMag>("mag", UnitType.Mag);
            infantryFactory = new UnitFactory<UnitInfantry>("infantry", UnitType.Infantry);
        }

        public List<Unit> CreateUnits(UnitListSource unitListSource)
        {
            List<Unit> list = new List<Unit>();

            foreach(UnitSource unitSource in unitListSource.root) 
            { 
                if (magFactory.CanCreate(unitSource.unit.type))
                {
                    list.Add(magFactory.Create(unitSource.unit));
                } 
                else if (infantryFactory.CanCreate(unitSource.unit.type))
                {
                    list.Add(infantryFactory.Create(unitSource.unit));
                }
            }

            return list;
        }
    }
}
