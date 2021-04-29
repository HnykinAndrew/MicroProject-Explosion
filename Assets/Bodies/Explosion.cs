using UnityEngine;
using System.Collections;

// Applies an explosion force to all nearby rigidbodies
public class Explosion : MonoBehaviour
{
    public GameObject bomb;
    public float radius_0 = 0.1F;
    public float radius_step = 0.05F;
    public float power_0 = 1.0F;
    public float upforce = 0.0F;
    public float refresh_time = 0.01F;
    public float detonate_time = 1;

    public float radius = 0.0F;
    public float power = 1.0F;

    void Start()
    {
        radius = radius_0;
        power = power_0 / Mathf.Sqrt(radius);
        Invoke("Detonate", detonate_time);
    }



    void Detonate()
    {
        Vector3 explosionPosition = bomb.transform.position;

        Collider[] colliders = Physics.OverlapSphere(explosionPosition, radius);
        Collider[] colliders_x = Physics.OverlapSphere(explosionPosition, radius - radius_step);
        foreach (Collider hit in colliders)
        {
            bool ind = false;
            foreach (Collider hit_x in colliders_x)
            {
                if (hit_x == hit)
                {
                    ind = true;
                }
            }
            
            if (ind == false)
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();

                if (rb != null)
                    rb.AddExplosionForce(power, explosionPosition, 0, upforce, ForceMode.Impulse);
            }

        }
        radius = radius + radius_step;
        power = power_0 / Mathf.Sqrt(radius);
        Invoke("Detonate", refresh_time);
    }
    
}