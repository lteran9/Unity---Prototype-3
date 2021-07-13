using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prototype3
{
   public class PlayerController : MonoBehaviour
   {
      bool isOnGround = true;
      float jumpForce = 250.0f;
      float gravityModifier = 0.25f;

      Rigidbody playerRb;
      Animator playerAnim;
      AudioSource playerAudio;

      [SerializeField] AudioClip jumpSound = default;
      [SerializeField] AudioClip crashSound = default;
      [SerializeField] ParticleSystem explosionParticle = default;
      [SerializeField] ParticleSystem dirtParticle = default;

      public bool gameOver = false;

      // Start is called before the first frame update
      void Start()
      {
         playerRb = GetComponent<Rigidbody>();
         playerAnim = GetComponent<Animator>();
         playerAudio = GetComponent<AudioSource>();

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
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
         }
      }

      void OnCollisionEnter(Collision other)
      {
         if (other.gameObject.CompareTag("Ground"))
         {
            isOnGround = true;
            dirtParticle.Play();
         }
         else if (other.gameObject.CompareTag("Obstacle"))
         {
            // Game Over
            gameOver = true;
            playerAudio.PlayOneShot(crashSound, 1.0f);
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
         }
      }
   }
}