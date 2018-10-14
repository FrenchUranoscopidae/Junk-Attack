using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissiles : MonoBehaviour 
{
	GameObject closest;
	bool launched;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!launched)
		{
			closest = FindClosestByTag ("Enemy");
			launched = true;
		}
		transform.position = Vector2.MoveTowards (transform.position, closest.transform.position, 0.04f);
		Debug.Log (closest.name);

		if (closest == null)
		{
			closest = FindClosestByTag ("Enemy");
		}
	}

	GameObject FindClosestByTag(string tag)
	{
		GameObject[] gos;
		gos = GameObject.FindGameObjectsWithTag(tag);
		GameObject closest = null;
		float distance = Mathf.Infinity;
		Vector3 position = transform.position;
		foreach (GameObject go in gos)
		{
			Vector3 diff = go.transform.position - position;
			float curDistance = diff.sqrMagnitude;
			if (curDistance < distance)
			{
				closest = go;
				distance = curDistance;
			}
		}
		return closest;
	} 
}
