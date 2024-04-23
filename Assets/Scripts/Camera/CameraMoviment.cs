using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoviment : MonoBehaviour
{
    public Transform alvo;
    public float altura = 2.0f;
    public float suavizacao = 5.0f;
    public float rota��oVelocidade = 2.0f;

    private Vector3 deslocamento;
    private float rota��oX = 0.0f;

    void Start()
    {
        deslocamento = alvo.position - transform.position;
    }

    void Update()
    {

        float rota��oHorizontal = Input.GetAxis("Mouse X") * rota��oVelocidade;

        alvo.Rotate(0, rota��oHorizontal, 0);

        rota��oX -= Input.GetAxis("Mouse Y") * rota��oVelocidade;
        rota��oX = Mathf.Clamp(rota��oX, -45.0f, 45.0f);

        Quaternion rota��oDesejada = Quaternion.Euler(rota��oX, alvo.eulerAngles.y, 0);

        Vector3 posicaoDesejada = alvo.position - (rota��oDesejada * deslocamento);
        posicaoDesejada.y = alvo.position.y + altura;

        transform.position = Vector3.Lerp(transform.position, posicaoDesejada, suavizacao * Time.deltaTime);

        transform.LookAt(alvo);


    }
}
