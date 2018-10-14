using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HeathShip2 : MonoBehaviour 
{
	public Text lives;

	int health;
	// Use this for initialization
	void Start () 
	{
		health = 50;
	}
	
	// Update is called once per frame
	void Update () 
	{
		lives.text = "Lives :" + health;

		if (health <= 0)
		{
			SceneManager.LoadScene ("GameIver");
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{

		if (col.gameObject.tag == "ProjectileE" || col.gameObject.tag == "Enemy" || col.gameObject.tag == "EnemyLaser")
		{
			health--;
			if (col.gameObject.tag == "ProjectileE")
			{
				Destroy (col.gameObject);
			}
		}
	}
}
