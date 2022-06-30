using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITouch
{
    public bool IsDragging { get; }
    public bool SwipeRight { get; }
    public bool SwipeLeft { get; }
}
