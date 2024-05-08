using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraMoviment : MonoBehaviour
{
    public Transform alvo;
    public float distance = 5.0f;
    public float altura = 2.0f;
    public float suavizacao = 5.0f;
    public Movimento movimentoScript;

    private void Start()
    {
        movimentoScript = alvo.GetComponent<Movimento>();
    }

    void Update()
    {
        if (movimentoScript.isInterior == true) { distance = 2.0f; altura = 3.0f; }
        else { distance = 5.0f; altura = 2.0f; }
        
        // Verifica se a referência ao jogador não é nula
        if (alvo!= null)
        {
            // Calcula a posição da câmera com base na posição do jogador
            Vector3 desiredPosition = alvo.position - alvo.forward * distance + Vector3.up * altura;

            // Define a posição da câmera
            transform.position = Vector3.Lerp(transform.position, desiredPosition, suavizacao * Time.deltaTime);

            // Faz a câmera sempre olhar para o jogador
            transform.LookAt(alvo.position);
        }
    }



}
