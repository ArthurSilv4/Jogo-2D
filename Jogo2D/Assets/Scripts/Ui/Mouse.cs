using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;

        Cursor.visible = false;
    }

    void FixedUpdate()
    {
        Vector2 curso = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = curso;
    }
}
