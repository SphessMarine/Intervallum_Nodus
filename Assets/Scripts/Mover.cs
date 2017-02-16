using UnityEngine;

public class Mover : MonoBehaviour
{

    public Rigidbody rb;
    public float speed = 1000.0f;
    public float jumpSpeed = 1000.0f;
    public bool isGrounded = false;
    // public bool isColliding = false;

    // Update is called once per frame

    void Update()
    {

        //MOVEMENT
        if (Input.GetKey(KeyCode.W) && rb.velocity.magnitude < 100.0f)
        {
            rb.AddForce(transform.forward * speed);
        }

        if (Input.GetKey(KeyCode.S) && rb.velocity.magnitude < 100.0f)
        {
            rb.AddForce(transform.forward * -speed);
        }

        if (Input.GetKey(KeyCode.A) && rb.velocity.magnitude < 100.0f)
        {
            rb.AddForce(transform.right * -speed);
        }

        if (Input.GetKey(KeyCode.D) && rb.velocity.magnitude < 100.0f)
        {
            rb.AddForce(transform.right * speed);
        }

        //JUMPING
        if (Input.GetButtonDown("Fire1") && isGrounded == true)
        {
            rb.AddForce(transform.up * jumpSpeed);
        }

    }

    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("floor"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("floor"))
        {
            isGrounded = false;
        }
    }
}