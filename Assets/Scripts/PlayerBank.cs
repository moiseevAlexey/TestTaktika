using System;
using UnityEngine;

namespace Taktika.Money
{
    public class PlayerBank : MonoBehaviour
    {
        [SerializeField] protected int _startGold;

        public int CurrentGold { get; private set; }
        public int CurrentKilledEnemies { get; private set; }

        public event Action<int> goldChanged;

        protected virtual void Awake()
        {
            CurrentGold = _startGold;
            CurrentKilledEnemies = 0;
        }

        public void AddGold(int money)
        {
            CurrentKilledEnemies++;
            CurrentGold += money;
            goldChanged?.Invoke(CurrentGold);
        }
    }
}
