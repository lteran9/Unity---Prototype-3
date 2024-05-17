using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prototype3 {
   public class DestroyOutOfBounds : MonoBehaviour {
      private Vector3 outOfBounds = new Vector3(-10, 0, 0);

      // Start is called before the first frame update
      private void Start() {

      }

      // Update is called once per frame
      private void Update() {
         if (transform.position.x <= outOfBounds.x) {
            Destroy(gameObject);
         }
      }
   }
}
