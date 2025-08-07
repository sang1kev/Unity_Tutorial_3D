using UnityEngine;

namespace Pattern
{
    public class CharacterMove : MonoBehaviour
    {
        /*public enum MoveState { Walk, Run, Fly }
        public MoveState moveState = MoveState.Walk;

        public float walkSpeed, runSpeed, flySpeed;

        void Update()
        {
            Move();
        }

        private void Move()
        {
            float speed = 0;
            switch (moveState)
            {
                case MoveState.Walk:
                    speed = walkSpeed;
                    break;
                case MoveState.Run:
                    speed = runSpeed;   
                    break;
                case MoveState.Fly:
                    speed = flySpeed;
                    break;
            }

            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }*/

        private IMove movement;

        void Start ()
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
                movement = new MoveWalk(7f);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            { 
                movement = new MoveWalk(11f);
            }
        }

        private void Move ()
        {
            movement.Move(transform);
        }
    }
}