using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI ammoText;
    public TextMeshProUGUI bombText;
    public Animator ammoAnim;
    public Animator bombAnim;
    public Animator HUD;
    public Animator DeathPanel;

    int score = 0;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        scoreText.text = score.ToString();
        HighScoreUpdate();
    }

    public void UpdateAmmo(int ammo)
    {
        ammoText.text = ammo.ToString();
        ammoAnim.Play("Base Layer.AmmoText");
    }

    public void UpdateBomb(int bomb)
    {
        bombText.text = bomb.ToString();
        bombAnim.Play("Base Layer.BombText");
    }

    public void UpdateScore(int points)
    {
        score += points;
        scoreText.text = score.ToString();
    }

    public void HighScoreUpdate()
    {
        if(PlayerPrefs.HasKey("SavedHighScore"))
        {
            if(score > PlayerPrefs.GetInt("SavedHighScore"))
            {
                PlayerPrefs.SetInt("SavedHighScore", score);
            }
        }
        else
        {
            PlayerPrefs.SetInt("SavedHighScore", score);
        }

        highScoreText.text = PlayerPrefs.GetInt("SavedHighScore").ToString();
    }

    public void Death()
    {
        HUD.SetTrigger("HUDAnim");
        DeathPanel.SetTrigger("DeathPanel");
    }

    public int getScore()
    {
        return score;
    }
}
