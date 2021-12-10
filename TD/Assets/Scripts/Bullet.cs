using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 40f;
    public int bulletDamage = 2;

    public Transform target;


    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
                return;
        }

        Vector3 dir = target.position - transform.position;
        float distance = speed * Time.deltaTime;

        if(dir.magnitude <= distance)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distance, Space.World);

    }

    public void SetTarget(Transform targetBuff)
    {
        target = targetBuff;
    }

    private void HitTarget()
    {
        Damage(target);
        Destroy(gameObject);
    }

    private void Damage(Transform enemy)
    {
        Enemy enemyBuffer = enemy.GetComponent<Enemy>();
        enemyBuffer.TakeDamage(bulletDamage);
    }
}
