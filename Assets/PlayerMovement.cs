using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float moveAcc = 0.1f;
    public float jumpAcc = 100.0f;

    public int jumpCD = 10;

    private int currentJumpCD = 0;

	void Start() {
		
	}

    void FixedUpdate() {
        if (Input.GetAxis("Horizontal") > 0) {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(+moveAcc, 0));
        }
        if (Input.GetAxis("Horizontal") < 0) {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(-moveAcc, 0));
        }

        currentJumpCD = Mathf.Max(0, currentJumpCD - 1);
        GameObject bl = transform.Find("BotLeft").gameObject;
        GameObject br = transform.Find("BotRight").gameObject;
        if (Input.GetButton("Jump") && 
            currentJumpCD == 0 && 
            GetComponent<Rigidbody2D>().velocity.y == 0 && 
            (bl.GetComponent<CircleCollider2D>().IsTouchingLayers() || br.GetComponent<CircleCollider2D>().IsTouchingLayers())) {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpAcc);
            currentJumpCD = jumpCD;
        }

        Debug.Log("Vel: " + GetComponent<Rigidbody2D>().velocity);
    }

    void Update() {
		
	}
}
