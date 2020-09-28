using System;
using System.Collections.Generic;
using Taktika.Damaging;
using UnityEngine;

namespace Taktika.Tower
{
    [RequireComponent (typeof(SphereCollider))]
    public class TowerTargeter : MonoBehaviour
    {
        [SerializeField] protected float _radius;

        public Damagable CurrentTarget { get; private set; }

        public event Action targetArrived;
        public event Action targetLost;

        protected LinkedList<Damagable> _possibleTargets;

        protected virtual void Awake()
        {
            _possibleTargets = new LinkedList<Damagable>();
            GetComponent<SphereCollider>().radius = _radius;
        }

        protected virtual void OnTriggerEnter(Collider other)
        {
            Damagable damagable = other.GetComponent<Damagable>();
            if (damagable != null && IsDamagableValid(damagable))
            {
                _possibleTargets.AddLast(damagable);
                damagable.destroyed += OnDamagableDestroyed;
            }

            if (CurrentTarget == null)
            {
                CurrentTarget = damagable;
                targetArrived?.Invoke();
            }
        }

        protected virtual void OnTriggerExit(Collider other)
        {
            Damagable damagable = other.GetComponent<Damagable>();
            if (damagable != null && IsDamagableValid(damagable))
            {
                RemoveTarget(damagable);
            }
        }

        protected void RemoveTarget(Damagable damagable)
        {
            _possibleTargets.Remove(damagable);

            if (CurrentTarget == damagable)
            {
                if (_possibleTargets.Count > 0)
                {
                    CurrentTarget = _possibleTargets.Last.Value;
                }
                else
                {
                    CurrentTarget = null;
                    targetLost?.Invoke();
                }
            }
        }

        protected virtual bool IsDamagableValid(Damagable damagable)
        {
            return damagable.tag == "Enemy" ? true : false;
        }

        protected void OnDamagableDestroyed(Damagable damagable)
        {
            RemoveTarget(damagable);
        }
    }
}
