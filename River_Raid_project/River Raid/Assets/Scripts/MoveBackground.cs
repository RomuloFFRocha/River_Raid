using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    public float speed;
    [Range(0, 1)] public float fuelDecreaseMultiplier;

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        float y = Input.GetAxis("Vertical");

        if (y == 0)
        {
            y = 1;
        }
        else if (y > 0.05)
        {
            y = 2;
        }
        else if (y < -0.05)
        {
            y = 0.5f;
        }

        transform.Translate(new Vector3(0, -speed * y, 0) * Time.deltaTime);

        FindObjectOfType<PlayerController>().fuel -= y * fuelDecreaseMultiplier;
    }
}
