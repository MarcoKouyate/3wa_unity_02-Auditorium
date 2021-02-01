using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepObjectWithinScreenBoundaries : MonoBehaviour
{
    private Vector2 screenBoundaries;
    private float objectWidth;
    private float objectHeight;

    private void Start()
    {
        screenBoundaries = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objectWidth = transform.localScale.x /2;
        objectHeight = transform.localScale.y /2;

        Debug.Log("Screen coordinates: (" + objectWidth + "," + objectHeight + ")");
    }

    private void LateUpdate()
    {
        Vector3 viewPosition = transform.position;
        viewPosition.x = Mathf.Clamp(viewPosition.x, screenBoundaries.x * -1 + objectWidth, screenBoundaries.x - objectWidth);
        viewPosition.y = Mathf.Clamp(viewPosition.y, screenBoundaries.y * -1 + objectHeight, screenBoundaries.y - objectHeight);
        Debug.Log("X coordinates: ( min: " + (screenBoundaries.x * -1 + objectWidth) + ", max: " + (screenBoundaries.x - objectWidth) + ")");
        transform.position = viewPosition;
    }
}
