using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawnerBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject _wallPrefab;
    [SerializeField] private float _numberOfWallsToSpawn = 5;
    [SerializeField] private float _verticalPadding = 2;
    [SerializeField] private float _horizontalPadding = 0;
    [SerializeField] private float _rotationLimit = 45;

    private List<GameObject> _walls = new List<GameObject>();

    private void Start()
    {
        // Get the screen's aspect ratio.
        float aspectRatio = (float)Screen.width / Screen.height;

        // When the camera is orthographic, the screen height in Unity units will be double the orthographic size
        float orthoWorldHeight = Camera.main.orthographicSize * 2;
        float orthoWorldWidth = orthoWorldHeight * aspectRatio;

        while (_walls.Count < _numberOfWallsToSpawn)
        {
            // Get a random x and y position with padding
            float xPos = Random.Range(-(orthoWorldWidth) + _horizontalPadding, (orthoWorldWidth) - _horizontalPadding);
            float yPos = Random.Range(-(orthoWorldHeight / 2) + _verticalPadding, (orthoWorldHeight / 2) - _verticalPadding);
            Vector2 pos = new Vector2(xPos, yPos);

            // TODO: Check if wall would overlap with another before placing

            // Get a random rotation based on _rotationLimit
            float rotation = Random.Range(-_rotationLimit, _rotationLimit);

            // Make a new wall
            GameObject wall = Instantiate(_wallPrefab);
            wall.transform.position = pos;
            wall.transform.eulerAngles = new Vector3(0, 0, rotation + 90);
        }
    }
}
