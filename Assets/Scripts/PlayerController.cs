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
   private Animator playerAnim;

   // Start is called before the first frame update
   void Start()
   {
      playerRb = GetComponent<Rigidbody>();
      playerAnim = GetComponent<Animator>();

      Physics.gravity *= gravityModifier;
   }

   // Update is called once per frame
   void Update()
   {
      if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
      {
         isOnGround = false;
         playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
         playerAnim.SetTrigger("Jump_trig");
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
         playerAnim.SetBool("Death_b", true);
         playerAnim.SetInteger("DeathType_int", 1);
      }
   }
}
