using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextPlatform : MonoBehaviour {
	void Start () {
        // Create background from collider
        Vector3 colliderSize = GetComponent<BoxCollider2D>().size;
        GameObject go = Object.Instantiate<GameObject>(Resources.Load("Platform") as GameObject);
        go.transform.parent = transform;
        go.transform.localPosition = new Vector3(colliderSize.x / 2, -colliderSize.y / 2, 0);
        go.transform.localScale = colliderSize;
        go.GetComponent<MeshRenderer>().material.color = new Color(.25f, .25f, .25f, 1);
    }

    void Update() {
		
	}
}
