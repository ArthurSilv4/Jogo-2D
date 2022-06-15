using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Botoes : MonoBehaviour
{
    public Text Textsegundos;
    public Text Textminutos;
    public Text TextPontos;


    public GameObject canvasInicial;
    public GameObject canvasSobre;
    public GameObject canvasPause;
    public GameObject canvasGameOver;

    void Start()
    {
        PauseOn();

        canvasSobre.SetActive(false);
        canvasInicial.SetActive(true);
        canvasPause.SetActive(false);
        canvasGameOver.SetActive(false);

    }

    private void Update()
    {
        GameOver();
    }


    public void GameOver()
    {
        Textsegundos.text = Cronometro.segundos.ToString("00");
        Textminutos.text = Cronometro.minutos.ToString("00");

        TextPontos.text = Cronometro.pontos.ToString("0");

        if (ControlePlayer.morto == true)
        {
            canvasGameOver.SetActive(true);
        }
    }

    public void Play()
    {
        PauseOFF();

        canvasInicial.SetActive(false);
    }

    public void SobreOpen()
    {
        canvasSobre.SetActive(true);
    }

    public void SobreOFF()
    {
        canvasSobre.SetActive(false);
    }

    public void PausadoON()
    {
        canvasPause.SetActive(true);

        PauseOn();

    }

    public void PausadoOFF()
    {
        canvasPause.SetActive(false);

        PauseOFF();
    }

    public void Reiniciar()
    {
        canvasPause.SetActive(false);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void PauseOn()
    {
        Time.timeScale = 0;
    }

    void PauseOFF()
    {
        Time.timeScale = 1;
    }
}
