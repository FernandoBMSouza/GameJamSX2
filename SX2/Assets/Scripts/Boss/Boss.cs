using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    [SerializeField]private Animator anim;
    private GameObject tree;

    

    private void Awake()
    {
        tree = GameObject.FindWithTag("Arvore");
        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        speed = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        Go2Tree();
        if (distance <= 4f)
        {
            speed = 0f;
        }

        if (hp == 0)
        {
            BossDeath();
        }

    }

    public void Go2Tree()
    {
        distance = Vector2.Distance(transform.position, tree.transform.position);
        Vector2 direction = tree.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.position = Vector2.MoveTowards(this.transform.position, tree.transform.position, speed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(Vector3.forward * angle);
    }

    private void AttackTree()
    {

    }

    void BossDeath()
    {

    }
}
