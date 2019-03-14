using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public int enemySpeed;
	public Vector3 moveDirection;

	void Start () {
		
		
	}
	
	void Update () {
		transform.Translate(transform.right * enemySpeed * Time.deltaTime);

		if (Mathf.Abs(transform.position.x) > 8 || Mathf.Abs(transform.position.y) > 6) {
			Destroy(gameObject);
		}
	}
}
