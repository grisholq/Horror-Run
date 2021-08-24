using UnityEngine;

public class Test : MonoBehaviour
{
    void Update()
    {
        Debug.Log(transform.eulerAngles.z);     
        Debug.Log(transform.eulerAngles.y);   
    }
}