using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxManager : MonoBehaviour
{
    BoxCollider2D hitbox;

    void Awake()
    {
        hitbox = GetComponentInChildren<BoxCollider2D>();


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {


        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<IDamageable>().TakeDamage(10, 100, gameObject);


        }
    }


    public void ToogleHitbox()
    {
        hitbox.enabled = !hitbox.enabled;
    }

}
