using UnityEngine;
using Cinemachine;

public class CanviCamera : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera camSegueixPersonatge; 
    [SerializeField] private CinemachineVirtualCamera camFixaAigua; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            camSegueixPersonatge.Priority = 0; 
            camFixaAigua.Priority = 10; 
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            camSegueixPersonatge.Priority = 10;
            camFixaAigua.Priority = 0; 
        }
    }
}
