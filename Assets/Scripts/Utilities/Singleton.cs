using UnityEngine;

namespace Taktika.Utilities
{
	public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
	{
		protected static T _instance = null;

		public static T Instance
		{
			get
			{
				return _instance;
			}
			protected set
			{
				_instance = value;
			}
		}

		protected virtual void Awake()
		{
			if (_instance != null)
			{
				Destroy(gameObject);
			}
			else
			{
				_instance = (T)this;
			}
		}

		protected virtual void OnDestroy()
		{
			if (_instance == this)
			{
				_instance = null;
			}
		}
	}
}
