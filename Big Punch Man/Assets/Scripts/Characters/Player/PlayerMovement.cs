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
            if (CheckMovementVector(_joystick.GetTouchPosition))
            {
                _agent.Move(ConvertYVelocityToZ(_joystick.GetTouchPosition) * _speed * Time.deltaTime);
            }
        }

    }

    private Vector3 ConvertYVelocityToZ(Vector2 touchPos) => new Vector3(touchPos.x, 0, touchPos.y);

    private void Final()
    {
        _isMoving = false;
        //Destroy(_joystick.gameObject);
    }

    private bool CheckMovementVector(Vector2 vector)
    {
        return Round(vector, 2) != Vector2.zero;
    }

    private Vector2 Round(Vector2 vector, int digits)
    {
        return new Vector2((float)System.Math.Round(vector.x, digits), (float)System.Math.Round(vector.x, digits));
    }
}
