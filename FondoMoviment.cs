using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FondoMoviment : MonoBehaviour
{
    [SerializeField] private Vector2 velocitatMoviment;
    private Vector2 offset;
    private Material material;

    private void Awake()
    {
        material=GetComponent<SpriteRenderer>().material;
    }

    private void Update()
    {
        offset = velocitatMoviment * Time.deltaTime;
        material.mainTextureOffset += offset;
    }
}
