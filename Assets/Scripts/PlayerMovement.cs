using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

	public float reloadSpeed;
	public int damageTaken;
	public float speed;
	public float bulletSpawnVerticalOffset;

	public int health;
	int healthInt;
	float healthPercent;
	public int hitCooldown;
	int hitCooldownCount;
	
	public GameObject PlayerHealth;
	public GameObject bullet;

	public Animator anim;

	public SpriteRenderer spriteRenderer;


	Image image;

	float reloadCount;

	void Start () {
		reloadCount = reloadSpeed;
		PlayerHealth = GameObject.Find("PlayerHealth");
		image = PlayerHealth.GetComponent<Image>();
		healthInt = health;
		hitCooldownCount = 0;
		anim.enabled = false;
	}

	void Update () {

		healthPercent = (float) healthInt / health;
		image.fillAmount = healthPercent;

		reloadCount -= 0.1f;

		float moveX = Input.GetAxisRaw("Horizontal");
		float moveY = Input.GetAxisRaw("Vertical");

		transform.position = new Vector2(transform.position.x + (moveX * speed * Time.deltaTime), transform.position.y + (moveY * speed * Time.deltaTime));
		if (Mathf.Abs(transform.position.x) > 6.93f) {
			transform.position = new Vector3(Mathf.Sign(transform.position.x) * 6.93f, transform.position.y, 0);
		}

		if (Mathf.Abs(transform.position.y) > 4.95f) {
			transform.position = new Vector3(transform.position.x, Mathf.Sign(transform.position.y) * 4.95f, 0);
		}

		if (reloadCount <= 0) {
			Instantiate(bullet, new Vector2(transform.position.x, transform.position.y + bulletSpawnVerticalOffset), transform.rotation);
			reloadCount = reloadSpeed;
		}

		hitCooldownCount -= 1;

		if (hitCooldownCount > 0) {
			anim.enabled = true;
		} else {
			anim.enabled = false;
			spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 1);
		}
	}

	void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.layer == 8 && hitCooldownCount <= 0) {
			healthInt -= damageTaken;
			hitCooldownCount = hitCooldown;
		}
	}

}
