using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   public bool isOnGround = true;
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

   void OnCollisionEnter(Collision other) {
      isOnGround = true;   
   }
}
