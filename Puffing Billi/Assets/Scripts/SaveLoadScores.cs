﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public static class SaveLoadScores
{
    static string fileLocation = Application.persistentDataPath + "/scores.bytes";
    public static void SaveScore(float score, TextAsset file)
    {
		if (score != 0) {
			string previousItems = File.ReadAllText (fileLocation);
			File.WriteAllText (fileLocation, previousItems + "\r\n" + score.ToString ());
		}
    }
    public static float[] LoadScores()
    {
        string loadScores = File.ReadAllText(fileLocation);
        string score = "";
        float[] scores = new float[50];
        int scoresLocation = 0;
        bool saveNumber = false;
        foreach(char c in loadScores)
        {
            if(c == '\n' || c == '\r')
            {
                saveNumber = true;
            }
            else
            {
                score += c;
            }
            if(saveNumber && score != "")
            {
                scores[scoresLocation] = float.Parse(score);
                scoresLocation++;
                saveNumber = false;
                score = "";
            }
			if(c == loadScores[loadScores.Length - 1])
			{
				scores[scoresLocation] = float.Parse(score);
				scoresLocation++;
				saveNumber = false;
				score = "";
			}
            saveNumber = false;
        }
        return scores;
    }
}
