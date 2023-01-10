using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public int gemsCount;
    public Text gemsCountText;

    public static Inventory instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de Inventory dans la scène");
            return;
        }
        instance = this;
    }

    public void AddGems(int count)
    {
        gemsCount += count;
        gemsCountText.text = gemsCount.ToString();
    }
}
