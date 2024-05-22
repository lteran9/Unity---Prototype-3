using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prototype3 {
   public class RepeatBackground : MonoBehaviour {
      private float repeatWidth {
         get {
            if (boxCollider != null) {
               return boxCollider.size.x / 2;
            }

            return 1f;
         }
      }
      private Vector3 startPos;
      private BoxCollider boxCollider;

      // Start is called before the first frame update
      private void Start() {
         // Cache initial position of game object
         startPos = transform.position;
         boxCollider = GetComponent<BoxCollider>();
      }

      // Update is called once per frame
      private void Update() {
         if (transform.position.x < startPos.x - repeatWidth) {
            transform.position = startPos;
         }
      }
   }
}
