using UnityEngine;
using System.Collections;

namespace chinen
{
	/// <summary>
	/// Loading controller.
	/// </summary>
	public class LoadingController : MonoBehaviour
	{
		[SceneName]
		public string nextLevel;

		IEnumerator Start ()
		{
			yield return new WaitForSeconds (3);

			Application.LoadLevel (nextLevel);
		}
	}
}
