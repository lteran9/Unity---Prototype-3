﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Prototype3.Challenge3
{
   public class MoveLeftX : MonoBehaviour
   {
      float speed = 5.0f;
      float leftBound = -10;

      PlayerControllerX playerControllerScript;

      // Start is called before the first frame update
      void Start()
      {
         playerControllerScript = GameObject.Find("Player").GetComponent<PlayerControllerX>();
      }

      // Update is called once per frame
      void FixedUpdate()
      {
         // If game is not over, move to the left
         if (!playerControllerScript.gameOver)
         {
            transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
         }

         // If object goes off screen that is NOT the background, destroy it
         if (transform.position.x < leftBound && !gameObject.CompareTag("Background"))
         {
            Destroy(gameObject);
         }
      }
   }
}