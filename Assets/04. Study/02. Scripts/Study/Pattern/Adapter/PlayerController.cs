using UnityEngine;

namespace Pattern.Adapter
{
    public class PlayerController : MonoBehaviour
    {
        public GameObject player;

        private ICharacter character;

        void Start()
        {
            character = player.GetComponent<ICharacter>();
            
            character.Move(Vector3.forward);
            
            character.Attack();
            
            
            LegacyPlayer legacyPlayer = new LegacyPlayer();
            legacyPlayer.LegacyMove(0, 0, 1);
        }
    }
}