using UnityEngine;

public class MoveFly : MonoBehaviour, IMove
{
    public float speed;

    public MoveFly(float speed)
    {
        this.speed = speed;
    }

    public void Move(Transform transform)
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
