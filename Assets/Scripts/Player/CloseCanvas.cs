using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CloseCanvas : MonoBehaviour
{
    public AudioSource click;
    public Canvas canvas;
    public RespostasAdição respostasAdição;

    public void fechar_click()
    {
         // Desativa o Canvas
        canvas.enabled = false;

    }

    public void verificarR2_click()
    {
        respostasAdição = GameObject.FindObjectOfType<RespostasAdição>();
        respostasAdição.R2();
    }

    public void verificarR3_click()
    {
        respostasAdição = GameObject.FindObjectOfType<RespostasAdição>();
        respostasAdição.R3();
    }

    public void verificarR4_click()
    {
        respostasAdição = GameObject.FindObjectOfType<RespostasAdição>();
        respostasAdição.R4();
    }
}
