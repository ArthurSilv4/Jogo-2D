using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawninimigo : MonoBehaviour
{
    public GameObject[] inimigoSpawnavel;
    public Transform[] pontoSpawn;

    private float tempoMaximoSpawn;
    private float tempoAtualSpawn;

    void Start()
    {
        tempoAtualSpawn = tempoMaximoSpawn;
    }

    void Update()
    {
        tempoAtualSpawn -= Time.deltaTime;

        if (tempoAtualSpawn <= 0)
        {
            SpawnarInimigo();
        }

        NivelSpawn();
    }

    void SpawnarInimigo()
    {
        int inimigoAleatorio = Random.Range(0, inimigoSpawnavel.Length);
        int pontoAleatorio = Random.Range(0, pontoSpawn.Length);

        Instantiate(inimigoSpawnavel[inimigoAleatorio], pontoSpawn[pontoAleatorio].position, Quaternion.Euler(0,0,0));

        tempoAtualSpawn = tempoMaximoSpawn;
    }

    //
    private void NivelSpawn()
    {
        switch (XpPlayer.nivelAtual)
        {
            case 1:
                tempoMaximoSpawn = 5;
                break;
        }
    }
}
