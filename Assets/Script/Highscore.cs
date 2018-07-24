using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highscore : MonoBehaviour {
    
    private string key = "HIGH_SCORE";

    public void SetNewHighscore(int score) {
        if (score > GetHighscore()) {
            PlayerPrefs.SetInt(key, score);
        }
    }

    public int GetHighscore() {
        return PlayerPrefs.GetInt(key);
    }

}
