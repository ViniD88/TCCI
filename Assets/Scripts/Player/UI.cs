using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    public RespostasAdi��o respostasAdi��o;
    public TMP_Text conclu�das;

    // Start is called before the first frame update
    void Start()
    {
        respostasAdi��o = GameObject.FindObjectOfType<RespostasAdi��o>();
    }

    // Update is called once per frame
    void Update()
    {
        conclu�das.text = respostasAdi��o.questoesCertas.Count.ToString();
    }
}
