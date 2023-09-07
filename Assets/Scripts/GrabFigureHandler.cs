using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabFigureHandler : MonoBehaviour
{
    [SerializeField] private FieldCreator _fieldCreator;
    [SerializeField] private FigureSpawner _figureSpawner;
    private Dragable _currentFigure;
    private void Awake()
    {
        _figureSpawner.OnCompleteSpawn += CompleteSpawn;
    }

    private void CompleteSpawn()
    {
        foreach (var i in _fieldCreator.Cells)
        {
            i.OnDropFigure += DropFigure;
        }

        foreach (var i in _figureSpawner.Figures)
        {
            i.OnDragFigure += DragFigure;
        }
    }

    private void DropFigure(Cell cell)
    {
        if (!cell.HasFigure())
        {
            cell.SetDragable(_currentFigure);
            _currentFigure.SetCell(cell);
        }
    }

    private void DragFigure(Dragable figure)
    {
        _currentFigure = figure;
        figure.ClearSelfCell();
    }
}
