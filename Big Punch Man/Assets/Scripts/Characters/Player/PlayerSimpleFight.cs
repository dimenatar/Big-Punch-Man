using UnityEngine;

public class PlayerSimpleFight : MonoBehaviour
{
    [SerializeField] private HitRandomizer _hitRandomizer;
    [SerializeField] private SimpleTouchController _simpleTouchController;
    [SerializeField] private float _animationDuration;
    #region PunchParts
    [SerializeField] private PunchPart _leftArm;
    [SerializeField] private PunchPart _rightArm;
    [SerializeField] private PunchPart _leftLeg;
    [SerializeField] private PunchPart _rightLeg;
    #endregion

    private void Awake()
    {
        _simpleTouchController.OnEndDrag += Attack;
    }

    private void Attack()
    {
        Hits hit = _hitRandomizer.GetHit();
        switch (hit)
        {
            case Hits.LeftArm:
                {
                    _leftArm.Enable(_animationDuration);
                    break;
                }
            case Hits.RightArm:
                {
                    _rightArm.Enable(_animationDuration);
                    break;
                }
            case Hits.LeftLeg:
                {
                    _leftLeg.Enable(_animationDuration);
                    break;
                }
            case Hits.RightLeg:
                {
                    _rightLeg.Enable(_animationDuration);
                    break;
                }
        }

    }
}
