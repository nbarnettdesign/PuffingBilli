using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    private GameManager m_gm;
    [SerializeField] Text m_highScore;
	// Use this for initialization
	void Start ()
    {
        m_gm = GameManager.instance;
        m_gm.MenuState += SetupMenu;
        m_gm.SetState(State.MENU);
    }


	// Update is called once per frame
	void Update () {
		
	}

    void SetupMenu()
    {
        if (m_gm.scoresAvaliable)
        {
            m_highScore.text = m_gm.GetTopScore().ToString();
        }
        else
        {
            m_highScore.text = "0";
        }
    }
}
