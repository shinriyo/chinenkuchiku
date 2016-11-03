using UnityEngine;
using System.Collections;
using UniRx;

namespace chinen
{
	/// <summary>
	/// Start controller.
	/// </summary>
	[RequireComponent (typeof(AudioSource))]
	public class StartController : MonoBehaviour
	{
		[SceneName]
		[SerializeField]
		/// <summary>
		/// The next level.
		/// </summary>
		private string nextLevel;

		[SerializeField]
		/// <summary>
		/// The enter.
		/// </summary>
		private KeyCode enter = KeyCode.X;

		void Awake ()
		{
			IObservable<long> clickStream = Observable
				.EveryUpdate ()
				.Where (_ => Input.GetMouseButtonDown (0)); // 左クリックしたフレームだけに
//			clickStream.Subscribe (_ => Load ()).AddTo (gameObject);
		}


		/// <summary>
		/// Update this instance.
		/// </summary>
		void Update ()
		{
		}

		private void Load ()
		{
			StartCoroutine (LoadStage ());
		}

		/// <summary>
		/// Loads the stage.
		/// </summary>
		/// <returns>The stage.</returns>
		private IEnumerator LoadStage ()
		{
			foreach (AudioSource audioS in FindObjectsOfType<AudioSource>()) {
				audioS.volume = 0.2f;
			}

			AudioSource audioSource = GetComponent<AudioSource> ();
			audioSource.volume = 1;
			audioSource.Play ();

			yield return new WaitForSeconds (audioSource.clip.length + 0.5f);
			Application.LoadLevel (nextLevel);
		}
	}
}
