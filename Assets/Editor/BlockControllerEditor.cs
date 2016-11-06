using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Chinen
{
	/// <summary>
	/// Block controller editor.
	/// </summary>
	[CustomEditor(typeof(BlockController))]
	public class BlockControllerEditor : Editor 
	{
		public override void OnInspectorGUI()
		{
			BlockController myTarget = (BlockController)target;

//			myTarget.experience = EditorGUILayout.IntField("Experience", myTarget.experience);
//			EditorGUILayout.LabelField("Level", myTarget.Level.ToString());
			EditorGUILayout.LabelField("Level", "1");
			if(GUILayout.Button("爆発"))
			{

			}
		}
	}
}
