using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlePlayer : MonoBehaviour
{
    public Animator anin;
    public Rigidbody2D rig;

    [SerializeField] private Transform armaAux;
    [SerializeField] private GameObject bala;
    [SerializeField] private Transform spawnBala;

    [SerializeField] private float velocidadeMoimento;

    private float deleiAtirar;
    private float tempoAtualTiro;

    private Vector2 movimento;

    private Quaternion miraDireita;
    private Quaternion miraEsuerda;

    public static Vector3 olhandoDireita;
    public static Vector3 olhandoEsquerda;

    void Start()
    {
        olhandoDireita = transform.localScale;
        olhandoEsquerda = transform.localScale;
        olhandoEsquerda.x = olhandoEsquerda.x * -1;

        miraDireita = spawnBala.gameObject.transform.rotation;
        miraEsuerda = spawnBala.gameObject.transform.rotation;
        miraEsuerda.z = 170;

        tempoAtualTiro = 0.9f;

        rig.GetComponent<Rigidbody2D>();
        anin.GetComponent<Animator>();
    }

    void Update()
    {
        movimento.x = Input.GetAxisRaw("Horizontal");
        movimento.y = Input.GetAxisRaw("Vertical");

        Animacao();
        Rotacao();
        Atirar();
    }

    private void FixedUpdate()
    {
        rig.MovePosition(rig.position + movimento.normalized * velocidadeMoimento * Time.fixedDeltaTime);
    }

    void Rotacao()
    {
        if (Input.GetAxisRaw("Horizontal") > 0) //Olhando direita
        {
            spawnBala.transform.localRotation = miraDireita;

            armaAux.transform.localScale = olhandoDireita;
            transform.localScale = olhandoDireita;
        }
        if (Input.GetAxisRaw("Horizontal") < 0) //Olhando esquerda
        {
            spawnBala.transform.localRotation = miraEsuerda;

            armaAux.transform.localScale = olhandoEsquerda;
            transform.localScale = olhandoEsquerda;
        }
    }

    void Atirar()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (deleiAtirar <= 0)
            {
                anin.SetBool("Atirando", true);

                deleiAtirar = tempoAtualTiro;

                Instantiate(bala, spawnBala.position, spawnBala.rotation);
            }
        }
        else
        {
            anin.SetBool("Atirando", false);

        }

        if (deleiAtirar > 0)
        {
            deleiAtirar -= 1 * Time.deltaTime;
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
    }
}
