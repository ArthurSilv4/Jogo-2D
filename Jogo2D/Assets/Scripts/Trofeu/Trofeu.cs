using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trofeu : MonoBehaviour
{

    void Update()
    {
        StartCoroutine(Destruir());
    }

    IEnumerator Destruir()
    {
        yield return new WaitForSeconds(70f);
        Destroy(gameObject);
        SawnTrofeu.quantia--;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SawnTrofeu.trofeuCorrente += 1;

            Destroy(gameObject);
        }
    }
}
