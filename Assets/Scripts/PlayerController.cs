using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Scripting.APIUpdating;

public class PlayerController : MonoBehaviour
{
    [SerializeField]private float moveSpeed =1f;
    private PlayerControls playerControls;
    private Vector2 movement;
    private Rigidbody2D rb ;
    private Animator myAnimator;
    private SpriteRenderer mySpriteRender;
    private bool isRunning;
    private Vector3 originalScale;
   private void Awake()
{
    playerControls = new PlayerControls();
    rb = GetComponent<Rigidbody2D>();
    myAnimator = GetComponentInChildren<Animator>();
    mySpriteRender = transform.Find("Body").GetComponent<SpriteRenderer>();

    originalScale = transform.localScale;
}
    private void OnEnable(){
        playerControls.Enable();
    }

    private void Update()
    {
        PlayerInput();
    }
    private void FixedUpdate()
    {
        AdjustPlayerFacingDirection();
        Move();
    }
    private void PlayerInput()
{
    movement = playerControls.Movement.Move.ReadValue<Vector2>();

    isRunning = playerControls.Movement.Sprint.IsPressed();

    myAnimator.SetFloat("moveX", movement.x);
    myAnimator.SetFloat("moveY", movement.y);

    float speed = 0f;

    if (movement != Vector2.zero)
    {
        speed = isRunning ? 1f : 0.5f;
    }

    myAnimator.SetFloat("speed", speed);
}
    private void Move()
{
    float currentSpeed = isRunning ? moveSpeed * 2f : moveSpeed;

    rb.MovePosition(rb.position + movement * (currentSpeed * Time.fixedDeltaTime));
}
private void AdjustPlayerFacingDirection()
{
    if (movement.x < 0)
    {
        mySpriteRender.flipX = true;
    }
    else if (movement.x > 0)
    {
        mySpriteRender.flipX = false;
    }
}
    }
   