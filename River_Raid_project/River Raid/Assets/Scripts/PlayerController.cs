using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D myRigidbody;
    Animator myAnimator;

    public float horizontalSpeed;

    public float timerTiro;
    public GameObject tiro;
    public Transform muzzle;

    public Slider fuelSlider;
    public GameObject player;

    bool canShot = true;
    bool alive = true;

    [HideInInspector] public float fuel = 100;

    [Header("Efeitos Sonoros")]
    public AudioClip collisionSfx;
    public AudioClip fuelSfx;


    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }
    
    void Update()
    {
        MoveCharacter();
        Shoot();
        Fuel();
    }

    void MoveCharacter()
    {
        float x = Input.GetAxis("Horizontal");
        myRigidbody.velocity = new Vector2(x * horizontalSpeed, 0f);

        if (x == 0)
        {
            myAnimator.SetBool("Front", true);
        }
        else 
        {
            myAnimator.SetBool("Front", false);
            myAnimator.SetFloat("Side", x);
        }
    }

    void Shoot()
    {
        if (Input.GetButtonDown("Fire") && canShot)
        {
            Instantiate(tiro, muzzle.position, Quaternion.identity);
            StartCoroutine(DelayTiro());
        }

    }

    void Fuel()
    {
        fuelSlider.value = fuel;

        if (fuelSlider.value == fuelSlider.minValue)
        {
            DeathAnimation();
            AudioManager.PlaySFX(collisionSfx, 0.3f);
        }
    }

    void DeathAnimation()
    {
        if (alive)
        {
            myAnimator.SetTrigger("Dead");
            alive = false;
        }
    }

    void Death()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            AudioManager.PlaySFX(collisionSfx, 0.5f);
            DeathAnimation();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            AudioManager.PlaySFX(collisionSfx, 0.5f);
            DeathAnimation();
        }

        if (collision.CompareTag("Fuel"))
        {
            AudioManager.PlaySFX(fuelSfx, 0.5f);
            fuel = 100;
        }
    }

    IEnumerator DelayTiro()
    {
        canShot = false;
        yield return new WaitForSeconds(timerTiro);
        canShot = true;
    }
}
