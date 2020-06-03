using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PuxarAlavanca : MonoBehaviour
{
	private bool playerInRange;
	public int alavanca;
	public Puzzle puzzle;
	public GameObject actionButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(CrossPlatformInputManager.GetButtonDown("Fire1") && playerInRange)
		{
			Debug.Log("AlavancaPuxada");
			Puxar();
		}
    }
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			playerInRange = true;
			actionButton.SetActive(true);
		}
	}
	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			playerInRange = false;
			actionButton.SetActive(false);
		}
	}

	public void Puxar()
	{
		puzzle.alavancaPuxada = alavanca;
		puzzle.CheckAlavanca();
	}
}
