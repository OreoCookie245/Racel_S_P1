using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 5f;

    public int damage = 10;

    private void Start()
    {
        Destroy(gameObject, lifetime); //destroy after 5 sec
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Apply damage
            PlayerHealth enemyHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
            }
        }

        Destroy(gameObject); //destroy on hit
    }

    private void FixedUpdate()
    {
        //Movement
        transform.position += transform.forward * speed * Time.fixedDeltaTime;
    }
}
