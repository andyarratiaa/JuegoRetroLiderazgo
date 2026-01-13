using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float PlayerSpeed;
    [SerializeField] float JumpForce;
    [SerializeField] Rigidbody2D PlayerRigidbody;
    [SerializeField] CapsuleCollider2D CapsuleCollisionStand;
    [SerializeField] CapsuleCollider2D CapsuleCollisionCrouch;
    [SerializeField] GameObject CapsuleStand;
    [SerializeField] GameObject CapsuleCrouch;

    [SerializeField] BoxCollider2D attackCollider;
    [SerializeField] BoxCollider2D attackColliderCrouch;





    private bool isGrounded = true;
    private bool isCroached = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    private void Update()
    {
        if (GetComponent<PlayerVariablesManager>().isPlayerDead)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && !isCroached)
        {
            //Activar animacion ataque standing (cambiar corutina a animation event)
            StartCoroutine(AttackStanding());
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0) && isCroached)
        {
            //Activar animacion ataque crouch (cambiar corutina a animation event)
            StartCoroutine(AttackCrouching());
        }


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //isGrounded = Physics2D.CircleCast(transform.position, 0.5f, Vector2.down, 0.05f, GoundObjets);
        if (GetComponent<PlayerVariablesManager>().isPlayerDead)
        {
            return;
        }

        if (!isCroached)
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.position = new Vector3(transform.position.x - PlayerSpeed, transform.position.y, transform.position.z);
                transform.localScale = new Vector3(-1f, transform.localScale.y, transform.localScale.z);
            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.position = new Vector3(transform.position.x + PlayerSpeed, transform.position.y, transform.position.z);
                transform.localScale = new Vector3(1f, transform.localScale.y, transform.localScale.z);
            }

            if (Input.GetKey(KeyCode.Space) && isGrounded)
            {
                isGrounded = false;
                PlayerRigidbody.AddForce(transform.up * JumpForce);
            }
        }

        else
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.localScale = new Vector3(-1f, transform.localScale.y, transform.localScale.z);
            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.localScale = new Vector3(1f, transform.localScale.y, transform.localScale.z);
            }
        }



        if (Input.GetKey(KeyCode.LeftControl))
        {
            isCroached = true;
            CapsuleCollisionStand.enabled = false;
            CapsuleStand.SetActive(false);

            CapsuleCollisionCrouch.enabled = true;
            CapsuleCrouch.SetActive(true);
        }

        else
        {
            isCroached = false;
            CapsuleCollisionCrouch.enabled = false;
            CapsuleCrouch.SetActive(false);

            CapsuleCollisionStand.enabled = true;
            CapsuleStand.SetActive(true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    public void OnDead()
    {
        CapsuleCollisionStand.enabled = false;
        CapsuleCollisionCrouch.enabled = false;
    }

    void ActivateAttackColliderStanding()
    {
        attackCollider.enabled = true;
    }

    void DeactivateAttackColliderStanding()
    {
        attackCollider.enabled = false;
    }

    void ActivateAttackColliderCrouch()
    {
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
