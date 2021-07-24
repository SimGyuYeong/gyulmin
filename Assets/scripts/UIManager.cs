using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private PlayerMove playerMove = null;
    public bool stageChange = false;
    [SerializeField]
    private int score = 0;
    private int targetScore = 10;
    public int stage = 1;
    [SerializeField]
    private Text textScore = null;
    // Start is called before the first frame update
    void Start()
    {
        playerMove = FindObjectOfType<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore()
    {
        score += 1;
        textScore.text = string.Format("SCORE {0}", score);
        if (score >= targetScore)
        {
            stageChange = true;
            targetScore += stage * 10;
            stage += 1;
            playerMove.col.enabled = false;
        }
    }
}
