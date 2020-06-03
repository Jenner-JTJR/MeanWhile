using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class DoorWithoutDialog : MonoBehaviour
{
	public SpriteRenderer doorSprite;
	public BoxCollider2D doorCollider;
	public Inventory inventory;
	public bool playerInRange;
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
			if (CrossPlatformInputManager.GetButtonDown("Fire1") && playerInRange)
			{
				player.playerMove = true;
				Destroy(gameObject);
			}

		}

		if (inventory.xKey == gameObject.tag)
		{
			if (CrossPlatformInputManager.GetButtonDown("Fire1") && playerInRange)
			{
				player.playerMove = true;
				Destroy(gameObject);
			}

		}

		if (inventory.chaveMadeira == gameObject.tag)
		{
			if (CrossPlatformInputManager.GetButtonDown("Fire1") && playerInRange)
			{
				player.playerMove = true;
				Destroy(gameObject);
			}

		}

		if (gameObject.tag == "keyless" && CrossPlatformInputManager.GetButtonDown("Fire1") && playerInRange)
		{
			player.playerMove = true;
			Destroy(gameObject);
		}
		if (inventory.goldenKey == gameObject.tag && CrossPlatformInputManager.GetButtonDown("Fire1"))
		{
			doorSprite.enabled = false;
			doorCollider.enabled = false;
		}
	}
}
