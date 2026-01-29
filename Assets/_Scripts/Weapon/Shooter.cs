using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject projectile1;
    public GameObject projectile2;

    public Transform shootPoint;

    void Update()
    {
        // Right Mouse Button (PC)
        if (Input.GetMouseButtonDown(1))
        {
            ShootRandomSphere();
        }

        // Right Trigger (Controller)
        if (Input.GetAxis("RightTrigger") > 0.1f)
        {
            ShootRandomSphere();
        }
    }

    void ShootRandomSphere()
    {
        GameObject prefabToShoot;

        // Randomly choose sphere
        if (Random.value < 0.5f)
        {
            prefabToShoot = projectile1;
        }
        else
        {
            prefabToShoot = projectile2;
        }

        GameObject projectile = Instantiate(prefabToShoot, shootPoint.position, shootPoint.rotation);

        // Set damage based on size
        Projectile projScript = projectile.GetComponent<Projectile>();
        if (projScript != null)
        {
            projScript.damage = (prefabToShoot == projectile2) ? 20 : 10;
        }
    }
}
