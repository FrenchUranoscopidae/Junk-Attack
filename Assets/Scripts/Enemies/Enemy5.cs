using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy5 : MonoBehaviour 
{
	public Sprite sprite1;
	public Sprite sprite2;
	public Sprite sprite3;
	public Sprite sprite4;
	public Sprite sprite5;

	SpriteRenderer spriteRenderer;

	Rigidbody2D rb;
	Collider2D colEnemy1;

	float health = 50;
	// Use this for initialization
	void Start () 
	{
		spriteRenderer = GetComponent<SpriteRenderer> ();
		rb = GetComponent<Rigidbody2D> ();
		colEnemy1 = GetComponent<Collider2D> ();
	}

	// Update is called once per frame
	void Update () 
	{
		//Change le sprite de l'ennemi en fonction de ses points de vie.
		if (health <= 40)
		{
			spriteRenderer.sprite = sprite2;
		}

		if (health <= 30)
		{
			spriteRenderer.sprite = sprite3;
		}

		if (health <= 20)
		{
			spriteRenderer.sprite = sprite4;
		}

		if (health <= 10)
		{
			spriteRenderer.sprite = sprite5;
		}

		if (health <= 0)
		{
			Destroy (gameObject);
			Data.score += 500;
		}
		//Fait avancer l'ennemi.
		rb.velocity = new Vector2(-0.2f, 0);
	}
	//Détecte les collisions avec les tirs et le joueur et calcule ses points de vie en concéquence.
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player" || col.gameObject.tag == "ProjectileP")
		{
			health--;
			if (col.gameObject.CompareTag ("ProjectileP"))
			{
				Destroy (col.gameObject);
			}
		}

		if (col.gameObject.tag == "ProjectileE" || col.gameObject.tag == "Enemy")
		{
			Physics2D.IgnoreCollision (col, colEnemy1);
		}

		if (col.gameObject.tag == "Wall")
		{
			Destroy (gameObject);
		}

		if (col.gameObject.tag == "Missile")
		{
			health -= 2.0f;
			Destroy (col.gameObject);
		}
	}

	void OnTriggerStay2D(Collider2D col)
	{
		if (col.gameObject.tag == "Laser")
		{
			health -= 0.4f;
		}

		if (col.gameObject.tag == "Explosion")
		{
			health -= 0.6f;
		}
	}
}

