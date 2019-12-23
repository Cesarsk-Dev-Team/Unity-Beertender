using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomSlider : MonoBehaviour
{
    //Public variables
    public float dragSpeed = 1f;
    public GameObject area;
    public GameObject dummy;

    //Private Variables
    private Vector3 lastMousePos;
    private float width;
    private float minValue, maxValue;

    //Methods
    private void Start()
    {
        RectTransform rt = (RectTransform)area.transform;
        width = rt.rect.width;
        maxValue = width / 2;
        minValue = -(width / 2);
        //DebugLog();
    }
    private void DebugLog()
    {
        Debug.Log("width: " + width);
        Debug.Log("scale: " + transform.parent.parent.localScale.x);
        Debug.Log("minValue: " + minValue);
        Debug.Log("maxValue: " + maxValue);
    }
    public void OnMouseDown()
    {
        lastMousePos = Input.mousePosition;
    }
    public void OnMouseDrag()
    {
        if (!RailManager.isBusy)
        {
            SlideObject(1f);
        }
        else
        {
            SlideObject(10f);
        }
    }
    private void SlideObject(float slideFactor)
    {
        //slideFactor: the higher it is the less it slides
        Vector3 delta = Input.mousePosition - lastMousePos;
        Vector3 pos = transform.localPosition;
        pos.x += delta.x * dragSpeed;
        pos.x = Mathf.Clamp(pos.x, minValue / slideFactor, maxValue / slideFactor);
        lastMousePos = Input.mousePosition;
        transform.localPosition = new Vector3(pos.x, pos.y);
        dummy.transform.position = new Vector3(transform.position.x, dummy.transform.position.y, 0);
    }
}
