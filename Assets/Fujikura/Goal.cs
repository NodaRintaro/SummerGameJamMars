using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] ParticleSystem fireWork;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("test");
        if (other.gameObject.CompareTag("Player"))
        {
            GoalIn();
        }
    }
    private void GoalIn()
    {
        fireWork.Play();
    }
}
