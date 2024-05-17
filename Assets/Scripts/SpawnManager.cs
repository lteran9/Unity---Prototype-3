using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prototype3 {
   public class SpawnManager : MonoBehaviour {
      private float startDelay = 2f;
      private float repeatRate = 2f;

      private Vector3 spawnPos = new Vector3(25, 0, 0);
      private PlayerController playerControllerScript;

      [SerializeField] private GameObject obstaclePrefab;

      // Start is called before the first frame update
      private void Start() {
         playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();

         InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
      }

      // Update is called once per frame
      private void Update() {

      }

      private void SpawnObstacle() {
         if (playerControllerScript?.gameOver == false) {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
         }
      }
   }
}