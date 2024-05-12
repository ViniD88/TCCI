using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;

public class Movimento : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    public float jumpForce;
    public float rotationSpeed; 
    private Rigidbody rb; 
    public bool isGrounded;
    private Animator animator;
    private Vector3 direcaoAnterior;
    public Vector3 direcaoAtual;
    public bool objetoColetado, isInterior;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        direcaoAnterior = rb.velocity.normalized;
    }

    void Update()
    {
        // Verifica se o personagem est� no ch�o
        isGrounded = Physics.Raycast(transform.position, Vector3.down, .5f);

        Coletar script = GetComponent<Coletar>();
        objetoColetado = script.objetoColetado;

        // pulo + anima��o de pulo
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            if (Input.GetKey(KeyCode.LeftShift))
            {
                animator.SetBool("isJumpingRunning", true);
            }
            else
            {
                animator.SetBool("isJumpingRunning", false);
                animator.SetBool("isJumping", true);

            }
        }
        else
        {
            animator.SetBool("isJumpingRunning", false);
            animator.SetBool("isJumping", false);
        }

    }

    void FixedUpdate()
    {
        float movimentoHorizontal = Input.GetAxis("Horizontal");
        float movimentoVertical = Input.GetAxis("Vertical");

        // Verifica a dire��o atual do rigidbody
        direcaoAtual = rb.velocity.normalized;

        //movimenta��o
        if (Input.GetKey(KeyCode.LeftShift))
        {
            //movimenta��o com corrida
            Vector3 movimento = 2.2f * moveSpeed * Time.deltaTime * new Vector3(0, 0.0f, movimentoVertical);
            transform.Translate(movimento);
           }
        else
        {   
            //movimenta��o normal
            Vector3 movimento = moveSpeed * Time.deltaTime * new Vector3(0, 0.0f, movimentoVertical);
            transform.Translate(movimento);
        }

        //rotacionar o personagem

        Coletar script = GetComponent<Coletar>();
        bool objetoColetado = script.objetoColetado;

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0f, -rotationSpeed, 0f);

            //verifica se o personagem est� se movendo. Aplica a rota��o para a ESQUERDA apenas se o personagem est� parado
            if (Input.GetAxis("Vertical") == 0) {
                if (objetoColetado)
                {
                    animator.SetBool("isCarryingLeft", true);
                    animator.SetBool("isWalking", false);
                    animator.SetBool("isTurningLeft", false);
                }
                else
                {
                    animator.SetBool("isTurningLeft", true);
                    animator.SetBool("isWalking", false);
                    animator.SetBool("isCarryingLeft", false);
                }

            }

        }
        else
        {
            animator.SetBool("isTurningLeft", false);
            animator.SetBool("isCarryingLeft", false);
        }


        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0f, rotationSpeed, 0f);

            //verifica se o personagem est� se movendo. Aplica a rota��o para a DIREITA apenas se o personagem est� parado
            if (Input.GetAxis("Vertical") == 0)
            {
                if (objetoColetado)
                {
                    animator.SetBool("isCarryingRight", true);
                    animator.SetBool("isWalking", false);
                    animator.SetBool("isTurningRight", false);
                }
                else
                {
                    animator.SetBool("isTurningRight", true);
                    animator.SetBool("isWalking", false);
                    animator.SetBool("isCarryingRight", false);
                }

            }
        }
        else
        {
            animator.SetBool("isTurningRight", false);
            animator.SetBool("isCarryingRight", false);
        }

        //anima��o para pulo

        if (isGrounded)
        {
            animator.SetBool("isJumping", false);
        }

        Anima��o();
    }

    void Anima��o()
    {

        float movimento = Input.GetAxis("Vertical");

        if (Input.GetAxis("Vertical") != 0 && isGrounded)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                if (!objetoColetado)
                {
                    animator.SetBool("isWalking", false);
                    animator.SetBool("isTurningRight", false);
                    animator.SetBool("isTurningLeft", false);
                    animator.SetBool("isRunning", true);
                }
                else
                {
                    animator.SetBool("isCarryingWalking", false);
                    animator.SetBool("isRunning", false);
                    animator.SetBool("isWalking", false);
                    animator.SetBool("isCarryingRunning", true);
                }
            }
            else
            {
                if (movimento > 0 && !objetoColetado)
                {
                    animator.SetBool("isWalking", true);
                    animator.SetBool("isWalkingBack", false);
                }
                else if (movimento < 0 && !objetoColetado)
                {
                    animator.SetBool("isWalking", false);
                    animator.SetBool("isWalkingBack", true);
                }
                else if (movimento > 0 && objetoColetado)
                {
                    animator.SetBool("isCarryingWalking", true);
                    animator.SetBool("isCarryingRunning", false);
                }
            }
        }
        else
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isRunning", false);
            animator.SetBool("isWalkingBack", false);
            animator.SetBool("isCarryingWalking", false);
            animator.SetBool("isCarryingRunning", false);

        }
    }

    private void OnTriggerStay(Collider other)
    {
        // verifica se o personagem est� dentro de algum lugar
        if (other.CompareTag("interior"))
        {
            isInterior = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        // verifica se o personagem est� dentro de algum lugar
        if (other.CompareTag("interior"))
        {
            isInterior = false;
        }
    }

}