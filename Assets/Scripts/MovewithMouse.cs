using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovewithMouse : MonoBehaviour
{
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;
    [SerializeField] float screenWidthInUnits = 16f;
    public float padding;
    
    void Start()
    {
    }

    void Update()
    {
        float mousePos = padding + Input.mousePosition.x / Screen.width * screenWidthInUnits;
        Vector2 paddlePos = new Vector2(mousePos, transform.position.y);
        paddlePos.x = Mathf.Clamp(mousePos, minX, maxX);
        transform.position = paddlePos;
    }
}
