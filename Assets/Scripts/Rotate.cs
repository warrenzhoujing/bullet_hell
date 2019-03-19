using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

	public float rotateSpeed;
	public GameObject setRotation;
	public bool RotateWithParent;


	Vector3 originalRotation;

	void Start () {
		originalRotation = transform.eulerAngles;
	}

	void Update () {
		if (setRotation != null) {
			transform.rotation = Quaternion.Euler(setRotation.transform.eulerAngles * (RotateWithParent?0.5f:1) + originalRotation);
		} else {
			transform.Rotate(Vector3.forward * rotateSpeed);
		}
		
	}
}

