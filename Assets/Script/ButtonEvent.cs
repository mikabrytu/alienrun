using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonEvent : MonoBehaviour {

    private PanelEvent panel;
    private ScoreController score;
    private SpawnManager spawnManager;
    private Highscore highscore;

    private void Start() {
        panel = GameObject.Find("Panel").GetComponent<PanelEvent>();
        score = GameObject.Find("Score").GetComponent<ScoreController>();
        spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();

        highscore = new Highscore();

        panel.HidePanel();
    }

    public void Play() {
        if (Time.timeScale == 0) {
            Time.timeScale = 1;
        }

        SceneManager.LoadScene("Main");
    }

    public void HighScore() {
        SceneManager.LoadScene("HighScore");
    }

    public void Menu() {
        SceneManager.LoadScene("Menu");
    }

    public void Restart() {
        score.ResetScore();

        GameObject[] meteors = GameObject.FindGameObjectsWithTag("Meteors");
        foreach (GameObject m in meteors) {
            Destroy(m);
        }

        GameObject[] tiles = GameObject.FindGameObjectsWithTag("Background");
        foreach (GameObject t in tiles) {
            t.GetComponent<BackgroundScroll>().ResetSpeed();
        }

        panel.HidePanel();
        Time.timeScale = 1;
        spawnManager.ResetSpawnTime();
    }

    public void Stop() {
        Time.timeScale = 0;
        highscore.SetNewHighscore((int)score.GetScore());
        panel.ShowPanel();
        GameObject.Find("Score Label").GetComponent<Text>().text = ((int)score.GetScore()) + " m";
    }
}
