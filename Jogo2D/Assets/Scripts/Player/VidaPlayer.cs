using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class VidaPlayer : MonoBehaviour
{

    public static int maxVida;
    public static int currenteVida;

    private void Start()
    {
        maxVida = 100;
        currenteVida = maxVida;
    }

    private void Update()
    {
        if(Cronometro.minutos == 2 || Cronometro.minutos == 4 || Cronometro.minutos == 6)
        {
            currenteVida += 2;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Vida"))
        {
            currenteVida += 5;
            Destroy(collision.gameObject);
        }
    }
}
