using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace Chinen
{
	/// <summary>
	/// Point controller.
	/// </summary>
	public class PointController : MonoBehaviour
	{
		[Header("合計値")]
		[SerializeField]
		private GUIText total;

		[Header("アイテム")]
		[SerializeField]
		private GUIText item;

		private static PointController mInstance;

		public static PointController instance {
			get {
				if (mInstance == false) {
					mInstance = FindObjectOfType<PointController> ();
				}
				return mInstance;
			}
		}

		/// <summary>
		/// Adds the coin.
		/// </summary>
		public void AddCoin ()
		{
			item.text = (Convert.ToInt32 (item.text) + 1).ToString ("00");
			total.text = (Convert.ToInt32 (total.text) + 100).ToString ("0000000");
		}
	}
}
