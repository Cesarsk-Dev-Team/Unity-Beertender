using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    //const variables
    private const int TIER_ZERO_MINIMUM = 0;
    private const int TIER_ZERO_MAXIMUM = 100;
    private const int TIER_ONE_MINIMUM = TIER_ZERO_MAXIMUM;
    private const int TIER_ONE_MAXIMUM = 300;
    private const int TIER_TWO_MINIMUM = TIER_ONE_MAXIMUM;
    private const int TIER_TWO_MAXIMUM = 600;
    private const int TIER_THREE_MINIMUM = TIER_TWO_MAXIMUM;
    private const int TIER_THREE_MAXIMUM = 900;
    private const int TIER_FOUR_MINIMUM = TIER_THREE_MAXIMUM;
    private const int TIER_FOUR_MAXIMUM = 1200;

    //private variables
    private int lives = 0;
    private static GameManager instance;
    private int popularity = 0;

    //public variables
    [HideInInspector]
    public int streak = 1;
    [HideInInspector]
    public int currentTier = 0;
    public static bool dropSpilled = false;
    public GameObject livesContainer;
    public Text streakLabel;
    public GameObject pauseCanvas;
    public GameObject gameOverCanvas;
    public GameObject popularityTimer;
    public GameObject gameTimer;
    public Animator[] livesAnimators;
    
    static public bool isPaused = false;

    private void Awake()
    {
        if (instance != null) Destroy(gameObject);
        else instance = this;
    }
    private void Start()
    {
        for (int i = 0; i <= SaveManager.SV_UPGRADE_LIFE; i++)
        {
            IncreaseLife();
        }
        currentTier = 0;
        Time.timeScale = 1;
    }
    private void IncreaseLife()
    {
        livesContainer.transform.GetChild(lives).gameObject.SetActive(true);
        lives++;
    }
    public void DecreaseLife()
    {
        livesAnimators[lives-1].SetTrigger("Lost a life");
        //livesContainer.transform.GetChild(lives).gameObject.SetActive(false);
        lives--;
        ResetStreak();
        if (lives == 0)
        {
            GameOver();
        }
    }
    public void GameOver()
    {
        Time.timeScale = 0;
        gameOverCanvas.SetActive(true);
    }
    private void Update()
    {
        UpdatePopularity();
        //DebugPopularityTier();
    }
    //Managing popularity and tiers
    private void UpdatePopularity()
    {
        //Handling popularity and unlocked tier via Upgrade Scene
        popularity = popularityTimer.GetComponent<TimeManager>().counter;
        if (popularity >= TIER_ZERO_MINIMUM && popularity < TIER_ZERO_MAXIMUM && SaveManager.SV_UPGRADE_TIER >= 0)
        {
            currentTier = 0;
        }
        else if (popularity >= TIER_ONE_MINIMUM && popularity < TIER_ONE_MAXIMUM && SaveManager.SV_UPGRADE_TIER >= 1)
        {
            currentTier = 1;
        }
        else if (popularity >= TIER_TWO_MINIMUM && popularity < TIER_TWO_MAXIMUM && SaveManager.SV_UPGRADE_TIER >= 2)
        {
            currentTier = 2;
        }
        else if (popularity >= TIER_THREE_MINIMUM && popularity < TIER_THREE_MAXIMUM && SaveManager.SV_UPGRADE_TIER >= 3)
        {
            currentTier = 3;
        }
        else if (popularity >= TIER_FOUR_MINIMUM && popularity < TIER_FOUR_MAXIMUM && SaveManager.SV_UPGRADE_TIER >= 4)
        {
            currentTier = 4;
        }
    }
    private void DebugPopularityTier()
    {
        Debug.Log("Popularity: " + popularity);
        Debug.Log("Tier: " + currentTier);
    }
    private IEnumerator DropCooldown()
    {
        dropSpilled = true;
        yield return new WaitForSeconds(1f);
        dropSpilled = false;
    }
    public static GameManager GetInstance()
    {
        return instance;
    }
    public void DecreaseScore()
    {
        Score.GetInstance().score = (Score.GetInstance().score - Score.GetInstance().score / 100);
        dropSpilled = true;
        StartCoroutine(DropCooldown());
    }
    public void IncreaseStreak()
    {
        streak++;
        streakLabel.text = "X" + streak;
    }
    public void ResetStreak()
    {
        streak = 1;
        streakLabel.text = "X" + streak;
    }
    public void PauseGame()
    {
        if (!isPaused)
        {
            isPaused = true;
            pauseCanvas.SetActive(true);
            //Pause TimeManager?
            Time.timeScale = 0;
        }
    }
    public void ResumeGame()
    {
        if (isPaused)
        {
            isPaused = false;
            pauseCanvas.SetActive(false);
            //Pause TimeManager?
            Time.timeScale = 1;
        }
    }
    public void Ragequit()
    {
        SceneManager.LoadScene("Menu");
    }

    public void RestartMain()
    {
        Destroy(GameObject.Find("CustomerManager"));
        Destroy(GameObject.Find("Managers"));
        Destroy(GameObject.Find("GameManager"));
        SceneManager.LoadScene("Main");
    }
}