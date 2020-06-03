using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Puzzle : MonoBehaviour
{
	public bool playerInRange;
	private bool mostrandoImagem;
	public GameObject actionButton;
	public GameObject[] imagens;
	private int[] sequencia = {1,0,2};
	[SerializeField]private int contadorSequencia;
	public int alavancaPuxada;
	public GameObject chave;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (CrossPlatformInputManager.GetButtonDown("Fire1"))
		{
			if (playerInRange && !mostrandoImagem)
			{
				MostrarImagem(contadorSequencia);
			}
			else if (mostrandoImagem)
			{
				EsconderImagem(contadorSequencia);
			}
		}
		
		if(contadorSequencia == 3)
		{
			MostrarChave();
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

	public void MostrarImagem(int imagem)
	{
		imagens[imagem].SetActive(true);
		mostrandoImagem = true;
	}

	public void EsconderImagem(int imagem)
	{
		mostrandoImagem = false;
		imagens[imagem].SetActive(false);
	}

	public void AumentarContador()
	{
		contadorSequencia++;
	}

	public void ResetContador()
	{
		contadorSequencia = 0;
	}

	public void CheckAlavanca()
	{
		bool alavancaCorreta = sequencia[contadorSequencia] == alavancaPuxada;
		if(alavancaCorreta)
		{
			AumentarContador();
		}
		else
		{
			ResetContador();
		}
	}

	public void MostrarChave()
	{
		chave.SetActive(true);
	}
}
