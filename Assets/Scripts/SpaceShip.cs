using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    public float speed;
    public float XRight;
    public float XLeft;
    public string direction = "right";
    
    //for shot
    public Bullet bulletPrefab;
    private float bulletSpeed = 25.0f;
    private float angle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //gerak terus
        if (direction == "right")
        {
            //kalo spaceship lewat pinggir kanan layar
            if (transform.position.x >= XRight)
            {
                Vector2 pos = new Vector2(XLeft, transform.position.y);
                transform.position = pos;
                transform.Translate(Vector2.right * speed * Time.deltaTime);
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
                Vector2 pos = new Vector2(XRight, transform.position.y);
                transform.position = pos;
                transform.Translate(Vector2.left * speed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector2.left * speed * Time.deltaTime);
            }
        }
        

        //kalo pencet tombol
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            SwitchAndShoot();
        }

    }

    // Switch and Shoot
    void SwitchAndShoot()
    {
        if(direction == "right")
        {
            direction = "left";
            var bullet = Instantiate(bulletPrefab);
            bullet.Shoot(transform.position, bulletSpeed);
        }
        else
        {
            direction = "right";
            var bullet = Instantiate(bulletPrefab);
            bullet.Shoot(transform.position, bulletSpeed);
        }
    }
}
