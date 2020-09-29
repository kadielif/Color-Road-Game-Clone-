using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class InputManager : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{

    Vector2 startedPos;
    public PointerEventData eventData;
    public Camera cam;
    public RaycastHit hit;
    private Vector2 delta;
    public Vector2 input;
    public float maxDistance = .8f;

    #region Singleton
    public static InputManager instance = null;
    public void Awake()
    {
        if (instance == null) instance = this;
    }
    #endregion

    public void OnPointerDown(PointerEventData _eventData)
    {
        eventData = _eventData;
        startedPos = eventData.position;
    }
    public void OnPointerUp(PointerEventData _eventData)
    {
        eventData = null;
        //delta = Vector2.zero;
        //startedPos = Vector2.zero;
        //input = Vector3.up;
        //hit = new RaycastHit();
    }
    void FixedUpdate()
    {
        if (eventData == null) return;
        Ray ray = cam.ScreenPointToRay(eventData.position);
        Physics.Raycast(ray, out hit);
        // continous input
        delta = eventData.position - startedPos;
        delta.x = Mathf.Clamp(delta.x, -50f, 50f);
        //delta.y = Mathf.Clamp(delta.y, -50f, 50f);
        
        input = delta/maxDistance ;
    }

}




