using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CompleteProject
{
    public class GameOverManager : MonoBehaviour
    {
        public PlayerHealth playerHealth;       // Reference to the player's health.


        Animator anim;                          // Reference to the animator component.


        void Awake ()
        {
            // Set up the reference.
            anim = GetComponent <Animator> ();
        }


        void Update ()
        {
            // If the player has run out of health...
            if(playerHealth.currentHealth <= 0)
            {
                // ... tell the animator the game is over.
                // anim.SetTrigger ("GameOver");
                StartCoroutine("GameOver");
            }
        }

        IEnumerator GameOver() {
            yield return new WaitForSeconds(3);
            anim.SetTrigger ("GameOver");
        }

        // IEnumerator WaitAnimationEnd(string name) {
        //     bool finish = false;
        //     while(!finish) {
        //         if("condition") {

        //         } else {
        //             yield return new WaitForSeconds(0.1f);
        //         }
        //     }
        // }
    }
}
