using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed;
    public Transform[] waypoints;
    public SpriteRenderer graphics;
    public Transform target;
    private int _destPoint = 0;
    
    void Start()
    {
        target = waypoints[0];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.position += dir.normalized * speed * Time.deltaTime;
        // If enemy is near to the dest target
        if (Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            _destPoint = (_destPoint + 1) % waypoints.Length;
            target = waypoints[_destPoint];
            graphics.flipX = !graphics.flipX;
        }
        
    }
}

