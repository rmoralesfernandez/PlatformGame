using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallsMove : MonoBehaviour
{
    public float _speed = 30;
    public GameObject ball;
    public float time = 6;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        transform.Translate(Vector3.right * _speed * Time.deltaTime, Space.Self);

        if(time <= 0)
        {
            Destroy(ball);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.tag.Equals("Enemy"))
        {
            Destroy(collider2D.gameObject);
            Destroy(ball);
        }

        if (collider2D.tag.Equals("DestroyPU"))
        {
            Destroy(ball);
        }

        if(collider2D.tag.Equals("Finish"))
        {
            TakeItemManager.stars++;
            Destroy(collider2D.gameObject);
            Destroy(ball);
        }
    }
}
