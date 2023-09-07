using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class FieldCreator : MonoBehaviour
{
    [SerializeField] private Cell _whiteSquare;
    [SerializeField] private Cell _blackSquare;
    [SerializeField] private Transform _parent;
    [SerializeField] private GridLayoutGroup _gridLayout;
    public List<Cell> Cells { get; private set; }

    public UnityAction OnComplete;
    private void Start()
    {
        Cells = new List<Cell>();
        Fill();
    }
    private void Fill()
    {
        var currentFirst = _whiteSquare;
        var currentSecond = _blackSquare;

        bool swap = false;
        for (int i = 0; i < 64; i++)
        {
            if (i % 8 == 0)
            {
                swap = !swap;
                currentFirst = swap ? _whiteSquare : _blackSquare;
                currentSecond = swap ? _blackSquare : _whiteSquare;
            }

            if (i % 2 == 0)
                Cells.Add(Instantiate(currentFirst, _parent));
            else
                Cells.Add(Instantiate(currentSecond, _parent));
        }

        StartCoroutine(DisableGridComponent());
    }

    private IEnumerator DisableGridComponent()
    {
        yield return null;
        _gridLayout.enabled = false;
        OnComplete?.Invoke();
    }
}
