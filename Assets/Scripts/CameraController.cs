using System;
using System.Collections;
using UnityEngine;
using X_UniTMX;

namespace chinen
{
	[RequireComponent (typeof(Camera))]
	public class CameraController : MonoBehaviour
	{
		[Header("ターゲット")]
		[SerializeField]
		private Transform target;

		[Header("ポジション")]
		[SerializeField]
		private Transform stopPosition;

		[Header("マップ")]
		[SerializeField]
		private TiledMapComponent map;

		[Header("シーン名")]
		[SceneName]
		[SerializeField]
		private string nextLevel;

		private Camera m_camera;

		void Awake ()
		{
			m_camera = GetComponent<Camera> ();
		}

		/// <summary>
		/// Start this instance.
		/// </summary>
		void Start()
		{
			var width = this.map.TiledMap.Width;
			var height = this.map.TiledMap.Height;
			Debug.Log (width);
			Debug.Log (height);
		}

		void LateUpdate ()
		{
			var right = m_camera.ViewportToWorldPoint (Vector2.right);
			var center = m_camera.ViewportToWorldPoint (Vector2.one * 0.5f);

			if (center.x < target.position.x) {
				var pos = m_camera.transform.position;

				if (Math.Abs (pos.x - target.position.x) >= 0.0000001f) {
					m_camera.transform.position = new Vector3 (target.position.x, pos.y, pos.z);
				}
			}

			/*
			if (stopPosition.position.x - right.x < 0) {
				StartCoroutine (INTERNAL_Clear ());
				enabled = false;
			}
			*/
		}

		private IEnumerator INTERNAL_Clear ()
		{
			var player = GameObject.FindGameObjectWithTag ("Player");

			if (player) {
				player.SendMessage ("Clear", SendMessageOptions.DontRequireReceiver);
			}

			yield return new WaitForSeconds (3);

			Application.LoadLevel (nextLevel);
		}
	}
}
