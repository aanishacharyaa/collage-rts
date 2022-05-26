using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;
using System;

public class moveViewPort : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public RectTransform dragObject;
    private bool draging = false;

    /// <summary>
    /// The area in which we are able to move the dragObject around.
    /// if null: canvas is used
    /// </summary>
    public RectTransform dragArea ;

    private Vector2 originalLocalPointerPosition;
    private Vector3 originalPanelLocalPosition;


    private void Update()
    {
        if (draging)
        {
            // Camera.main.transform.position.Set(dragObject.position.x, 0, dragObject.position.y);
            
            Camera.main.transform.position = Map.Current.MapPositionToWorld(new Vector2(dragObject.position.x,dragObject.position.y));

            
            

            //Camera.main.transform.Translate(Map.Current.MapPositionToWorld(new Vector3(dragObject.position.x,-65, dragObject.position.y)));
        }
    }


    private RectTransform dragObjectInternal
    {
        get
        {
            if (dragObject == null)
                return (transform as RectTransform);
            else
                return dragObject;
        }
    }

    private RectTransform dragAreaInternal
    {
        get
        {
            if (dragArea == null)
            {
                RectTransform canvas = transform as RectTransform;
                while (canvas.parent != null && canvas.parent is RectTransform)
                {
                    canvas = canvas.parent as RectTransform;
                }
                return canvas;
            }
            else
                return dragArea;
        }
    }

    public void OnBeginDrag(PointerEventData data)
    {
        originalPanelLocalPosition = dragObjectInternal.localPosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(dragAreaInternal, data.position, data.pressEventCamera, out originalLocalPointerPosition);

       
    }

    public void OnDrag(PointerEventData data)
    {

        Vector2 localPointerPosition;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(dragAreaInternal, data.position, data.pressEventCamera, out localPointerPosition))
        {
            Vector3 offsetToOriginal = localPointerPosition - originalLocalPointerPosition;
            dragObjectInternal.localPosition = originalPanelLocalPosition + offsetToOriginal;
        }

        ClampToArea();

        draging = true;

        //Camera.main.transform.position =Map.Current.MapPositionToWorld(new Vector2(dragObject.position.x, dragObject.position.y));
    }

    // Clamp panel to dragArea
    private void ClampToArea()
    {
        Vector3 pos = dragObjectInternal.localPosition;

        Vector3 minPosition = dragAreaInternal.rect.min - dragObjectInternal.rect.min;
        Vector3 maxPosition = dragAreaInternal.rect.max - dragObjectInternal.rect.max;

        pos.x = Mathf.Clamp(dragObjectInternal.localPosition.x, minPosition.x, maxPosition.x);
        pos.y = Mathf.Clamp(dragObjectInternal.localPosition.y, minPosition.y, maxPosition.y);

        dragObjectInternal.localPosition = pos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        draging = false;
    }
}
