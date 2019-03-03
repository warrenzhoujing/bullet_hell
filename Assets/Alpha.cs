using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Alpha : MonoBehaviour {
	public GameObject HealthBar;
	Image image;

	[Range(0, 1)]
	float healthPercent;
	public int health;
	int healthInt;

	public Animator anim;

	bool Phase2;

	void Start () {
		HealthBar = GameObject.Find("BossHealth");
		image = HealthBar.GetComponent<Image>();
		healthInt = health;
		Phase2 = false;
	}
	
	void Update () {
		healthPercent = (float) healthInt / health;
		image.fillAmount = healthPercent;

		if (healthPercent < 0.4f) {
			anim.enabled = true;
			Phase2 = true;
		}
	}

	void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.tag == "bullet") {
			healthInt -= 5;
		}
	}
}
