using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public interface IEnemyTank : ITank
    {
        /// <summary>
        /// Максимальный разброс точности
        /// </summary>
        public float maxAccuracy { get; set; }

        /// <summary>
        /// Текущий разброс точности
        /// </summary>
        public float currentAccuracy { get; set; }

        /// <summary>
        /// Скорость изменения точности
        /// </summary>
        public float changeAccuracy { get; set; }

    }
}
