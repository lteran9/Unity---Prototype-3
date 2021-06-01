using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombControllerX : MonoBehaviour
{
   float speed = 0.25f;
   float originalY;


   // Start is called before the first frame update
   void Start()
   {
      originalY = transform.position.y;
   }

   // Update is called once per frame
   void FixedUpdate()
   {
      Vector3 pos = transform.position;
      float length = 1.0f;
      pos.y = Mathf.PingPong(Time.time, length) + originalY;
      transform.position = pos;
   }
}
