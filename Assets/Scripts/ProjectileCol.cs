using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Annule les tirs enntre eux.
 */
public class ProjectileCol : MonoBehaviour 
{
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "ProjectileE")
		{
			Destroy (gameObject);
			Destroy (col.gameObject);
		}

        if (col.gameObject.tag == "ProjectileKiller")
        {
            Destroy(gameObject);
        }
	}
}