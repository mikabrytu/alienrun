using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public float speed = 1f;

    private Transform destroyPoint;
    private AudioSource sound;

    void Start() {
        destroyPoint = GameObject.Find("Final Position").GetComponent<Transform>();
        sound = GetComponent<AudioSource>();
    }

    void Update () {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.y < destroyPoint.position.y) {
            Destroy(gameObject);
        }
	}

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.name == "Player") {
            sound.Play();
            GameObject.Find("EventSystem").GetComponent<ButtonEvent>().Stop();
        }
    }
}
