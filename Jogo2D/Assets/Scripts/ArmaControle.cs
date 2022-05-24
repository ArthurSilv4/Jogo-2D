using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaControle : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private Transform player;

    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.position);

        Vector2 offset = new Vector2(mousePosition.x - screenPoint.x, mousePosition.y - screenPoint.y);

        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle);

        sprite.flipY = (mousePosition.x < screenPoint.x);

        if (Input.GetKeyDown(KeyCode.Mouse1) && sprite.flipY == true)
        {
            player.transform.localScale = ControlePlayer.olhandoEsquerda;
            transform.localScale = ControlePlayer.olhandoEsquerda;
        }

        if (Input.GetKeyDown(KeyCode.Mouse1) && sprite.flipY == false)
        {
            player.transform.localScale = ControlePlayer.olhandoDireita;
            transform.localScale = ControlePlayer.olhandoDireita;
        }
    }
}
