using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Config")]
    [SerializeField]
    private float speed, walkspeed, runspeed;
    private Vector2 moveDirection;
    [SerializeField] private PlayerStats stats;

    private Player player;
    private PlayerStamina stamina;
    private PlayerAnimations playeranimations;
    private PlayerActions actions;
    private Rigidbody2D rd2d;

    private void Awake()
    {
        player = GetComponent<Player>();
        playeranimations = GetComponent<PlayerAnimations>();
        stamina = GetComponent<PlayerStamina>();    
        rd2d = GetComponent<Rigidbody2D>();
        actions = new PlayerActions();
    }

    private void Update()
    {
        ReadMovement();
        Attack();
    }
    private void FixedUpdate()
    {
        Move();
        Run();
    }
    // Hareket Fonksiyonu
    private void Run()
    {
        if(stats.Stamina<=0)
        { 
            speed = walkspeed;
            stamina.GainStamina();
            return;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = runspeed;
            stamina.LostStamina();
        }
        else 
        {
            stamina.GainStamina();
            speed = walkspeed; 
        }
    }
    private void Move()
    {
        if(player.Stats.Health <= 0f) return; 
    rd2d.MovePosition(rd2d.position+moveDirection*(speed*Time.deltaTime));        
    }
    // Inputu Okuyor ve deðiþkene atýyor
    private void ReadMovement()
    {
        moveDirection = actions.Movement.Move.ReadValue<Vector2>().normalized;
        if (moveDirection == Vector2.zero)
        {
            playeranimations.SetMoveBooltransaitoin(false);
            return;
        }

        playeranimations.SetMoveBooltransaitoin(true);
        playeranimations.SetMoveAnimation(moveDirection);
    }
    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            playeranimations.TriggerAttackAnimation();
            Debug.Log("Attack pressed");
        }
    }


    private void OnEnable()
    {
        actions.Enable();
    }
    private void OnDisable()
    {
        actions.Disable();
    }
}
