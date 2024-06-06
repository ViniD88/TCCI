using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coletar : MonoBehaviour
{
    private Transform personagem;
    private GameObject objetoColetavel;
    public bool objetoColetado = false;
    private Rigidbody objetoRigidbody; // Armazenar o Rigidbody do objeto coletável
    private Collider objetoCollider; // Armazenar o Collider do objeto coletável
    private Quaternion rotacaoRelativa; // Armazenar a rotação relativa entre o objeto coletável e o personagem
    private Animator animator;
    public bool isGrounded;
    public bool coleta;
    public GameObject player;
    public LayerMask layerColetaveis;
    private bool ignorarColisão = false;
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

        // Verificar se a tecla Q foi pressionada para coletar algum objeto coletável
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // Se o objeto estiver coletado, soltá-lo
            if (objetoColetado)
            {
                SoltarObjeto();
            }
            // Se não, coletar o objeto
            else
            {
                ColetarObjeto();
            }
        }


    }


    void FixedUpdate()
    {

        // Se o objeto estiver coletado, atualizar sua posição e orientação para acompanhar o personagem
        if (objetoColetado && objetoColetavel != null)
        {
            // Atualizar a posição do objeto coletável para acompanhar o personagem
            Vector3 novaPosicao = personagem.position + personagem.forward * objectDistance + Vector3.up; // Ajuste conforme necessário
            objetoColetavel.transform.position = novaPosicao;

            // Aplicar a rotação relativa para manter a orientação do objeto em relação ao personagem
            objetoColetavel.transform.rotation = personagem.rotation * rotacaoRelativa;
        }

    }

    private void OnTriggerEnter(Collider other)
    { 

        if (!ignorarColisão)
        {
            // Verificar se o objeto está na layer "Coletáveis"
            if (layerColetaveis == (layerColetaveis | (1 << other.gameObject.layer)))
            {
                // Guardar uma referência para o objeto coletável
                objetoColetavel = other.gameObject;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (!ignorarColisão)
        {
            // Verificar se o objeto está na layer "Coletáveis"
            if (layerColetaveis == (layerColetaveis | (1 << other.gameObject.layer)))
            {
                // Guardar uma referência para o objeto coletável
                objetoColetavel = null;
            }
        }
    }

    private void ColetarObjeto()
    {
        if (objetoColetavel != null)
        {
            // Guardar o componente Rigidbody antes de desativá-lo
            objetoRigidbody = objetoColetavel.GetComponent<Rigidbody>();
            objetoCollider = objetoColetavel.GetComponent<Collider>();

            // Desativar o Rigidbody temporariamente
            objetoRigidbody.isKinematic = true;
            objetoCollider.enabled = false;

            // Armazenar a rotação relativa entre o objeto coletável e o personagem
            rotacaoRelativa = Quaternion.Inverse(personagem.rotation) * objetoColetavel.transform.rotation;

            // verificar qual objeto foi coletado para alterar a distancia em relação ao personagem
            if (objetoColetavel.tag == "Prato" || objetoColetavel.tag == "Barril")
            {
                objectDistance = 0.5f;
            }else if (objetoColetavel.tag == "Pedra_1") {
                objectDistance = 0.7f;
            }

            // Marcar o objeto como coletado
            objetoColetado = true;
            // Ignorar a detetecção de colisão
            ignorarColisão = true;

            //animação quando carregando objeto
            animator.SetBool("isWalking", false);
            animator.SetBool("isIdle", false);
            animator.SetBool("isCarrying", true);
            
            

        }
    }

    private void SoltarObjeto()
    {
        // Restaurar o Rigidbody  e colisor do objeto coletável
        objetoRigidbody.isKinematic = false;
        objetoCollider.enabled = true;

        // Resetar o estado do objeto coletável
        objetoColetavel = null;
        objetoColetado = false;
        // Retomar a detetecção de colisão
        ignorarColisão = false;

        // animação retorna ao padrão quando solta objeto
        animator.SetBool("isCarrying", false);
        animator.SetBool("isIdle", true);
    }

}