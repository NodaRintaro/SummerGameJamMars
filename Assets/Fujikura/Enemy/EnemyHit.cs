using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    [SerializeField] float amountReduced = 1;
    [SerializeField] bool sky = false;
    [SerializeField] ParticleSystem particle;

    [SerializeField] Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            HitPlayer();
        }
    }
    void HitPlayer()
    {
        StaminaBar.instance.StaminaDown(amountReduced);
        ParticleSystem Wing = Instantiate(particle);
        Wing.transform.position = this.transform.position;
        Destroy(Wing.gameObject,5.0f);
        
        if(sky)
        {
            rb.gravityScale = -100;
            Destroy(gameObject, 3f);

        }
        else
        {
            rb.gravityScale = 10;
            Destroy(gameObject, 3f);
        }
    }
}
