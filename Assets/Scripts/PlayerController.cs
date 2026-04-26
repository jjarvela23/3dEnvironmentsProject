using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Collision : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Rigidbody MyCharacter;
    private bool onGround = false;
    private bool canDoubleJump = false;

    public bool HasDoubleJumped = false;

    private Vector2 oldDirection;
    InputAction move;
    InputAction jump;
    public float moveSpeed;
    public float jumpSpeed;
    [SerializeField] private Animator MovementAnimator;

    void Start()
    {
        MyCharacter = gameObject.GetComponent<Rigidbody>();
        move = InputSystem.actions.FindAction("Move");
        jump = InputSystem.actions.FindAction("Jump");
        onGround = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 moveDirection = move.ReadValue<Vector2>();
        MyCharacter.position += (new Vector3(moveDirection.x, 0f, moveDirection.y) * moveSpeed * Time.deltaTime);
        if (moveDirection != oldDirection)
        {
            MyCharacter.rotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0f, moveDirection.y));
        }
        oldDirection = moveDirection;
        if (move.IsPressed())
        {
            MovementAnimator.SetBool("IsWalking", true);
        }
        else
        {
            MovementAnimator.SetBool("IsWalking", false);
        }
    }

    void Update()
    {
        if (jump.IsPressed() && onGround)
        {
            MyCharacter.linearVelocity = new Vector3(0f, jumpSpeed, 0f);
            gameObject.GetComponent<AudioSource>().Play();
            onGround = false;
        }
        else if (!jump.IsPressed() && !onGround)
        {
            canDoubleJump = true;
        }
        else if (jump.IsPressed() && !onGround && canDoubleJump && !HasDoubleJumped)
        {
            //MyCharacter.AddForce(0f, jumpSpeed - 15f , 0f, ForceMode.VelocityChange);
            MyCharacter.linearVelocity = new Vector3(0f, jumpSpeed / (3/2), 0f);
            gameObject.GetComponent<AudioSource>().Play();
            canDoubleJump = false;
            HasDoubleJumped = true;
            
        }
    }

    private void OnCollisionStay(UnityEngine.Collision collision)
    {
        //Debug.Log("you are grounded");
        if (collision.collider.CompareTag("floor"))
        {
            onGround = true;
            HasDoubleJumped = false;
            canDoubleJump = false;
        }
    }

    public void SetMoveSpeed(float speed)
    {
        moveSpeed = speed;
    }

}
