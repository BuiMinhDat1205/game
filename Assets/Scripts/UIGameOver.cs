using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIGameOver : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;
    ASM_MN ASM_MN;

    void Awake()
    {
        scoreKeeper = FindFirstObjectByType<ScoreKeeper>();
        ASM_MN = FindFirstObjectByType<ASM_MN>();

        Debug.Log("scoreText: " + scoreText);
        Debug.Log("scoreKeeper: " + scoreKeeper);
        Debug.Log("ASM_MN: " + ASM_MN);
    }

    void Start()
    {
        scoreText.text = "You Scored:\n" + scoreKeeper.GetScore();

        int playerId = 1;                 // ID người chơi hiện tại
        string playerName = "Player1";    // Tên người chơi
        int playerScore = scoreKeeper.GetScore(); // Điểm hiện tại
        int playerRegionId = 0;            // ID Region

        // Lưu thông tin người chơi (YC1)
        ASM_MN.YC1(playerId, playerName, playerScore, playerRegionId);

        // Xuất danh sách người chơi (YC2)
        ASM_MN.YC2();
    }
}
