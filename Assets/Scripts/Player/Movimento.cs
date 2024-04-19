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

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

    }

    void Update()
    {
        float movimentoHorizontal = Input.GetAxis("Horizontal");
        float movimentoVertical = Input.GetAxis("Vertical");

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


        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0f, -rotationSpeed, 0f);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0f, rotationSpeed, 0f);
        }

        // Verifica se o personagem está no chão
        isGrounded = Physics.Raycast(transform.position, Vector3.down, .5f);

        if (isGrounded)
        {
            animator.SetBool("isJumping", false);
        }

        // pulo + animação de pulo
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            if (Input.GetKey(KeyCode.LeftShift))
            {
                animator.SetBool("isJumpingRunning", true);
            }
            else {
                animator.SetBool("isJumpingRunning", false);
                animator.SetBool("isJumping", true);

            }

        }
        else
        {
            animator.SetBool("isJumpingRunning", false);
            animator.SetBool("isJumping", false);
        }

        Animação();
    }

    void Animação()
    {

        if (Input.GetKey(KeyCode.W) && isGrounded)
        {

            if (Input.GetKey(KeyCode.LeftShift))
            {
                animator.SetBool("isRunning", true);
                animator.SetBool("isWalking", false);

            }
            else
            {
                animator.SetBool("isWalking", true);
                animator.SetBool("isRunning", false);
            }
        }
        else
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isRunning", false);
        }



    }

}