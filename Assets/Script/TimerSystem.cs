using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerSystem : MonoBehaviour
{
    public int Duration;
    public ScoreManager scoreManager;
    public bool isLevelPass;
    
    [SerializeField] private Image uiFill;
    [SerializeField] private TextMeshProUGUI uiText;

    private int remainingDuration;
    
    // Start is called before the first frame update
    void Start()
    {
        Being(Duration);
    }

    private void Being(int second)
    {
        remainingDuration = second;
        StartCoroutine(UpdateTimer());
    }

    private IEnumerator UpdateTimer()
    {
        while (remainingDuration >= 0 && isLevelPass == false)
        {
            uiText.text = $"{remainingDuration}s ";
            uiFill.fillAmount = Mathf.InverseLerp(0, Duration, remainingDuration);
            remainingDuration--;
            yield return new WaitForSeconds(1f);
        }
        OnEnd();
    }

    private void OnEnd()
    {
        scoreManager.SetRemainingTime(remainingDuration);
        print("End");
    }
}
