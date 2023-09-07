using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TouchIndicatorManager : MonoBehaviour
{
    public Image touchIndicatorPrefab;

    private void Update()
    {
        // Проверяем касания
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                // Создаем визуальную отметку
                CreateTouchIndicator(touch.fingerId, touch.position);
            }
            else if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            {
                // Обновляем позицию существующей визуальной отметки
                UpdateTouchIndicatorPosition(touch.fingerId, touch.position);
            }
            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                // Уничтожаем визуальную отметку при завершении касания
                DestroyTouchIndicator(touch.fingerId);
            }
        }
    }

    // Создаем визуальную отметку для указанного пальца
    private void CreateTouchIndicator(int fingerId, Vector2 position)
    {
        Image touchIndicator = Instantiate(touchIndicatorPrefab, transform);
        touchIndicator.rectTransform.position = position;
        touchIndicator.name = "TouchIndicator" + fingerId;
    }

    // Обновляем позицию визуальной отметки для указанного пальца
    private void UpdateTouchIndicatorPosition(int fingerId, Vector2 position)
    {
        Image touchIndicator = transform.Find("TouchIndicator" + fingerId)?.GetComponent<Image>();
        if (touchIndicator != null)
        {
            touchIndicator.rectTransform.position = position;
        }
    }

    // Уничтожаем визуальную отметку для указанного пальца
    private void DestroyTouchIndicator(int fingerId)
    {
        Image touchIndicator = transform.Find("TouchIndicator" + fingerId)?.GetComponent<Image>();
        if (touchIndicator != null)
        {
            Destroy(touchIndicator.gameObject);
        }
    }
}