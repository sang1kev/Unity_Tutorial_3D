using UnityEngine;

public class MoveWalk : MonoBehaviour, IMove
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
