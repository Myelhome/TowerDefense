using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;
    public int health = 10;

    private Transform target;
    private int waypointIndex = 0;
    private bool dead = false;

    private void Start()
    {
        target = Waypoints.points[0];
    }

    private void Update()
    {
        Vector3 movement = target.position - transform.position;
        transform.Translate(movement.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.3f)
        {
            GetNextWaypoint();
        } 
    }

    private void GetNextWaypoint()
    {
        if (dead) return;
        if (waypointIndex >= Waypoints.points.Length - 1)
        {
            Hit();
        }
        else
        {
            waypointIndex++;
            target = Waypoints.points[waypointIndex];
        }
    }

    public void TakeDamage(int ammount)
    {
        health -= ammount;

        if (health <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        Player.money++;
        Destruction();
    }

    private void Hit()
    {
        Player.lives--;
        if (Player.lives <= 0)
        {
            ChangeScenes.GameLost();
        }
        Destruction();
    }

    private void Destruction()
    {
        WaveSpawn.enemiesAmount--;
        dead = true;
        if(Player.lives > 0 && WaveSpawn.enemiesAmount <= 0)
        {
            ChangeScenes.GameWon();
        }
        GetComponent<Animation>().Play("EnemyDeath");
    }

    public void DestroyAfterAnimation()
    {
        Destroy(gameObject);
    }

}

