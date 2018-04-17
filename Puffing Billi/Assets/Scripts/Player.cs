using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Game game;
    private Size mySize;
	// Use this for initialization
	void Start ()
    {
        mySize = Size.SIZE_1;
        game = Game.instance;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void SetSize(Size a_size)
    {
        mySize = a_size;
    }
    public Size GetSize()
    {
        return mySize;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Fish>().GetSize() > mySize)
        {
            game.PlayerKilled();
        }
        else if(other.GetComponent<Fish>().GetSize() <= mySize)
        {
            game.EatenFish();
        }

    }
}
