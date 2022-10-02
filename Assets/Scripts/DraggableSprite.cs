using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableSprite : MonoBehaviour
{

    private Vector3 _currentPosition;
    private Vector3 _newPosition;
    private Rigidbody2D _rigidbody;

    private bool _isDragging;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_isDragging)
        {
            _rigidbody.position = _newPosition; //Vector3.Lerp(_currentPosition, _newPosition, Time.deltaTime);
        }
    }

    private void OnMouseDown()
    {
        _isDragging = true;
    }

    private void OnMouseUp()
    {
        _isDragging = false;
    }

    private void OnMouseDrag()
    {
        if (!_isDragging)
            return;
        
        var screenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z);
        _newPosition = Camera.main.ScreenToWorldPoint(screenPoint);
    }

    public bool IsDragging()
    {
        return _isDragging;
    }
}
