using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XpUI : MonoBehaviour
{
    [SerializeField] private Image xp;
    [SerializeField] private float velocidade;

    private void LateUpdate()
    {
        float porcentagemXp = (float)XpPlayer.currenteXp / XpPlayer.maxXp;
        xp.fillAmount = Mathf.Lerp(xp.fillAmount, porcentagemXp, Time.deltaTime * velocidade);
    }
}
