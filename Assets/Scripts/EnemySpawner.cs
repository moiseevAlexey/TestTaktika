using System.Collections;
using Taktika.Config;
using Taktika.Damaging;
using UnityEngine;

namespace Taktika.Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] protected GameObject _enemyObject;
        [SerializeField] protected Damagable _targetBase;
        [SerializeField] protected EnemyConfig _startEnemyConfig;
        [SerializeField] protected GameConfig _startGameConfig;
        [SerializeField] protected float _enemiesDelay;
        [SerializeField] protected int _startEnemyCount;
        [SerializeField] protected int _maxDelta;

        protected int _waveNumber;
        protected float _spawnsDelay;
        protected EnemyConfig _currentEnemyConfig;

        protected virtual void Awake()
        {
            _waveNumber = 0;
            _spawnsDelay = _startGameConfig.spawnsDelay;
            _currentEnemyConfig = _startEnemyConfig;
        }

        protected virtual void Start()
        {
            StartCoroutine(SpawnWaves());
        }

        IEnumerator SpawnEnemies(int enemiesCount)
        {
            for (int i = 0; i < enemiesCount; i++)
            {
                GameObject newEnemy = Instantiate(_enemyObject, transform);
                EnemyBehaviour enemy = newEnemy.GetComponent<EnemyBehaviour>();
                if (enemy == null)
                {
                    Debug.LogError("Spawned prefab doesn't have base attack component");
                }
                enemy.Init(_currentEnemyConfig, _targetBase);

                yield return new WaitForSeconds(_enemiesDelay);
            }
        }

        IEnumerator SpawnWaves()
        {
            while (true)
            {
                yield return StartCoroutine(SpawnEnemies(_waveNumber + _startEnemyCount + Random.Range(0, _maxDelta)));
                _waveNumber++;
                _currentEnemyConfig.UpgradeEnemies();
                yield return new WaitForSeconds(_spawnsDelay);
            }
        }
    }
}
