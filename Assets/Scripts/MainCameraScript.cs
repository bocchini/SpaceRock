using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainCameraScript : MonoBehaviour {

    public Text pointText;
    public int points;
    public Button restartbtn;

    public void AddPoints()
    {
        this.points += 100;
        this.pointText.text = points.ToString();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void ShowRestartBtn()
    {
        this.restartbtn.gameObject.SetActive(true);
    }
}
