using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonGameStart : MonoBehaviour 
{

	[SerializeField]
	Button _buttonStart;

	void OnEnable()
	{
		_buttonStart.onClick.AddListener( GoButtonClick);
	}

	bool fullscreen;
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.F10))
		{
			Resolution[] resolutions = Screen.resolutions;
			fullscreen=!fullscreen;
			if (fullscreen)
				Screen.SetResolution(resolutions[resolutions.Length-1].width, resolutions[resolutions.Length-1].height,fullscreen);
			else
				Screen.SetResolution(1920, 1080,fullscreen);
		}
	}

	void  GoButtonClick()
	{
		Application.LoadLevel ("Game");
	}

	void OnDisable()
	{
		_buttonStart.onClick.AddListener (GoButtonClick);
	}
}
