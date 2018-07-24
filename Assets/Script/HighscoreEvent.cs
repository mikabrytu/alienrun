using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreEvent : MonoBehaviour {

	void Start () {
        Highscore highscore = new Highscore();
        gameObject.GetComponent<Text>().text = highscore.GetHighscore().ToString() + " m";
	}
}
