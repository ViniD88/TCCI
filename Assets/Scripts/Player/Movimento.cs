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
    public AudioSource stepOnGrass, stepOnWood;
    public float movimento;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        direcaoAnterior = rb.velocity.normalized;
        stepOnGrass.pitch = 0.8f; 
        stepOnWood.pitch = 0.5f;


    }

    void Update()
    {
        // Verifica se o personagem está no chão
        isGrounded = Physics.Raycast(transform.position, Vector3.down, .5f);

        Coletar script = GetComponent<Coletar>();
        objetoColetado = script.objetoColetado;

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

        movimento = Input.GetAxis("Vertical");

        if (movimento != 0) {
            
            if (isInterior)
            {
                if (!stepOnWood.isPlaying)
                {
                    stepOnGrass.Stop();
                    stepOnWood.Play();
                }
            }
            else
            {
                if (!stepOnGrass.isPlaying)
                {
                    stepOnWood.Stop();
                    stepOnGrass.Play();
                }
            }
        }
        else { stepOnGrass.Stop(); stepOnWood.Stop(); }




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
            stepOnWood.pitch = 1.1f;
            stepOnGrass.pitch = 1.1f;

        }
        else
        {   
            //movimentação normal
            Vector3 movimento = moveSpeed * Time.deltaTime * new Vector3(0, 0.0f, movimentoVertical);
            transform.Translate(movimento);

            stepOnGrass.pitch = 0.8f;
            stepOnWood.pitch = 0.5f;

        }

        //rotacionar o personagem

        Coletar script = GetComponent<Coletar>();
        bool objetoColetado = script.objetoColetado;

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0f, -rotationSpeed, 0f);

            //verifica se o personagem está se movendo. Aplica a rotação para a ESQUERDA apenas se o personagem está parado
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

            //verifica se o personagem está se movendo. Aplica a rotação para a DIREITA apenas se o personagem está parado
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

        //animação para pulo

        if (isGrounded)
        {
            animator.SetBool("isJumping", false);
        }

        Animação();
    }

    void Animação()
    {       

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
        // verifica se o personagem está dentro de algum lugar
        if (other.CompareTag("interior"))
        {
            isInterior = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        // verifica se o personagem está dentro de algum lugar
        if (other.CompareTag("interior"))
        {
            isInterior = false;
        }
    }

}