using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	void Start() {
		
	}
	
	void Update() {
        GameObject go = GameObject.Find("Player");
        while (true) {
            Vector3 pos = GetComponent<Camera>().WorldToScreenPoint(go.transform.position);
            // Debug.Log("Pos: " + pos);
            if (pos.x < GetComponent<Camera>().pixelWidth * 0.8)
                break;
            transform.Translate(Vector3.right * 0.01f);
        }
	}
}
