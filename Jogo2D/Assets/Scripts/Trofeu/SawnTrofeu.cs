using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SawnTrofeu : MonoBehaviour
{
    public Text TextTrofeu;

    public GameObject trofeu;

    public Transform[] spawner;

    public static int quantia;

    public static int trofeuCorrente;

    void FixedUpdate()
    {
        CalcularTempo();
        ExibirUI();
    }

    void ExibirUI()
    {
        TextTrofeu.text = trofeuCorrente.ToString("0");
    }

    void CalcularTempo()
    {
        if(Cronometro.segundos >= 10 && Cronometro.segundos < 13)
        {

            SpawnarTrofeu();
            
        }
    }

    void SpawnarTrofeu()
    {
        int aleatorio = Random.Range(0, spawner.Length);

        if (spawner[aleatorio].position != null & quantia < 2)
        {
            Instantiate(trofeu, spawner[aleatorio].position, transform.rotation);

            quantia++;
        }
    }
}