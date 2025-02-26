using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerView : MonoBehaviour
{    
    [SerializeField] private int life;
    private Rigidbody2D _rb;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    //TODO сделать через новый Input 
    public void Move(Vector2 direction)
    {
        _rb.velocity = new Vector2(direction.x, direction.y) * 5;
    }

    public void ReduceLife()
    {
        life--;
        if (life == 0)
        {
            Death();
        }
    }

/*    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            ReduceLife();
            Debug.Log(life +"Хлоп");
        }
    }*/

    public void Death()
    {

        Destroy(gameObject);
    }
}
