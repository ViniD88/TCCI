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

    void Update()
    {
        // Verifica se a refer�ncia ao jogador n�o � nula
        if (alvo!= null)
        {
            // Calcula a posi��o da c�mera com base na posi��o do jogador
            Vector3 desiredPosition = alvo.position - alvo.forward * distance + Vector3.up * altura;

            // Define a posi��o da c�mera
            transform.position = Vector3.Lerp(transform.position, desiredPosition, suavizacao * Time.deltaTime);

            // Faz a c�mera sempre olhar para o jogador
            transform.LookAt(alvo.position);
        }
    }

}
