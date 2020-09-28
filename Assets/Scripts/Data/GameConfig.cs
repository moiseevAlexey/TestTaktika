using UnityEngine;

namespace Taktika.Config
{
    [CreateAssetMenu(fileName = "GameConfig", menuName = "ScriptableObjects/GameConfig", order = 2)]
    public class GameConfig : ScriptableObject
    {
        public float spawnsDelay;
    }
}
