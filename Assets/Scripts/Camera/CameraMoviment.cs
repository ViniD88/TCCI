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
    public float sensibilidade = 200f;
    private float xRotation = 0f;
    public Vector3 cameraPos;
    public float mouseX, mouseY;
    public bool is_moving;

    void Start()
    {
        alvo.position = transform.localPosition = new Vector3(PlayerPrefs.GetFloat("X"), PlayerPrefs.GetFloat("Y"), PlayerPrefs.GetFloat("Z"));
        // Calcula a posi��o da c�mera com base na posi��o do jogador
        Vector3 desiredPosition = alvo.position - alvo.forward * distance + Vector3.up * altura;
        // Define a posi��o inicial da c�mera
        transform.position = desiredPosition;
        // Faz a c�mera olhar para o jogador
        transform.LookAt(alvo.position);
        
        movimentoScript = alvo.GetComponent<Movimento>();
        

    }

    void Update()
    {

        mouseX = Input.GetAxis("Mouse X") * sensibilidade * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * sensibilidade * Time.deltaTime;
        if(!is_moving)
        {
            if (mouseX != 0f || mouseY != 0f)
            {
                transform.localRotation = Quaternion.Euler(xRotation, transform.localEulerAngles.y + mouseX, 0f);
            }

        }
    }


    void FixedUpdate()
    {
          
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Limita a rota��o vertical

        if (movimentoScript.isInterior == true) { distance = 2.5f; altura = 3.5f; }
        else { distance = 7.0f; altura = 3.0f; }      

        // Verifica se existe um alvo
        if (alvo!= null)
        {
            // se houver movimento do jogador a camera reposiciona
            if(movimentoScript.movimento != 0)
            {
                // Calcula a posi��o da c�mera com base na posi��o do jogador
                Vector3 desiredPosition = alvo.position - alvo.forward * distance + Vector3.up * altura;

                // Define a posi��o da c�mera
                transform.position = Vector3.Lerp(transform.position, desiredPosition, suavizacao * Time.deltaTime);

                // Faz a c�mera sempre olhar para o jogador
                transform.LookAt(alvo.position);
                is_moving = true;
            }
            else
            {
                is_moving = false;
            }
            // se n�o ela fica livre pela rota��o do mouse


        }
    }



}
