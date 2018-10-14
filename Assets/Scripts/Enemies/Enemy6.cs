using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy6 : MonoBehaviour 
{
	Rigidbody2D rb;
	Collider2D colEnemy1;

	float health = 2;
	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody2D> ();
		colEnemy1 = GetComponent<Collider2D> ();
	}

	// Update is called once per frame
	void Update () 
	{
		//Détruit l'ennemi quand il n'a plus de vie.
		if (health <= 0)
		{
			Destroy (gameObject);
			Data.score += 100;
		}
		//Fait avancer l'ennemi.
		rb.velocity = new Vector2(1, 0);
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
