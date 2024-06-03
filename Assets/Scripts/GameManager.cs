using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TMP_Text highScoreText;
    [SerializeField] private TMP_Text energyText;
    [SerializeField] private int maxEnergy;
    [SerializeField] private int energyRechargeDuration;

    private const string EnergyKey = "Energy";
    private const string EnergyReadyKey = "EnergyReady";
    private int energy;

    private void Start()
    {

        energy = PlayerPrefs.GetInt(EnergyKey, maxEnergy);

        if (energy == 0)
        {
            string energyReadyString = PlayerPrefs.GetString(EnergyReadyKey, string.Empty);

            if (energyReadyString == String.Empty)
                return;

            DateTime energyReady = DateTime.Parse(energyReadyString);

            if (DateTime.Now > energyReady)
            {
                energy = maxEnergy;
                PlayerPrefs.SetInt(EnergyKey, energy);
            }
            
        }

        energyText.text = $"Fuel: {energy}";
        int highscore = PlayerPrefs.GetInt(ScoreManager.highScoreKey);
        highScoreText.text = $"Highscore: {highscore}";
    }

    public void MenuPlayButton()
    {
        if (energy<1)
            return;

        energy--;
        
        PlayerPrefs.SetInt(EnergyKey,energy);

        if (energy == 0)
        {
            DateTime energyReady = DateTime.Now.AddMinutes(energyRechargeDuration);
            PlayerPrefs.SetString(EnergyReadyKey,energyReady.ToString());
            
        }
        
        SceneManager.LoadScene("Game Scene");
    }
    
    
}
