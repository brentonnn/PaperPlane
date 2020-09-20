using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ControlHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    
    enum Direction
    {
        Left,
        Right,
        None
    }
    
    public static bool left = false;
    public static bool right = false;

    [SerializeField] Direction direction = Direction.None;
    
    // Start is called before the first frame update
    void Start()
    {
        left = false;
        right = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        
        if (direction == Direction.Left)
        {
            left = true;
            right = false;
        }
        else if(direction == Direction.Right)
        {
            left = false;
            right = true;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        left = false;
        right = false;
    }
}
