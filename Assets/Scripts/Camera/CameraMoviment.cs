using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class CameraMoviment : MonoBehaviour
{
    public Transform alvo;
    public float distance = 7.0f;
    public float altura = 3.0f;
    public float suavizacao = 5.0f;
    public Movimento movimentoScript;
    public float sensibilidade = 100f;
    private float xRotation = 0f;
    private Quaternion cameraRotation;
    public Vector3 cameraPos;

    void Start()
    {
        // Calcula a posição da câmera com base na posição do jogador
        Vector3 desiredPosition = alvo.position - alvo.forward * distance + Vector3.up * altura;
        // Define a posição inicial da câmera
        transform.position = desiredPosition;
        // Faz a câmera olhar para o jogador
        transform.LookAt(alvo.position);

        movimentoScript = alvo.GetComponent<Movimento>();
    }

    void Update()
    {
        
        float mouseX = Input.GetAxis("Mouse X") * sensibilidade * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidade * Time.deltaTime;
        
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Limita a rotação vertical

        if (movimentoScript.isInterior == true) { distance = 2.5f; altura = 3.5f; }
        else { distance = 7.0f; altura = 3.0f; }      

        // Verifica se existe um alvo
        if (alvo!= null)
        {
            // se houver movimento do jogador a camera reposiciona
            if(movimentoScript.movimento != 0)
            {
                // Calcula a posição da câmera com base na posição do jogador
                Vector3 desiredPosition = alvo.position - alvo.forward * distance + Vector3.up * altura;

                // Define a posição da câmera
                transform.position = Vector3.Lerp(transform.position, desiredPosition, suavizacao * Time.deltaTime);

                // Faz a câmera sempre olhar para o jogador
                transform.LookAt(alvo.position);
            }
            // se não ela fica livre pela rotação do mouse
            else
            {   
                if(mouseX != 0f || mouseY != 0f)
                {
                    transform.localRotation = Quaternion.Euler(xRotation, transform.localEulerAngles.y + mouseX, 0f);
                }

            }

        }
    }



}
