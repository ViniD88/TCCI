using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    public AudioSource click;
    public Canvas canvas;
    public RespostasAdição respostasAdição;
    public RespostasSubtração respostasSubtração;
    public RespostasMultiplicação respostasMultiplicação;
    public RespostasDivisão respostasDivisão;
    public Transição transição;
    public PauseMenu pauseMenu;
    public GameObject Player;

    public void fechar_click()
    {
         // Desativa o Canvas
        canvas.enabled = false;

    }

    public void iniciar() {
        transição = GameObject.FindObjectOfType<Transição>();
        transição.TransitionToScene("Game");
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetFloat("X", 594.25f);
        PlayerPrefs.SetFloat("Y", 5.036f);
        PlayerPrefs.SetFloat("Z", 321.36f);
    }

    public void carregar()
    {
        transição = GameObject.FindObjectOfType<Transição>();
        transição.TransitionToScene("Game");
    }

    public void controles()
    {
        transição = GameObject.FindObjectOfType<Transição>();
        transição.TransitionToScene("Controles");
    }

    public void vamosLá()
    {
        transição = GameObject.FindObjectOfType<Transição>();
        transição.TransitionToScene("MenuInicial");
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

        respostasAdição = GameObject.FindObjectOfType<RespostasAdição>();
        respostasSubtração = GameObject.FindObjectOfType<RespostasSubtração>();
        respostasMultiplicação = GameObject.FindObjectOfType<RespostasMultiplicação>();
        respostasDivisão = GameObject.FindObjectOfType<RespostasDivisão>();

        PlayerPrefs.SetInt("Q1_ad", respostasAdição.Q1ad);
        PlayerPrefs.SetInt("Q2_ad", respostasAdição.Q2ad);
        PlayerPrefs.SetInt("Q3_ad", respostasAdição.Q3ad);
        PlayerPrefs.SetInt("Q4_ad", respostasAdição.Q4ad);
        PlayerPrefs.SetInt("Q5_ad", respostasAdição.Q5ad);

        PlayerPrefs.SetInt("Q1_sub", respostasSubtração.Q1sub);
        PlayerPrefs.SetInt("Q2_sub", respostasSubtração.Q2sub);
        PlayerPrefs.SetInt("Q3_sub", respostasSubtração.Q3sub);
        PlayerPrefs.SetInt("Q4_sub", respostasSubtração.Q4sub);
        PlayerPrefs.SetInt("Q5_sub", respostasSubtração.Q5sub);

        PlayerPrefs.SetInt("Q1_mul", respostasMultiplicação.Q1mul);
        PlayerPrefs.SetInt("Q2_mul", respostasMultiplicação.Q2mul);
        PlayerPrefs.SetInt("Q3_mul", respostasMultiplicação.Q3mul);
        PlayerPrefs.SetInt("Q4_mul", respostasMultiplicação.Q4mul);
        PlayerPrefs.SetInt("Q5_mul", respostasMultiplicação.Q5mul);

        PlayerPrefs.SetInt("Q1_div", respostasDivisão.Q1div);
        PlayerPrefs.SetInt("Q2_div", respostasDivisão.Q2div);
        PlayerPrefs.SetInt("Q3_div", respostasDivisão.Q3div);
        PlayerPrefs.SetInt("Q4_div", respostasDivisão.Q4div);
        PlayerPrefs.SetInt("Q5_div", respostasDivisão.Q5div);

        PlayerPrefs.Save();
        Debug.Log(PlayerPrefs.GetInt("Q2_ad"));
    }

    public void continuar()
    {
        transição = GameObject.FindObjectOfType<Transição>();
        transição.TransitionToScene("Créditos");
    }

    // verificar adição
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

    // verificar subtração

    public void verificarR1_sub_click()
    {
        respostasSubtração = GameObject.FindObjectOfType<RespostasSubtração>();
        respostasSubtração.R1();
    }
    public void verificarR2_sub_click()
    {
        respostasSubtração = GameObject.FindObjectOfType<RespostasSubtração>();
        respostasSubtração.R2();
    }

    public void verificarR3_sub_click()
    {
        respostasSubtração = GameObject.FindObjectOfType<RespostasSubtração>();
        respostasSubtração.R3();
    }

    public void verificarR5_sub_click()
    {
        respostasSubtração = GameObject.FindObjectOfType<RespostasSubtração>();
        respostasSubtração.R5();
    }

    // verificar multiplicação

    public void verificarR2_mult_click()
    {
        respostasMultiplicação = GameObject.FindObjectOfType<RespostasMultiplicação>();
        respostasMultiplicação.R2();
    }

    public void verificarR3_mult_click()
    {
        respostasMultiplicação = GameObject.FindObjectOfType<RespostasMultiplicação>();
        respostasMultiplicação.R3();
    }

    public void verificarR4_mult_click()
    {
        respostasMultiplicação = GameObject.FindObjectOfType<RespostasMultiplicação>();
        respostasMultiplicação.R4();
    }

    // verificar divisão

    public void verificarR1_div_click()
    {
        respostasDivisão = GameObject.FindObjectOfType<RespostasDivisão>();
        respostasDivisão.R1();
    }
    public void verificarR2_div_click()
    {
        respostasDivisão = GameObject.FindObjectOfType<RespostasDivisão>();
        respostasDivisão.R2();
    }

    public void verificarR3_div_click()
    {
        respostasDivisão = GameObject.FindObjectOfType<RespostasDivisão>();
        respostasDivisão.R3();
    }

    public void verificarR5_div_click()
    {
        respostasDivisão = GameObject.FindObjectOfType<RespostasDivisão>();
        respostasDivisão.R5();
    }
}
