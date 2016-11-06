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
		// Use this for initialization
		void Start ()
		{
			this.Create (1, 3);
		}

		/// <summary>
		/// Create the specified x and y.
		/// </summary>
		/// <param name="x">The x coordinate.</param>
		/// <param name="y">The y coordinate.</param>
		protected override void Create (int x, int y)
		{
			GameObject go = Instantiate<GameObject> (this.prefab);	
			go.name = string.Format ("item_{0}", id);
			id++;
			Transform trans = go.transform;
			trans.SetParent (transform);
			trans.localPosition = new Vector3 (
				firstPosX + x * size, firstPosY - y * size, 1);
			trans.localScale = Vector3.one;
		}
	}
}
