using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawnerBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject _ballPrefab;
    [Space]
    [SerializeField] private float _ballLifetime = 10;
    [SerializeField] private float _spawnDelay = 1;
    [SerializeField] private Vector2 _initialVelocity = new Vector2();

    private float _spawnTimer;

    private void Start()
    {
        _spawnTimer = _spawnDelay;
    }

    private void Update()
    {
        // Increase timer
        _spawnTimer += Time.deltaTime;

        // If timer exceeds delay
        if (_spawnTimer > _spawnDelay)
        {
            // Reset the timer
            _spawnTimer = 0;

            // Spawn a ball
            GameObject ball = Instantiate(_ballPrefab);

            // Move it to our current position
            ball.transform.position = transform.position;

            // Set the initial velocity
            ball.GetComponent<Rigidbody2D>().velocity = _initialVelocity;

            // Destroy the ball after it's lifetime is expired
            Destroy(ball, _ballLifetime);
        }
    }
}
