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
	public class GroundContoller : FactoryBehaviour
	{
		const float firstPosX = -34;
		const float firstPosY = 12;

		/// <summary>
		/// Use this for initialization.
		/// </summary>
		void Start ()
		{
			Create (1, 0);
			Create (1, 3);
			Create (8, 3);
			Create (9, 3);

			this.gameObject.AddComponent<ObservableUpdateTrigger>()
				.UpdateAsObservable()
				.SampleFrame(30)
				.Subscribe(
					_ => this.Check(),
					() => Debug.Log("destroy")
				);
		}

		private void Create (int x, int y)
		{
			GameObject go = Instantiate<GameObject> (base.prefab);	
			go.name = string.Format ("block_{0}", id);
			id++;
			Transform trans = go.transform;
			trans.SetParent (transform);
			trans.localPosition = new Vector3(
				firstPosX + x * 2, firstPosY - y * 2, 1);
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
