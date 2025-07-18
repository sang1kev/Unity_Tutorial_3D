using UnityEngine;

public class BombAction : MonoBehaviour
{
    public GameObject bombEffect;

    private void OnCollisionEnter(Collision other)
    {
        GameObject eff = Instantiate(bombEffect);
        eff.transform.position = transform.position;

        Destroy(gameObject);
    }
}
