using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegacyInputListener : MonoBehaviour
{
    private PlayerController _controller;

    public void Construct(PlayerController controller)
    {
        _controller = controller;
    }

    private void Update()
    {
        if (_controller != null)
        {
            float horizontal;
            horizontal = Input.GetAxis("Horizontal");
            float vertical;
            vertical = Input.GetAxis("Vertical");
            if (vertical == 0)
            {
                Vector2 vec = new Vector2(horizontal,0);
                _controller.Move(vec);
            }

            else if (horizontal == 0)
            { 
                Vector2 vec = new Vector2 (0,vertical);
                _controller.Move(vec);
            }
        }
    }
}
