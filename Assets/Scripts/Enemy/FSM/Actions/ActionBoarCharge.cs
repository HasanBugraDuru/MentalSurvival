using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionBoarCharge : FSMAction
{
    [Header("Config")]
    [SerializeField] private float chargeSpeed;
    [SerializeField] private bool  trackingPlayer;

    [SerializeField] private bool  chargeEnded;
     
    public float chargeTimer;
    [SerializeField] private float chargeReq;


    [SerializeField] private float chargeLenght;
    [SerializeField] private float chargeLenghtTimer;

    Vector3 dirToPlayer;

    private EnemyBrain enemy;
    private DecisionStun stun;
    private DecisionAttackEnd attackEnd;
    private void Awake()
    {
        enemy = GetComponent<EnemyBrain>();
        stun = GetComponent<DecisionStun>();
        attackEnd = GetComponent<DecisionAttackEnd>();
    }
    public override void Act()
    {
        BoarCharge();
        
    }

    private void BoarCharge()
    {
        
        if (chargeTimer < chargeReq)
        {
            TrackPlayer();
            chargeTimer += Time.deltaTime;

            trackingPlayer = true;
            chargeEnded = false;
        }
        else if (chargeLenghtTimer < chargeLenght)
        {
            chargeLenghtTimer += Time.deltaTime;
            trackingPlayer = false;
            transform.Translate(dirToPlayer.normalized * (chargeSpeed * Time.deltaTime));
        }
        else
        {
            chargeEnded = true;
            Debug.Log("Charge End");
            chargeLenghtTimer = 0;
            chargeTimer = 0f;
        }

        attackEnd.attackEnded = chargeEnded;
    }
    private void TrackPlayer()
    {
      dirToPlayer = enemy.Player.transform.position - transform.position;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (trackingPlayer == false&&collision.gameObject==enemy.Player)
        {
            collision.gameObject.GetComponent<IDamageable>().TakeDamage(10);
        }
        if (collision.gameObject.CompareTag("Heavy"))
        {
            stun.isStunned = true;
        }
        Debug.Log(collision.collider.name + "Hit");
    }

}
