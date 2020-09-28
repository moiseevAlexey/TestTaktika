using System;
using System.Collections;
using Taktika.Manager;
using UnityEngine;

namespace Taktika.Moving
{
    public class MoveAgent : MonoBehaviour
    {
        [SerializeField] protected float _speed;

        protected Waypoints _waypoints;
        protected int _currentPointIndex;

        public event Action PassIsPassed;

        protected virtual void Awake()
        {
            _currentPointIndex = 0;
        }

        protected virtual void Start()
        {
            _waypoints = LevelManager.Instance.Waypoints;
            transform.position = _waypoints.Points[0];

            StartCoroutine(PassWaypoints());
        }

        IEnumerator PassWaypoints()
        {
            while (_currentPointIndex < _waypoints.Points.Length - 1)
            {
                transform.forward = _waypoints.Points[_currentPointIndex + 1] - transform.position;

                transform.position = Vector3.MoveTowards(transform.position, _waypoints.Points[_currentPointIndex + 1], _speed * Time.deltaTime);
                if (transform.position == _waypoints.Points[_currentPointIndex + 1])
                {
                    _currentPointIndex++;
                }

                yield return null;
            }

            PassIsPassed?.Invoke();
        }
    }
}
