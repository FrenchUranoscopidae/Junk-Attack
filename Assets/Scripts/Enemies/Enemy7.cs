using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy7 : MonoBehaviour 
{
	public GameObject projectile;
	Collider2D col1;
	Collider2D colEnnemy1;
	public AudioClip shot;

	float health;
	int frames;
	// Use this for initialization
	void Start () 
	{
		health = 2;
		colEnnemy1 = GetComponent<Collider2D> ();;
	}

	// Update is called once per frame
	void Update () 
	{
		frames++;
		//Détruit l'ennemi quand il n'a plus de vie.
		if (health <= 0)
		{
			Destroy(gameObject);
			Data.score += 500;
		}

		if (frames == 40) {
			frames = 0;
			GameObject clone;
			clone = Instantiate (projectile, transform.position, transform.rotation);
			col1 = clone.GetComponent<Collider2D> ();
			Rigidbody2D rib;
			rib = clone.GetComponent<Rigidbody2D> ();
			rib.velocity = transform.right * 3;
			AudioSource.PlayClipAtPoint (shot, transform.position, 0.3f);
		}
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
			Debug.Log ("hit");
		}

		if (col.gameObject.tag == "Explosion")
		{
			health -= 0.6f;
		}
	}
}
