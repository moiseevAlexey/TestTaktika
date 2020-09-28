using Taktika.Manager;
using UnityEngine;
using UnityEngine.UI;

namespace Taktika.UI
{
    public class DefeatScreen : MonoBehaviour
    {
        [SerializeField] protected Text _killedEnemies;

        protected virtual void OnEnable()
        {
            _killedEnemies.text = "Enemies killed: " + LevelManager.Instance.PlayerBank.CurrentKilledEnemies.ToString();
        }

        public void Restart()
        {
            LevelManager.Instance.RestartGame();
        }
    }
}
