using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Cell : MonoBehaviour, IDropHandler
{
    [SerializeField] private Dragable _dragablePrefab;
    private Dragable _dragable;
    public UnityAction<Cell> OnDropFigure;
    public void OnDrop(PointerEventData eventData)
    {
        OnDropFigure?.Invoke(this);
    }

    internal void Initing()
    {
        int instantiateChance = Random.Range(0, 11);
        if (instantiateChance > 9)
        {
            _dragable = Instantiate(_dragablePrefab, transform);
        }
    }

    internal void SetDragable(Dragable dragable)
    {
        _dragable = dragable;
    }

    public bool HasFigure()
    {
        return _dragable != null;
    }

    internal void CLearFigure()
    {
        _dragable = null;
    }
}
