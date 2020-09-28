using System;
using UnityEngine;

namespace Taktika.Damaging
{
    [RequireComponent (typeof(DeathAffector))]
    public class Damagable : MonoBehaviour
    {
        public int CurrentHP { get; set; }

        [SerializeField] protected int _defaultHP;

        public event Action<Damagable> died;
        public event Action<Damagable> destroyed;
        public event Action<int> hpChanged;

        protected DeathAffector _deathAffector;

        protected virtual void Awake()
        {
            CurrentHP = _defaultHP;

            _deathAffector = GetComponent<DeathAffector>();
        }

        public void TakeDamage(int damage)
        {
            CurrentHP -= damage;

            hpChanged?.Invoke(CurrentHP);

            if (CurrentHP <= 0)
            {
                Die();
            }
        }

        public void Die()
        {
            died?.Invoke(this);
            _deathAffector.Die();
        }

        protected virtual void OnDestroy()
        {
            destroyed?.Invoke(this);
        }
    }
}
