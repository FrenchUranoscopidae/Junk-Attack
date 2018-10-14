using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissilePhase : MonoBehaviour 
{
	public GameObject missiles;
	public GameObject player1;
	public GameObject player2;
	GameObject clone;

	// Use this for initialization
	void Start ()
	{
		player1 = GameObject.Find ("Player1");
		player2 = GameObject.Find ("Player2");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Data.bossHealth < 990)
		{
			if (clone == null)
			{
				clone = Instantiate (missiles, transform.position, transform.rotation);
			}
		}
		if (Data.ship == 1)
		{
			clone.transform.position = Vector3.MoveTowards (clone.transform.position, player1.transform.localPosition, 0.03f);
		}

		if (Data.ship == 2)
		{
			clone.transform.position = Vector3.MoveTowards (clone.transform.position, player2.transform.localPosition, 0.03f);
		}
	}
}
