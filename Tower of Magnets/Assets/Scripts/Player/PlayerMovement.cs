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

    public PhysicsMaterial2D sticky;
    public PhysicsMaterial2D bouncy1, bouncy2, bouncy3, bouncy4, bouncy5, bouncy6, bouncy7, bouncy8;
    
    public int bounceCounter = 9;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
        var hit = Physics2D.BoxCast(new Vector2(transform.position.x, transform.position.y), new Vector2(0.48f,0.1f),
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


    public void Switch(bool thing, int strength)
    {
        if (thing)
        {
            bounceCounter = strength;
            stunned = true;
            rb.constraints = RigidbodyConstraints2D.None;
            canMove = false;
            capsuleCollider.enabled = true;
            capsuleColliderTrigger.enabled = true;

            switch (strength)
            {
                case 8:
                    rb.sharedMaterial = bouncy8;
                    capsuleCollider.sharedMaterial = bouncy8;
                    break;
                case 7:
                    rb.sharedMaterial = bouncy7;
                    capsuleCollider.sharedMaterial = bouncy7;
                    break;
                case 6:
                    rb.sharedMaterial = bouncy6;
                    capsuleCollider.sharedMaterial = bouncy6;
                    break;
                case 5:
                    rb.sharedMaterial = bouncy5;
                    capsuleCollider.sharedMaterial = bouncy5;
                    break;
                case 4:
                    rb.sharedMaterial = bouncy4;
                    capsuleCollider.sharedMaterial = bouncy4;
                    break;
                case 3:
                    rb.sharedMaterial = bouncy3;
                    capsuleCollider.sharedMaterial = bouncy3;
                    break;
                case 2:
                    rb.sharedMaterial = bouncy2;
                    capsuleCollider.sharedMaterial = bouncy2;
                    break;
                case 1:
                    rb.sharedMaterial = bouncy1;
                    capsuleCollider.sharedMaterial = bouncy1;
                    break;
                default:
                    rb.sharedMaterial = sticky;
                    capsuleCollider.sharedMaterial = sticky;
                    break;
                
            }
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
            if (rb.velocity.magnitude >= 2.5f && !other.CompareTag("Forcefield"))
            {
                
                bounceCounter--;
                switch (bounceCounter)
                {
                    case >= 8:
                        rb.sharedMaterial = bouncy8;
                        capsuleCollider.sharedMaterial = bouncy8;
                        break;
                    case 7:
                        rb.sharedMaterial = bouncy7;
                        capsuleCollider.sharedMaterial = bouncy7;
                        break;
                    case 6:
                        rb.sharedMaterial = bouncy6;
                        capsuleCollider.sharedMaterial = bouncy6;
                        break;
                    case 5:
                        rb.sharedMaterial = bouncy5;
                        capsuleCollider.sharedMaterial = bouncy5;
                        break;
                    case 4:
                        rb.sharedMaterial = bouncy4;
                        capsuleCollider.sharedMaterial = bouncy4;
                        break;
                    case 3:
                        rb.sharedMaterial = bouncy3;
                        capsuleCollider.sharedMaterial = bouncy3;
                        break;
                    case 2:
                        rb.sharedMaterial = bouncy2;
                        capsuleCollider.sharedMaterial = bouncy2;
                        break;
                    case 1:
                        rb.sharedMaterial = bouncy1;
                        capsuleCollider.sharedMaterial = bouncy1;
                        break;
                    default:
                        rb.sharedMaterial = sticky;
                        capsuleCollider.sharedMaterial = sticky;
                        break;
                }

                hitSound.pitch = Random.Range(0.5f, 0.8f);
                hitSound.Play();
                cameraShake.Shake(rb.velocity.magnitude * 3, 2f, 0.1f);
            }
        }
        
    }
    
    public void SwitchState(PlayerBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
}
