using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Chinen
{
	/// <summary>
	/// Item controller.
	/// </summary>
	public class ItemController : MonoBehaviour
	{
		[SerializeField]
		private AudioClip getCoin;

		/// <summary>
		/// Raises the trigger enter2 d event.
		/// </summary>
		/// <param name="other">Other.</param>
		void OnTriggerEnter2D (Collider2D other)
		{
			if (other.tag == "Player") {
				PointController.instance.AddItem ();
				AudioSourceController.instance.PlayOneShot (getCoin);
				Destroy (gameObject);
			}
		}
	}
}
