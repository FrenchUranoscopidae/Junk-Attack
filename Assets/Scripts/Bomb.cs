using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour 
{
	public GameObject explosion;
	public AudioClip noise;
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Enemy")
		{
			GameObject clone;
			clone = Instantiate (explosion, transform.position, transform.rotation);
			AudioSource.PlayClipAtPoint (noise, transform.position);
			Destroy (gameObject);

		}

		if (col.gameObject.tag == "ProjectileKiller")
		{
			Destroy (gameObject);
		}
	}
}
