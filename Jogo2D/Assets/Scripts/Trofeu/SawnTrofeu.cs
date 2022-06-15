using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawnTrofeu : MonoBehaviour
{
    public GameObject trofeu;

    public Transform[] spawner;

    public static bool podeSpawnar;
    int aleatorio;

    void Start()
    {
        podeSpawnar = true;
    }

    void FixedUpdate()
    {
        StartCoroutine(CalcularTempo());
    }

    IEnumerator CalcularTempo()
    {
        if(Cronometro.segundos >= 10 && Cronometro.segundos < 15)
        {

            SpawnarTrofeu();

            yield return new WaitForSeconds(60f);
            podeSpawnar = true;
        }
    }

    void SpawnarTrofeu()
    {
        int aleatorio = Random.Range(0, spawner.Length);

        if (spawner[aleatorio].position != null & podeSpawnar == true)
        {
            Instantiate(trofeu, spawner[aleatorio].position, transform.rotation);

            podeSpawnar = false;
        }
    }
}
