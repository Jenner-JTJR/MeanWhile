using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class Door : MonoBehaviour
{
	public SpriteRenderer doorSprite;
	public BoxCollider2D doorCollider;
	public Inventory inventory;
	public bool playerInRange;
	public DialogTest dialog;
	public PlayerMove player;
	public GameObject actionButton;

    void Start()
    {
		
    }

    void Update()
    {
		OpenDoor();
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			actionButton.SetActive(true);
			playerInRange = true;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		actionButton.SetActive(false);
		playerInRange = false;
	}

	public void OpenDoor()
	{
		if (inventory.rustedKey == gameObject.tag)
		{
			gameObject.GetComponent<DialogTest>().enabled = false;
			dialog.image.SetActive(false);
			if (CrossPlatformInputManager.GetButtonDown("Fire1") && playerInRange)
			{
				player.playerMove = true;
				Destroy(gameObject);
				dialog.dialogBox.SetActive(false);
			}

		}

		if (inventory.xKey == gameObject.tag)
		{
			gameObject.GetComponent<DialogTest>().enabled = false;
			dialog.image.SetActive(false);
			if (CrossPlatformInputManager.GetButtonDown("Fire1") && playerInRange)
			{
				Destroy(gameObject);
				dialog.dialogBox.SetActive(false);
			}

		}

		if (inventory.chaveMadeira == gameObject.tag)
		{
			gameObject.GetComponent<DialogTest>().enabled = false;
			dialog.image.SetActive(false);
			if (CrossPlatformInputManager.GetButtonDown("Fire1") && playerInRange)
			{
				Destroy(gameObject);
				dialog.dialogBox.SetActive(false);
			}

		}

		if (inventory.chaveRunica == gameObject.tag)
		{
			gameObject.GetComponent<DialogTest>().enabled = false;
			dialog.image.SetActive(false);
			if (CrossPlatformInputManager.GetButtonDown("Fire1") && playerInRange)
			{
				Destroy(gameObject);
				dialog.dialogBox.SetActive(false);
			}

		}


	}
}
