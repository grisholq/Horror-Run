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
        while (!HasReachedTarget(character.eulerAngles.y, targetY))
        {
            Vector3 eulers = character.eulerAngles;
            eulers.y = Mathf.MoveTowardsAngle(character.eulerAngles.y, targetY, Time.deltaTime * _rotationSpeed);
            character.eulerAngles = eulers;
            yield return null;
        }

    }

    private bool HasReachedTarget(float angle, float target)
    {
        Debug.Log(Mathf.Abs(Mathf.DeltaAngle(angle, target)));
        float distance = Mathf.Abs(Mathf.DeltaAngle(angle, target));
        return distance <= 1.5f;
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