using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchInput : MonoBehaviour, ITouch
{
    Vector2 startTouch, swipeDelta;
    bool swipeLeft, swipeRight, isDragging;
    public bool IsDragging { get { return isDragging; } }
    public bool SwipeRight { get { return swipeLeft; } }
    public bool SwipeLeft { get { return swipeRight; } }

    private void Update()
    {
        Swipe();
    }

    private void Swipe()
    {
        swipeLeft = swipeRight = false;
        if (Input.touches.Length > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                isDragging = true;
                startTouch = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                Reset();
            }
        }

        swipeDelta = Vector2.zero;

        if (isDragging)
        {
            if (Input.touches.Length > 0)
                swipeDelta = startTouch - Input.touches[0].position;
        }

        if (swipeDelta.magnitude > 125)
        {
            if (swipeDelta.x > 0)
                swipeRight = true;

            if (swipeDelta.x < 0)
                swipeLeft = true;
        }
    }

    private void Reset()
    {
        isDragging = false;
        startTouch = swipeDelta = Vector2.zero;
    }
}
