using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectOrigin : MonoBehaviour {

	public Vector3[] rotations;

	public GameObject Object;

	public bool shootInObjectDirection;

	public float reloadSpeed;
	public float startDelay;


	float reloadCount;
	
	void Start () {
		reloadCount = reloadSpeed * 0.4f + startDelay;

		if (startDelay > 0) {
			for (int i = 0; i < rotations.Length; i++) {
				Quaternion enemy_rotation = Quaternion.Euler(rotations[i]);
				Instantiate(Object, transform.position, enemy_rotation);
			}
		}
		
	}
	
	void Update () {
		reloadCount -= 0.1f;

		if (reloadCount < 0) {
			reloadCount = reloadSpeed;

			for (int i = 0; i < rotations.Length; i++) {
				Quaternion enemy_rotation = Quaternion.Euler(rotations[i]);
				GameObject obj = (GameObject)Instantiate(Object);
				obj.transform.position = transform.position;

				obj.transform.rotation = !shootInObjectDirection?enemy_rotation:transform.rotation;
				
				obj.SetActive(true);
			}
			
		}

	}
}
