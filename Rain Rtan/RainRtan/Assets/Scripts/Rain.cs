using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : MonoBehaviour
{
    float size;
    int type;
    int score;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ground"))
            Destroy(gameObject);

        if(other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance().AddScore(score);
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        float x = Random.Range(-2.7f, 2.7f);
        float y = Random.Range(3.0f, 5.0f);
        transform.position = new Vector3(x, y, 0);

        type = Random.Range(1, 5);

        switch (type)
        {
            case 1:
                size = 1.2f;
                score = 3;
                GetComponent<SpriteRenderer>().color = new Color(100 / 255f, 100 / 255f, 1, 1);
                break;

            case 2:
                size = 1.0f;
                score = 2;
                GetComponent<SpriteRenderer>().color = new Color(130 / 255f, 130 / 255f, 1, 1);
                break;
            case 3:
                size = 0.8f;
                score = 1;
                GetComponent<SpriteRenderer>().color = new Color(150 / 255f, 150 / 255f, 1, 1);
                break;

            case 4:
                size = 0.8f;
                score = -5;
                GetComponent<SpriteRenderer>().color = new Color(255 / 255f, 100.0f / 255f, 100.0f / 255f, 1);
                break;
        }

        transform.localScale = new Vector3(size, size, 0);

    }
}
