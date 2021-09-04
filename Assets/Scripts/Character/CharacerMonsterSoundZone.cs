using UnityEngine;

public class CharacerMonsterSoundZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (IsMonster(other))
        {
            SoundsPlayer.Instance.PlayMonsterComing();
        }
    }

    private bool IsMonster(Collider other)
    {
        return other.GetComponent<Monster>() != null;
    }
}