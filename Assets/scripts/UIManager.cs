using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private PlayerMove playerMove = null;
    public bool stageChange = false;
    [SerializeField]
    public int score = 0;
    public int targetScore = 10;
    public int stage = 1;
    [SerializeField]
    private Text textScore = null;

    private void Awake()
    {
        score = PlayerPrefs.GetInt("SCORE", 0);
        textScore.text = string.Format("SCORE {0}", score);
        stage = PlayerPrefs.GetInt("STAGE", 0);
        targetScore = PlayerPrefs.GetInt("TARGETSCORE", 0);
    }

    void Start()
    {
        stageChange = false;
        playerMove = FindObjectOfType<PlayerMove>();
    }

    public void AddScore()
    {
        score += 1;
        textScore.text = string.Format("SCORE {0}", score);
        if (score >= targetScore)
        {
            PlayerPrefs.SetInt("SCORE", score);
            stage++;
            PlayerPrefs.SetInt("STAGE", stage);
            targetScore += stage * 10;
            PlayerPrefs.SetInt("TARGETSCORE", targetScore);
            stageChange = true;
        }
    }

    public void scoreReset()
    {
        score = 0;
        stage = 1;
        targetScore = 10;
        textScore.text = string.Format("SCORE {0}", score);
        PlayerPrefs.SetInt("SCORE", score);
        PlayerPrefs.SetInt("STAGE", stage);
        PlayerPrefs.SetInt("TARGETSCORE", targetScore);
    }
}
