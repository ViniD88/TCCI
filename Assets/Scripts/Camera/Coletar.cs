using Unity.VisualScripting;
using UnityEngine;

public class Coletar : MonoBehaviour
{
    private Transform personagem;
    private GameObject objetoColetavel;
    private bool objetoColetado = false;
    private Rigidbody objetoRigidbody; // Armazenar o Rigidbody do objeto colet�vel
    private Quaternion rotacaoRelativa; // Armazenar a rota��o relativa entre o objeto colet�vel e o personagem
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
            // Se o objeto estiver coletado, solt�-lo
            if (objetoColetado)
            {
                SoltarObjeto();
                animator.SetBool("isCarrying", false);
                animator.SetBool("isIdle", true);

            }
            // Se n�o, coletar o objeto
            else
            {
                ColetarObjeto();
                animator.SetBool("isCarrying", true);
                animator.SetBool("isIdle", false);
            }
        }

        // Se o objeto estiver coletado, atualizar sua posi��o e orienta��o para acompanhar o personagem
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
            // Guardar uma refer�ncia para o objeto colet�vel
            objetoColetavel = other.gameObject;
        }
    }

    private void ColetarObjeto()
    {
        if (objetoColetavel != null)
        {
            // Guardar o componente Rigidbody antes de desativ�-lo
            objetoRigidbody = objetoColetavel.GetComponent<Rigidbody>();

            // Desativar o Rigidbody temporariamente
            objetoRigidbody.isKinematic = true;

            // Armazenar a rota��o relativa entre o objeto colet�vel e o personagem
            rotacaoRelativa = Quaternion.Inverse(personagem.rotation) * objetoColetavel.transform.rotation;

            // Posicionar o objeto colet�vel � frente e ligeiramente acima do personagem
            PosicionarObjetoAFrente();

            // Marcar o objeto como coletado
            objetoColetado = true;
        }
    }

    private void SoltarObjeto()
    {
        // Restaurar o Rigidbody do objeto colet�vel
        objetoRigidbody.isKinematic = false;

        // Resetar o estado do objeto colet�vel
        objetoColetavel = null;
        objetoColetado = false;
    }

    private void PosicionarObjetoAFrente()
    {
        // Definir a posi��o do objeto colet�vel � frente e ligeiramente acima do personagem
        Vector3 novaPosicao = personagem.position + personagem.forward * 1f + Vector3.up; // Ajuste a altura conforme necess�rio
        objetoColetavel.transform.position = novaPosicao;

        // Aplicar a rota��o relativa para manter a orienta��o do objeto em rela��o ao personagem
        objetoColetavel.transform.rotation = personagem.rotation * rotacaoRelativa;
    }

    private void AtualizarPosicaoEOrientacaoObjeto()
    {
        // Atualizar a posi��o do objeto colet�vel para acompanhar o personagem
        Vector3 novaPosicao = personagem.position + personagem.forward * 1f + Vector3.up; // Ajuste conforme necess�rio
        objetoColetavel.transform.position = novaPosicao;

        // Aplicar a rota��o relativa para manter a orienta��o do objeto em rela��o ao personagem
        objetoColetavel.transform.rotation = personagem.rotation * rotacaoRelativa;
    }
}