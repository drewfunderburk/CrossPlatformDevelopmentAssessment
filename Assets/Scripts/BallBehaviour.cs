using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private float _gravityScale;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _gravityScale = _rigidbody.gravityScale;
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Line") && _rigidbody.velocity.y > 0)
    //        _rigidbody.gravityScale = 0;
    //}

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Line"))
    //        _rigidbody.gravityScale = _gravityScale;
    //}
}
