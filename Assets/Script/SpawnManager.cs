using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    public GameObject[] objs;
    public Transform[] spawnPoints;
    public float spawnTime;

    private float backgroundSpeed;

	void Start () {
        Invoke("Spawn", spawnTime);
	}

    private void FixedUpdate() {
        if (backgroundSpeed > 3 && backgroundSpeed < 6 && spawnTime == 2) {
            spawnTime = 1;
        }

        if (backgroundSpeed > 6 && spawnTime == 1) {
            spawnTime = 0.5f;
        }
    }

    private void Spawn() {
        int objectIndex = Random.Range(0, objs.Length);
        int spawnIndex = Random.Range(0, spawnPoints.Length);

        backgroundSpeed = GameObject.Find("Tile").GetComponent<BackgroundScroll>().speed;
        float speed = backgroundSpeed;

        if (speed < 2) {
            speed += 0.5f;
        }

        if (speed > 2 && speed < 6) {
            speed += 1f;
        }

        if (speed > 6) {
            speed += 2.5f;
        }

        objs[objectIndex].GetComponent<EnemyController>().speed = speed;

        Instantiate(objs[objectIndex], spawnPoints[spawnIndex].position, spawnPoints[spawnIndex].rotation);

        Invoke("Spawn", spawnTime);
    }

    public void ResetSpawnTime() {
        backgroundSpeed = 0;
        spawnTime = 2f;
    }
}
