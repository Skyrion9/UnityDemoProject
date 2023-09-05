using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animControlPlayer : MonoBehaviour
{
    //Animator Vars
    Animator animator;
    int yurume, ziplama;
    bool yuruyor = false;
    bool zipliyor = false;
    bool yurumeBasla = false;
    bool ziplamaBasla = false;

    // Movement Vars
    public float movementSpeed = 4f;
    public float rotationSpeed = 4f;
    public float jumpForce = 8f;
    bool isGrounded = false;
    void Start()
    {
        animator = GetComponent<Animator>();
        yurume = Animator.StringToHash("isWalking");
        ziplama = Animator.StringToHash("isJumping");
    }

    void Update()
    {
        //Movement code
        playerMove();
        playerJump();

        //Animation parameter updates
        yuruyor = animator.GetBool(yurume);
        zipliyor = animator.GetBool(ziplama);

        if (!yuruyor && yurumeBasla)
        {
            animator.SetBool(yurume, true);
            Debug.Log("Yurumeye basla!");
            //animator.SetFloat("walkingSpeed", 1.0f);
        }
        if (yuruyor && !yurumeBasla)
        {
            animator.SetBool(yurume, false);
            Debug.Log("Yurumeye W'den el cekildi dur");
            //animator.SetFloat("walkingSpeed", -1.0f);  backwards movement
        }
        if (!zipliyor && ziplamaBasla)
        {
            animator.SetBool(ziplama, true);
            Debug.Log("Ziplamiyor ve ziplamaya basla");
        }
        if (zipliyor && !ziplamaBasla)
        {
            animator.SetBool(ziplama, false);
            Debug.Log("Yurumeye W'den el cekildi dur");
        }
    }
    //Check if standing on ground tag
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("floor"))
        {
            isGrounded = true;
            animator.SetBool(ziplama, false);
            ziplamaBasla = false;
        }
    }

    private void playerMove()
    {
        float horizontalMovement = Input.GetAxis("Horizontal"); //yatay düzlemde 8 axis movement
        float verticalMovement = Input.GetAxis("Vertical");     
        Vector3 movementVector = new Vector3(horizontalMovement, 0f, verticalMovement); 
        transform.position += movementVector * movementSpeed * Time.deltaTime;
        if (movementVector != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movementVector * rotationSpeed * Time.deltaTime);
            transform.rotation = targetRotation;
        }

        yurumeBasla = movementVector.magnitude != 0;
    }
    
    private void playerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            ziplamaBasla = true;
        }
    }
}
