﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

    public GameObject pauseMenu;
    public Button pause;
    public Button resume;
    public Text score;
    public Text pauseScore;


    public void Pause()
    {
        pauseMenu.gameObject.SetActive(true);
        pauseScore.text = score.text;
        Time.timeScale = 0;
    }

    public void Resume()
    {
        Time.timeScale = 1;
        pauseMenu.gameObject.SetActive(false);
    }


    // Update is called once per frame
    void Update () {
		
	}
}
