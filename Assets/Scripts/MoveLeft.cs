using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prototype3
{
   public class MoveLeft : MonoBehaviour
   {
      float speed = 30.0f;
      PlayerController playerControllerScript;

      // Start is called before the first frame update
      void Start()
      {
         playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
      }

      // Update is called once per frame
      void Update()
      {
         if (playerControllerScript.gameOver == false)
         {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
         }
      }
   }
}
