using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
	public Text textButtonPlay;
	public bool startGame;
	
	// This script is to write new methods
	private void Start()
	{
		textButtonPlay.text = "New Game";
	}

	private void Update()
	{
		if (startGame)
		{
			textButtonPlay.text = "Play";
		}
	}
	
	public void GameStarted()
	{
		startGame = true;
	}
}
