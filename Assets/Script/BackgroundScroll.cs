using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour {

    public Transform startPos, finalPos;
    public float speed, accelaration, maxSpeed;

    void FixedUpdate () {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        speed += accelaration * Time.deltaTime;

        if (speed > maxSpeed) {
            speed = maxSpeed;
        }

        if (transform.position.y < finalPos.position.y) {
            transform.position = startPos.position;
        }
	}

    public void ResetSpeed() {
        speed = 1.6f;
    }
}
