using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prototype3.Challenge3
{
   public class SpawnManagerX : MonoBehaviour
   {
      float spawnDelay = 2;
      float spawnInterval = 1.5f;

      PlayerControllerX playerControllerScript;

      [SerializeField] GameObject[] objectPrefabs;

      // Start is called before the first frame update
      void Start()
      {
         InvokeRepeating("SpawnObjects", spawnDelay, spawnInterval);
         playerControllerScript = GameObject.Find("Player").GetComponent<PlayerControllerX>();
      }

      // Spawn obstacles
      void SpawnObjects()
      {
         // Set random spawn location and random object index
         Vector3 spawnLocation = new Vector3(30, Random.Range(5, 15), 0);
         int index = Random.Range(0, objectPrefabs.Length);

         // If game is still active, spawn new object
         if (!playerControllerScript.gameOver)
         {
            var spawn = Instantiate(objectPrefabs[index], spawnLocation, objectPrefabs[index].transform.rotation);

            if (spawn.name.Contains("Bomb"))
            {
               // Add Script to Move
               spawn.AddComponent<BombControllerX>();
            }
         }
      }
   }
}