using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawBehaviour : MonoBehaviour
{
    [SerializeField] private Material _material;
    [SerializeField] private Color _colorWhileDrawing;
    [SerializeField] private Color _colorWhenFinished;
    [Space]
    [SerializeField] private float _lineWidth = 0.1f;

    [Tooltip("Distance to use when simplifying the line. A lower value will result in a more detailed line.")]
    [SerializeField] private float _distanceBetweenPoints = 0.1f;

    private LineRenderer _lineRenderer;
    private EdgeCollider2D _edgeCollider;

    private GameObject _start;
    private Vector2 _lastMousePosition = new Vector2();
    private Vector2 _startMousePosition = new Vector2();

    private void Update()
    {
        // Get the mouse position in world space
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        DrawLine(mousePosition);
        DeleteLinesInArea(mousePosition);
    }

    private void DeleteLinesInArea(Vector2 mousePosition)
    {
        // When right mouse is pressed
        if (Input.GetMouseButtonDown(1))
        {
            // Set the start position to the current mouse position
            _startMousePosition = mousePosition;
        }
        // When right mouse is released
        else if (Input.GetMouseButtonUp(1))
        {
            // Collect all colliders within the square drawn
            Collider2D[] colliders = Physics2D.OverlapAreaAll(_startMousePosition, mousePosition);
            foreach (Collider2D collider in colliders)
            {
                // Destroy those gameobjects
                Destroy(collider.gameObject);
            }
        }
    }

    private void DrawLine(Vector2 mousePosition)
    {
        // When left mouse is clicked
        if (Input.GetMouseButtonDown(0))
        {
            // Update _lastMousePosition
            _lastMousePosition = mousePosition;

            // Make _start a new game object and move it to mousePosition
            _start = new GameObject();
            _start.transform.position = mousePosition;
            _start.tag = "Line";

            // Add a LineRenderer to _start and initialize it
            _lineRenderer = _start.AddComponent<LineRenderer>();
            if (_material)
            {
                _lineRenderer.material = _material;
                _lineRenderer.material.color = _colorWhileDrawing;
            }
            _lineRenderer.startWidth = _lineWidth;
            _lineRenderer.endWidth = _lineWidth;
            _lineRenderer.SetPosition(0, mousePosition);
            _lineRenderer.SetPosition(1, mousePosition);
        }
        // While left mouse is held
        else if (Input.GetMouseButton(0))
        {
            // If the mouse has move more than _distanceBetweenPoints, add a new point
            if (Vector3.Distance(_lastMousePosition, mousePosition) > 0)
            {
                // Increase the line renderer's position count
                _lineRenderer.positionCount++;

                // Set the position of the new point to mousePosition
                _lineRenderer.SetPosition(_lineRenderer.positionCount - 1, mousePosition);
            }
        }
        // When left mouse is released
        else if (Input.GetMouseButtonUp(0))
        {
            // Set the line renderer's color
            _lineRenderer.material.color = _colorWhenFinished;

            // Simplify the line renderer to reduce the number of points based on the given distance
            _lineRenderer.Simplify(_distanceBetweenPoints);

            // Add line renderer to the list for score calculation
            GameManagerBehaviour.Lines.Add(_lineRenderer);

            // Add an EdgeCollider2D to _start and initialize it
            _edgeCollider = _start.AddComponent<EdgeCollider2D>();
            _edgeCollider.offset = -_start.transform.position;
            _edgeCollider.edgeRadius = _lineWidth / 2;
            _edgeCollider.points = new Vector2[] { _startMousePosition, _startMousePosition };

            // Create an array to store the line renderer's points
            Vector2[] currentPoints = new Vector2[_lineRenderer.positionCount];
            for (int i = 0; i < _lineRenderer.positionCount; i++)
            {
                currentPoints[i] = _lineRenderer.GetPosition(i);
            }

            // Update the edge collider to match the line renderer
            _edgeCollider.points = currentPoints;
        }
    }
}
