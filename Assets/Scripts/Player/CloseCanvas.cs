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
    public RespostasSubtra��o respostasSubtra��o;

    public void fechar_click()
    {
         // Desativa o Canvas
        canvas.enabled = false;

    }
    // verificar adi��o
    public void verificarR2_click()
    {
        respostasAdi��o = GameObject.FindObjectOfType<RespostasAdi��o>();
        respostasAdi��o.R2();
    }

    public void verificarR3_click()
    {
        respostasAdi��o = GameObject.FindObjectOfType<RespostasAdi��o>();
        respostasAdi��o.R3();
    }

    public void verificarR4_click()
    {
        respostasAdi��o = GameObject.FindObjectOfType<RespostasAdi��o>();
        respostasAdi��o.R4();
    }

    // verificar subtra��o

    public void verificarR1_sub_click()
    {
        respostasSubtra��o = GameObject.FindObjectOfType<RespostasSubtra��o>();
        respostasSubtra��o.R1();
    }
    public void verificarR2_sub_click()
    {
        respostasSubtra��o = GameObject.FindObjectOfType<RespostasSubtra��o>();
        respostasSubtra��o.R2();
    }

    public void verificarR3_sub_click()
    {
        respostasSubtra��o = GameObject.FindObjectOfType<RespostasSubtra��o>();
        respostasSubtra��o.R3();
    }

    public void verificarR5_sub_click()
    {
        respostasSubtra��o = GameObject.FindObjectOfType<RespostasSubtra��o>();
        respostasSubtra��o.R5();
    }
}
