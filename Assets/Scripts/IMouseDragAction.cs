using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMouseDragAction
{
    void UpdateMousePosition(RaycastHit2D hit);
}
