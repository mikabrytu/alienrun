using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

    private float score;
    private Text text;

    private void Start() {
        text = GetComponent<Text>();
    }

    void Update () {
        score += Time.deltaTime * 2;
        text.text = (int)score + " m";
	}

    public void ResetScore() {
        score = 0;
    }

    public float GetScore() {
        return score;
    }
}
