using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vitória : MonoBehaviour
{

    public RespostasAdição respostasAdição;
    public RespostasSubtração respostasSubtração;
    public RespostasMultiplicação respostasMultiplicação;
    public RespostasDivisão respostasDivisão;
    public bool vitoria;
    public Transição transição;
    // Start is called before the first frame update
    void Start()
    {
        respostasAdição = GameObject.FindObjectOfType<RespostasAdição>();
        respostasSubtração = GameObject.FindObjectOfType<RespostasSubtração>(); 
        respostasMultiplicação = GameObject.FindObjectOfType<RespostasMultiplicação>(); 
        respostasDivisão = GameObject.FindObjectOfType<RespostasDivisão>(); 
}

    // Update is called once per frame
    void Update()
    {
        if(respostasAdição.questoesCertas.Count == 5 && respostasSubtração.questoesCertas.Count == 5 && respostasMultiplicação.questoesCertas.Count == 5 && respostasDivisão.questoesCertas.Count == 5){
            vitoria = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (vitoria && other.CompareTag("GateFinish"))
        {
            transição = GameObject.FindObjectOfType<Transição>();
            transição.TransitionToScene("Vitória");
        }
    }
}
