using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private Text _scoreText = null;
    private int _oldScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        _scoreText = GetComponent<Text>();
        if (Manager._instance != null)
        {
            _scoreText.text = "SCORE: " + Manager._instance.Score;
        }
        else
        {
            Destroy(this);
        }
    }

    void Update()
    {
        if (_oldScore != Manager._instance.Score)
        {
            _scoreText.text = "SCORE: " + Manager._instance.Score;
            _oldScore = Manager._instance.Score;
        }
    }
}
