using UnityEngine;

public class MoveRun : IMovement
{
    public float speed;
    
    public MoveRun(float speed)
    {
        this.speed = speed;
    }
    
    public void Move(Transform transform)
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}