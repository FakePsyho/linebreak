using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float moveAcc = 0.1f;

	void Start() {
		
	}

    void FixedUpdate() {
        if (Input.GetAxis("Horizontal") > 0) {
            // Debug.Log("right");
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(+moveAcc, 0));
        }
        if (Input.GetAxis("Horizontal") < 0) {
            // Debug.Log("left");
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-moveAcc, 0));
        }
        if (Input.GetButton("Jump")) {
            Debug.Log("jump");
        }
    }

    void Update() {
		
	}
}
