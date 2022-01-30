using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Random = UnityEngine.Random;

public class PlayerMovement : MonoBehaviour
{
    [HideInInspector] public Rigidbody2D rb;
    public bool grounded;
    public float movementSpeed = 5f;
    [HideInInspector] public float yVelocity = 0f;

    public float jumpForce = 6f;

    public bool canMove = true;

    public bool stunned = false;

    [SerializeField] private LayerMask groundLayer;
    
    [SerializeField] private CapsuleCollider2D capsuleCollider, capsuleColliderTrigger;
    private BoxCollider2D boxCollider;

    private AudioSource hitSound;

    [SerializeField] CameraShake cameraShake;
    
    public Animator playerAnimator;
    public Transform spriteTransform;
    [HideInInspector] public float initialSpriteTransform;
    
    PlayerBaseState currentState;
    public PlayerMoveState MoveState = new PlayerMoveState();
    public PlayerAirState AirState = new PlayerAirState();
    public PlayerStunnedState StunnedState = new PlayerStunnedState();
    public PlayerCutsceneState CutsceneState = new PlayerCutsceneState();

    public PhysicsMaterial2D bouncy, sticky;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        hitSound = GetComponent<AudioSource>();
        initialSpriteTransform = spriteTransform.localScale.x;
        
        currentState = MoveState;
        
        currentState.EnterState(this);
    }


    private void Update()
    {
        currentState.UpdateState(this);
    }

    private void FixedUpdate()
    {
        var hit = Physics2D.BoxCast(new Vector2(transform.position.x, transform.position.y), new Vector2(1f,0.1f),
            0f, Vector2.down, 0.1f, groundLayer);
        
        if (hit.collider != null && yVelocity <= 0f)
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }
        
        currentState.FixedUpdateState(this);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        //Gizmos.DrawWireCube(transform.position + transform.forward, new Vector3(1,0.05));
    }


    public void Switch(bool thing)
    {
        if (thing)
        {
            stunned = true;
            rb.constraints = RigidbodyConstraints2D.None;
            canMove = false;
            capsuleCollider.enabled = true;
            capsuleColliderTrigger.enabled = true;
            rb.sharedMaterial = bouncy;
            capsuleCollider.sharedMaterial = bouncy;
        }
        else
        {
            stunned = false;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            rb.velocity = Vector2.zero;
            yVelocity = 2f;
            canMove = true;
            transform.DOLocalRotate(new Vector3(0, 0, 0), 0.25f);
            capsuleColliderTrigger.enabled = false;
            rb.sharedMaterial = sticky;
            capsuleCollider.sharedMaterial = sticky;
            
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (stunned)
        {
            if (rb.velocity.magnitude >= 1f)
            {
                hitSound.pitch = Random.Range(0.9f, 1.1f);
                hitSound.Play();
                cameraShake.Shake(rb.velocity.magnitude, 10f, 0.1f);
            }
        }
        
    }
    
    public void SwitchState(PlayerBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
}
