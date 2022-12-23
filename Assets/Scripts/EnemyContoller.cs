using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyContoller : MonoBehaviour
{
    public float speed;
    Rigidbody2D rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 position = rigidbody2D.position;
        position.x = position.x + Time.deltaTime * speed;

        rigidbody2D.MovePosition(position);
    }
}
