using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chinen
{
	/// <summary>
	/// Factory behaviour.
	/// </summary>
	public class FactoryBehaviour : MonoBehaviour
	{
		protected const float firstPosX = -34;
		protected const float firstPosY = 12;

		protected GameObject prefab = null;
		protected const float size = 2.0f;
		const string prefabFormat = "ChinenMap/{0}";

		[SerializeField]
		protected string prefabName = "Name";

		[SerializeField]
		protected string nameFormat = "name_{0}";

		private int id = 0;
		protected virtual void Awake ()
		{
			this.prefab = Resources.Load <GameObject> (
				string.Format (prefabFormat, prefabName)
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

		/// <summary>
		/// Gets the name.
		/// </summary>
		/// <returns>The name.</returns>
		protected string GetName ()
		{
			string objName = string.Format (nameFormat, this.id);
			this.id++;
			return objName;
		}
	}
}
