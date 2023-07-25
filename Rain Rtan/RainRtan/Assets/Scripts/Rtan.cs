using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rtan : MonoBehaviour
{
    public float speed = 0.1f;
    float direction = 1;
    float toward = 1.0f;
    void Start()
    {

    }

    void Update()
    {


        if (Input.GetMouseButtonDown(0))
        {
            direction *= -1;
            toward *= -1;
        }

        if (transform.position.x > Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, transform.position.y, 0)).x)
        {
            direction = -1;
            toward = -1.0f;
        }

        if (transform.position.x < -Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, transform.position.y, 0)).x)
        {
            direction = 1;
            toward = 1.0f;
        }

        transform.localScale = new Vector3(toward, 1, 1);

    }

    private void FixedUpdate()
    {
        transform.position += new Vector3(direction * speed, 0, 0);
    }
}
