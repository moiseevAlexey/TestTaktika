using Taktika.Manager;

namespace Taktika.Damaging
{
    public class BaseDeathAffector : DeathAffector
    {
        public override void Die()
        {
            LevelManager.Instance.DefeatScreen.gameObject.SetActive(true);
        }
    }
}
