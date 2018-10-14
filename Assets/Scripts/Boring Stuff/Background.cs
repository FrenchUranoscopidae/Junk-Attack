using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Gère les backgrounds (PAS FINI).
 */

public class Background : MonoBehaviour 
{
	public GameObject backgroundInstance1;
	public GameObject backgroundInstance2;
	public GameObject backgroundInstance3;
	public GameObject secondBackground;
	public GameObject secondBackground2;
	public GameObject secondBackground3;
	public GameObject secondBackground4;

	float initialPos;
	float velocity;
	float velocity2;
	float velocity3;
	// Use this for initialization
	void Start () 
	{
		initialPos = backgroundInstance1.transform.position.x;
	}
	
	// Update is called once per frame
	void Update () 
	{
		velocity = -1.5f * Time.deltaTime;
		velocity2 = -1 * Time.deltaTime;
		velocity3 = -0.5f * Time.deltaTime;

		transform.position += new Vector3(velocity, 0, 0);
		backgroundInstance1.transform.position += new Vector3 (velocity, 0, 0);
		backgroundInstance2.transform.position += new Vector3 (velocity2, 0, 0);
		backgroundInstance3.transform.position += new Vector3 (velocity3, 0, 0);

		if (transform.position.x <= -25.4)
		{
			transform.position = secondBackground.transform.position + new Vector3(33.63f, 0, 0);
		}

		if (backgroundInstance1.transform.position.x <= -25.4)
		{
			backgroundInstance1.transform.position = secondBackground2.transform.position + new Vector3(33.63f, 0, 0);
		}

		if (backgroundInstance2.transform.position.x <= -25.4)
		{
			backgroundInstance2.transform.position = secondBackground3.transform.position + new Vector3(33.63f, 0, 0);
		}

		if (backgroundInstance3.transform.position.x <= -25.4)
		{
			backgroundInstance3.transform.position = secondBackground4.transform.position + new Vector3(33.63f, 0, 0);
		}
	}
}
