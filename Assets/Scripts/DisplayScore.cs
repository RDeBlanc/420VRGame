using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour
{
    public static int score = 0;
    public List<Text> Score;
    // Start is called before the first frame update
    void Start() {
        updateScore();
    }
    void Update() {
        updateScore();
    }

    void updateScore() {
        foreach(Text scoreObject in Score) {
            scoreObject.text = "Score: " + score;
        }
        //Score[0].text = "Score: " + score;
    }
}
