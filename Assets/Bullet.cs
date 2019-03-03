using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector2.up * Time.deltaTime * speed, Space.World);

		if (transform.position.y > 5) {
			Destroy(gameObject);
		}
	}

	void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.tag == "boss") {
			Destroy(gameObject);
		}
	}
}
