using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    static public List<GameObject> enemyList = new List<GameObject>();

    public float speed;
    public float stoppingDistance;
    public float neighborRadius;
    public Transform target;
    private Vector3 moveVector;
    private SpriteRenderer spriteRenderer;
    private float timeSinceBoidCalc;
    private Boids boidScript;
    // Start is called before the first frame update
    void Start()
    {
        enemyList.Add(this.gameObject);
        timeSinceBoidCalc = 0f;
        spriteRenderer = GetComponent<SpriteRenderer>();
        boidScript = GetComponent<Boids>();
        moveVector = boidScript.CalculateBoid(enemyList, FetchNeighbors(), target).normalized;

    }

    // Update is called once per frame
    void Update()
    {
        if(timeSinceBoidCalc > .2f)
        {
            timeSinceBoidCalc = 0f;
            moveVector = boidScript.CalculateBoid(enemyList, FetchNeighbors(), target).normalized;
        }
        else
        {
            timeSinceBoidCalc = Time.deltaTime+timeSinceBoidCalc;
        }
        transform.position +=  moveVector* speed * Time.deltaTime;

    }
    private void OnDestroy()
    {
        enemyList.Remove(this.gameObject);
    }
    private List<GameObject> FetchNeighbors()
    {
        List<GameObject> neighborList= new List<GameObject>();
        Collider2D[] results;
        LayerMask mask = LayerMask.GetMask("Obstacles");
        results = Physics2D.OverlapCircleAll(transform.position, neighborRadius, mask);
        foreach (Collider2D result in results)
        {
            if(result.gameObject != this.gameObject)
                neighborList.Add(result.gameObject);
        }
        return neighborList;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
     //Use the same vars you use to draw your Overlap SPhere to draw your Wire Sphere.
        Gizmos.DrawWireSphere(transform.position, neighborRadius);
    }
}
