using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento4 : MonoBehaviour
{
    public CharacterController controller;

    Vector3 forward;
    Vector3 strafe;
    Vector3 vertical;

    float forwardSpeed = 6f;
    float strafeSpeed = 6f;

    float gravity;
    float jumpSpeed;
    float maxJumpHeight = 2f;
    float timeToMaxHeight = 0.5f;

    public Animator Animacao;

    private bool PodeAndar = true;
    private float meutempoAndar = 0;

    private Gerenciador GJ;

    void Start()
    {
        GJ = GameObject.FindGameObjectWithTag("GameController").GetComponent<Gerenciador>();

        controller = GetComponent<CharacterController>();

        gravity = (-2 * maxJumpHeight) / (timeToMaxHeight * timeToMaxHeight);
        jumpSpeed = (2 * maxJumpHeight) / timeToMaxHeight;

    }

    void Update()
    {
        if (GJ.EstadoDoJogo() == true)
        {
            if (PodeAndar == false)
            {
                meutempoAndar += Time.deltaTime;
                if (meutempoAndar > 0.5f)
                {
                    PodeAndar = true;
                    meutempoAndar = 0;
                }
            }


            float forwardInput = Input.GetAxisRaw("Vertical");
            float strafeInput = Input.GetAxisRaw("Horizontal");

            // force = input * speed * direction
            forward = forwardInput * forwardSpeed * transform.forward;
            strafe = strafeInput * strafeSpeed * transform.right;

            vertical += gravity * Time.deltaTime * Vector3.up;

            if (controller.isGrounded)
            {
                Animacao.SetBool("Pular", false);
                vertical = Vector3.down;
            }

            if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded)
            {
                PodeAndar = false;
                Animacao.SetBool("Pular", true);
                Animacao.SetBool("Andar", false);
                Animacao.SetBool("Ataque", false);
                Animacao.SetBool("Morrer", false);
                vertical = jumpSpeed * Vector3.up;
            }

            if (vertical.y > 0 && (controller.collisionFlags & CollisionFlags.Above) != 0)
            {

                vertical = Vector3.zero;
            }

            Vector3 finalVelocity = forward + strafe + vertical;

            controller.Move(finalVelocity * Time.deltaTime);

            if (forwardInput != 0 || strafeInput != 0)
            {
                if (PodeAndar == true)
                {
                    Animacao.SetBool("Andar", true);
                    Animacao.SetBool("Pular", false);
                    Animacao.SetBool("Ataque", false);
                    Animacao.SetBool("Morrer", false);
                }

            }

            else
            {
                if (PodeAndar == true)
                {
                    Animacao.SetBool("Andar", false);
                }
            }
        }

    }


}