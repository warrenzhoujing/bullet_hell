using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletOrigin : MonoBehaviour {

	public Vector3[] rotations;

	public GameObject BossBullet;
	public float reloadSpeed;
	float reloadCount;
	
	void Start () {
		reloadCount = reloadSpeed;
	}
	void Update () {
		reloadCount -= 0.1f;

		if (reloadCount < 0) {
			reloadCount = reloadSpeed;
			for (int i = 0; i < rotations.Length; i++) {
				Quaternion bullet_rotation = Quaternion.Euler(rotations[i]);
				Instantiate(BossBullet, transform.position, bullet_rotation);
			}
			
		}

	}
}
