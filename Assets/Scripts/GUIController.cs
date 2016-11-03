using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chinen
{
	/// <summary>
	/// GUI controller.
	/// </summary>
	public class GUIController : MonoBehaviour
	{
		[Header("名前")]
		[SerializeField]
		private GUIText paleyrName;

		[Header("ステージ")]
		[SerializeField]
		private GUIText stage;

		/// <summary>
		/// Sets the name of the player.
		/// </summary>
		/// <param name="name">Name.</param>
		public void SetPlayerName(string name)
		{
			this.paleyrName.text = name;
		}

		/// <summary>
		/// Sets the stage.
		/// </summary>
		/// <param name="area">Area.</param>
		/// <param name="stage">Stage.</param>
		public void SetStage(int area, int stage)
		{
			this.stage.text = string.Format("{0}-{1}", area, stage);
		}
	}
}
