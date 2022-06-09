using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Finish _finish;
    [SerializeField] private SimpleTouchController _joystick;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private float _speed;

    private bool _isMoving = true;

    private void Awake()
    {
        _finish.OnFinish += Final;
    }

    private void FixedUpdate()
    {
        if (_isMoving)
        _agent.Move(ConvertYVelocityToZ(_joystick.GetTouchPosition) * _speed);
    }

    private Vector3 ConvertYVelocityToZ(Vector2 touchPos) => new Vector3(touchPos.x, 0, touchPos.y);

    private void Final()
    {
        _isMoving = false;
        Destroy(_joystick.gameObject);
    }
}
