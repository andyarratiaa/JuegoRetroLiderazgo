using Mono.Cecil;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float PlayerSpeed;
    float startingPlayerSpeed;
    [SerializeField] float veloSpeed; 
    [SerializeField] float JumpForce;
    int extraJumps = 1;
    [SerializeField] Rigidbody2D PlayerRigidbody;
    [SerializeField] CapsuleCollider2D CapsuleCollisionStand;
    [SerializeField] CapsuleCollider2D CapsuleCollisionCrouch;
    [SerializeField] GameObject CapsuleStand;
    [SerializeField] GameObject TriceAttack;

    [SerializeField] BoxCollider2D attackCollider;
    [SerializeField] BoxCollider2D attackColliderCrouch;

    Animator anim;

    PlayerVariablesManager playerVariablesManager;
    float moveDirection;

    public InputActionReference jump;
    public InputActionReference attack;
    public InputActionReference crouch;



    private bool isGrounded = true;
    private bool isCroached = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerVariablesManager = GetComponent<PlayerVariablesManager>();
        anim = GetComponentInChildren<Animator>();
        startingPlayerSpeed = PlayerSpeed;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        moveDirection = Input.GetAxis("Horizontal");
        Debug.Log(moveDirection);
        if(playerVariablesManager.veloPowerup)
        {
            PlayerSpeed = veloSpeed;
        } else
        {
            PlayerSpeed = startingPlayerSpeed;
        }
        if (GetComponent<PlayerVariablesManager>().isPlayerDead)
        {
            anim.SetBool("isJumping", true);
            return;
        } 

        if(isCroached)
        {
            anim.SetBool("isCrouch", true);
        }
        else
        {
            anim.SetBool("isCrouch", false);
        }

        if(!isGrounded)
        {
            anim.SetBool("isJumping", true);
        } else
        {
            extraJumps = 1;
            anim.SetBool("isJumping", false);
        }

        if(moveDirection > 0.001 || moveDirection < -0.001 ||Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            anim.SetBool("isMoving", true);
        } else
        {
            anim.SetBool("isMoving", false);
        }

        //if(!isCroached)
        //{
        //    attack.action.started += Attack;
        //} else if(isCroached)
        //{
        //    attack.action.started += Attack;
        //}
        if (Input.GetKeyDown(KeyCode.Mouse0) && !isCroached || Input.GetButtonDown("Fire1")  && !isCroached)
        {
            //Activar animacion ataque standing (cambiar corutina a animation event)
            //StartCoroutine(AttackStanding());
            anim.SetTrigger("Attack");
            //if (playerVariablesManager.tricePowerup)
            //{
            //    TriceAttack.SetActive(true);
            //}
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0) && isCroached || Input.GetButtonDown("Fire1") && isCroached)
        {
            //Activar animacion ataque crouch (cambiar corutina a animation event)
            //StartCoroutine(AttackCrouching());
            anim.SetTrigger("Attack");
            //if(playerVariablesManager.tricePowerup)
            //{
            //    TriceAttack.SetActive(true);
            //}
        }

        if (!isCroached)
        {
            //if(!isGrounded)
            //{
            //    jump.action.performed += Jump;
            //} else if (isGrounded)
            //{
            //    jump.action.performed += JumpGround;
            //}
            if (Input.GetKeyDown(KeyCode.Space) && !isGrounded || Input.GetButtonDown("Jump") && !isGrounded)
            {
                if (playerVariablesManager.pteroPowerup)
                {
                    if (extraJumps > 0)
                    {
                        extraJumps--;
                        PlayerRigidbody.linearVelocity = Vector3.zero;
                        PlayerRigidbody.AddForce(transform.up * JumpForce);
                    }
                }
                //else if (Input.GetKey(KeyCode.Space) && !isGrounded)
                //{
                //    PlayerRigidbody.gravityScale = 0.5f;
                //}
            }

            if (Input.GetKeyDown(KeyCode.Space) && isGrounded || Input.GetButtonDown("Jump") && isGrounded)
            {
                extraJumps = 1;
                isGrounded = false;
                PlayerRigidbody.AddForce(transform.up * JumpForce);

            }
        }


    }

    private void Attack(InputAction.CallbackContext obj)
    {
        anim.SetTrigger("Attack");
        attack.action.started -= Attack;

    }

    private void Crouch(InputAction.CallbackContext obj)
    {

        isCroached = true;
        CapsuleCollisionStand.enabled = false;
        //CapsuleStand.SetActive(false);

        CapsuleCollisionCrouch.enabled = true;
        //CapsuleCrouch.SetActive(true);

    }

    private void Jump(InputAction.CallbackContext obj)
    {

        if (!obj.performed)
            return;

        if (!playerVariablesManager.pteroPowerup)
            return;

        if (extraJumps <= 0)
            return;

        extraJumps--;
                PlayerRigidbody.linearVelocity = Vector3.zero;
                PlayerRigidbody.AddForce(transform.up * JumpForce);
          
    }

    private void JumpGround(InputAction.CallbackContext obj)
    {
        //extraJumps = 1;
        isGrounded = false;
        PlayerRigidbody.AddForce(transform.up * JumpForce);
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //float moveDirection = Input.GetAxis("Horizontal");
        //isGrounded = Physics2D.CircleCast(transform.position, 0.5f, Vector2.down, 0.05f, GoundObjets);
        if (GetComponent<PlayerVariablesManager>().isPlayerDead)
        {
            return;
        }

        if (!isCroached)
        {
            if (Input.GetKey(KeyCode.A) || moveDirection < -0.01)
            {
                transform.position = new Vector3(transform.position.x - PlayerSpeed, transform.position.y, transform.position.z);
                transform.localScale = new Vector3(-1f, transform.localScale.y, transform.localScale.z);
            }

            if (Input.GetKey(KeyCode.D) || moveDirection > 0.01)
            {
                transform.position = new Vector3(transform.position.x + PlayerSpeed, transform.position.y, transform.position.z);
                transform.localScale = new Vector3(1f, transform.localScale.y, transform.localScale.z);
            }

           
            

            //if (Input.GetKeyUp(KeyCode.Space)) 
            //{
            //    PlayerRigidbody.gravityScale = 1f;
            //}



        }

        else
        {
            if (Input.GetKey(KeyCode.A) || moveDirection < -0.001)
            {
                transform.localScale = new Vector3(-1f, transform.localScale.y, transform.localScale.z);
            }

            if (Input.GetKey(KeyCode.D) || moveDirection > 0.001)
            {
                transform.localScale = new Vector3(1f, transform.localScale.y, transform.localScale.z);
            }
        }


        //crouch.action.performed += Crouch;
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetButton("Fire2"))
        {
            isCroached = true;
            CapsuleCollisionStand.enabled = false;
            //CapsuleStand.SetActive(false);

            CapsuleCollisionCrouch.enabled = true;
            //CapsuleCrouch.SetActive(true);
        }

        else
        {
            isCroached = false;
            CapsuleCollisionCrouch.enabled = false;
            //CapsuleCrouch.SetActive(false);

            CapsuleCollisionStand.enabled = true;
            //CapsuleStand.SetActive(true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            extraJumps = 1;
            isGrounded = true;
        }
    }

    public void OnDead()
    {
        PlayerSoundManager.instance.PlaySoundDeath();
        CapsuleCollisionStand.enabled = false;
        CapsuleCollisionCrouch.enabled = false;
    }

    void ActivateAttackColliderStanding()
    {
        PlayerSoundManager.instance.PlaySoundAttack();
        attackCollider.enabled = true;
    }

    void DeactivateAttackColliderStanding()
    {
        attackCollider.enabled = false;
    }

    void ActivateAttackColliderCrouch()
    {
        PlayerSoundManager.instance.PlaySoundAttack();
        attackColliderCrouch.enabled = true;
    }

    void DeactivateAttackColliderCrouch()
    {
        attackColliderCrouch.enabled = false;
    }

    IEnumerator AttackStanding()
    {
        ActivateAttackColliderStanding();
        yield return new WaitForSeconds(0.5f);
        DeactivateAttackColliderStanding();
    }

    IEnumerator AttackCrouching()
    {
        ActivateAttackColliderCrouch();
        yield return new WaitForSeconds(0.5f);
        DeactivateAttackColliderCrouch();
    }
}
