using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float movementSpeed = 4f;
    public float jumpForce = 8f;
    bool isGrounded = false;
    // Update is called once per frame
    void Update()
    {
        float horizontalMovement = Input.GetAxis("Horizontal"); //yatay düzlemde 8 axis movement
        float verticalMovement = Input.GetAxis("Vertical");



        Vector3 movementVector = new Vector3(horizontalMovement, 0f, verticalMovement) * movementSpeed * Time.deltaTime; //TODO add Y vector for jumps.

        transform.Translate(movementVector);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

      /*  OLD implementation
        float movementAmount = movementSpeed * Time.deltaTime;

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * movementAmount);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * movementAmount);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left* movementAmount);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * movementAmount);
        }*/

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("floor"))
        {
            isGrounded = true;
        }
    }
}
