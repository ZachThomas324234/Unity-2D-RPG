using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    public int UsermaxHP = 100;
    int UsercurrentHP;
    // Start is called before the first frame update
    void Start()
    {
        UsercurrentHP = UsermaxHP;
    }

    public void TakeDamage(int damage)
    {
        UsercurrentHP -= damage;

        //Play hurt animation

        if(UsercurrentHP <= 0)
        {
            Die();
        }

    }

    void Die()
    {
        Debug.Log("You died!");

        //Die animation

        //Disable the enemy

    }
}