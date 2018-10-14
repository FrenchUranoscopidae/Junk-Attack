using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/**
 * Gère la sélection du vaisseau.
 */
public class PlayerSelection : MonoBehaviour 
{
	public GameObject player1;
	public GameObject player2;
	public GameObject icon1;
	public GameObject icon2;
	public int isPlayer;
	public Text edalas;
	public Text sanana;

	// Use this for initialization
	void Start () 
	{
		transform.position = player1.transform.position;
		icon2.SetActive (false);
		edalas.text = "";
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Bouge le curseur pour sur les vaisseaux.
		if (Input.GetKeyDown ("left"))
		{
			transform.position = player1.transform.position;
			icon1.SetActive (true);
			icon2.SetActive (false);
			sanana.text = "SANANA";
			edalas.text = " ";
		}

		if (Input.GetKeyDown ("right"))
		{
			transform.position = player2.transform.position;
			icon2.SetActive (true);
			icon1.SetActive (false);
			sanana.text = " ";
			edalas.text = "EDALAS";
		}

		//Sélectionne le vaisseau.
		if (transform.position == player1.transform.position && Input.GetKeyDown ("space"))
		{
			isPlayer = 1;
			Data.ship = 1;
			SceneManager.LoadScene ("Cinematic");
		}

		if (transform.position == player2.transform.position && Input.GetKeyDown ("space"))
		{
			isPlayer = 2;
			Data.ship = 2;
			SceneManager.LoadScene ("Cinematic");
		}
	}
}
