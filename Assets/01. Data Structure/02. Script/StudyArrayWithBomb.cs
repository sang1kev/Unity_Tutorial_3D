using System;
using System.Collections;
using UnityEngine;

public class StudyArrayWithBomb : MonoBehaviour
{
    private Transform bombTf;
    private Transform bombParticle;
    
    private Rigidbody bombRB;

    [SerializeField] private float explodeTime = 3f;
    [SerializeField] private float bombRange = 10f;
    [SerializeField] LayerMask layerMask;

    void Awake()
    {
        bombTf = transform.GetChild(0);
        bombParticle = transform.GetChild(1);

        bombRB = GetComponent<Rigidbody>();
    }

    IEnumerator Start()
    {
        yield return new WaitForSeconds(explodeTime);

        bombTf.gameObject.SetActive(false);
        bombParticle.gameObject.SetActive(true);

        ExplodeBomb();
    }

    private void ExplodeBomb()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, bombRange, layerMask);

        for (int i = 0; i < colliders.Length; i++)
        {
            Rigidbody rb = colliders[i].GetComponent<Rigidbody>();
            rb.AddExplosionForce(250f, transform.position, bombRange, 1f);
        }
    }
}
