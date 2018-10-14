using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShotBoss : MonoBehaviour 
{
	public GameObject laser;
	public GameObject cannon2;
	GameObject clone;

	int frameCount;
	bool laserShotRight;
	bool laserShotLeft;
	// Use this for initialization
	void Start () 
	{
		laserShotLeft = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		frameCount++;
		if (Data.bossHealth > 2000)
		{
			if (frameCount >= 120 && laserShotRight == false)
			{
				clone = Instantiate (laser, transform.position - new Vector3(6.8f, 0, 0), transform.rotation);
				laserShotRight = true;
			}

			if (frameCount >= 120 && laserShotLeft == false)
			{
				clone = Instantiate (laser, cannon2.transform.position - new Vector3(6.8f, 0, 0), cannon2.transform.rotation);
				laserShotLeft = true;
			}

			if (frameCount >= 240)
			{
				frameCount = 0;

				if (clone.transform.position == cannon2.transform.position - new Vector3(6.8f, 0, 0))
				{
					laserShotRight = false;
				}

				if (clone.transform.position == transform.position - new Vector3(6.8f, 0, 0))
				{
					laserShotLeft = false;
				}

				Destroy (clone);
			}
		}

		if (Data.bossHealth < 2000)
		{
			if (frameCount >= 240 && laserShotRight == false)
			{
				clone = Instantiate (laser, cannon2.transform.position - new Vector3(6.8f, 0, 0), cannon2.transform.rotation);
				laserShotRight = true;
			}

			if (frameCount >= 240 && laserShotLeft == false)
			{
				clone = Instantiate (laser, cannon2.transform.position - new Vector3(6.8f, 0, 0), cannon2.transform.rotation);
				laserShotLeft = true;
			}

			if (frameCount >= 360)
			{
				frameCount = 0;

				if (clone.transform.position == cannon2.transform.position - new Vector3(6.8f, 0, 0))
				{
					laserShotRight = false;
				}

				if (clone.transform.position == transform.position - new Vector3(6.8f, 0, 0))
				{
					laserShotLeft = false;
				}

				Destroy (clone);
			}
		}
	}
}
