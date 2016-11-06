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
		/// <summary>
		/// Use this for initialization.
		/// </summary>
		void Start ()
		{
			this.Create (0, 0);
		}

		/// <summary>
		/// Create the specified x and y.
		/// </summary>
		/// <param name="x">The x coordinate.</param>
		/// <param name="y">The y coordinate.</param>
		protected override void Create (int x, int y)
		{
			GameObject go = Instantiate<GameObject> (this.prefab);	
			go.name = string.Format ("enemy_{0}", id);
			id++;
			Transform trans = go.transform;
			trans.SetParent (transform);
			trans.localPosition = new Vector3(
				firstPosX + x * size, firstPosY - y * size, 1);
			trans.localScale = new Vector3(1.5f, 1.5f, 1);
		}
	}
}
