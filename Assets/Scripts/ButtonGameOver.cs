using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonGameOver : MonoBehaviour 
{
	[SerializeField]
	Button _buttonNew;

	void OnEnable()
	{
		_buttonNew.onClick.AddListener( GoButtonClick);
	}

	void Start () 
	{
	
	}

	void  GoButtonClick()
	{
		Application.LoadLevel ("Game");

	}
		
	void OnDisable()
	{

		_buttonNew.onClick.AddListener (GoButtonClick);
	}
}
