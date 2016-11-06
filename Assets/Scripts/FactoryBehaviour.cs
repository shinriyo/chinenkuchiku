using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chinen
{
	public class FactoryBehaviour : MonoBehaviour
	{
		protected int id = 0;
		protected GameObject prefab = null;
		const string format = "ChinenMap/{0}";

		[SerializeField]
		protected string prefabName;

		protected virtual void Awake ()
		{
			this.prefab = Resources.Load <GameObject> (
				string.Format(format, prefabName)
			);
		}
	}
}
