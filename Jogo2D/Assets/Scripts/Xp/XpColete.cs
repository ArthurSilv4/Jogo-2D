using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XpColete : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            XpPlayer.currenteXp += 1;

            Destroy(this.gameObject);
        }
    }
}
