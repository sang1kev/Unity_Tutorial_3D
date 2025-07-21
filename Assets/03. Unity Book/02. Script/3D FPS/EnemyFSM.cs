using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyFSM : MonoBehaviour
{
    private enum EnemyState { IDLE, MOVE, ATTACK, RETURN, DAMAGED, DIE }
    private EnemyState enemyFSM;

    private Transform player;
    private CharacterController cc;

    public float findDistance = 8f;
    public float attackDistance = 3f;
    public float moveSpeed = 5f;
    public float moveDistance = 20f;
    private Vector3 originPos;

    private float currTime = 0f;
    private float attackDelay = 2f;

    public float damage = 2f;
    public float hp = 15f;
    private float maxHp = 15f;
    public Slider hpSlider;

    void Start()
    {
        enemyFSM = EnemyState.IDLE;
        player = GameObject.Find("Player").transform;
        cc = GetComponent<CharacterController>();
        originPos = transform.position;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (FPSGameManager.Instance.gState == FPSGameManager.GameState.READY)
            return;

        switch (enemyFSM)
        {
            case EnemyState.IDLE:
                Idle();
                break;
            case EnemyState.MOVE:
                Move();
                break;
            case EnemyState.ATTACK:
                Attack();
                break;
            case EnemyState.RETURN:
                Return();
                break;
            case EnemyState.DAMAGED:
                //Damaged();
                break;
            case EnemyState.DIE:
                //Die();
                break;
        }

        hpSlider.value = (float)hp / (float)maxHp;
    }

    private void Idle()
    {
        if (Vector3.Distance(transform.position, player.position) < findDistance)
        {
            enemyFSM = EnemyState.MOVE;
            Debug.Log("Idle -> Move");
        }
    }

    private void Move()
    {
        if (Vector3.Distance(transform.position, originPos) > moveDistance)
        {
            enemyFSM = EnemyState.RETURN;
            Debug.Log("Move -> Return");

        }
        else if (Vector3.Distance(transform.position, player.position) > attackDistance)
        {
            Vector3 dir = (player.position - transform.position).normalized;
            cc.Move(dir * moveSpeed * Time.deltaTime);
        }
        else
        {
            currTime = attackDelay;
            enemyFSM = EnemyState.ATTACK;
            Debug.Log("Move -> Attack");
        }
    }

    private void Attack()
    {
        if(Vector3.Distance(transform.position, player.position) <  attackDistance)
        {
            currTime += Time.deltaTime;
            if (currTime > attackDelay)
            {
                currTime = 0f;
                player.GetComponent<FPSPlayerMove>().DamageAction(damage);
                Debug.Log("Attack");
            }
        }
        else
        {
            currTime = 0f;
            enemyFSM = EnemyState.MOVE;
            Debug.Log("상태 전환 : Attack -> Move");
        }
    }

    private void Return()
    {
        if (Vector3.Distance(transform.position, originPos) > 0.1f)
        {
            Vector3 dir = (originPos - transform.position).normalized;
            cc.Move(dir * moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = originPos;
            hp = 15f;
            enemyFSM = EnemyState.IDLE;
            Debug.Log("Return -> Idle");
        }
    }

    private void Damaged()
    {
        StartCoroutine(DamageProcess());
    }

    IEnumerator DamageProcess()
    {
        yield return new WaitForSeconds(0.5f);

        enemyFSM = EnemyState.MOVE;
        Debug.Log("Damaged -> Move");
    }

    public void HitEnemy(float hitPower)
    {
        if (enemyFSM == EnemyState.DAMAGED || enemyFSM == EnemyState.DIE || enemyFSM == EnemyState.RETURN)
            return;

        hp -= hitPower;

        if (hp > 0f)
        {
            enemyFSM = EnemyState.DAMAGED;
            Debug.Log("AnyState -> Damaged");
            Damaged();
        }
        else
        {
            enemyFSM = EnemyState.DIE;
            Debug.Log("Any State -> Die");
            Die();
        }
    }

    private void Die()
    {
        StopAllCoroutines();

        StartCoroutine(DieProcess());
    }

    IEnumerator DieProcess()
    {
        cc.enabled = false;

        yield return new WaitForSeconds(2f);
        Debug.Log("소멸");
        Destroy(gameObject);
    }
}
