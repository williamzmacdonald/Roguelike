using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;

    private Transform target;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, target.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        if(transform.position.x - target.position.x <0)
        {
            transform.localScale = new Vector3(-.15f, .15f, 1);
        }
        else
        {
            transform.localScale = new Vector3(.15f, .15f, 1);
        }
    }
    private void FetchObstacles()
    {
        foreach(Enemy e in Enemy.enemyByType[enemyType])
        {

        }
    }
}
