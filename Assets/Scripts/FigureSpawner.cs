using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FigureSpawner : MonoBehaviour
{

    [SerializeField] private FieldCreator _filedFill;
    [SerializeField] private Dragable _figurePrefab;
    [SerializeField] private Transform _fieldTransform;
    public List<Dragable> Figures { get; private set; }
    public UnityAction OnCompleteSpawn;

    private GameObject _parentToSpawnFigures;
    private void Awake()
    {
        _filedFill.OnComplete += StartSpawn;
    }

    private void StartSpawn()
    {
        Figures = new List<Dragable>();

        _parentToSpawnFigures = new GameObject("Figures");
        _parentToSpawnFigures.transform.parent = _fieldTransform;
        _parentToSpawnFigures.transform.SetAsLastSibling();

        foreach (var i in _filedFill.Cells)
        {
            if (UnityEngine.Random.Range(0, 11) > 9)
            {
                Dragable dragable = Instantiate(_figurePrefab, i.transform.position, Quaternion.identity, _parentToSpawnFigures.transform);
                Figures.Add(dragable);
                i.SetDragable(dragable);
                dragable.SetCell(i);
            }
        }

        OnCompleteSpawn?.Invoke();
    }
}
