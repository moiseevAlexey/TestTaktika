using UnityEngine;

namespace Taktika.Config
{
    [CreateAssetMenu(fileName = "EnemyConfig", menuName = "ScriptableObjects/EnemyConfig", order = 1)]
    public class EnemyConfig : ScriptableObject
    {
        public int hp;
        public int damage;
        public int goldForKill;

        public void UpgradeEnemies()
        {
            //Sorry for magic numbers
            if (Random.Range(0f, 1f) > 0.5)
            {
                hp++;
            }
            if (Random.Range(0f, 1f) > 0.5)
            {
                damage++;
            }
            if (Random.Range(0f, 1f) > 0.5)
            {
                goldForKill++;
            }
        }
    }
}
