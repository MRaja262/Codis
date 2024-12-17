using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentPlataforma : MonoBehaviour
{
    [SerializeField] private float velocitat;
    [SerializeField] private Transform controladorTerraE;
    [SerializeField] private float distancia;
    [SerializeField] private bool movimentDreta;
    private Rigidbody2D rb;
    private Mono monoScript;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        monoScript = GetComponent<Mono>();
    }

    private void FixedUpdate()
    {
        if (monoScript.GetVida() <= 0)
        {
            rb.velocity = Vector2.zero;
            return;
        }

        RaycastHit2D informacioTerra = Physics2D.Raycast(controladorTerraE.position, Vector2.down, distancia);

        rb.velocity = new Vector2(velocitat, rb.velocity.y);

        if (informacioTerra == false)
        {
            //Girar
            Girar();
        }
    }

    private void Girar()
    {
        movimentDreta = !movimentDreta;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        velocitat *= -1;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(controladorTerraE.transform.position, controladorTerraE.transform.position + Vector3.down * distancia);
    }
}