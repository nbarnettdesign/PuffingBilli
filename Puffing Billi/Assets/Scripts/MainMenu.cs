using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public SceneFader sceneFader;

	public string levelToLoad = "Main";
	
	// Update is called once per frame
	public void Play () {
		sceneFader.FadeTo (levelToLoad);
	}
}
