using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Dragable : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private CanvasGroup _canvasGroup;
    public UnityAction<Dragable> OnDragFigure;
    private Cell _selfCell;
    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.pointerId > 0)
            return;

        OnDragFigure?.Invoke(this);
        gameObject.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _canvasGroup.blocksRaycasts = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        transform.SetAsLastSibling();
        _canvasGroup.blocksRaycasts = false;
    }

    internal void ClearSelfCell()
    {
        if (_selfCell != null)
            _selfCell.CLearFigure();

        _selfCell = null;
    }

    public void SetCell(Cell cell)
    {
        _selfCell = cell;
        gameObject.transform.position = cell.transform.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _canvasGroup.blocksRaycasts = true;
    }
}
