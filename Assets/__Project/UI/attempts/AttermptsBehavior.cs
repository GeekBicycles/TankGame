using UnityEngine;
using UnityEngine.UI;

namespace Tank_Game
{
    public class AttermptsBehavior : MonoBehaviour, IAttermptsBehavior
    {
        [SerializeField] private Text _attempts;
        public Text attempts { get { return _attempts; } }
    }
}
