using System;
using System.Collections;
using UnityEngine;

public class ShootBow : MonoBehaviour
{
    public GameObject arrowPrefab;
    public Transform shootPos;
    public bool isShoot;

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        bool isTargeting = Physics.Raycast(ray, out hit);

        Debug.DrawRay(transform.position, transform.forward, Color.green);

        if (isTargeting && !isShoot)
        {
            StartCoroutine(ShootRoutine());
        }

    }

    IEnumerator ShootRoutine()
    {
        isShoot = true;

        GameObject arrow = Instantiate(arrowPrefab, transform);
        Quaternion rot = Quaternion.Euler(new Vector3(90, 0, 0));
        arrow.transform.SetPositionAndRotation(shootPos.position, rot);

        yield return new WaitForSeconds(3f);
        isShoot = false;
    }

    private void OnDrawGizmo()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, transform.forward);
    }
}
