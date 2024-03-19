using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Config")]
    [SerializeField]
    private float speed;
    private Vector2 moveDirection;

    private Player player;
    private PlayerAnimations playeranimations;
    private PlayerActions actions;
    private Rigidbody2D rd2d;

    private void Awake()
    {
        player = GetComponent<Player>();
        playeranimations = GetComponent<PlayerAnimations>();
        rd2d = GetComponent<Rigidbody2D>();
        actions = new PlayerActions();
    }

    private void Update()
    {
        ReadMovement();
    }
    private void FixedUpdate()
    {
        Move();
    }
    // Hareket Fonksiyonu
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
    private void OnEnable()
    {
        actions.Enable();
    }
    private void OnDisable()
    {
        actions.Disable();
    }
}
