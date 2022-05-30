using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaInimigo : MonoBehaviour
{
    public GameObject spritXp;

    public static int maxVida;
    public static int currenteVida;

    private void Start()
    {
        maxVida = 100;
        currenteVida = maxVida;
    }

    public void ReceberDano(int dano)
    {
        currenteVida -= dano;

        if (currenteVida <= 0)
        {
            Destroy(this.gameObject);

            Instantiate(spritXp, this.transform.position, this.transform.rotation);

            Cronometro.pontos += 7.4f;
        }
    }
}
