using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TimerSystem timerSystem;
    public GameObject ResultUI;
    public GameObject TaskMark1;
    public GameObject TaskMark2;
    public TextMeshProUGUI Timer;
    public TextMeshProUGUI CiviliansCount;
    public TextMeshProUGUI FireExtinguishCout;
    
    private int _fireExtinguishCount;
    private int _civiliansRescueCount;
    private int _remainingTime;
    private bool isRescue;
    private bool isExtinguish;

    private void Update()
    {
        if (_civiliansRescueCount >= CountCivilians())
        {
            TaskMark1.SetActive(true);
            isRescue = true;
        }
        
        if (_fireExtinguishCount >= CountFires())
        {
            TaskMark2.SetActive(true);
            isExtinguish = true;
        }

        if (isRescue == true && isExtinguish == true)
        {
            OnAllTaskComplete();
        }
        
    }

    public void AddFireExtinguish()
    {
        _fireExtinguishCount++;
    }

    public void AddCivilians()
    {
        _civiliansRescueCount++;
    }
    
    public void SetRemainingTime(int time)
    {
        _remainingTime = time;
    }
    
    public int CountFires()
    {
        return GameObject.FindGameObjectsWithTag("fire").Length;
    }

    public int CountCivilians()
    {
        return GameObject.FindGameObjectsWithTag("Civilians").Length;
    }

    public void OnAllTaskComplete()
    {
        timerSystem.isLevelPass = true;
        Timer.text = $"Time Remaining: {_remainingTime}s";
        CiviliansCount.text = $"Civilians Rescued: {_civiliansRescueCount}";
        FireExtinguishCout.text = $"Fires Extinguished Score: {_fireExtinguishCount}";
        
        ResultUI.SetActive(true);
    }
}
