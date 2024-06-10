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
    public RespostasSubtração respostasSubtração;
    public RespostasMultiplicação respostasMultiplicação;

    public void fechar_click()
    {
         // Desativa o Canvas
        canvas.enabled = false;

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
}
