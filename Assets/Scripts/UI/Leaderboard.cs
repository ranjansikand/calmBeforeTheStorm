// Online global leaderboard



using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Dan.Main;
using UnityEngine.SceneManagement;

public class Leaderboard : MonoBehaviour
{
    string publicKey = "cc2d9bd213c422643646aa22975fca4d9f7880fdcb3129d792b9dea41c03323d";

    [SerializeField] private TMP_InputField _usernameInputField;

    [SerializeField] private List<TextMeshProUGUI> names, score;



    private void OnEnable() {
        GetLeaderboard();
    }

    public void GetLeaderboard() {
        LeaderboardCreator.GetLeaderboard(publicKey, ((msg) => {
            int loopLength = (msg.Length < names.Count) ? msg.Length : names.Count;
            for (int i = 0; i < loopLength; i++) {
                names[i].text = (i+1) + ". " + msg[i].Username;
                score[i].text = Timer.ConvertToTime(msg[i].Score);
            }
        }));
    }

    public void SetLeaderboardEntry(string username, int score) {
        LeaderboardCreator.UploadNewEntry(publicKey, username, score, ((msg) => {
            GetLeaderboard();
        }));
    }

    public void ReturnToTile() {
        SceneManager.LoadScene("Title");
    }
        
    public void UploadEntry() {
        SetLeaderboardEntry(_usernameInputField.text, PlayerStats.score);
    }
}