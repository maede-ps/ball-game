using UnityEngine;
using UnityEngine.SceneManagement;

public class game_maneger : MonoBehaviour
{
    public static game_maneger Instance;

    public int score = 0;
    public int life = 3;

    // ضرب‌کننده امتیاز
    public int scoreMultiplier = 1;
    private float multiplierDuration = 0f;

    public AudioSource Coin_Sound;
    public AudioSource bomb_Sound;
    public AudioSource time_Sound;
    public AudioSource Life_Sound;


    public DragKick ball;


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
        Coin_Sound.Play();
        Debug.Log("Score: " + score);

        if (ball != null && ball.skin != null)
        {
            var skin = ball.skin;
            var spriteRenderer = ball.GetComponent<SpriteRenderer>();

            if (score >= skin.level_4.score && skin.level < 4)
            {
                skin.level = 4;
                spriteRenderer.sprite = skin.level_4.Skin;
            }
            else if (score >= skin.level_3.score && skin.level < 3)
            {
                skin.level = 3;
                spriteRenderer.sprite = skin.level_3.Skin;
            }
            else if (score >= skin.level_2.score && skin.level < 2)
            {
                skin.level = 2;
                spriteRenderer.sprite = skin.level_2.Skin;
            }
        }
    }

    public void DecreaseLife(int amount)
    {
        life -= amount;
        bomb_Sound.Play();
        if (life <= 0 )
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void IncreaseLife(int amount)
    {
        Life_Sound.Play();
        life += amount;
    }

    public void ActivateScoreMultiplier(int multiplier, float duration)
    {
        time_Sound.Play();
        scoreMultiplier = multiplier;
        multiplierDuration = duration;
//        Debug.Log("Multiplier Activated: x" + multiplier + " for " + duration + " seconds");
    }
}
