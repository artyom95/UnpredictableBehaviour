using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 0.01f;

    private static readonly int MoveForfard = Animator.StringToHash("MoveForward");
    private static readonly int MoveBack = Animator.StringToHash("MoveBack");
    private static readonly float PunchOrKick = Animator.StringToHash("PunchOrKick");


    private Transform _objectPosition;

    private Animator _animator;
    private Vector3 _currentPosition;

    // Start is called before the first frame update
    void Start()
    {
        _objectPosition = gameObject.GetComponent<Transform>();
        _animator = gameObject.GetComponentInChildren<Animator>();
        _currentPosition = _objectPosition.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            MooveForward();

            return;
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            _animator.SetInteger(MoveForfard, 0);
            return;
        }

        if (Input.GetKey(KeyCode.S))
        {
            MooveBack();

            return;
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            _animator.SetInteger(MoveBack, 0);
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Punch();
        }
    }


    private void MooveForward()
    {
        _animator.SetInteger(MoveForfard, 1);
        _objectPosition.Translate(Vector3.back * _speed);
    }

    private void MooveBack()
    {
        _animator.SetInteger(MoveBack, 1);
        _objectPosition.Translate(Vector3.forward * _speed);
    }

    private void Punch()
    {
        var number = Random.Range(0, 10);


        _animator.SetInteger("PunchOrKick", number);
        _animator.SetTrigger("iSPunch");
    }
}