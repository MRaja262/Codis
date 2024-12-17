using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Menu : MonoBehaviour
{
	[SerializeField] private GameObject menu;
	private VidaDeMiguel vidaDeMiguel;
	
	private void Start()
	{
		vidaDeMiguel = GameObject.FindGameObjectWithTag("Player").GetComponent<VidaDeMiguel>();
		vidaDeMiguel.MortJugador += ObrirMenu;
	}
	
	private void ObrirMenu(object sender, EventArgs e)
	{
		menu.SetActive(true);
	}
	
	public void Reiniciar()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
