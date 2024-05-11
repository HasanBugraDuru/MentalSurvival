using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionDetectPlayer : FSMDecision
// Start is called before the first frame update
{
    [Header("Config")]
    [SerializeField] private float range ;

    [SerializeField] LayerMask playerMask;

    private EnemyBrain enemy;

    private void Awake()
    {
        enemy = GetComponent<EnemyBrain>();
    }
    public override bool Decide()
    {
        return DetectPlayer();
    }

    private bool DetectPlayer()
    {
        Collider2D playerCollider = Physics2D.OverlapCircle(enemy.transform.position, range, playerMask);


        if (playerCollider != null)
        {
            enemy.Player = playerCollider.gameObject;
            Debug.Log("Player Detected");
            return true;
        }
        else
            enemy.Player = null;
        return false;

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

}
