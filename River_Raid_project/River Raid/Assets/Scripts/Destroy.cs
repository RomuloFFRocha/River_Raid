using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.CompareTag("Tiro")))
            animator.SetTrigger("Touched");

        if ((collision.CompareTag("Player")) || (collision.CompareTag("Tiro")))
            animator.SetTrigger("Fuel");
    }
}
