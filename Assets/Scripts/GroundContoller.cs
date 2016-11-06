using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace chinen
{
	/// <summary>
	/// Ground contoller.
	/// </summary>
	public class GroundContoller : MonoBehaviour
	{
		GameObject prefab;
		void Awake ()
		{
			this.prefab = Resources.Load <GameObject>("ChinenMap/block");
		}

		// Use this for initialization
		void Start ()
		{
			GameObject go = Instantiate<GameObject> (this.prefab);	
			go.name = string.Format("block_{0}", 1);
			Transform trans = go.transform;
			trans.SetParent(transform);
			trans.localPosition = Vector3.zero;
			trans.localScale = Vector3.one;
		}
	
		// Update is called once per frame
		void Update ()
		{
		
		}
	}
}
