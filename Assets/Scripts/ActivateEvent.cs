using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateEvent : MonoBehaviour
{

	public GameObject actEvent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			if(actEvent.tag == "XDoor")
			{
				Destroy(actEvent);
			}
			else if(actEvent.tag == "PortaRunica")
			{
				Destroy(actEvent);
			}
			else if(actEvent.tag == "PortaMadeira")
			{
				Destroy(actEvent);
			}
			else
			{
				actEvent.SetActive(true);
			}
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{

		}

	}
}
