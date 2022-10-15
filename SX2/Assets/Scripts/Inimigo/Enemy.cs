using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected float health, moveSpeed, distance;
    protected GameObject tree;

    protected virtual void Awake()
    {
        tree = GameObject.FindWithTag("Tree");
    }

    protected virtual void Update()
    {
        GoToTree();

        if (distance <= 1)
        {
            moveSpeed = 0f;
        }

        if (health == 0)
        {
            Death();
        }
    }

    protected void GoToTree()
    {
        distance = Vector2.Distance(transform.position, tree.transform.position);
        Vector2 direction = tree.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.position = Vector2.MoveTowards(this.transform.position, tree.transform.position, moveSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(Vector3.forward * angle);
    }

    protected void Death()
    {
        Destroy(gameObject);
    }
}