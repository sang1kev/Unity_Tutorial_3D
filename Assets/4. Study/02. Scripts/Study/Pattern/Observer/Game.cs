using Pattern.Observer;
using UnityEngine;

namespace Pattern.Observer
{
    public class Game : MonoBehaviour
    {
        void Start()
        {
            Player player = new Player();

            player.AddScore(100);
            
            player.AddScore(500);
            
            player.AddScore(1000);
        }
    }
}