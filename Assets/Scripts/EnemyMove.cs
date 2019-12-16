using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float speed;
    public float XRight;
    public float XLeft;
    string[] texts = new string[] { "right", "left" };
    public string direction;
    private int downcounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        direction = texts[Random.Range(0, texts.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        if (direction == "right")
        {
            //kalo spaceship lewat pinggir kanan layar
            if (transform.position.x >= XRight)
            {
                Vector2 pos = new Vector2(transform.position.x, transform.position.y);
                transform.position = pos;
                transform.Translate(Vector2.down * speed * Time.deltaTime);
                downcounter++;
                if (downcounter == 10)
                {
                    direction = "left";
                    downcounter = 0;
                }

            }
            else
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime);
            }
        }
        else
        {
            //kalo spaceship lewat pinggir kiri layar
            if (transform.position.x <= XLeft)
            {
                Vector2 pos = new Vector2(transform.position.x, transform.position.y);
                transform.position = pos;
                transform.Translate(Vector2.down * speed * Time.deltaTime);
                downcounter++;
                if (downcounter == 10)
                {
                    direction = "right";
                    downcounter = 0;
                }
            }
            else
            {
                transform.Translate(Vector2.left * speed * Time.deltaTime);
            }
        }

        var posOnScreen = Camera.main.WorldToViewportPoint(transform.position);

        if ((posOnScreen.x <= -1) || (posOnScreen.x >= 1.1))
            Destroy(this.gameObject);

        if ((posOnScreen.y <= -0.1) || (posOnScreen.y >= 1.1))
            Destroy(this.gameObject);
    }
}
