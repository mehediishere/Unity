using UnityEngine;
using UnityEditor;

public class Colorizer : EditorWindow
{
	Color color;

	[MenuItem("Window/Colorizer")]
	public static void ShowWindow()
	{
		GetWindow<Colorizer>("Colorizer");
	}

	void OnGUI()
	{
		GUILayout.Label("Color the selected objects!", EditorStyles.boldLabel);

		color = EditorGUILayout.ColorField("Color", color);

		if (GUILayout.Button("COLORIZE!"))
		{
			Colorize();
		}
		if (GUILayout.Button("RANDOM COLORIZE!"))
		{
			GenerateColor();
		}
		if (GUILayout.Button("RESET COLORIZE!"))
		{
			Reset();
		}
	}

	void Colorize()
	{
		foreach (GameObject obj in Selection.gameObjects)
		{
			Renderer renderer = obj.GetComponent<Renderer>();
			if (renderer != null)
			{
				renderer.sharedMaterial.color = color;
			}
		}
	}
	public void GenerateColor()
	{
		foreach (GameObject obj in Selection.gameObjects)
		{
			Renderer renderer = obj.GetComponent<Renderer>();
			if (renderer != null)
			{
				renderer.sharedMaterial.color = Random.ColorHSV();
			}
		}
	}

	public void Reset()
	{
		foreach (GameObject obj in Selection.gameObjects)
		{
			Renderer renderer = obj.GetComponent<Renderer>();
			if (renderer != null)
			{
				renderer.sharedMaterial.color = Color.white;
			}
		}
	}
}
