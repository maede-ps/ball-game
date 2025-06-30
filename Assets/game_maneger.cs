using UnityEngine;

public class game_maneger : MonoBehaviour
{
    public static game_maneger Instance;

    public int score = 0;
    public int life = 3;

    // ضرب‌کننده امتیاز
    public int scoreMultiplier = 1;
    private float multiplierDuration = 0f;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Update()
    {
        if (multiplierDuration > 0f)
        {
            multiplierDuration -= Time.deltaTime;
            if (multiplierDuration <= 0f)
            {
                scoreMultiplier = 1; // بازگشت به حالت عادی
            }
        }
    }

    public void AddScore(int amount)
    {
        score += amount * scoreMultiplier;
        Debug.Log("Score: " + score);
    }

    public void DecreaseLife(int amount)
    {
        life -= amount;
    }

    public void IncreaseLife(int amount)
    {
        life += amount;
    }

    public void ActivateScoreMultiplier(int multiplier, float duration)
    {
        scoreMultiplier = multiplier;
        multiplierDuration = duration;
//        Debug.Log("Multiplier Activated: x" + multiplier + " for " + duration + " seconds");
    }
}
