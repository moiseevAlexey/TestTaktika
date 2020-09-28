using UnityEngine;

namespace Taktika.Damaging
{
    public class DeathAffector : MonoBehaviour
    {
        public virtual void Die()
        {
            Destroy(gameObject);
        }
    }
}
