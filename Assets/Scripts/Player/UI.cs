using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    public RespostasAdição respostasAdição;
    public RespostasSubtração respostasSubtração;
    public TMP_Text concluídas, concluídas_sub;
    public bool vila_ad, vila_sub, vila_mult, vila_div;

    // Start is called before the first frame update
    void Start()
    {
        respostasAdição = GameObject.FindObjectOfType<RespostasAdição>();
        respostasSubtração = GameObject.FindObjectOfType<RespostasSubtração>();
    }

    // Update is called once per frame
    void Update()
    {
        if (vila_ad) { concluídas.text = respostasAdição.questoesCertas.Count.ToString(); }
        if (vila_sub) { concluídas.text = respostasSubtração.questoesCertas.Count.ToString(); }
        if (vila_mult) { concluídas.text = respostasSubtração.questoesCertas.Count.ToString(); }
        if (vila_div) { concluídas.text = respostasSubtração.questoesCertas.Count.ToString(); }

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
