using System.Diagnostics;
using UnityEngine;


public enum ItemType
{
    Coin,
    Bomb,
    Heart,
    Clock
}

public class Item : MonoBehaviour
{
    public ItemType itemType; // تعیین نوع آیتم در Inspector

    private void OnTriggerEnter2D(Collider2D collision)
    {
    
     
            HandleItemEffect();
            Destroy(gameObject); // حذف آیتم بعد از برخورد
       
    }





    private void HandleItemEffect()
    {
        switch (itemType)
        {
            case ItemType.Coin:
                game_maneger.Instance.AddScore(1);
                break;
            case ItemType.Bomb:
                game_maneger.Instance.DecreaseLife(1
                    );
                break;
            case ItemType.Heart:
                game_maneger.Instance.IncreaseLife(1);
                break;
            case ItemType.Clock:
                game_maneger.Instance.ActivateScoreMultiplier(3, 10f); // 10 ثانیه امتیاز 3 برابر
                break;
        }
    }
}
