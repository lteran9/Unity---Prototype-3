using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prototype3
{
   public class DestroyOutOfBounds : MonoBehaviour
   {
      Vector3 outOfBounds = new Vector3(-10, 0, 0);

      // Start is called before the first frame update
      void Start()
      {

      }

      // Update is called once per frame
      void Update()
      {
         if (transform.position.x <= outOfBounds.x)
         {
            Destroy(gameObject);
         }
      }
   }
}
