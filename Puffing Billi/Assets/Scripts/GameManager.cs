using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.IO;
using UnityEngine.SceneManagement;

public enum State
{
    PRELOAD,
    MENU,
    GAME
}

public delegate void GameStateChange();
public class GameManager : MonoBehaviour
{
    [SerializeField] TextAsset file;
    public static GameManager instance;
    public event GameStateChange MenuState;
    public event GameStateChange GameState;
    [SerializeField] float[] scores;
    public bool scoresAvaliable = false;
    // Use this for initialization
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        if (instance != this)
        {
            Destroy(this);
        }
        try
        {
            file = (TextAsset)AssetDatabase.LoadAssetAtPath("Assets/Resources/scores.bytes", typeof(TextAsset));
            if (file == null)
            {
                File.Create("Assets/Resources/scores.bytes");
                //file = (TextAsset)AssetDatabase.LoadAssetAtPath("Assets/Resources/scores.bytes", typeof(TextAsset));
                scoresAvaliable = false;
            }
            else
            {
                scores = SaveLoadScores.LoadScores();
                ThinScoresArray();
                SortScoreArray();
                scoresAvaliable = true;
            }
        }
        catch (Exception e)
        {

        }
    }
    void ThinScoresArray()
    {
        int numInArray = 0;
        for (int i = 0; i < scores.Length; i++)
        {
            if(scores[i] == 0 && i == 0)
            {
                numInArray = 1;
            }
            if (scores[i] != 0)
            {
                numInArray++;
            }
        }

        float[] temp = new float[numInArray];
        for (int i = 0; i < temp.Length; i++)
        {
            temp[i] = scores[i];
        }

        scores = temp;
    }
    void SortScoreArray()
    {
        for(int i = 0; i < scores.Length - 1; i ++)
        {
            for(int j = 1; j < scores.Length; j ++)
            {
                if(scores[j] > scores[i])
                {
                    float temp = scores[i];
                    scores[i] = scores[j];
                    scores[j] = temp;
                }
            }
        }
    }
    public void SaveScore(float a_score)
    {
        SaveLoadScores.SaveScore(a_score, file);
    }
    public float GetTopScore()
    {
		try
		{
			return scores[0];
		}
		catch(Exception e)
		{
			return 0;
		}
		return 0;
        
    }
    public void SetState(State a_state)
    {
        if (a_state == State.MENU)
        {
            if (MenuState != null)
            {
                MenuState();
            }
        }
        if (a_state == State.GAME)
        {
            GameState();
        }
        if(a_state == State.PRELOAD)
        {
			#if UNITY_EDITOR
            SceneManager.LoadScene(1);
			#endif
        }
    }

}
