using UnityEngine;

public class CharacterItemsViewField : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(IsSanityItem(other))
        {
            other.GetComponent<SanityItem>().OnEnterFieldOfView();
        }
    } 

    private bool IsSanityItem(Collider other)
    {
        return other.GetComponent<SanityItem>() != null;
    }
}