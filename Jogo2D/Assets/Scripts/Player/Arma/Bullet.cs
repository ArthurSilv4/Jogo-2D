using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float velocidade;

    void Update()
    {
        transform.Translate(Vector2.right * velocidade * Time.deltaTime);

        StartCoroutine(Destruir());
    }

    IEnumerator Acertou()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }

    IEnumerator Destruir()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Inimigo"))
        {
            VidaInimigo.currenteVida -= 5;

            StartCoroutine(Acertou());
        }
    }
}
