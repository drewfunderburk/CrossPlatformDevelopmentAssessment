using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerBehaviour : MonoBehaviour
{
    public static List<LineRenderer> Lines = new List<LineRenderer>();
    [SerializeField] private float _baseScore = 1000;

    public float CalculateScore()
    {
        float totalDistance = 0;

        // Loop through each line renderer
        foreach (LineRenderer line in Lines)
        {
            // Loop through each point in the renderer
            for (int i = 1; i < line.positionCount; i++)
            {
                // Get the distance between the current and previous points
                float distance = Vector2.Distance(line.GetPosition(i), line.GetPosition(i - 1));

                // Add it to totalDistance
                totalDistance += distance;
            }
        }

        // Score should decrease with longer lines, so we will subtract totalDistance from baseScore to come up with our final score
        return _baseScore - totalDistance;
    }
}
