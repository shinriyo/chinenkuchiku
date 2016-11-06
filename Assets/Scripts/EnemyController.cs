using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chinen
{
	/// <summary>
	/// Enemy controller.
	/// </summary>
	public class EnemyController : FactoryBehaviour
	{
		protected override string prefabName {
			get { 
				return "ChinenMap/Enemy";
			}
		}

		// Use this for initialization
		void Start ()
		{
			GameObject go = Instantiate<GameObject> (this.prefab);	
			go.name = string.Format ("item_{0}", 1);
			Transform trans = go.transform;
			trans.SetParent (transform);
			trans.localPosition = Vector3.zero;
			trans.localScale = new Vector3(1.5f, 1.5f, 1);
		}
	}
}
