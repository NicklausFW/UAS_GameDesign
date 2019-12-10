using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float speed = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Shoot (Vector2 initialPos, float speed_)
    {
        speed = speed_;
        transform.position = new Vector2(initialPos.x, initialPos.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);

        var posOnScreen = Camera.main.WorldToViewportPoint(transform.position);

        if ((posOnScreen.x <= 0) || (posOnScreen.x >= 1))
            Destroy(this.gameObject);

        if ((posOnScreen.y <= 0) || (posOnScreen.y >= 1))
            Destroy(this.gameObject);
    }
}
