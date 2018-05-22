using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AnalogController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
	RectTransform rectTrans;
	Vector2 StartTouchPos;
	public delegate void AnalogValueDel(Vector2 value);
	public AnalogValueDel AnalogValue;
	public delegate void OnAnalogReleasedDel(Vector2 value);
	public OnAnalogReleasedDel OnAnalogReleased;
	Camera camera;

	// Use this for initialization
	void Start () {
		rectTrans = GetComponent<RectTransform>();
		camera = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnBeginDrag(PointerEventData eventData)
    {
		StartTouchPos = eventData.position;
	}

	public void OnDrag(PointerEventData eventData)
    {
		rectTrans.anchoredPosition = eventData.position - StartTouchPos;
		if(Vector2.Distance(rectTrans.anchoredPosition, Vector2.zero) > 80){
			rectTrans.anchoredPosition = rectTrans.anchoredPosition.normalized * 80;
		}
		if(AnalogValue != null) AnalogValue(rectTrans.anchoredPosition.normalized);
	}

	public void OnEndDrag(PointerEventData eventData)
    {
		if(Vector2.Distance(rectTrans.anchoredPosition, Vector2.zero) > 50){
			if(OnAnalogReleased != null) OnAnalogReleased(rectTrans.anchoredPosition.normalized);
		}
		if(AnalogValue != null) AnalogValue(Vector2.zero);
		rectTrans.anchoredPosition = Vector2.zero;
	}
}
