using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Prototype3.Challenge3
{
   public class PlayerControllerX : MonoBehaviour
   {
      [HideInInspector] public bool gameOver;

      int score;
      float gravityModifier = 1.5f;
      Rigidbody playerRb;
      AudioSource playerAudio;

      [SerializeField] float floatForce;
      [SerializeField] ParticleSystem explosionParticle;
      [SerializeField] ParticleSystem fireworksParticle;
      [SerializeField] AudioClip moneySound;
      [SerializeField] AudioClip explodeSound;
      [SerializeField] TextMeshProUGUI scoreText;


      // Start is called before the first frame update
      void Start()
      {
         Physics.gravity *= gravityModifier;
         playerAudio = GetComponent<AudioSource>();

         playerRb = GetComponent<Rigidbody>();

         // Apply a small upward force at the start of the game
         playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);
      }

      // Update is called once per frame
      void Update()
      {
         // While space is pressed and player is low enough, float up
         if (Input.GetKey(KeyCode.Space) && !gameOver)
         {
            if (transform.position.y < 15)
            {
               playerRb.AddForce(Vector3.up * floatForce);
            }
         }
      }

      void FixedUpdate()
      {
         scoreText.text = "Score: " + score;
      }

      private void OnCollisionEnter(Collision other)
      {
         // if player collides with bomb, explode and set gameOver to true
         if (other.gameObject.CompareTag("Bomb"))
         {
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            gameOver = true;
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
            Destroy(gameObject);
         }
         // if player collides with money, fireworks
         else if (other.gameObject.CompareTag("Money"))
         {
            score++;
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            Destroy(other.gameObject);
         }
         // if player collides with ground
         else if (other.gameObject.CompareTag("Ground"))
         {
            playerRb.AddForce(Vector3.up * 10, ForceMode.Impulse);
         }
      }


      public int GetScore()
      {
         return score;
      }
   }
}