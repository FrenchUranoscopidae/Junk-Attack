using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour 
{
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "ProjectileE" || col.gameObject.tag == "ProjectileP")
		{
			Destroy (col.gameObject);
		}
	}
}
