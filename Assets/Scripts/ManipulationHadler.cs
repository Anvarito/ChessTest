using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManipulationHadler : MonoBehaviour
{
    protected Touch _fingerOne = new Touch();
    protected Touch _fingerTwo = new Touch();

    void Update()
    {
        if (Input.touchCount == 2)
        {
            _fingerOne = Input.GetTouch(0);
            _fingerTwo = Input.GetTouch(1);

            if (_fingerOne.phase == TouchPhase.Began || _fingerTwo.phase == TouchPhase.Began)
            {
                FingersBegan();
            }

            if (_fingerOne.phase == TouchPhase.Moved || _fingerTwo.phase == TouchPhase.Moved)
            {
                FingersMoved();
            }
        }
    }
    protected virtual void FingersBegan()
    {

    }
    protected virtual void FingersMoved()
    {

    }
}
