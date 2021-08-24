using UnityEngine;
using System.Collections;

public class RoadTurn : MonoBehaviour
{
    [SerializeField] private float _angle;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private bool _enabled;

    private void OnTriggerEnter(Collider other)
    {
        if(IsCharacter(other) && _enabled)
        {
            Transform character = other.transform;
            StartCoroutine(Turn(character, character.eulerAngles.y + _angle));
            _enabled = false;
        }
    }

    private bool IsCharacter(Collider other)
    {
        return other.GetComponent<Character>() != null;
    }

    private IEnumerator Turn(Transform character, float targetY)
    {
        while(!HasReachedTarget(transform.eulerAngles.y , targetY))
        {
            Vector3 eulers = character.eulerAngles;
            eulers.y = Mathf.MoveTowardsAngle(character.eulerAngles.y, targetY, Time.deltaTime * _rotationSpeed);
            character.eulerAngles = eulers;
            yield return null;
        }
    }

    private bool HasReachedTarget(float angle, float target)
    {
        return angle == target || ChangeAngleSign(angle) == target;
    }

    private float ChangeAngleSign(float angle)
    {
        if(angle > 0)
        {
            return -360 + angle;
        }
        else
        {
            return 360 + angle;
        }
    }
}