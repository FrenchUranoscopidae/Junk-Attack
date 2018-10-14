using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move7 : MonoBehaviour 
{
	Rigidbody2D rb;

	float health;

	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody2D> ();
		health = 5;
	}
	
	// Update is called once per frame
	void Update () 
	{
		rb.velocity = new Vector2(-1, 0);
	}
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
