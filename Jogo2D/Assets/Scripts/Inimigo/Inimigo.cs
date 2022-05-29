using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    [SerializeField] private Transform posicaoPlayer;
    [SerializeField] private float velocidade;

    [SerializeField] private SpriteRenderer inimigo;

    private float delei;
    private float deleiAtaque;

    void Start()
    {
        posicaoPlayer = GameObject.FindGameObjectWithTag("Player").transform;

        this.inimigo.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(posicaoPlayer.gameObject != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, posicaoPlayer.position, velocidade * Time.deltaTime);
        }

        //virar inimigo
        if(this.posicaoPlayer.position.x < this.transform.position.x)
        {
            this.inimigo.flipX = true;
        }
        else
        {
            this.inimigo.flipX = false;
        }

        delei -= Time.deltaTime;

        NivelAtaque();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(delei <= 0)
            {
                DanoPlayeer();
            }
        }
    }

    private void DanoPlayeer()
    {
        VidaPlayer.currenteVida -= 3;

        delei = deleiAtaque;
    }

    private void NivelAtaque()
    {
        switch (XpPlayer.nivelAtual)
        {
            case 1:
                deleiAtaque = 2;
                break;
        }
    }
}
