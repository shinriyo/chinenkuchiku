using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using X_UniTMX;

namespace Chinen
{
	/// <summary>
	/// Camera controller.
	/// </summary>
	[RequireComponent (typeof(Camera))]
	public class CameraController : MonoBehaviour
	{
		[Header ("ターゲット")]
		[SerializeField]
		private Transform target;

		[Header ("クリアの止めるポジション")]
		[SerializeField]
		private Transform stopPosition;

		[Header ("シーン名")]
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
		void Start ()
		{
		}

		/// <summary>
		/// Lates the update.
		/// </summary>
		void LateUpdate ()
		{
//			var right = mCamera.ViewportToWorldPoint (Vector2.right);
			var center = mCamera.ViewportToWorldPoint (Vector2.one * 0.5f);

			// 真ん中より右.
//			if (center.x < target.position.x)

//			if (center.x < target.position.x)
			{
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

		/// <summary>
		/// ステージクリア.
		/// </summary>
		/// <returns>The l clear.</returns>
		private IEnumerator INTERNAL_Clear ()
		{
			var player = GameObject.FindGameObjectWithTag ("Player");

			if (player) {
				player.SendMessage ("Clear", SendMessageOptions.DontRequireReceiver);
			}

			yield return new WaitForSeconds (3);

			SceneManager.LoadScene (nextLevel);
		}
	}
}
