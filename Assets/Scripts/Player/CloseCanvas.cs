using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CloseCanvas : MonoBehaviour
{
    public AudioSource click;
    public Canvas canvas;
    public RespostasAdi��o respostasAdi��o;

    public void fechar_click()
    {
         // Desativa o Canvas
        canvas.enabled = false;
        Debug.Log("Clicou");
    }

    public void verificarR2_click()
    {
        respostasAdi��o = GameObject.FindObjectOfType<RespostasAdi��o>();
        respostasAdi��o.R2();
    }
}
