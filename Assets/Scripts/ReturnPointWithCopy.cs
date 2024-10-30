using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkAndReturnPoint : MonoBehaviour
{
    private Vector3 markedPoint;
    private bool pointMarked = false;
    private GameObject marker;

    // Public variables to configure the marker
    public GameObject markerPrefab;
    public Vector3 markerScale = new Vector3(0.5f, 0.5f, 0.5f); // Size of the marker

    void Update()
    {
        // Mark the point when pressing the F key
        if (Input.GetKeyDown(KeyCode.F))
        {
            MarkPoint();
        }

        // Return to the marked point when pressing the G key
        if (Input.GetKeyDown(KeyCode.G))
        {
            ReturnToPoint();
        }
    }

    void MarkPoint()
    {
        // Save the current position
        markedPoint = transform.position;
        pointMarked = true;

        // Create a marker cube at the marked position
        if (marker != null)
        {
            Destroy(marker);
        }
        marker = GameObject.CreatePrimitive(PrimitiveType.Cube);
        marker.transform.position = markedPoint;
        marker.transform.localScale = markerScale;

        Debug.Log("Point marked and marker cube created at: " + markedPoint);
    }

    void ReturnToPoint()
    {
        if (pointMarked)
        {
            // Move the player to the marked point
            transform.position = markedPoint;

            // Destroy the marker
            if (marker != null)
            {
                Destroy(marker);
            }

            Debug.Log("Returned to point and destroyed marker cube: " + markedPoint);
        }
        else
        {
            Debug.Log("No point marked yet.");
        }
    }
}