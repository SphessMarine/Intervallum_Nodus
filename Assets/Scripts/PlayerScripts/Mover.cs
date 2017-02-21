using UnityEngine;
using MasterFunctions;

public class Mover : MonoBehaviour
{
   public Rigidbody rb;
   public float speed = 20.0f;
   public float gravity = 10.0f;
   public float jumpSpeed = 250.0f;
   public bool isGrounded = false;
   public bool EmilyPls = false;

   // Update is called once per frame
   void Update()
   {
      //MOVEMENT
      if (Input.GetKey(KeyCode.W) && rb.velocity.magnitude < speed)
      {
         if (!EmilyPls)
            rb.AddForce(new Vector3(transform.forward.x, 0.0f, transform.forward.z) * speed);
         else
           rb.AddForce(transform.forward * speed);
      }

      if (Input.GetKey(KeyCode.S) && rb.velocity.magnitude < speed)
      {
         if (!EmilyPls)
            rb.AddForce(new Vector3(transform.forward.x, 0.0f, transform.forward.z) * -speed);
         else
           rb.AddForce(transform.forward * -speed);
      }

      if (Input.GetKey(KeyCode.A) && rb.velocity.magnitude < speed)
      {
          rb.AddForce(transform.right * -speed);
      }

      if (Input.GetKey(KeyCode.D) && rb.velocity.magnitude < speed)
      {
          rb.AddForce(transform.right * speed);
      }

      //JUMPING
      if (Input.GetKey(KeyCode.Space) && isGrounded == true)
      {
         rb.AddForce(new Vector3(0.0f, 1.0f, 0.0f) * jumpSpeed);
         isGrounded = false;
      }

      if (!isGrounded && !EmilyPls)
      {
         rb.AddForce(new Vector3(0.0f, 1.0f, 0.0f) * -gravity);
      }
   }

   void OnCollisionStay(Collision other)
   {
       if (other.gameObject.CompareTag(Master.GetTag(TagKey.TAG_FLOOR)))
       {
           isGrounded = true;
       }
   }

   void OnCollisionExit(Collision other)
   {
       if (other.gameObject.CompareTag(Master.GetTag(TagKey.TAG_FLOOR)))
       {
           isGrounded = false;
       }
   }

}