using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour
{
    public static int score = 0;
    public Text Score;
    // Start is called before the first frame update
    void Start() {
        updateScore();
    }
    void Update() {
        updateScore();
    }

    void updateScore() {
        Score.text = "Score: " + score;
    }
}
