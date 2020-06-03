﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;
using TMPro;

public class DialogTest : MonoBehaviour

{
	public GameObject dialogBox;
	public bool playerInRange;
	public TextMeshProUGUI textDisplay;
	public string[] sentences;
	private int index;
	public float typingSpeed;
	public bool canContinue;
	public GameObject image;
	public PlayerMove player;
	public GameObject actionButton;

	// Start is called before the first frame update
	void Start()
    {
		canContinue = true;
	}

	private void Update()
	{
		if (textDisplay.text == sentences[index])
		{
			canContinue = true;
		}

		DialogInputSystem();

		
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			actionButton.SetActive(true);
			playerInRange = true;
			dialogBox.SetActive(false);
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			actionButton.SetActive(false);
			playerInRange = false;
			dialogBox.SetActive(false);
		}
	}

	public void DialogInputSystem()
	{
		if (CrossPlatformInputManager.GetButtonDown("Fire1") && playerInRange == true)
		{
			if (dialogBox.activeInHierarchy == false)
			{
				player.playerMove = false;
				dialogBox.SetActive(true);
				image.SetActive(true);
				StartCoroutine(Type());
			}
			else if (CrossPlatformInputManager.GetButtonDown("Fire1") && index < sentences.Length - 1 && canContinue)
			{
				NextSentence();
			}
		}
		else if (dialogBox && index == sentences.Length - 1)
		{
			player.playerMove = true;
			dialogBox.SetActive(false);
			image.SetActive(false);
			index = 0;
			if (gameObject.tag == "OneTimeEvent")
			{
				Destroy(gameObject);
			}
		}
	}

	IEnumerator Type()
	{
		foreach(char letter in sentences[index].ToCharArray())
		{
			textDisplay.text += letter;
			yield return new WaitForSeconds(typingSpeed);
			canContinue = false;
		}
	}

	public void NextSentence()
	{
		canContinue = false;

		if (index < sentences.Length - 1)
		{
			index++;
			textDisplay.text = "";
			StartCoroutine(Type());
		}
		else
		{
			textDisplay.text = "";
			canContinue = false;
		}
	}

}
