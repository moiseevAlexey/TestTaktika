using System.Collections;
using System.Collections.Generic;
using Taktika.Damaging;
using Taktika.Enemy;
using Taktika.Money;
using Taktika.Moving;
using Taktika.UI;
using Taktika.Utilities;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Taktika.Manager
{
    public class LevelManager : Singleton<LevelManager>
    {
        [SerializeField] protected string _gameSceneName;
        [SerializeField] protected Waypoints _waypoints;
        [SerializeField] protected PlayerBank _playerBnk;
        [SerializeField] protected EnemySpawner _enemySpawner;
        [SerializeField] protected Damagable _base;
        [SerializeField] protected DefeatScreen _defeatScreen;

        public Waypoints Waypoints { get { return _waypoints; } }

        public PlayerBank PlayerBank { get { return _playerBnk; } }

        public EnemySpawner EnemySpawner { get { return _enemySpawner; } }

        public Damagable Base { get { return _base; } }

        public DefeatScreen DefeatScreen { get { return _defeatScreen; } }

        public void RestartGame()
        {
            SceneManager.LoadScene(_gameSceneName);
        }
    }
}
