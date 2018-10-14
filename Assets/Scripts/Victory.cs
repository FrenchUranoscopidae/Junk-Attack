using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour 
{
	public Text yourScore;
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		yourScore.text = "Your score : " + Data.score;

		if (Input.anyKeyDown)
		{
			SceneManager.LoadScene ("Main_Menu");
		}
	}
}
