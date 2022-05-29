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

    public void ReceberDano(int dano)
    {
        currenteVida -= dano;

        if (currenteVida <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void NivelVida()
    {
        switch (XpPlayer.nivelAtual)
        {
            case 1:
                maxVida = 50;
                break;
        }
    }
}
