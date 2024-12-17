using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mono : MonoBehaviour
{
    [SerializeField] private float vida;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void FaMal(float mal)
    {
        vida -= mal;

        if (vida <= 0)
        {
            Mort();
        }
    }

    private void Mort()
    {
        animator.SetTrigger("MortMono");
    }

    public float GetVida()
    {
        return vida;
    }
}
