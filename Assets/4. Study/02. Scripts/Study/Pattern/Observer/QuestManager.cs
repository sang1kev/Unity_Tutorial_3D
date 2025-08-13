using UnityEngine;

namespace Pattern
{
    public class QuestManager : MonoBehaviour, IObserver
    {
        private bool isQuestClear1 = false;
        private bool isQuestClear2 = false;
        private bool isQuestClear3 = false;
        
        public ISubject subject;

        void OnEnable()
        {
            subject.AddObserver(this);
        }

        void OnDisable()
        {
            subject.RemoveObserver(this);
        }

        public void Notify(int score)
        {
            if (score >= 100 && !isQuestClear1)
            {
                isQuestClear1 = true;
                Debug.Log("100점 달성");
            }
            else if (score >= 500 && !isQuestClear2)
            {
                isQuestClear2 = true;
                Debug.Log("500점 달성");
            }
            else if (score >= 1000 && !isQuestClear3)
            {
                isQuestClear3 = true;
                Debug.Log("1000점 달성");
            }
        }
    }
}