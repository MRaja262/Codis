using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moneda : MonoBehaviour
{
    [SerializeField] private float cuantitatPunts; 
    [SerializeField] private Puntaje puntaje; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (puntaje != null)
            {
                puntaje.SumarPuntos(cuantitatPunts);
                Destroy(gameObject); 
            }
            else
            {
                Debug.LogError("Referencia de 'puntaje' no asignada. Asegúrate de asignar un objeto en el Inspector.");
            }
        }
    }
}
