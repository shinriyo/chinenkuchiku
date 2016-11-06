using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chinen
{
	public class FactoryBehaviour : MonoBehaviour
	{
		protected const float firstPosX = -34;
		protected const float firstPosY = 12;

		protected int id = 0;
		protected GameObject prefab = null;
		protected const float size = 2.0f;
		const string format = "ChinenMap/{0}";

		[SerializeField]
		protected string prefabName = "Name";

		[SerializeField]
		protected string nameFormat = "name_{0}";

		protected virtual void Awake ()
		{
			this.prefab = Resources.Load <GameObject> (
				string.Format (format, prefabName)
			);
		}

		/// <summary>
		/// Create the specified x and y.
		/// </summary>
		/// <param name="x">The x coordinate.</param>
		/// <param name="y">The y coordinate.</param>
		protected virtual void Create (int x, int y)
		{
		}
	}
}
