using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    [SerializeField] float amountReduced = 1;
    [SerializeField] bool sky = false;

    [SerializeField] Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            HitPlayer();
        }
    }
    void HitPlayer()
    {
        StaminaBar.instance.StaminaDown(amountReduced);
        
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
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            HitPlayer();
        }
    }
}
