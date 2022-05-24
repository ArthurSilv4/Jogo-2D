using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaControle : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sprite;

    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.position);

        Vector2 offset = new Vector2(mousePosition.x - screenPoint.x, mousePosition.y - screenPoint.y);

        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle);

        sprite.flipY = (mousePosition.x < screenPoint.x);
    }
}
