using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    public AudioSource click;
    public Canvas canvas;
    public RespostasAdi��o respostasAdi��o;
    public RespostasSubtra��o respostasSubtra��o;
    public RespostasMultiplica��o respostasMultiplica��o;
    public RespostasDivis�o respostasDivis�o;
    public Transi��o transi��o;
    public PauseMenu pauseMenu;

    public void fechar_click()
    {
         // Desativa o Canvas
        canvas.enabled = false;

    }

    public void iniciar() {
        transi��o = GameObject.FindObjectOfType<Transi��o>();
        transi��o.TransitionToScene("Game");
    }

    public void controles()
    {
        transi��o = GameObject.FindObjectOfType<Transi��o>();
        transi��o.TransitionToScene("Controles");
    }

    public void vamosL�()
    {
        transi��o = GameObject.FindObjectOfType<Transi��o>();
        transi��o.TransitionToScene("MenuInicial");
    }

    public void sair()
    {
        Application.Quit();
    }

    public void continuar()
    {
        transi��o = GameObject.FindObjectOfType<Transi��o>();
        transi��o.TransitionToScene("Cr�ditos");
    }
    public void Menu()
    {
        pauseMenu = GameObject.FindObjectOfType<PauseMenu>();
        pauseMenu.Resume();
        transi��o = GameObject.FindObjectOfType<Transi��o>();
        transi��o.TransitionToScene("MenuInicial");
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

    // verificar multiplica��o

    public void verificarR2_mult_click()
    {
        respostasMultiplica��o = GameObject.FindObjectOfType<RespostasMultiplica��o>();
        respostasMultiplica��o.R2();
    }

    public void verificarR3_mult_click()
    {
        respostasMultiplica��o = GameObject.FindObjectOfType<RespostasMultiplica��o>();
        respostasMultiplica��o.R3();
    }

    public void verificarR4_mult_click()
    {
        respostasMultiplica��o = GameObject.FindObjectOfType<RespostasMultiplica��o>();
        respostasMultiplica��o.R4();
    }

    // verificar divis�o

    public void verificarR1_div_click()
    {
        respostasDivis�o = GameObject.FindObjectOfType<RespostasDivis�o>();
        respostasDivis�o.R1();
    }
    public void verificarR2_div_click()
    {
        respostasDivis�o = GameObject.FindObjectOfType<RespostasDivis�o>();
        respostasDivis�o.R2();
    }

    public void verificarR3_div_click()
    {
        respostasDivis�o = GameObject.FindObjectOfType<RespostasDivis�o>();
        respostasDivis�o.R3();
    }

    public void verificarR5_div_click()
    {
        respostasDivis�o = GameObject.FindObjectOfType<RespostasDivis�o>();
        respostasDivis�o.R5();
    }
}
