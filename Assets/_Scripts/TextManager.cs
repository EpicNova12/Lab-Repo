using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public TextMeshProUGUI textHealth;
    public TextMeshProUGUI textScore;

    private int health;
    private int score;
    // Start is called before the first frame update
    void Start()
    {
        textHealth = GetComponent<TextMeshProUGUI>();
        textScore = GetComponent<TextMeshProUGUI>();

        health = PlayerHealth.instance.getHealth();
        score = Score.instance.getScore();

        textHealth.text = "Health: " + health.ToString();
        textScore.text = "Score: " + Score.instance.getScore().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
