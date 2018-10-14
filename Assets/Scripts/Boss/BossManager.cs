using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossManager : MonoBehaviour 
{
	public GameObject shield;

	int frameCount;
	bool isShielded1;
	bool isShielded2;
	// Use this for initialization
	void Start () 
	{
		Data.bossHealth = 3000;
		shield.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Data.bossHealth <= 0)
		{
			SceneManager.LoadScene("Victory");
		}
			
		if (Data.bossHealth <= 2000 && Data.bossHealth >= 1990 && frameCount == 0 && !isShielded1)
		{
			shield.SetActive (true);
			isShielded1 = true;
		}

		if (isShielded1)
		{
			frameCount++;
			if (frameCount == 600)
			{
				shield.SetActive (false);
			}
		}

		if (Data.bossHealth <= 1000 && Data.bossHealth >= 990 && frameCount == 0 && !isShielded2)
		{
			shield.SetActive (true);
			isShielded2 = true;
		}

		if (isShielded1)
		{
			frameCount++;
			if (frameCount == 600)
			{
				shield.SetActive (false);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player" || col.gameObject.tag == "ProjectileP")
		{
			Data.bossHealth--;
			if (col.gameObject.CompareTag ("ProjectileP"))
			{
				Destroy (col.gameObject);
			}
		}

		if (col.gameObject.tag == "Missile")
		{
			Data.bossHealth -= 2.0f;
			Destroy (col.gameObject);
		}
	}

	void OnTriggerStay2D(Collider2D col)
	{
		if (col.gameObject.tag == "Laser")
		{
			Data.bossHealth -= 0.4f;
		}

		if (col.gameObject.tag == "Explosion")
		{
			Data.bossHealth -= 0.6f;
		}
	}
}
