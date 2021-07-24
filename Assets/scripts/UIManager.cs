using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
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
        }
    }
}
