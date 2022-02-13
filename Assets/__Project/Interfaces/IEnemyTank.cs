using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank_Game
{
    public interface IEnemyTank : ITank
    {
        /// <summary>
        /// ������������ ������� ��������
        /// </summary>
        public float maxAccuracy { get; set; }

        /// <summary>
        /// ������� ������� ��������
        /// </summary>
        public float currentAccuracy { get; set; }

        /// <summary>
        /// �������� ��������� ��������
        /// </summary>
        public float changeAccuracy { get; set; }

    }
}
