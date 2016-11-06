using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chinen
{
	public class FactoryBehaviour : MonoBehaviour
	{
		protected GameObject prefab = null;

		protected virtual string prefabName {
			get { 
				return "";
			}
		}

		protected virtual void Awake ()
		{
			this.prefab = Resources.Load <GameObject> (prefabName);
		}
	}
}
