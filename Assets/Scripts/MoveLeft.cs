﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prototype3 {
   public class MoveLeft : MonoBehaviour {
      private float speed = 30.0f;

      [SerializeField] private PlayerController playerControllerScript;

      // Start is called before the first frame update
      private void Start() {
         if (playerControllerScript != null) {
            playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
         }
      }

      // Update is called once per frame
      private void Update() {
         if (playerControllerScript?.gameOver == false) {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
         }
      }
   }
}
