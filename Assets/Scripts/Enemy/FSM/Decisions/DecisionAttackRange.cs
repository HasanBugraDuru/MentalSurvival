using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionAttackRange : FSMDecision
{

    [Header("Config")]
    [SerializeField] private float attackrange;

    [SerializeField] LayerMask playerMask;

    private EnemyBrain enemy;

    private void Awake()
    {
        enemy = GetComponent<EnemyBrain>();
    }
    public override bool Decide()
    {
        return CheckAttackRange();
    }

  
    private bool CheckAttackRange()
    {
        if (enemy.Player == null) return false;
        Collider2D playerCollider = Physics2D.OverlapCircle(enemy.transform.position, attackrange, playerMask);


        if (playerCollider != null)
        {
            enemy.Player = playerCollider.gameObject;
            Debug.Log(playerCollider.name+"In attack Range");
            return true;
        }
        else
            
        return false;

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attackrange);
    }


}
