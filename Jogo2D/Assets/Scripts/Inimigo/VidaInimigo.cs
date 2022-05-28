using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaInimigo : MonoBehaviour
{
    public static int maxVida;
    public static int currenteVida;

    private void Start()
    {
        maxVida = 50;
        currenteVida = maxVida;
    }

    private void Update()
    {
        if(currenteVida <= 0)
        {
            Destroy(gameObject);
        }
    }
}
