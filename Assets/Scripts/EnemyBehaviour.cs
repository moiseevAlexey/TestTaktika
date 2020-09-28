using System;
using Taktika.Config;
using Taktika.Damaging;
using Taktika.Manager;
using Taktika.Moving;
using UnityEngine;

namespace Taktika.Enemy
{
    [RequireComponent(typeof(MoveAgent)), RequireComponent(typeof(Damager)), RequireComponent(typeof(Damagable))]
    public class EnemyBehaviour : MonoBehaviour
    {
        public event Action<int> monsterDied;

        protected int _goldForKill;
        protected MoveAgent _moveAgent;
        protected Damager _damager;
        protected Damagable _damagable;
        protected Damagable _targetBase;

        public void Init(EnemyConfig config, Damagable targetBase)
        {
            _damagable.CurrentHP = config.hp;
            _damager.CurrentDamage = config.damage;
            _goldForKill = config.goldForKill;

            _goldForKill = config.goldForKill;

            _damager.CurrentDamagable = targetBase;
        }

        protected virtual void Awake()
        {
            _moveAgent = GetComponent<MoveAgent>();
            _damager = GetComponent<Damager>();
            _damagable = GetComponent<Damagable>();

            _moveAgent.PassIsPassed += BaseIsReached;
            _damagable.died += OnMonsterDied;

            monsterDied += LevelManager.Instance.PlayerBank.AddGold;
        }

        public void BaseIsReached()
        {
            _damager.MakeDamage();
            _damagable.Die();
        }

        public void OnMonsterDied(Damagable damagable)
        {
            monsterDied?.Invoke(_goldForKill);
        }
    }
}
