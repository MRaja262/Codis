using UnityEngine;
using Cinemachine;

public class CanviCamera2 : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera camSegueixPersonatge; 
    [SerializeField] private CinemachineVirtualCamera camFixaCoba; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            camSegueixPersonatge.Priority = 0; 
            camFixaCoba.Priority = 10; 
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            camSegueixPersonatge.Priority = 10;
            camFixaCoba.Priority = 0; 
        }
    }
}