using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    public RespostasAdição respostasAdição;
    public TMP_Text concluídas;

    // Start is called before the first frame update
    void Start()
    {
        respostasAdição = GameObject.FindObjectOfType<RespostasAdição>();
    }

    // Update is called once per frame
    void Update()
    {
        concluídas.text = respostasAdição.questoesCertas.Count.ToString();
    }
}
