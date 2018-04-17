using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreLoad : MonoBehaviour
{
    GameManager gm;
	// Use this for initialization
	void Start () {
        gm = GameManager.instance;
	}
	
	// Update is called once per frame
	void Update ()
    {
        gm.SetState(State.PRELOAD);
	}
}
