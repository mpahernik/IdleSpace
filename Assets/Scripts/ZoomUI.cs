using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ZoomUI : MonoBehaviour
{
    public float maxscale = 1.5f;
    public float minscale = 0.5f;
    float _currentscale;
    // Start is called before the first frame update
    void Start()
    {
        _currentscale = this.gameObject.transform.localScale.x;


    }

    // Update is called once per frame
    void Update()
    {
        Zoom(Input.GetAxis("Mouse ScrollWheel"));
    }

    void Zoom(float incrament)
    {
        _currentscale += incrament;

        if (_currentscale >= maxscale)
        {
            _currentscale = maxscale;

        }
        else if (_currentscale <= minscale)
        {
            _currentscale = minscale;

        }
        this.gameObject.transform.localScale = new Vector2(_currentscale,_currentscale);

    } 
}
