using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prototype3
{
   public class SpawnManager : MonoBehaviour
   {
      float startDelay = 2f;
      float repeatRate = 2f;

      Vector3 spawnPos = new Vector3(25, 0, 0);
      PlayerController playerControllerScript;

      [SerializeField] GameObject obstaclePrefab;

      // Start is called before the first frame update
      void Start()
      {
         playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();

         InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
      }

      // Update is called once per frame
      void Update()
      {

      }

      void SpawnObstacle()
      {
         if (playerControllerScript.gameOver == false)
         {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
         }
      }
   }
}