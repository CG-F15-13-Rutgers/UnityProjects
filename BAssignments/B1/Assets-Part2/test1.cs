using UnityEngine;
using System.Collections;

public class test1 : MonoBehaviour 
{

	public static int lkl;
	bool paused;

	// Use this for initialization

	//var guiSkin : GUISkin;
	//var MainMenu = Rect(10, 10, 200, 200);


	void Start () 
	{
		lkl = 10;
		paused = false;
	}
	
	void OnGUI()
	{



		if (GUI.Button (new Rect (10, 10, 50, 50), "Pause")) {

			paused = true;
			//Time.timeScale = 0;

			GUI.Box(new Rect (20, 20, 300, 250), "");
			/*if(GUI.Button(new Rect(55, 100, 180, 40), "Resume")) 
			{
				Time.timeScale = 1;
			}*/

		}
		if (GUILayout.Button ("Restart")) {

		}
	}
}
