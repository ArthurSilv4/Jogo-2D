using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XpPlayer : MonoBehaviour
{

    public static int currenteXp;
    public static int maxXp;

    public static int nivelAtual;

    private void Start()
    {
        currenteXp = maxXp;
    }

    private void FixedUpdate()
    {
        //Passar Nivel
        if(currenteXp >= maxXp)
        {
            nivelAtual++;
            currenteXp = 0;
        }

        XpNivel();
    }

    private void XpNivel()
    {
        switch (nivelAtual)
        {
            case 1:
                maxXp = 10;
                break;
            case 2:
                maxXp = 15;
                break;
        }

        if(nivelAtual > 2)
        {
            maxXp = 20;
        }
    }
}
