using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

//Gestion des boutons du jeu.
public class Buttons : MonoBehaviour 
{
	public Button btnPlay;
	public Button btnExit;

	void Start()
	{
		btnPlay.onClick.AddListener (TaskOnClick);
		btnExit.onClick.AddListener (TaskOnClick);
	}

	void TaskOnClick()
	{
		//Lance le jeu en cliquant le bouton play.
		if (EventSystem.current.currentSelectedGameObject.name == "PlayButton")
		{
			SceneManager.LoadScene ("Menu_Player");
		}

		//Ferme le jeu en cliquant le bouton exit.
		if (EventSystem.current.currentSelectedGameObject.name == "ExitButton")
		{
			Application.Quit ();
		}
	}
}
