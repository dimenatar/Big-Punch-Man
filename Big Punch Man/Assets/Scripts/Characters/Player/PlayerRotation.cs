using DG.Tweening;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField] private Finish _finish;
    [SerializeField] private SimpleTouchController _joystick;
    [SerializeField] private Transform _transformToRotate;

    [SerializeField] private float _finalRotationDuration = 0.5f;
    [SerializeField] private float _finalYRotation = 180;

    private void Awake()
    {
        _finish.OnFinish += FinalRotate;
    }

    private void Update()
    {
        RotatePlayer();
    }

    private void RotatePlayer()
    {
        if (_joystick.TouchPresent)
        {
            _transformToRotate.localRotation = Quaternion.Euler(new Vector3(_transformToRotate.eulerAngles.x, 0, Mathf.Atan2(_joystick.GetTouchPosition.x, _joystick.GetTouchPosition.y) * Mathf.Rad2Deg));
        }
    }

    private void FinalRotate()
    {
        _transformToRotate.DORotate(new Vector3(-90, 0, _finalYRotation), _finalRotationDuration).SetUpdate(true);
    }
}
