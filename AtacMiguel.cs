using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtacMiguel : MonoBehaviour
{
    [SerializeField] private Transform controladorAtac;
    [SerializeField] private float radiAtac;
    [SerializeField] private float malAtac;
	[SerializeField] private float tempsEntreAtac;
    [SerializeField] private float tempsSeguentAtac;
	private Animator animator;
	
	private void Start()
	{
		animator = GetComponent<Animator>();
	}

    private void Update()
    {
		if (tempsSeguentAtac > 0)
		{
			tempsSeguentAtac -= Time.deltaTime;
		}
		
        if (Input.GetButtonDown("Fire1") && tempsSeguentAtac <= 0)
        {
            Atac();
			tempsSeguentAtac = tempsEntreAtac;
        }
    }

    private void Atac()
    {
		animator.SetTrigger("Atac");
		
        Collider2D[] objectes = Physics2D.OverlapCircleAll(controladorAtac.position, radiAtac);

        foreach (Collider2D colisionador in objectes)
        {
            if (colisionador.CompareTag("Mono"))
            {
                colisionador.transform.GetComponent<Mono>().FaMal(malAtac);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controladorAtac.position, radiAtac);
    }
	
}
