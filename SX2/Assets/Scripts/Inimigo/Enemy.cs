using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]private Animator anim;
    public SpriteRenderer sprite;


    [HideInInspector]
    public float hp;

    [HideInInspector]
    public float speed;

    private GameObject tree;

    [HideInInspector]
    public float distance;

    [SerializeField] private Transform shootPoint;

    void Awake()
    {
        tree = GameObject.FindWithTag("Arvore");
        anim = this.GetComponent<Animator>();
    }

    void Start()
    {
        this.speed = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        GoToTree();

        if (distance <= 1)
        {
            speed = 0f;
        }  

        if (hp == 0)
        {
            EnemyDead();
        }
    }


    public void GoToTree()
    {
        distance = Vector2.Distance(transform.position, tree.transform.position);
        Vector2 direction = tree.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.position = Vector2.MoveTowards(this.transform.position, tree.transform.position, speed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(Vector3.forward * angle);
    }

    public void EnemyDead()
    {

    }
}
