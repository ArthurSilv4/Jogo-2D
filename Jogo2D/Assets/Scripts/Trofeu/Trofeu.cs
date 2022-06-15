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
        yield return new WaitForSeconds(50f);
        Destroy(gameObject);
    }
}
