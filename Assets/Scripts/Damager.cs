using UnityEngine;

namespace Taktika.Damaging
{
    public class Damager : MonoBehaviour
    {
        [SerializeField] protected int _defaultDamage;

        public int CurrentDamage { get; set; }
        public Damagable CurrentDamagable { get; set; }

        private void Awake()
        {
            CurrentDamage = _defaultDamage;
        }

        public void MakeDamage()
        {
            CurrentDamagable.TakeDamage(CurrentDamage);
        }
    }
}
