using UnityEngine;

public class MeteorTrigger : MonoBehaviour
{
    public Animator meteorAnimator;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            meteorAnimator.SetTrigger("ActivateMeteor");
        }
    }
}
