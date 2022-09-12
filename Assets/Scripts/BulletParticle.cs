using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletParticle : MonoBehaviour
{
    ParticleSystem particleSystem;

    private void Start()
    {
        particleSystem = gameObject.GetComponent<ParticleSystem>();
        Debug.Log(particleSystem.transform.name);
    }
    private void OnParticleCollision(GameObject other)
    {
        if (other.GetComponent<EnemyBehaviorScript>() != null)
        {
            other.GetComponent<EnemyBehaviorScript>().TakeHit();
            Debug.Log("EnemyHit");
        }
        Debug.Log("Hit");
    }
}
