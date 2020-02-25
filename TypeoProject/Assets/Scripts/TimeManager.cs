using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
  
    public float TimeLimit;
    public Text TimerLabel;

    private float _currentTime;
        
    void Start()
    {
        _currentTime = TimeLimit;
    }

    void Update()
    {

        if (_currentTime > 0)
        {
            _currentTime -= Time.deltaTime;
        }
        else 
        {
            Conditions.Lose = true;
        }

        if (_currentTime > TimeLimit / 2)
        {
            TimerLabel.text = "<color=lime>==Time== \n" + ((double) _currentTime).ToString().Substring(0, 5) + "s</color>";
        }
        else
        {
            TimerLabel.text = "<color=red>==Time== \n" + ((double)_currentTime).ToString().Substring(0, 5) + "s</color>";
        }
    }
}
