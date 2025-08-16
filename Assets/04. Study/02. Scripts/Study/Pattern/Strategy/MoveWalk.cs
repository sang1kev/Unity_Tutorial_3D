using UnityEngine;

public class MoveWalk : IMovement
{
    public float speed;

    public MoveWalk(float speed)
    {
        this.speed = speed;
    }
    
    public void Move(Transform transform)
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}