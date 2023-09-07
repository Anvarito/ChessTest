using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotating : ManipulationHadler
{
    protected override void FingersMoved()
    {
        base.FingersMoved();
        HandleRotation();
    }

    private void HandleRotation()
    {
        var prevPos1 = _fingerOne.position - _fingerOne.deltaPosition;
        var prevPos2 = _fingerTwo.position - _fingerTwo.deltaPosition;

        var prevDir = prevPos2 - prevPos1;
        var currDir = _fingerTwo.position - _fingerOne.position;

        var angle = Vector2.SignedAngle(prevDir, currDir);

        transform.Rotate(0, 0, angle);
    }

}

