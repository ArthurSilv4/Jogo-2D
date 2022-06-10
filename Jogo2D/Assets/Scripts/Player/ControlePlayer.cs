using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlePlayer : MonoBehaviour
{
    [SerializeField] private SpriteRenderer render;

    [SerializeField] private GameObject scriptInimigo;
    [SerializeField] private GameObject explosao;


    [SerializeField] private Animator armaAnin;
    [SerializeField] private Animator anin;
    [SerializeField] private Rigidbody2D rig;

    [SerializeField] private GameObject bala;
    [SerializeField] private Transform spawnBala;

    [SerializeField] private float velocidadeMoimento;

    private float deleiAtirar;
    private float tempoAtualTiro;

    private Vector2 movimento;

    void Start()
    {
        explosao.SetActive(false);

        scriptInimigo.GetComponent<Inimigo>().enabled = true;

        tempoAtualTiro = 0.85f;

        render.gameObject.GetComponent<SpriteRenderer>();
        rig.gameObject.GetComponent<Rigidbody2D>();
        anin.gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        movimento.x = Input.GetAxisRaw("Horizontal");
        movimento.y = Input.GetAxisRaw("Vertical");

        Animacao();
        Rotacao();
        Atirar();
        StartCoroutine(Recarregar());
        StartCoroutine(MudarACor());
    }

    private void FixedUpdate()
    {
        rig.MovePosition(rig.position + movimento.normalized * velocidadeMoimento * Time.fixedDeltaTime);
    }

    void Rotacao()
    {
        if (Input.GetAxisRaw("Horizontal") > 0) //Olhando direita
        {
            render.flipX = false;
        }
        if (Input.GetAxisRaw("Horizontal") < 0) //Olhando esquerda
        {
            render.flipX = true;
        }
    }

    IEnumerator Recarregar()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (ArmaControle.municaoAtual != ArmaControle.penteTotal)
            {
                yield return new WaitForSeconds(0.5f);
                ArmaControle.municaoAtual = ArmaControle.penteTotal;
            }
        }
    }

    void Atirar()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (deleiAtirar <= 0 && ArmaControle.municaoAtual > 0)
            {
                armaAnin.SetTrigger("Fire");

                anin.SetBool("Atirando", true);

                deleiAtirar = tempoAtualTiro;

                ArmaControle.municaoAtual--;

                Instantiate(bala, spawnBala.position, spawnBala.rotation);
            }
        }
        else
        {
            anin.SetBool("Atirando", false);
        }

        if (deleiAtirar > 0)
        {
            deleiAtirar -=  Time.deltaTime;
        }
    }

    IEnumerator MudarACor()
    {
        if (Inimigo.inimigoAtacando == true)
        {
            render.color = Color.red;

            yield return new WaitForSeconds(0.5f);

            render.color = Color.white;
        }
    }

    void Animacao()
    {
        //Andando
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            anin.SetBool("Andando", true);
        }
        else
        {
            anin.SetBool("Andando", false);
        }

        if (VidaPlayer.currenteVida <= 0)
        {
            anin.SetBool("Morrendo", true);

            explosao.SetActive(true);

            gameObject.GetComponent<ControlePlayer>().enabled = false;
            gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
            scriptInimigo.GetComponent<Inimigo>().enabled = false;
        }
    }
}
