using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeNum : MonoBehaviour
{
    private Text _lifeText = null;
    private int _oldlife = 0;

    // Start is called before the first frame update
    void Start()
    {
        _lifeText = GetComponent<Text>();
        if (Manager._instance != null)
        {
            _lifeText.text = "LIFE: " + Manager._instance.Life;
        }
        else
        {
            Destroy(this);
        }
    }

    void Update()
    {
        if (_oldlife != Manager._instance.Life)
        {
            _lifeText.text = "LIFE: " + Manager._instance.Life;
            _oldlife = Manager._instance.Life;
        }
    }
}