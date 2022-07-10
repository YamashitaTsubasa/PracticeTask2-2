using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCont : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _gravity;
    [SerializeField] private float _jumpSpeed;
    [SerializeField] private float _jumpHeight;
    [SerializeField] private float _jumpLimitTime;
    [SerializeField] private GroundCheck _grounds;
    [SerializeField] private GroundCheck _heads;
    private Animator _ani = null;
    private Rigidbody2D _rig = null;
    private bool _ground = false;
    private bool _jump = false;
    private bool _head = false;
    private float _jumpPos = 0.0f;
    private float _jumpTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        _ani = GetComponent<Animator>();
        _rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _ground = _grounds.Ground();
        _head = _heads.Ground();
        float xSpeed = 0.0f;
        float ySpeed = -_gravity;

        if (_ground)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                ySpeed = _jumpSpeed;
                _jumpPos = transform.position.y;
                _jump = true;
                _jumpTime = 0.0f;
            }
            else
            {
                _jump = false;
            }
        }
        else if (_jump)
        {
            bool canHeight = _jumpPos + _jumpHeight > transform.position.y;
            bool canTime = _jumpLimitTime > _jumpTime;

            if(Input.GetKey(KeyCode.UpArrow) && canHeight && canTime && !_head)
            {
                ySpeed = _jumpSpeed;
                _jumpTime += Time.deltaTime;
            }
            else
            {
                _jump = false;
                _jumpTime = 0.0f;
            }
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.localScale = new Vector3(1, 1, 1);
            _ani.SetBool("TankMove",true);
            xSpeed = -_speed;


        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.localScale = new Vector3(-1, 1, 1);
            _ani.SetBool("TankMove", true);
            xSpeed = _speed;
        }
        else
        {
            _ani.SetBool("TankMove", false);
            xSpeed = 0.0f;
        }

        _ani.SetBool("TankWaiting", _ground);
        _rig.velocity = new Vector2(xSpeed,ySpeed);

    }
}
