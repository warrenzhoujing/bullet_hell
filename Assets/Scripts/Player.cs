using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	public int speed;
	public int hitCooldown;
	int hitCooldownCount;

	public Animator anim;

	public SpriteRenderer spriteRenderer;


	Image image;

	void Start () {
		anim.enabled = false;
	}

	void Update () {

		transform.Rotate(Vector3.forward * -2);

		float moveX = Input.GetAxisRaw("Horizontal");
		float moveY = Input.GetAxisRaw("Vertical");

		transform.position = new Vector2(transform.position.x + (moveX * speed * Time.deltaTime), transform.position.y + (moveY * speed * Time.deltaTime));
		if (Mathf.Abs(transform.position.x) > 6.93f) {
			transform.position = new Vector3(Mathf.Sign(transform.position.x) * 6.93f, transform.position.y, 0);
		}

		if (Mathf.Abs(transform.position.y) > 4.95f) {
			transform.position = new Vector3(transform.position.x, Mathf.Sign(transform.position.y) * 4.95f, 0);
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
			hitCooldownCount = hitCooldown;
		}
	}

}
