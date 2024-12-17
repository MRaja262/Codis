using UnityEngine;

public class VidaPickup : MonoBehaviour
{
    [SerializeField] private float quantitatVida = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Assegura't que el tag sigui correcte
        {
            // Buscar el component VidaDeMiguel en el jugador
            VidaDeMiguel vidaJugador = collision.GetComponent<VidaDeMiguel>();
            if (vidaJugador != null)
            {
                Debug.Log("Jugador detectat i component VidaDeMiguel trobat. Restaurant vida...");
                vidaJugador.RestaurarVida(quantitatVida);
            }
            else
            {
                Debug.LogError("Jugador detectat, però el component VidaDeMiguel no s'ha trobat!");
            }

            // Destruir l'objecte de vida després de la col·lisió
            Destroy(gameObject);
        }
    }
}