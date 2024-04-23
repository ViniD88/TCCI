using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoviment : MonoBehaviour
{
    public Transform alvo;
    public float altura = 2.0f;
    public float suavizacao = 5.0f;
    public float rotaçãoVelocidade = 2.0f;

    private Vector3 deslocamento;
    private float rotaçãoX = 0.0f;

    void Start()
    {
        deslocamento = alvo.position - transform.position;
    }

    void Update()
    {

        float rotaçãoHorizontal = Input.GetAxis("Mouse X") * rotaçãoVelocidade;

        alvo.Rotate(0, rotaçãoHorizontal, 0);

        rotaçãoX -= Input.GetAxis("Mouse Y") * rotaçãoVelocidade;
        rotaçãoX = Mathf.Clamp(rotaçãoX, -45.0f, 45.0f);

        Quaternion rotaçãoDesejada = Quaternion.Euler(rotaçãoX, alvo.eulerAngles.y, 0);

        Vector3 posicaoDesejada = alvo.position - (rotaçãoDesejada * deslocamento);
        posicaoDesejada.y = alvo.position.y + altura;

        transform.position = Vector3.Lerp(transform.position, posicaoDesejada, suavizacao * Time.deltaTime);

        transform.LookAt(alvo);


    }
}
