using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float speed;
	public string damageTag;
	public bool alwaysGoUp;

	
	void Update () {
		if (alwaysGoUp) {
			transform.Translate(Vector2.up * Time.deltaTime * speed, Space.World);	
		} else {
			transform.Translate(transform.right * Time.deltaTime * speed, Space.World);
		}

		if (Mathf.Abs(transform.position.y) > 5) {
			Destroy(gameObject);
		}
	}

	void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.tag == "boss") {
			Destroy(gameObject);
		}
	}
}
