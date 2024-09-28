using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    public RespostasAdi��o respostasAdi��o;
    public RespostasSubtra��o respostasSubtra��o;
    public RespostasMultiplica��o respostasMultiplica��o;
    public RespostasDivis�o respostasDivis�o;
    public TMP_Text conclu�das, vila, opera��o, desafios, total;
    public bool vila_ad, vila_sub, vila_mult, vila_div;
    public int totalDesafios;

    // Start is called before the first frame update
    void Start()
    {
        respostasAdi��o = GameObject.FindObjectOfType<RespostasAdi��o>();
        respostasSubtra��o = GameObject.FindObjectOfType<RespostasSubtra��o>();
        respostasMultiplica��o = GameObject.FindObjectOfType<RespostasMultiplica��o>();
        respostasDivis�o = GameObject.FindObjectOfType<RespostasDivis�o>();
        totalDesafios = 6;
    }

    // Update is called once per frame
    void Update()
    {
        if (vila_ad) { 
            conclu�das.text = respostasAdi��o.questoesCertas.Count.ToString();
            vila.text = "VILA SOMA";
            opera��o.text = "ADI��O";
            desafios.text = "Desafios Conclu�dos";
            total.text = "/ " + totalDesafios.ToString();

        }

        if (vila_sub) { 
            conclu�das.text = respostasSubtra��o.questoesCertas.Count.ToString();
            vila.text = "VILA MENOS";
            opera��o.text = "SUBTRA��O";
            desafios.text = "Desafios Conclu�dos";
            total.text = "/ " + totalDesafios.ToString();
        }
        
        if (vila_mult) { 
            conclu�das.text = respostasMultiplica��o.questoesCertas.Count.ToString();
            vila.text = "VILA VEZES";
            opera��o.text = "MULTIPLICA��O";
            desafios.text = "Desafios Conclu�dos";
            total.text = "/ " + totalDesafios.ToString();
        }
        
        if (vila_div) {
            conclu�das.text = respostasDivis�o.questoesCertas.Count.ToString();
            vila.text = "VILA REPARTIR";
            opera��o.text = "DIVIS�O";
            desafios.text = "Desafios Conclu�dos";
            total.text = "/ "+ totalDesafios.ToString();
        }

        if(!vila_ad && !vila_sub && !vila_mult && !vila_div ){
            conclu�das.text = "";
            vila.text = "MATEMATICAL�NDIA";
            opera��o.text = "+ - X �";
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
