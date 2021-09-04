using UnityEngine;
using UnityEngine.Events;

public class MonsterBodyCollider : MonoBehaviour
{
    [SerializeField] private UnityEvent CollidedPlayer;

    private void OnTriggerEnter(Collider other)
    {
        if(IsCharacter(other.gameObject))
        {
            CollidedPlayer?.Invoke();
            VibrationUtility.Instance.VibrateMedium();
            SoundsPlayer.Instance.PlayMonsterTouch();
        }
    }

    private bool IsCharacter(GameObject gameObject)
    {
        return gameObject.GetComponent<Character>() != null;
    }
}