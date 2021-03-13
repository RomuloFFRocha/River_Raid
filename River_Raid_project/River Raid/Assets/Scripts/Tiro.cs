using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro : MonoBehaviour
{
    public float speed;
    public float lifetime;

    public AudioClip shotSfx;

    void Start()
    {
        StartCoroutine(TimeToDestroy());
        AudioManager.PlaySFX(shotSfx, 1f);
    }
    
    void FixedUpdate()
    {
        transform.Translate(new Vector3(0f, speed, 0f) * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject)
            Destroy(gameObject);
    }

    IEnumerator TimeToDestroy()
    {
        yield return new WaitForSeconds(lifetime);
        Destroy(gameObject);
    }
}
