using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public Animator animator;

    public Transform attackPoint;
    public LayerMask enemyLayers;

    public float attackRange = 0.5f;
    public int attackDamage = 5;

    public bool isAttacking = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(isAttacking == true) return;
            Debug.Log("Attack");
            Attack();
        }
    }
    void Attack()
    {
        Debug.Log("Attack run");
        //Play an attack animation
        animator.SetTrigger("Attack1");

        //Detect enemies in range
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        //Damage enemy
        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit" + enemy.name);
            enemy.GetComponent<EnemyHP>().TakeDamage(attackDamage);
        }

    }

void OnDrawGizmosSelected()
{
    if(attackPoint == null)
        return;

    Gizmos.DrawWireSphere(attackPoint.position, attackRange);
}
}
