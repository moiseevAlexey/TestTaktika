using UnityEngine;

namespace Taktika.Moving
{
    public class Waypoints : MonoBehaviour
    {
        public Vector3[] Points { get; private set; }

        protected virtual void Awake()
        {
            Points = new Vector3[transform.childCount];
            for (int i = 0; i < transform.childCount; i++)
            {
                Points[i] = transform.GetChild(i).position;
            }
        }
    }
}
