using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Animator anim;

    private PlayerInput playerInput;

    private CharacterController cc;
    private Vector3 moveInput;

    [SerializeField] private float charSpeed;
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float sprintSpeed = 9f;
    [SerializeField] private float turnSpeed = 10f;

    private bool isSprint;

    private Vector3 velocity;
    private const float GRAVITY = -9.8f;

    void Start()
    {
        anim = GetComponent<Animator>();
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        velocity.y += GRAVITY;
        var dir = moveInput * charSpeed + Vector3.up * velocity.y;
        cc.Move(dir * Time.deltaTime);
        Turn();
        SetAnim();
    }

    private void OnMove(InputValue inputValue)
    {
        var move = inputValue.Get<Vector2>();
        moveInput = new Vector3(move.x, 0, move.y);
    }

    private void Turn()
    {
        if (moveInput != Vector3.zero)
        {
            Quaternion targetRot = Quaternion.LookRotation(moveInput);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, turnSpeed * Time.deltaTime);
        }
    }

    private void OnSprint(InputValue inputValue)
    {
        isSprint = inputValue.isPressed;
    }

    private void SetAnim()
    {
        float targetValue = 0f;
        if (moveInput != Vector3.zero)
        {
            targetValue = isSprint ? 1f : 0.5f;
            charSpeed = isSprint ? sprintSpeed : moveSpeed;
        }

        float animValue = anim.GetFloat("Move");
        
        animValue = Mathf.Lerp(animValue, targetValue, 10f *  Time.deltaTime);

        anim.SetFloat("Move", animValue);
    }
}
