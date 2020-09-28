using Taktika.Damaging;
using UnityEngine;

namespace Taktika.Tower
{
    [RequireComponent(typeof(Damager)), RequireComponent (typeof(TowerTargeter))]
    public class TowerBehaviour : MonoBehaviour
    {
        [SerializeField] protected float _attackSpeed;

        protected float _currentAttackCount;
        protected bool _isCanAttack;
        protected Damager _damager;
        protected TowerTargeter _towerTargeter;

        protected virtual void Awake()
        {
            _currentAttackCount = 0;
            _isCanAttack = false;

            _damager = GetComponent<Damager>();
            _towerTargeter = GetComponent<TowerTargeter>();

            _towerTargeter.targetArrived += TargetArrived;
            _towerTargeter.targetLost += TargetLost;
        }

        protected virtual void Update()
        {
            if (_isCanAttack)
            {
                _currentAttackCount += _attackSpeed * Time.deltaTime;
                while (_currentAttackCount >= 1f)
                {
                    _damager.CurrentDamagable = _towerTargeter.CurrentTarget;
                    _damager.MakeDamage();
                    _currentAttackCount -= 1f;
                }
            }
        }

        protected void TargetArrived()
        {
            _isCanAttack = true;
        }

        protected void TargetLost()
        {
            _isCanAttack = false;
            _currentAttackCount = 0;
        }
    }
}
