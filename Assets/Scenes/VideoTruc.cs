using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class VideoTruc : MonoBehaviour {

	public Button btnSkip;

	void Start()
	{
		btnSkip.onClick.AddListener (TaskOnClick);
	}

	void TaskOnClick()
	{
		if (EventSystem.current.currentSelectedGameObject.name == "Skip")
		{
			SceneManager.LoadScene ("Level");
		}
	}
}
