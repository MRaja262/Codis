using System;  
using System.Collections;  
using System.Collections.Generic;  
using UnityEngine;  
using TMPro;  
using UnityEngine.UI;  

public class VidaDeMiguel : MonoBehaviour  
{  
    [SerializeField] private float vidaInicial = 3f;  
    private float vida;  
    private MovimentDeMiguel movimentDeMiguel;  
    [SerializeField] private float tempsPerduaControl;  
    private Animator animator;  

    [Header("UI")]  
    [SerializeField] private TextMeshProUGUI textVida;  
    [SerializeField] private Button botonReintentar;  

    public event EventHandler MortJugador;   

    private void Start()   
    {  
        vida = vidaInicial;  
        movimentDeMiguel = GetComponent<MovimentDeMiguel>();  
        animator = GetComponent<Animator>();  
        ActualizarTextoVida();  
        botonReintentar.gameObject.SetActive(false);  
    }  

    public void TomarDaño(float daño)   
    {  
        TomarDaño(daño, Vector2.zero);  
    }  

    public void TomarDaño(float daño, Vector2 posicion)  
    {  
        vida -= daño;  
        ActualizarTextoVida();  

        if (vida > 0)  
        {  
            animator.SetTrigger("Golpe");  
        }  
        else  
        {  
            animator.SetTrigger("Muerte");  
            Physics2D.IgnoreLayerCollision(8, 9, true);  
            MortJugadorEvento();   
        }  
        StartCoroutine(PerdreControl());  
        movimentDeMiguel.Rebote(posicion);  
    }  

    public void MortJugadorEvento()  
    {  
        MortJugador?.Invoke(this, EventArgs.Empty);   
        botonReintentar.gameObject.SetActive(true);  
    }  

    private IEnumerator PerdreControl()  
    {  
        movimentDeMiguel.esPotMoure = false;  
        yield return new WaitForSeconds(tempsPerduaControl);  
        movimentDeMiguel.esPotMoure = true;  
    }  

    private void ActualizarTextoVida()  
    {  
        if (textVida != null)  
        {  
            textVida.text = vida.ToString("0");  
        }  
    }  

    public void RestaurarVida(float cantidad)  
    {  
        vida += cantidad;  
        ActualizarTextoVida();  
    }  

    public void Reintentar()  
    {  
        botonReintentar.gameObject.SetActive(false);  
        vida = vidaInicial;  
        ActualizarTextoVida();  
        transform.position = new Vector3(-6f, -2.753266f, transform.position.z);  
        Physics2D.IgnoreLayerCollision(8, 9, false);  
    }  
}