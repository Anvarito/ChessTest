using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TouchIndicatorManager : MonoBehaviour
{
    public Image touchIndicatorPrefab;

    private void Update()
    {
        // ��������� �������
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                // ������� ���������� �������
                CreateTouchIndicator(touch.fingerId, touch.position);
            }
            else if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            {
                // ��������� ������� ������������ ���������� �������
                UpdateTouchIndicatorPosition(touch.fingerId, touch.position);
            }
            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                // ���������� ���������� ������� ��� ���������� �������
                DestroyTouchIndicator(touch.fingerId);
            }
        }
    }

    // ������� ���������� ������� ��� ���������� ������
    private void CreateTouchIndicator(int fingerId, Vector2 position)
    {
        Image touchIndicator = Instantiate(touchIndicatorPrefab, transform);
        touchIndicator.rectTransform.position = position;
        touchIndicator.name = "TouchIndicator" + fingerId;
    }

    // ��������� ������� ���������� ������� ��� ���������� ������
    private void UpdateTouchIndicatorPosition(int fingerId, Vector2 position)
    {
        Image touchIndicator = transform.Find("TouchIndicator" + fingerId)?.GetComponent<Image>();
        if (touchIndicator != null)
        {
            touchIndicator.rectTransform.position = position;
        }
    }

    // ���������� ���������� ������� ��� ���������� ������
    private void DestroyTouchIndicator(int fingerId)
    {
        Image touchIndicator = transform.Find("TouchIndicator" + fingerId)?.GetComponent<Image>();
        if (touchIndicator != null)
        {
            Destroy(touchIndicator.gameObject);
        }
    }
}