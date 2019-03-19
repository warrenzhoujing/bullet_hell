using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public bool affectedByPlayerBullet;
	
	void OnCollisionEnter2D (Collision2D collision) {
		if (collision.gameObject.tag == "Player Bullet" && affectedByPlayerBullet) {
			Destroy(gameObject);
		}
	}
}
