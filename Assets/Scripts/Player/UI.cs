using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    public RespostasAdi��o respostasAdi��o;
    public RespostasSubtra��o respostasSubtra��o;
    public TMP_Text conclu�das, conclu�das_sub;
    public bool vila_ad, vila_sub, vila_mult, vila_div;

    // Start is called before the first frame update
    void Start()
    {
        respostasAdi��o = GameObject.FindObjectOfType<RespostasAdi��o>();
        respostasSubtra��o = GameObject.FindObjectOfType<RespostasSubtra��o>();
    }

    // Update is called once per frame
    void Update()
    {
        if (vila_ad) { conclu�das.text = respostasAdi��o.questoesCertas.Count.ToString(); }
        if (vila_sub) { conclu�das.text = respostasSubtra��o.questoesCertas.Count.ToString(); }
        if (vila_mult) { conclu�das.text = respostasSubtra��o.questoesCertas.Count.ToString(); }
        if (vila_div) { conclu�das.text = respostasSubtra��o.questoesCertas.Count.ToString(); }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("vila_ad")) { vila_ad = true; }
        if (other.CompareTag("vila_sub")) { vila_sub = true; }
        if (other.CompareTag("vila_mult")) { vila_mult = true; }
        if (other.CompareTag("vila_div")) { vila_div = true; }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("vila_ad")) { vila_ad = false; }
        if (other.CompareTag("vila_sub")) { vila_sub = false; }
        if (other.CompareTag("vila_mult")) { vila_mult = false; }
        if (other.CompareTag("vila_div")) { vila_div = false; }
    }
}
