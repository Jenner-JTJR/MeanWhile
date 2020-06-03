using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class GlobalLightIntensity : MonoBehaviour
{
	public Light2D gLight;
	public bool playerInRange = false;


    void Update()
    {
        
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			if (gameObject.tag == "LowIntensity")
			{
				gLight.intensity = 0.1f;
			}
			else
			{
				gLight.intensity = 0.79f;
			}
		}
	}


}
