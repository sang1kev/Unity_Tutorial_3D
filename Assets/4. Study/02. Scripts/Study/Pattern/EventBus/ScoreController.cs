using UnityEngine;

namespace Pattern
{
    public class ScoreController : MonoBehaviour
    {
        private int score = 0;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                score++;
                StudyEventBus.ScoreChanged(score);
            }
        }
    }
}