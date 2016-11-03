using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
class ProjectEditor
{
	/// <summary>
	/// Initializes the <see cref="ProjectEditor"/> class.
	/// </summary>
	static ProjectEditor ()
	{
		EditorApplication.projectWindowItemOnGUI += ProjectWindowListElementOnGUI;
	}

	/// <summary>
	/// Projects the window list element on GU.
	/// </summary>
	/// <param name="guid">GUID.</param>
	/// <param name="selectionRect">Selection rect.</param>
	static void ProjectWindowListElementOnGUI (string guid, Rect selectionRect)
	{
		GUI.Label (new Rect (10, Screen.height - 100, Screen.width - 20, 30), "projectWindowItemOnGUI");
		if (GUI.Button (new Rect (10, Screen.height - 75, Screen.width - 20, 30), "test")) {
			Debug.Log ("hoge");
		}
	}
}