using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesaparecerPuerta2 : MonoBehaviour
{
    public GameObject puerta; 
    public GameObject llave;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            puerta.SetActive(false); 
            llave.SetActive(false);
        }
    }
}