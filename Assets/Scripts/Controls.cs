using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Controls : MonoBehaviour 
{
	public Camera cam;
	public GameObject player2;
	public GameObject projectile;
	public GameObject missiles;
	public GameObject laser;
	public GameObject bomb;
	public AudioClip piou;
	public Text lives;
	public AudioClip laserTir;
	public AudioClip missileLaunch;

	Collider2D col1;
	Collider2D colPlayer1;
	Collider2D colPlayer2;

	float horzAxis;
	float vertAxis;
	int health;
	int shotSelected;
	int frameCount;

	// Use this for initialization
	void Start () 
	{
		health = 50;
		//Positionne le vaisseau selectionné au centre de l'écran.
		if (Data.ship == 1)
		{
			transform.position = new Vector3 (0, 0, 0);
		} 
		else
		{
			player2.transform.position = new Vector3 (0, 0, 0);
		}

		colPlayer1 = GetComponent<Collider2D> ();
		colPlayer2 = player2.GetComponent<Collider2D> ();
		shotSelected = 0;

		laser.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Déplace le vaisseau à l'écran dans les limites de la caméra.
		horzAxis = Input.GetAxis ("Horizontal");
		vertAxis = Input.GetAxis ("Vertical");

		if (Data.ship == 1)
		{
			frameCount++;
			transform.Translate (horzAxis / 20, 0, 0);
			transform.Translate (0, vertAxis / 20, 0);

			lives.text = "Lives :" + health;
			//Tir 1 (Missile tête chercheuse)
			if (Input.GetKeyDown ("space") && shotSelected == 0 && frameCount >= 30)
			{
				GameObject clone;
				clone = Instantiate (missiles, transform.position, transform.rotation);
				col1 = clone.GetComponent<Collider2D> ();
				frameCount = 0;
				AudioSource.PlayClipAtPoint (missileLaunch, transform.position);

			}
				
			//Tir 2 (Laser)
			if (Input.GetKey ("space") && shotSelected == 1)
			{
				laser.gameObject.SetActive (true);
			}

			if (Input.GetKeyDown ("space") && shotSelected == 1)
			{
				AudioSource.PlayClipAtPoint (laserTir, transform.position);
			}

			if (Input.GetKeyUp ("space"))
			{
				laser.gameObject.SetActive (false);
			}

			Physics2D.IgnoreCollision (col1, colPlayer1);

			if (health <= 0)
			{
				SceneManager.LoadScene ("GameIver");
			}
		}

		if (Data.ship == 2)
		{
			frameCount++;

			player2.transform.Translate (horzAxis / 20, 0, 0);
			player2.transform.Translate (0, vertAxis / 20, 0);

			if (Input.GetKey ("space") && shotSelected == 0)
			{
				if (frameCount >= 5)
				{
					GameObject clone;
					clone = Instantiate (projectile, player2.transform.position, player2.transform.rotation);
					Rigidbody2D rb;
					rb = clone.GetComponent<Rigidbody2D> ();
					col1 = clone.GetComponent<Collider2D> ();
					rb.AddForce (new Vector2 (5, 0), ForceMode2D.Impulse);
					frameCount = 0;
					AudioSource.PlayClipAtPoint (piou, player2.transform.position);
				}
			}

			if (Input.GetKeyDown ("space") && shotSelected == 1 && frameCount >= 50)
			{
				frameCount = 0;
				GameObject clone;
				clone = Instantiate (bomb, player2.transform.position, player2.transform.rotation);
				Rigidbody2D rb;
				rb = clone.GetComponent<Rigidbody2D> ();
				rb.AddForce (new Vector2 (5, 0), ForceMode2D.Impulse);
			}

			Physics2D.IgnoreCollision (col1, colPlayer1);
			Physics2D.IgnoreCollision (col1, colPlayer2);
		}

		if (Input.GetKeyDown ("e"))
		{
			if (shotSelected == 0)
			{
				shotSelected = 1;
			}

			else if (shotSelected == 1)
			{
				shotSelected = 0;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "Enemy" || coll.gameObject.tag == "EnemyLaser")
		{
			health--;
		}

		if (coll.gameObject.tag == "ProjectileE")
		{
			health--;
			Destroy (coll.gameObject);
		}

		if (coll.gameObject.tag == "Laser")
		{
			Physics2D.IgnoreCollision (colPlayer1, coll.gameObject.GetComponent<Collider2D>());
		}
	}
}
