using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject GameOverScreen;
    [SerializeField] private Button btnRestart;
    [SerializeField] private Button btnExit;
    [SerializeField] private TMP_Text tmpScore;
    [SerializeField] private int scorePerSecond = 10;
    [SerializeField] private float InitialScrollSpeed = 8f;
    private float scrollSpeed;
    private int score;
    private float timer;
    public static GameManager Instance { get; private set; }
    public float GetScrollSpeed() { return scrollSpeed; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;
    }
    public void ShowGameOverScreen()
    {
        GameOverScreen.SetActive(true);
    }
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
    private void ExitGame()
    {
        Application.Quit();
    }
    private void UpdateScore()
    {
        timer += Time.deltaTime;
        score = (int)(timer * scorePerSecond);
        tmpScore.text = string.Format("{0:00000}", score);
    }
    private void UpdateSpeed()
    {
        scrollSpeed = InitialScrollSpeed + timer / 10f;
    }
    void Start()
    {
        btnRestart.onClick.AddListener(() => RestartScene());
        btnExit.onClick.AddListener(() => ExitGame());
    }
    void Update()
    {
        UpdateScore();
        UpdateSpeed();
    }
}