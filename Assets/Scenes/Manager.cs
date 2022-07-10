using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager _instance = null;

    [SerializeField] private int _score;
    [SerializeField] private int _life;

    private void Start()
    {
        Score = _score;
        Life = _life;
    }
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public int Score { get; set; }
    public int Life { get; set; }
}
