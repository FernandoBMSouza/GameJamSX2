using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private GameObject target;
    [SerializeField] private float force;
    [SerializeField] private float damage;
    private Vector2 moveDirection;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if(GameObject.FindGameObjectWithTag("Player"))
        {
            target = GameObject.FindGameObjectWithTag("Player");
            moveDirection = (target.transform.position - transform.position).normalized * force;
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
            //Destroy(gameObject, 3);
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerHealth>(out PlayerHealth playerComponent))
        {
            playerComponent.TakeDamage(damage);
            Destroy(gameObject);
        }
        else if (collision.tag == "Tree")
        {
            //Does nothing
        }
        else if(collision.tag == "Enemy")
        {
            //Does nothing
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
