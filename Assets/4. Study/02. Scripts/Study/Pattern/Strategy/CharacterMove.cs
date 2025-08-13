using UnityEngine;

namespace Pattern
{
    public class CharacterMove : MonoBehaviour
    {
        private IMovement movement;

        void Start()
        {
            movement = new MoveWalk(3f);
        }

        void Update()
        {
            Move();

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                movement = new MoveWalk(3f);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                movement = new MoveRun(7f);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                movement = new MoveFly(1.5f);
            }
        }

        private void Move()
        {
            movement.Move(transform);
        }
    }
}