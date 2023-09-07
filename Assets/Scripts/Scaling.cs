using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaling : ManipulationHadler
{
    private float _initialDistance;
    private Vector2 _initialTouch1Position;
    private Vector2 _initialTouch2Position;

    protected override void FingersBegan()
    {
        base.FingersBegan();
        _initialTouch1Position = _fingerOne.position;
        _initialTouch2Position = _fingerTwo.position;
        _initialDistance = Vector2.Distance(_initialTouch1Position, _initialTouch2Position);
    }

    protected override void FingersMoved()
    {
        base.FingersMoved();
        HandleScalling();
    }

    private void HandleScalling()
    {
        float currentDistance = Vector2.Distance(_fingerOne.position, _fingerTwo.position);
        float scaleFactor = currentDistance / _initialDistance;

        Vector3 newScale = transform.localScale * scaleFactor;
        transform.localScale = newScale;

        _initialTouch1Position = _fingerOne.position;
        _initialTouch2Position = _fingerTwo.position;
        _initialDistance = currentDistance;
    }
}
