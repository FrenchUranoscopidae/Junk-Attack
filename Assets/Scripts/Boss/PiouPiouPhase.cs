using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiouPiouPhase : MonoBehaviour 
{
	int frameCount;

	GameObject clone;
	public GameObject pioupiou;
	Rigidbody2D rb;
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		frameCount++;
		if (Data.bossHealth < 1990 && Data.bossHealth > 1000)
		{
			if (frameCount >= 60)
			{
				clone = Instantiate (pioupiou, transform.position, transform.rotation);
				rb = clone.GetComponent<Rigidbody2D> ();
				rb.velocity = new Vector2(-1, 0);
				frameCount = 0;
			}
		}

		if (Data.bossHealth < 990)
		{
			if (frameCount >= 120)
			{
				clone = Instantiate (pioupiou, transform.position, transform.rotation);
				rb = clone.GetComponent<Rigidbody2D> ();
				rb.velocity = new Vector2(-1, 0);
				frameCount = 0;
			}
		}
	}
}
