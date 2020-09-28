using Taktika.Manager;
using UnityEngine;
using UnityEngine.UI;

namespace Taktika.UI
{
    public class IntIndicator : MonoBehaviour
    {
        [SerializeField] protected Text _hp;
        [SerializeField] protected Text _money;

        protected virtual void Start()
        {
            LevelManager.Instance.Base.hpChanged += OnHpChanged;
            LevelManager.Instance.PlayerBank.goldChanged += OnGoldChanged;

            OnHpChanged(LevelManager.Instance.Base.CurrentHP);
            OnGoldChanged(LevelManager.Instance.PlayerBank.CurrentGold);
        }
        public void OnHpChanged(int hp)
        {
            _hp.text = "HP: " + hp.ToString();
        }

        public void OnGoldChanged(int money)
        {
            _money.text = "Gold: " + money.ToString();
        }
    }
}
