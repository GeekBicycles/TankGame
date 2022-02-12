using UnityEngine;

namespace Tank_Game
{
    [CreateAssetMenu(fileName = "Data", menuName = "CreateScriptablePbject/Properties/CharacterSettings", order = 3)]

    public class CharacterData : ScriptableObject
    {

        [Range(0, 10)]
        public float Speed;

        [Range(0, 5)]
        public float Health;

        [Range(0, 10)]
        public float Damage;




    }
}
