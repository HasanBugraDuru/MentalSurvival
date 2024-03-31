using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour,IDamageable
{
    readonly UnitHealth enemyHealth = new(100, 100);
    Rigidbody2D rb;
    Animator animator;
    void Start()
    {
        // animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (enemyHealth.CurrentHealth == 0)
        {

            //animator.SetBool("Dead", true);
        }
    }

    public void TakeDamage(int x)
    {
        enemyHealth.DmgUnit(x);

    }
    public void TakeDamage(int dmg, int Knockback, GameObject damager)
    {
        
        enemyHealth.DmgUnit(dmg);
        Vector2 direction = (transform.position - damager.transform.position).normalized;
        rb.AddForce(direction * Knockback, ForceMode2D.Impulse);
        Debug.Log(enemyHealth.CurrentHealth);
    }

}
