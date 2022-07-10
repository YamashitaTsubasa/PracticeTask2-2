using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private string _groundTag = "Ground";
    private bool _ground = false;
    private bool _groundEnter, _groundStay, _groundExit;
    public bool Ground()
    {
        if(_groundEnter || _groundStay)
        {
            _ground = true;
        }
        else if (_groundExit)
        {
            _ground = false;
        }

        _groundEnter = false;
        _groundStay = false;
        _groundExit = false;
        
        return _ground;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == _groundTag)
        {
            _groundEnter = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == _groundTag)
        {
            _groundStay = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == _groundTag)
        {
            _groundExit = true;
        }
    }
}
