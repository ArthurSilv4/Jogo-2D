using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    [SerializeField] private Animator anim;

    [SerializeField] private Transform posicaoPlayer;
    [SerializeField] private float velocidade;

    [SerializeField] private SpriteRenderer inimigo;

    public static bool inimigoAtacando;

    private int danoInimigo;

    private float delei;
    private float deleiAtaque;

    void Start()
    {
        this.anim.GetComponent<Animator>();

        posicaoPlayer = GameObject.FindGameObjectWithTag("Player").transform;

        this.inimigo.GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
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

        //player.GetComponent<SpriteRenderer>().color = cores[1];


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
        else
        {
            inimigoAtacando = false;
        }
    }

    private void DanoPlayeer()
    {
        anim.SetTrigger("AtacandoInimigo");

        inimigoAtacando = true;

        VidaPlayer.currenteVida -= danoInimigo;

        delei = deleiAtaque;
    }

    //Player tem 100 de vida
    private void NivelAtaque()
    {
        switch (XpPlayer.nivelAtual)
        {
            case 1:
                deleiAtaque = 2;
                danoInimigo = 10;
                break;
        }
    }
}
