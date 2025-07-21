using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FPSPlayerMove : MonoBehaviour
{
    private CharacterController cc;

    public float moveSpeed = 7f;

    public float gravity = -10f;
    private float yVelocity = 0f;

    public float jumpPower = 5f;
    private bool isJumping = false;

    public float  hp = 20;

    private float maxHP = 20f;
    public Slider hpSlider;

    public GameObject hitEffect;

    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (FPSGameManager.Instance.gState == FPSGameManager.GameState.READY)
            return;

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v); // 크기와 방향이 있는 벡터
        dir = dir.normalized; // 방향만 있는 벡터 
        dir = Camera.main.transform.TransformDirection(dir);

        yVelocity += gravity * Time.deltaTime;
        dir.y = yVelocity;

        cc.Move(dir * moveSpeed * Time.deltaTime);

        if (cc.collisionFlags == CollisionFlags.Below)
        {
            if (isJumping)
            {
                isJumping = false;
            }
            yVelocity = 0f;
        }

        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            isJumping = true;
            yVelocity = jumpPower;
        }

        hpSlider.value = (float)hp / (float)maxHP;
    }

    public void DamageAction(float damage)
    {
        hp -= damage;
        hpSlider.value = (float)hp/(float)maxHP;
        if(hp > 0)
        {
            StartCoroutine(HitEffect());
        }
    }

    IEnumerator HitEffect()
    {
        hitEffect.SetActive(true);
        yield return new WaitForSeconds(0.5f);

        hitEffect.SetActive(false);
    }
}
