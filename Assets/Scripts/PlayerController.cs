using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   public bool isOnGround = true;
   public bool gameOver = false;
   public float jumpForce = 10;
   public float gravityModifier;

   private Rigidbody playerRb;

   // Start is called before the first frame update
   void Start()
   {
      playerRb = GetComponent<Rigidbody>();
      Physics.gravity *= gravityModifier;
   }

   // Update is called once per frame
   void Update()
   {
      if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
      {
         isOnGround = false;
         playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
      }
   }

   void OnCollisionEnter(Collision other)
   {
      if (other.gameObject.CompareTag("Ground"))
      {
         isOnGround = true;
      }
      else if (other.gameObject.CompareTag("Obstacle"))
      {
         // Game Over
         gameOver = true;
      }
   }
}
