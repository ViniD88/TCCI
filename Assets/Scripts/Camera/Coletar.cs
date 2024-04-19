using Unity.VisualScripting;
using UnityEngine;

public class Coletar : MonoBehaviour
{
    private Transform personagem;
    private GameObject objetoColetavel;
    private bool objetoColetado = false;
    private Rigidbody objetoRigidbody; // Armazenar o Rigidbody do objeto coletável
    private Quaternion rotacaoRelativa; // Armazenar a rotação relativa entre o objeto coletável e o personagem
    private Animator animator;
    public bool isGrounded;

    private void Start()
    {
        // Encontrar o personagem pela tag "Player"
        personagem = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Verificar se a tecla E foi pressionada
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Se o objeto estiver coletado, soltá-lo
            if (objetoColetado)
            {
                SoltarObjeto();
                animator.SetBool("isCarrying", false);
                animator.SetBool("isIdle", true);

            }
            // Se não, coletar o objeto
            else
            {
                ColetarObjeto();
                animator.SetBool("isCarrying", true);
                animator.SetBool("isIdle", false);
            }
        }

        // Se o objeto estiver coletado, atualizar sua posição e orientação para acompanhar o personagem
        if (objetoColetado && objetoColetavel != null)
        {
            AtualizarPosicaoEOrientacaoObjeto();
        }

        Movimento isgrounded = GetComponent<Movimento>();
        bool isGrounded = isgrounded.isGrounded;

        if (Input.GetKey(KeyCode.W) && isGrounded)
        {

            if (Input.GetKey(KeyCode.LeftShift))
            {
                animator.SetBool("isCarryingRunning", true);
                animator.SetBool("isCarryingWalking", false);

            }
            else
            {
                animator.SetBool("isCarryingWalking", true);
                animator.SetBool("isCarryingRunning", false);
            }
        }
        else
        {
            animator.SetBool("isCarryingWalking", false);
            animator.SetBool("isCarryingRunning", false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verificar se o objeto possui a tag "Coletavel"
        if (other.CompareTag("Coletavel"))
        {
            // Guardar uma referência para o objeto coletável
            objetoColetavel = other.gameObject;
        }
    }

    private void ColetarObjeto()
    {
        if (objetoColetavel != null)
        {
            // Guardar o componente Rigidbody antes de desativá-lo
            objetoRigidbody = objetoColetavel.GetComponent<Rigidbody>();

            // Desativar o Rigidbody temporariamente
            objetoRigidbody.isKinematic = true;

            // Armazenar a rotação relativa entre o objeto coletável e o personagem
            rotacaoRelativa = Quaternion.Inverse(personagem.rotation) * objetoColetavel.transform.rotation;

            // Posicionar o objeto coletável à frente e ligeiramente acima do personagem
            PosicionarObjetoAFrente();

            // Marcar o objeto como coletado
            objetoColetado = true;
        }
    }

    private void SoltarObjeto()
    {
        // Restaurar o Rigidbody do objeto coletável
        objetoRigidbody.isKinematic = false;

        // Resetar o estado do objeto coletável
        objetoColetavel = null;
        objetoColetado = false;
    }

    private void PosicionarObjetoAFrente()
    {
        // Definir a posição do objeto coletável à frente e ligeiramente acima do personagem
        Vector3 novaPosicao = personagem.position + personagem.forward * 1f + Vector3.up; // Ajuste a altura conforme necessário
        objetoColetavel.transform.position = novaPosicao;

        // Aplicar a rotação relativa para manter a orientação do objeto em relação ao personagem
        objetoColetavel.transform.rotation = personagem.rotation * rotacaoRelativa;
    }

    private void AtualizarPosicaoEOrientacaoObjeto()
    {
        // Atualizar a posição do objeto coletável para acompanhar o personagem
        Vector3 novaPosicao = personagem.position + personagem.forward * 1f + Vector3.up; // Ajuste conforme necessário
        objetoColetavel.transform.position = novaPosicao;

        // Aplicar a rotação relativa para manter a orientação do objeto em relação ao personagem
        objetoColetavel.transform.rotation = personagem.rotation * rotacaoRelativa;
    }
}