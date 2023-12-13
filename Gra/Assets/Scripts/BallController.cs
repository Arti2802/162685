using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    private int colCount = 0;
    private string colTag = "Finish";
    public Rigidbody2D rb;
    public ScoreManager manager;
    private float delay = 2.0f;
    public bool grounding = true;
    public Text info;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void ChangePoints()
    {
        colCount = 0;
        if(grounding)
        {
            if (rb.position.x < -0.53f)
            {
                grounding = false;
                manager.points2++;
                manager.Change();
                StartCoroutine(MoveBallDelayed(new Vector2(7.96f, 2.82f)));
            }
            else
            {
                grounding = false;
                manager.points1++;
                manager.Change();
                StartCoroutine(MoveBallDelayed(new Vector2(-8.16f, 2.82f)));
            }
        }
    }

    IEnumerator MoveBallDelayed(Vector2 newPosition)
    {
        yield return new WaitForSeconds(delay);
        rb.position = newPosition;
        grounding = true;
        info.text = "";
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Player2"))
        {
            if(!collision.gameObject.CompareTag(colTag))
            {
                colTag = collision.gameObject.tag;
                colCount = 1;
            }
            else
            {
                colCount++;
            }
            if (colCount > 3)
            {
                Debug.Log("Faul!");
                info.text = "Faul!";
                ChangePoints();
            }
            Debug.Log(colCount);
        }
        if(collision.gameObject.CompareTag("Ground"))
        {
            float bounce = 24f;
            rb.AddForce(collision.contacts[0].normal * bounce);
            ChangePoints();
        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            float bounce = 42f;
            rb.AddForce(collision.contacts[0].normal * bounce);
        }
    }
}
