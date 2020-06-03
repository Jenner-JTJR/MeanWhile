using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{

	public Inventory inventory;
	public GameObject itemButton;
	public AudioSource Pegar;

	// Start is called before the first frame update
	void Start()
    {
		inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player") && gameObject.tag != "Tocha")
		{
			for (int i = 0; i < inventory.slots.Length; i++)
			{
				if (inventory.isFull[i] == false)
				{
					inventory.isFull[i] = true;
					Instantiate(itemButton, inventory.slots[i].transform, false);
					GetKeyItem();
					Pegar.Play();
					Destroy(gameObject);
					break;
				}
			}
		}
		else if(collision.CompareTag("Player") && gameObject.tag == "Tocha")
		{
			GetKeyItem();
			Destroy(gameObject);
		}
	}

	public void GetKeyItem()
	{
		if(gameObject.tag == "RustedKey")
		{
			inventory.rustedKey = "RustedDoor";
		}
		if(gameObject.tag == "GoldenKey")
		{
			inventory.goldenKey = "GoldenDoor";
		}
		if(gameObject.tag == "XDoor")
		{
			inventory.xKey = "XDoor";
		}
		if(gameObject.tag == "Tocha")
		{
			inventory.tocha = "Tocha";
		}
		if (gameObject.tag == "PortaMadeira")
		{
			inventory.chaveMadeira = "PortaMadeira";
		}
		if (gameObject.tag == "PortaRunica")
		{
			inventory.chaveRunica = "PortaRunica";
		}
	}


}
