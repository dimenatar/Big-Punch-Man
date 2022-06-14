using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Stages _stages;
    [SerializeField] private Finish _finish;
    [SerializeField] private SimpleTouchController _joystick;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private float _speed;

    private bool _isMoving = false;
    private Vector3 _velocity;

    private void Awake()
    {
        _finish.OnFinish += Final;
        _stages.OnStageChanged += (stage) => _isMoving = true;
    }

    private void Update()
    {
        if (_isMoving)
        {
             _agent.Move(ConvertYVelocityToZ(_joystick.GetTouchPosition) * _speed * Time.deltaTime);
            // print($"{_agent.destination} {_agent.destination + ConvertYVelocityToZ(_joystick.GetTouchPosition) * _speed}");
            //_agent.Move(Vector3.SmoothDamp(_agent.destination - transform.position, _agent.destination + ConvertYVelocityToZ(_joystick.GetTouchPosition) * _speed - transform.position, ref _velocity, 0.2f));

        }

    }

    private Vector3 ConvertYVelocityToZ(Vector2 touchPos) => new Vector3(touchPos.x, 0, touchPos.y);

    private void Final()
    {
        _isMoving = false;
        Destroy(_joystick.gameObject);
    }
}
