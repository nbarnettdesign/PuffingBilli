using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    private GameManager gm;
	// Use this for initialization
	void Start ()
    {
        gm = GameManager.instance;
        gm.GameState += SetupScene;
        gm.SetState(State.GAME);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void SetupScene()
    {

    }
}
