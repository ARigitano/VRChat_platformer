
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using TMPro;

public class HighscoreBoard : UdonSharpBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _playerNameText; //Text for the first player's name.
    [SerializeField]
    private TextMeshProUGUI _scoreText; //Text for the first player's score.

    //Update the board do display the first player's name and score.
    public void UpdateBoard(string firstPlayerName, string firstPlayerScore)
    {
        _playerNameText.text = firstPlayerName;
        _scoreText.text = firstPlayerScore;
    }
}
