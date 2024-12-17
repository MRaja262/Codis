using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentDeMiguel : MonoBehaviour
{  
    private Rigidbody2D rb2D;  
    private float movimentHoritzontal;  
    private Vector3 velocitat = Vector3.zero;  
    private bool mirantDreta = true;  

    [Header("Configuració de Moviment")]  
    [SerializeField] private float velocitatDeMoviment;  
    [SerializeField] private LayerMask queEsTerra;  
    [SerializeField] private Transform controladorTerra;  
    [SerializeField] private Vector3 dimensionsCaixa;  
    [SerializeField] private bool enTerra;  
    private bool salt = false;  
    [SerializeField] private float forcaDeSalt;  

    [Header("Aigua")]  
    [SerializeField] private LayerMask queEsAigua;   
    private bool enAigua = false;   
    [SerializeField] private float velocitatEnAigua = 2f;   
    [SerializeField] private float saltEnAigua = 5f;   
    [SerializeField] private float suavitzatDeMoviment = 0.1f;   
    [SerializeField] private Vector2 velocitatRebot; 
    public bool esPotMoure = true; 

    [Header("Animació")]  
    private Animator animator;  

    private void Start()  
    {  
        rb2D = GetComponent<Rigidbody2D>();  
        animator = GetComponent<Animator>();  
    }  

    private void Update()  
    {  
        movimentHoritzontal = Input.GetAxisRaw("Horitzontal") * (enAigua ? velocitatEnAigua : velocitatDeMoviment);  

        animator.SetFloat("Horitzontal", Mathf.Abs(movimentHoritzontal));  
        animator.SetFloat("VelocitatY", rb2D.velocity.y);  

        if (Input.GetButtonDown("Jump"))  
        {  
            salt = true;  
        }  
    }  

    private void FixedUpdate()  
    {  
        enTerra = Physics2D.OverlapBox(controladorTerra.position, dimensionsCaixa, 0f, queEsTerra);  
        animator.SetBool("enTerra", enTerra);  

        if(esPotMoure)  
        {  
            Moure(movimentHoritzontal * Time.fixedDeltaTime, salt);  
        }  
        
        salt = false;  
    }  

    public void Rebote(Vector2 puntCop)  
    {  
        rb2D.velocity = new Vector2(-velocitatRebot.x * puntCop.x, velocitatRebot.y);  
    }  

    private void Moure(float moure, bool saltar)  
    {  
        if (enAigua)  
        {  
            Vector3 velocitatObjectiu = new Vector2(moure, rb2D.velocity.y * 0.9f);   
            rb2D.velocity = Vector3.SmoothDamp(rb2D.velocity, velocitatObjectiu, ref velocitat, suavitzatDeMoviment);  

            if (saltar)  
            {  
                rb2D.velocity = new Vector2(rb2D.velocity.x, saltEnAigua);   
            }  
        }  
        else  
        {  
            Vector3 velocitatObjectiu = new Vector2(moure, rb2D.velocity.y);  
            rb2D.velocity = Vector3.SmoothDamp(rb2D.velocity, velocitatObjectiu, ref velocitat, suavitzatDeMoviment);  

            if (enTerra && saltar)  
            {  
                enTerra = false;  
                rb2D.AddForce(new Vector2(0f, forcaDeSalt));  
            }  
        }  

        if (moure > 0 && !mirantDreta)  
        {  
            Girar();  
        }  
        else if (moure < 0 && mirantDreta)  
        {  
            Girar();  
        }  
    }  

    private void Girar()  
    {  
        mirantDreta = !mirantDreta;  
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);  
    }  

    private void OnDrawGizmos()  
    {  
        Gizmos.color = Color.yellow;  
        Gizmos.DrawWireCube(controladorTerra.position, dimensionsCaixa);  
    }  

    private void OnTriggerEnter2D(Collider2D collision)  
    {  
        if (((1 << collision.gameObject.layer) & queEsAigua) != 0)  
        {  
            enAigua = true;  
            animator.SetBool("enAigua", enAigua);  
            rb2D.gravityScale = 0.5f;   
        }  
    }  

    private void OnTriggerExit2D(Collider2D collision)  
    {  
        if (((1 << collision.gameObject.layer) & queEsAigua) != 0)
        {  
            enAigua = false;  
            animator.SetBool("enAigua", enAigua);  
            rb2D.gravityScale = 1f;   
        }  
    }  
}