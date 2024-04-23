using System.Collections;
using System.Collections.Generic;
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

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        direcaoAnterior = rb.velocity.normalized;
    }

    void Update()
    {
        // Verifica se o personagem está no chão
        isGrounded = Physics.Raycast(transform.position, Vector3.down, .5f);



        // pulo + animação de pulo
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

        // Verifica a direção atual do rigidbody
        direcaoAtual = rb.velocity.normalized;

        //movimentação
        if (Input.GetKey(KeyCode.LeftShift))
        {
            //movimentação com corrida
            Vector3 movimento = 2.2f * moveSpeed * Time.deltaTime * new Vector3(0, 0.0f, movimentoVertical);
            transform.Translate(movimento);
           }
        else
        {   
            //movimentação normal
            Vector3 movimento = moveSpeed * Time.deltaTime * new Vector3(0, 0.0f, movimentoVertical);
            transform.Translate(movimento);
        }




        //rotacionar o personagem

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0f, -rotationSpeed, 0f);

            //verifica se o personagem está se movendo. Aplica a rotação apenas se o personagem está parado
            if (Input.GetAxis("Vertical") == 0) {
                animator.SetBool("isTurningLeft", true);
                animator.SetBool("isWalking", false);
            }
        }
        else
        {
            animator.SetBool("isTurningLeft", false);
        }


        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0f, rotationSpeed, 0f);

            //verifica se o personagem está se movendo. Aplica a rotação apenas se o personagem está parado
            if (Input.GetAxis("Vertical") == 0)
            {
                animator.SetBool("isTurningRight", true);
                animator.SetBool("isWalking", false);
            }
        }
        else
        {
            animator.SetBool("isTurningRight", false);
        }


        if (isGrounded)
        {
            animator.SetBool("isJumping", false);
        }



        Animação();
    }

    void Animação()
    {

        float movimento = Input.GetAxis("Vertical");

        if (Input.GetAxis("Vertical") != 0 && isGrounded)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                animator.SetBool("isRunning", true);
                animator.SetBool("isWalking", false);
                animator.SetBool("isTurningRight", false);
                animator.SetBool("isTurningLeft", false);
            }
            else
            {
                if (movimento > 0)
                {
                    animator.SetBool("isWalking", true);
                    animator.SetBool("isWalkingBack", false);

                }
                else if (movimento < 0)
                {
                    animator.SetBool("isWalkingBack", true);
                    animator.SetBool("isWalking", false);
                }

            }
        }
        else
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isRunning", false);
            animator.SetBool("isWalkingBack", false);
        }

    }

}