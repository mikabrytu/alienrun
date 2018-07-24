using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    
    public float speed;

    private Touch initialTouch;
    private Vector3 target;
    private AudioSource sound;
    private bool moving = false;

    void Start() {
        sound = GetComponent<AudioSource>();
    }

    void FixedUpdate () {
        if (moving) {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

            if (transform.position == target) {
                moving = false;
                return;
            }
        }

        if (Input.touchCount > 0 && !moving) {
            foreach (Touch touch in Input.touches) {
                if (touch.phase == TouchPhase.Began) {
                    initialTouch = touch;
                }

                if (touch.phase == TouchPhase.Moved) {
                    float deltaX = touch.position.x - initialTouch.position.x;

                    if (deltaX < 0 && transform.position.x >= 0) {
                        target = new Vector3(transform.position.x - 2f, transform.position.y, transform.position.z);
                    }

                    if (deltaX > 0 && transform.position.x <= 0) {
                        target = new Vector3(transform.position.x + 2f, transform.position.y, transform.position.z);
                    }

                    moving = true;
                    PlaySound();

                    break;
                }
            }
        }


        // Debug
        if (Input.GetKeyUp(KeyCode.A)) {
            target = new Vector3(transform.position.x - 2f, transform.position.y, transform.position.z);
            moving = true;
            PlaySound();
        }

        if (Input.GetKeyUp(KeyCode.D)) {
            target = new Vector3(transform.position.x + 2f, transform.position.y, transform.position.z);
            moving = true;
            PlaySound();
        }
	}

    private void PlaySound() {
        sound.Play();
    }
}
