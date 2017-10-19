using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace CompleteProject
{
    public class ScoreManager : MonoBehaviour
    {
        public static int score;        // The player's score.

        Text text;                      // Reference to the Text component.


        void Awake ()
        {
            // Set up the reference.
            text = GetComponent <Text> ();

            // Reset the score.
            score = 0;
        }


        void Update()
        {
            // Set the displayed text to be the word "Score" followed by the score value.
            text.text = "Score: " + score;

            if (score >= 30)
            {
                // 黄色
                text.color = Color.yellow;
            }
            else if (score >= 20)
            {
                // 緑
                text.color = Color.green;
            }
            else if (score >= 10)
            {
                // 青
                text.color = Color.blue;
            }
            else
            {
                // 白
                text.color = Color.white;
            }

        }
    }
}
