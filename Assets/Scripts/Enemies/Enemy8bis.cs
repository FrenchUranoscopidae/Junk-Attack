using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy8bis : MonoBehaviour {

	public GameObject laser;
	GameObject clone;
	public AudioClip charge;
	public AudioClip tir;

	float frameCount;
	float health;
	int audioPlayed;
	// Use this for initialization
	void Start () 
	{
		frameCount = 0;
		health = 5;
	}

	// Spawn le laser et le détruit après 2 secondes environ.
	void Update () 
	{
		frameCount++;
		if (frameCount <= 100 && audioPlayed == 0)
		{
			AudioSource.PlayClipAtPoint (charge, transform.position);
			audioPlayed += 1;
		}

		if (frameCount == 100)
		{
			clone = Instantiate (laser, transform.position - new Vector3(0.1f, 2.5f, 0), transform.rotation);
			AudioSource.PlayClipAtPoint (tir, transform.position);
		}

		if (frameCount >= 240)
		{
			Destroy (clone);
		}

		if (health <= 0)
		{
			Destroy (gameObject);
			Destroy (clone);
			Data.score += 300;
		}
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
		}

		if (col.gameObject.tag == "Explosion")
		{
			health -= 0.6f;
		}
	}
}
