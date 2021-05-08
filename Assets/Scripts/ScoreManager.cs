using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static float redScore;
    public static float blueScore;

    public Text redScoreText;
    public Text BlueScoreText;
    public Text YellowScoreText;

    private void Update()
    {
        redScoreText.text = redScore.ToString();
        BlueScoreText.text = blueScore.ToString();
        YellowScoreText.text = blueScore.ToString();
    }
}
