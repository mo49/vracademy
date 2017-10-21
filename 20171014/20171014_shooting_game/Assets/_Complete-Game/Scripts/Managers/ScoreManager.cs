using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace CompleteProject
{
    public class ScoreManager : MonoBehaviour
    {
        public static int score;        // The player's score.
        private EnemyManager[] scripts;
        private const int INTERVAL_UPDATE_COUNT = 100;
        private const int INTERVAL_UPDATE_SPEED = 200;
        private int nextTargetScore1 = INTERVAL_UPDATE_COUNT;
        private int nextTargetScore2 = INTERVAL_UPDATE_SPEED;

        Text text;                      // Reference to the Text component.

        EventManager eventManager;

        void Awake ()
        {
            // Set up the reference.
            text = GetComponent <Text> ();

            // Reset the score.
            score = 0;

            scripts = GameObject.Find("EnemyManager").GetComponents<EnemyManager>();
        }

        void Start() {
            eventManager = EventManager.Instance;
        }

        void Update()
        {
            score = eventManager.getScore();

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

            // 100ptごとにspown率を更新
            if(score >= nextTargetScore1){
                nextTargetScore1 += INTERVAL_UPDATE_COUNT;
                foreach (var script in scripts)
                {
                    script.UpdateSpown();
                }
            }
            // 200ptごとにスピードアップ
            if(score >= nextTargetScore2){
                nextTargetScore2 += INTERVAL_UPDATE_SPEED;
                foreach (var script in scripts)
                {
                    script.UpdateSpeed();
                }
            }

        }
    }
}
