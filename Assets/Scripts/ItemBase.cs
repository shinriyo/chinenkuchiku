using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chinen
{
	/// <summary>
	/// Item base.
	/// </summary>
	public class ItemBase : FactoryBehaviour
	{
		protected override string prefabName {
			get { 
				return "ChinenMap/Item";
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
			trans.localScale = Vector3.one;
		}
	}
}
