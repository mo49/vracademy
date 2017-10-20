﻿using UnityEngine;

namespace CompleteProject
{
    public class EnemyManager : MonoBehaviour
    {
        public PlayerHealth playerHealth;       // Reference to the player's heatlh.
        public GameObject enemy;                // The enemy prefab to be spawned.
        public GameObject enemyInstance;
        public float spawnTime = 3f;            // How long between each spawn.
        public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.

        private int speedCount = 0;


        void Start ()
        {
            // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
            InvokeRepeating ("Spawn", spawnTime, spawnTime);
        }

        void Update() {
            Debug.Log("[score] " + ScoreManager.score);
        }

        void Spawn ()
        {
            // If the player has no health left...
            if(playerHealth.currentHealth <= 0f)
            {
                // ... exit the function.
                return;
            }

            // Find a random index between zero and one less than the number of spawn points.
            int spawnPointIndex = Random.Range (0, spawnPoints.Length);

            // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
            enemyInstance = Instantiate (enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);

            enemyInstance.GetComponent<UnityEngine.AI.NavMeshAgent>().speed *= Mathf.Pow(1.05f,speedCount);
        }

        public void UpdateSpown() {
            spawnTime *= 0.9f;
            CancelInvoke("Spawn");
            InvokeRepeating ("Spawn", spawnTime, spawnTime);
        }

        public void UpdateSpeed() {
            speedCount++;
        }

    }
}
