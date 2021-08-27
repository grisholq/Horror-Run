using UnityEngine;

public class CharacterMonsterViewField : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (IsMonster(other))
        {
            Monster monster = other.GetComponent<Monster>();
            monster.Eyes.Activate();
        }
    }

    private bool IsMonster(Collider other)
    {
        return other.GetComponent<Monster>() != null;
    }
}