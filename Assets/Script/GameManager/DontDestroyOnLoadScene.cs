using UnityEngine;

public class DontDestroyOnLoadScene : MonoBehaviour
{
    public GameObject[] objects;

    void Awake()
    {
       foreach(var element in objects)
        {
            // Uncomment when instance is possible (bug with pause menu)
            //DontDestroyOnLoad(element);
        }
    }
}
