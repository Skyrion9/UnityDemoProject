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

    // Movement Vars, add private float rotationAngle = 0f; if using alternative rotation method.
    public float movementSpeed = 4f;
    public float rotationSpeed = 8f;
    public float jumpForce = 8f;
    bool isGrounded = false;
    private float rotcompNumber = 0.0001f;
    Vector3 movementVector = new Vector3(0f, 0f, 0f);

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
        playerRotation();
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

    
    private void OnCollisionEnter(Collision collision)  //Check if standing on ground tag
    {
        if (collision.gameObject.CompareTag("floor"))
        {
            isGrounded = true;
            animator.SetBool(ziplama, false);
            ziplamaBasla = false;
        }
    }

    protected void playerMove()
    {
        float horizontalMovement = Input.GetAxis("Horizontal"); //yatay düzlemde 8 axis movement
        float verticalMovement = Input.GetAxis("Vertical");
        movementVector = new Vector3(horizontalMovement, 0f, verticalMovement);
        transform.position += movementVector * movementSpeed * Time.deltaTime;
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

    private void playerRotation()
    {
        if (movementVector.magnitude > rotcompNumber)
        {
            /*      Alternative method to rotate
            rotationAngle = Mathf.Atan2(movementVector.x, movementVector.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(rotationAngle, Vector3.up);*/
            Quaternion targetRotation = Quaternion.LookRotation(movementVector * rotationSpeed * Time.deltaTime);
            transform.rotation = targetRotation;       
        }
    }

}
