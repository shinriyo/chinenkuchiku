using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using X_UniTMX;

namespace chinen
{
	/// <summary>
	/// Camera controller.
	/// </summary>
	[RequireComponent (typeof(Camera))]
	public class CameraController : MonoBehaviour
	{
		[Header("ターゲット")]
		[SerializeField]
		private Transform target;

		[Header("止めるポジション")]
		[SerializeField]
		private Transform stopPosition;

		[Header("マップ")]
		[SerializeField]
		private TiledMapComponent map;

		[Header("シーン名")]
		[SceneName]
		[SerializeField]
		private string nextLevel;

		/// <summary>
		/// The m camera.
		/// </summary>
		private Camera mCamera;

		void Awake ()
		{
			this.mCamera = GetComponent<Camera> ();
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
			var tileWidth = this.map.TiledMap.TileWidth;
			var tileHeight = this.map.TiledMap.TileHeight;
			Debug.Log (tileWidth);
			Debug.Log (tileHeight);
		}

		/// <summary>
		/// Lates the update.
		/// </summary>
		void LateUpdate ()
		{
			var right = mCamera.ViewportToWorldPoint (Vector2.right);
			var center = mCamera.ViewportToWorldPoint (Vector2.one * 0.5f);

			if (center.x < target.position.x) {
				var pos = mCamera.transform.position;

				if (Math.Abs (pos.x - target.position.x) >= 0.0000001f) {
					mCamera.transform.position = new Vector3 (target.position.x, pos.y, pos.z);
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

//			Application.LoadLevel (nextLevel);
			SceneManager.LoadScene (nextLevel);
		}
	}
}
