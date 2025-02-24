using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    private Rigidbody2D _rb;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    public void Move( Vector2 direction)
    {
        _rb.velocity = new Vector2(direction.x * 5, direction.y);
    }
    public void Death()
    {
        Destroy(gameObject);
    }
}
