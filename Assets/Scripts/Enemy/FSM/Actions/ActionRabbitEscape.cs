using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionRabbitEscape : FSMAction
{

    EnemyBrain enemy;
    
    [SerializeField] float holeRange;
    [SerializeField] float runSpeed;
    [SerializeField] LayerMask rabbitHole;
    Collider2D[] rbHoles;
    [SerializeField] Transform targetHole;

    public override void Act()
    {
        FindRabbitHoles();
        if (targetHole != null)
        {
            GoToRabbitHole();

        }
        else RunAway();
    }
    private void Start()
    {
        enemy = GetComponent<EnemyBrain>();
    }
    private void FindRabbitHoles()
    {
        rbHoles = Physics2D.OverlapCircleAll(enemy.transform.position, holeRange, rabbitHole);
        if (targetHole == null)
        {
            targetHole = rbHoles[Random.Range(0, rbHoles.Length)].transform;

        }

    }
    private void GoToRabbitHole()
    {
        if (targetHole == null) return;
        Vector3 dirToTarget = targetHole.transform.position - transform.position;
        if (dirToTarget.magnitude > 0.2)
        {
            transform.Translate(dirToTarget.normalized * (runSpeed * Time.deltaTime));
        }

    }
    private void RunAway() {

        if (enemy.Player == null) return;
        Vector3 dirToPlayer = enemy.Player.transform.position - transform.position;
        if (dirToPlayer.magnitude > 1.3)
        {
            transform.Translate(-dirToPlayer.normalized * (runSpeed * Time.deltaTime));
        }


    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, holeRange);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            gameObject.SetActive(false);
        }
    }
}

