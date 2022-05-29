using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    [SerializeField] private Transform posicaoPlayer;
    [SerializeField] private float velocidade;

    void Start()
    {
        posicaoPlayer = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if(posicaoPlayer.gameObject != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, posicaoPlayer.position, velocidade * Time.deltaTime);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            print("Colidiu Plauer");
        }
    }
}
