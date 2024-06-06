using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coletar : MonoBehaviour
{
    private Transform personagem;
    private GameObject objetoColetavel;
    public bool objetoColetado = false;
    private Rigidbody objetoRigidbody; // Armazenar o Rigidbody do objeto colet�vel
    private Collider objetoCollider; // Armazenar o Collider do objeto colet�vel
    private Quaternion rotacaoRelativa; // Armazenar a rota��o relativa entre o objeto colet�vel e o personagem
    private Animator animator;
    public bool isGrounded;
    public bool coleta;
    public GameObject player;
    public LayerMask layerColetaveis;
    private bool ignorarColis�o = false;
    private float objectDistance;

    void Start()
    {
        // Encontrar o personagem pela tag "Player"
        player = GameObject.FindGameObjectWithTag("Player");
        personagem = player.transform;
        animator = GetComponent<Animator>();
        coleta = false;
        objectDistance = 0;
    }

    void Update()
    {
        isGrounded = player.GetComponent<Movimento>().isGrounded;

        // Verificar se a tecla Q foi pressionada para coletar algum objeto colet�vel
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // Se o objeto estiver coletado, solt�-lo
            if (objetoColetado)
            {
                SoltarObjeto();
            }
            // Se n�o, coletar o objeto
            else
            {
                ColetarObjeto();
            }
        }


    }


    void FixedUpdate()
    {

        // Se o objeto estiver coletado, atualizar sua posi��o e orienta��o para acompanhar o personagem
        if (objetoColetado && objetoColetavel != null)
        {
            // Atualizar a posi��o do objeto colet�vel para acompanhar o personagem
            Vector3 novaPosicao = personagem.position + personagem.forward * objectDistance + Vector3.up; // Ajuste conforme necess�rio
            objetoColetavel.transform.position = novaPosicao;

            // Aplicar a rota��o relativa para manter a orienta��o do objeto em rela��o ao personagem
            objetoColetavel.transform.rotation = personagem.rotation * rotacaoRelativa;
        }

    }

    private void OnTriggerEnter(Collider other)
    { 

        if (!ignorarColis�o)
        {
            // Verificar se o objeto est� na layer "Colet�veis"
            if (layerColetaveis == (layerColetaveis | (1 << other.gameObject.layer)))
            {
                // Guardar uma refer�ncia para o objeto colet�vel
                objetoColetavel = other.gameObject;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (!ignorarColis�o)
        {
            // Verificar se o objeto est� na layer "Colet�veis"
            if (layerColetaveis == (layerColetaveis | (1 << other.gameObject.layer)))
            {
                // Guardar uma refer�ncia para o objeto colet�vel
                objetoColetavel = null;
            }
        }
    }

    private void ColetarObjeto()
    {
        if (objetoColetavel != null)
        {
            // Guardar o componente Rigidbody antes de desativ�-lo
            objetoRigidbody = objetoColetavel.GetComponent<Rigidbody>();
            objetoCollider = objetoColetavel.GetComponent<Collider>();

            // Desativar o Rigidbody temporariamente
            objetoRigidbody.isKinematic = true;
            objetoCollider.enabled = false;

            // Armazenar a rota��o relativa entre o objeto colet�vel e o personagem
            rotacaoRelativa = Quaternion.Inverse(personagem.rotation) * objetoColetavel.transform.rotation;

            // verificar qual objeto foi coletado para alterar a distancia em rela��o ao personagem
            if (objetoColetavel.tag == "Prato" || objetoColetavel.tag == "Barril")
            {
                objectDistance = 0.5f;
            }else if (objetoColetavel.tag == "Pedra_1") {
                objectDistance = 0.7f;
            }

            // Marcar o objeto como coletado
            objetoColetado = true;
            // Ignorar a detetec��o de colis�o
            ignorarColis�o = true;

            //anima��o quando carregando objeto
            animator.SetBool("isWalking", false);
            animator.SetBool("isIdle", false);
            animator.SetBool("isCarrying", true);
            
            

        }
    }

    private void SoltarObjeto()
    {
        // Restaurar o Rigidbody  e colisor do objeto colet�vel
        objetoRigidbody.isKinematic = false;
        objetoCollider.enabled = true;

        // Resetar o estado do objeto colet�vel
        objetoColetavel = null;
        objetoColetado = false;
        // Retomar a detetec��o de colis�o
        ignorarColis�o = false;

        // anima��o retorna ao padr�o quando solta objeto
        animator.SetBool("isCarrying", false);
        animator.SetBool("isIdle", true);
    }

}