using System.Collections;
using UnityEngine;

public class GoombaWalk : MonoBehaviour
{
    public float speed;
    public Vector2 Movement = (Vector2.right/100)*-1;

    void Update()
    {
        transform.Translate(Movement*speed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("!");
        Movement = new Vector2(Movement.x*-1, 0);
        transform.localScale = new Vector2(transform.localScale.x*-1, transform.localScale.y);
    }
}