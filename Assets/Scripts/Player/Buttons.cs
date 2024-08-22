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
    public GameObject Player;

    public void fechar_click()
    {
         // Desativa o Canvas
        canvas.enabled = false;

    }

    public void iniciar() {
        transi��o = GameObject.FindObjectOfType<Transi��o>();
        transi��o.TransitionToScene("Game");
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetFloat("X", 594.25f);
        PlayerPrefs.SetFloat("Y", 5.036f);
        PlayerPrefs.SetFloat("Z", 321.36f);
    }

    public void carregar()
    {
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

    public void salvar()
    {
        PlayerPrefs.SetFloat("X", Player.transform.position.x);
        PlayerPrefs.SetFloat("Y", Player.transform.position.y);
        PlayerPrefs.SetFloat("Z", Player.transform.position.z);

        respostasAdi��o = GameObject.FindObjectOfType<RespostasAdi��o>();
        respostasSubtra��o = GameObject.FindObjectOfType<RespostasSubtra��o>();
        respostasMultiplica��o = GameObject.FindObjectOfType<RespostasMultiplica��o>();
        respostasDivis�o = GameObject.FindObjectOfType<RespostasDivis�o>();

        PlayerPrefs.SetInt("Q1_ad", respostasAdi��o.Q1ad);
        PlayerPrefs.SetInt("Q2_ad", respostasAdi��o.Q2ad);
        PlayerPrefs.SetInt("Q3_ad", respostasAdi��o.Q3ad);
        PlayerPrefs.SetInt("Q4_ad", respostasAdi��o.Q4ad);
        PlayerPrefs.SetInt("Q5_ad", respostasAdi��o.Q5ad);

        PlayerPrefs.SetInt("Q1_sub", respostasSubtra��o.Q1sub);
        PlayerPrefs.SetInt("Q2_sub", respostasSubtra��o.Q2sub);
        PlayerPrefs.SetInt("Q3_sub", respostasSubtra��o.Q3sub);
        PlayerPrefs.SetInt("Q4_sub", respostasSubtra��o.Q4sub);
        PlayerPrefs.SetInt("Q5_sub", respostasSubtra��o.Q5sub);

        PlayerPrefs.SetInt("Q1_mul", respostasMultiplica��o.Q1mul);
        PlayerPrefs.SetInt("Q2_mul", respostasMultiplica��o.Q2mul);
        PlayerPrefs.SetInt("Q3_mul", respostasMultiplica��o.Q3mul);
        PlayerPrefs.SetInt("Q4_mul", respostasMultiplica��o.Q4mul);
        PlayerPrefs.SetInt("Q5_mul", respostasMultiplica��o.Q5mul);

        PlayerPrefs.SetInt("Q1_div", respostasDivis�o.Q1div);
        PlayerPrefs.SetInt("Q2_div", respostasDivis�o.Q2div);
        PlayerPrefs.SetInt("Q3_div", respostasDivis�o.Q3div);
        PlayerPrefs.SetInt("Q4_div", respostasDivis�o.Q4div);
        PlayerPrefs.SetInt("Q5_div", respostasDivis�o.Q5div);

        PlayerPrefs.Save();
        Debug.Log(PlayerPrefs.GetInt("Q2_ad"));
    }

    public void continuar()
    {
        transi��o = GameObject.FindObjectOfType<Transi��o>();
        transi��o.TransitionToScene("Cr�ditos");
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
