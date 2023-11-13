using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public Animator animator;

    public int EnemymaxHP = 100;
    int EnemycurrentHP;
    // Start is called before the first frame update
    void Start()
    {
        EnemycurrentHP = EnemymaxHP;
    }

    public void TakeDamage(int damage)
    {
        EnemycurrentHP -= damage;

        //Play hurt animation
        animator.SetTrigger("Hurt");

        if(EnemycurrentHP <= 0)
        {
            Die();
        }

    }

    void Die()
    {
        Debug.Log("Enemy died!");

        //Die animation
        animator.SetBool("IsDead", true);

        //Disable the enemy
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;

    }

}
