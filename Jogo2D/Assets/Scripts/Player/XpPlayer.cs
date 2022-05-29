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
        maxXp = 10;
        currenteXp = maxXp;
    }

    private void FixedUpdate()
    {
        if(currenteXp >= maxXp)
        {
            nivelAtual++;
            currenteXp = 0;
        }
    }
}
