using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public int speed;
	public Vector3 moveDirection;
	public string DestroyTagMask;
	
	void Update () {
		transform.Translate(transform.right * speed * Time.deltaTime);

		if (Mathf.Abs(transform.position.x) > 7 || Mathf.Abs(transform.position.y) > 5) {
			Destroy(gameObject);
		}
	}

	void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.tag != DestroyTagMask) {
			Destroy(gameObject);
		}
		
	}
}
