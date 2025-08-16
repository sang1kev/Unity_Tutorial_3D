using System;
using UnityEngine;

public class AnimalEvent : MonoBehaviour
{
    [SerializeField] private GameObject flag;
    [SerializeField] private GameObject followtarget;
    private BoxCollider boxCollider;

    public static Action flagLost;

    private float timer;
    private bool isTimer;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        flagLost += SetRandomFlag;
    }

    void Update()
    {
        if (!isTimer)
            return;

        timer += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isTimer = true;
            SetRandomFlag();
            followtarget.SetActive(true);
            GameManager.Instance.SetCamState(CameraState.ANIMAL);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log($"깃발 찾는데 걸린 시간은 {timer:F1}초입니다.");
            isTimer = false;
            timer = 0f;

            SetFlag(Vector3.zero, false);
            GameManager.Instance.SetCamState(CameraState.OUTDOOR);
            followtarget.SetActive(false);
        }
    }

    private void SetRandomFlag()
    {
        float randomX = UnityEngine.Random.Range(boxCollider.bounds.min.x, boxCollider.bounds.max.x);
        float randomZ = UnityEngine.Random.Range(boxCollider.bounds.min.z, boxCollider.bounds.max.z);

        var randomPos = new Vector3(randomX, 0f, randomZ);

        SetFlag(randomPos, true);
    }

    private void SetFlag(Vector3 pos, bool isActive)
    {
        flag.transform.SetParent(transform);
        flag.transform.position = pos;
        flag.SetActive(isActive);
    }
}
