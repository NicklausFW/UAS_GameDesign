using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float speed = 3;
    public float XRight = 3;
    public float XLeft = -3;
    public string direction = "right";
    private int downcounter = 0;
    public Vector2 baru;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = baru;
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
                if (downcounter == 5)
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
                if (downcounter == 5)
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

        if ((posOnScreen.y <= -1) || (posOnScreen.y >= 1.1))
            Destroy(this.gameObject);
    }
}
