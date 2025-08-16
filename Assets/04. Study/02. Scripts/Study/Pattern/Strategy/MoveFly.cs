using UnityEngine;

public class MoveFly : IMovement
{
    public float speed;
    
    public MoveFly(float speed)
    {
        this.speed = speed;
    }
    
    public void Move(Transform transform)
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
}