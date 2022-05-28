using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmaControle : MonoBehaviour
{
    public Text txtPente;
    public Text txtMunicaoAtual;

    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private Transform player;

    public static int  municaoAtual;
    public static int penteTotal;

    void Update()
    {
        NivelArma();
        ExibirUI();

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

    void ExibirUI()
    {
        txtPente.text = penteTotal.ToString("00");
        txtMunicaoAtual.text = municaoAtual.ToString("00");
    }

    void NivelArma()
    {
        switch (XpPlayer.nivelAtual)
        {
            case 1:
                penteTotal = 5;
                break;
        }
            
    }
}
