using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

namespace Chinen
{
	/// <summary>
	/// Ground contoller.
	/// </summary>
	public class BlockContoller : FactoryBehaviour
	{
		/// <summary>
		/// Use this for initialization.
		/// </summary>
		void Start ()
		{
			this.Create (1, 0);
			this.Create (1, 3);
			this.Create (8, 3);
			this.Create (9, 3);

			this.gameObject.AddComponent<ObservableUpdateTrigger>()
				.UpdateAsObservable()
				.SampleFrame(30)
				.Subscribe(
					_ => this.Check(),
					() => Debug.Log("destroy")
				);
		}

		/// <summary>
		/// Create the specified x and y.
		/// </summary>
		/// <param name="x">The x coordinate.</param>
		/// <param name="y">The y coordinate.</param>
		protected void Create (int x, int y)
		{
			GameObject go = Instantiate<GameObject> (base.prefab);	
			go.name = base.GetName ();
			Transform trans = go.transform;
			trans.SetParent (transform);
			trans.localPosition = new Vector3(
				firstPosX + x * size, firstPosY - y * size, 1);
			trans.localScale = Vector3.one;
		}

		/// <summary>
		/// Check the specified x and y.
		/// </summary>
		private void Check ()
		{
			// 爆発チェック.	
		}
	}
}
