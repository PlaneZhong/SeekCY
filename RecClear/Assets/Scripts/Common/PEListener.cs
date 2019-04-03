/****************************************************
    文件：PEListener.cs
    作者：Plane
    QQ ：1785275942
    日期：2018/09/20 13:11
    功能：UI事件监听插件
*****************************************************/
using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class PEListener : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler, IDragHandler {
    public Action<GameObject> onClick;
    public Action<PointerEventData> onClickDown;
    public Action<PointerEventData> onClickUp;
    public Action<PointerEventData> onDrag;

    public object args = null;

    public void OnPointerClick(PointerEventData eventData) {
        if (onClick != null) onClick(gameObject);
    }

    public void OnDrag(PointerEventData eventData) {
        if (onDrag != null) {
            onDrag(eventData);
        }
    }

    public void OnPointerDown(PointerEventData eventData) {
        if (onClickDown != null)
            onClickDown(eventData);
    }

    public void OnPointerUp(PointerEventData eventData) {
        if (onClickUp != null)
            onClickUp(eventData);
    }
}