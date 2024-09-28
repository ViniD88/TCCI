using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    public RespostasAdição respostasAdição;
    public RespostasSubtração respostasSubtração;
    public RespostasMultiplicação respostasMultiplicação;
    public RespostasDivisão respostasDivisão;
    public TMP_Text concluídas, vila, operação, desafios, total;
    public bool vila_ad, vila_sub, vila_mult, vila_div;
    public int totalDesafios;

    // Start is called before the first frame update
    void Start()
    {
        respostasAdição = GameObject.FindObjectOfType<RespostasAdição>();
        respostasSubtração = GameObject.FindObjectOfType<RespostasSubtração>();
        respostasMultiplicação = GameObject.FindObjectOfType<RespostasMultiplicação>();
        respostasDivisão = GameObject.FindObjectOfType<RespostasDivisão>();
        totalDesafios = 6;
    }

    // Update is called once per frame
    void Update()
    {
        if (vila_ad) { 
            concluídas.text = respostasAdição.questoesCertas.Count.ToString();
            vila.text = "VILA SOMA";
            operação.text = "ADIÇÃO";
            desafios.text = "Desafios Concluídos";
            total.text = "/ " + totalDesafios.ToString();

        }

        if (vila_sub) { 
            concluídas.text = respostasSubtração.questoesCertas.Count.ToString();
            vila.text = "VILA MENOS";
            operação.text = "SUBTRAÇÃO";
            desafios.text = "Desafios Concluídos";
            total.text = "/ " + totalDesafios.ToString();
        }
        
        if (vila_mult) { 
            concluídas.text = respostasMultiplicação.questoesCertas.Count.ToString();
            vila.text = "VILA VEZES";
            operação.text = "MULTIPLICAÇÃO";
            desafios.text = "Desafios Concluídos";
            total.text = "/ " + totalDesafios.ToString();
        }
        
        if (vila_div) {
            concluídas.text = respostasDivisão.questoesCertas.Count.ToString();
            vila.text = "VILA REPARTIR";
            operação.text = "DIVISÃO";
            desafios.text = "Desafios Concluídos";
            total.text = "/ "+ totalDesafios.ToString();
        }

        if(!vila_ad && !vila_sub && !vila_mult && !vila_div ){
            concluídas.text = "";
            vila.text = "MATEMATICALÂNDIA";
            operação.text = "+ - X ÷";
            desafios.text = "";
            total.text = "";
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Vila_ad")) { vila_ad = true; }
        if (other.CompareTag("Vila_sub")) { vila_sub = true; }
        if (other.CompareTag("Vila_mult")) { vila_mult = true; }
        if (other.CompareTag("Vila_div")) { vila_div = true; }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Vila_ad")) { vila_ad = false; }
        if (other.CompareTag("Vila_sub")) { vila_sub = false; }
        if (other.CompareTag("Vila_mult")) { vila_mult = false; }
        if (other.CompareTag("Vila_div")) { vila_div = false; }
    }
}
