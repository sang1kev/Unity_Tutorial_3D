using UnityEngine;

namespace Pattern
{
    public class ScoreManager : MonoBehaviour
    {
        void OnEnable()
        {
            StudyEventBus.onScoreChanged += UpdateScore;
        }

        void OnDisable()
        {
            StudyEventBus.onScoreChanged -= UpdateScore;
        }
        
        private void UpdateScore(int newScore)
        {
            Debug.Log($"현재 점수 : {newScore}");
        }
    }
}