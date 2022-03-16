using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCount : MonoBehaviour
{
    // The text component to write our findings too
    [SerializeField]
    TextMeshProUGUI streakInfo;

    private int streak = 0; 
    private double time = 0;
    private double allowedTime = 20;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (streak != 0) // check if streak is running
        {
            time = time + Time.deltaTime; // count time
            if (time > allowedTime) 
            {
                //Game over
                streak = 0;
            }else 
            {
                
            }
        }
        streakInfo.text = streak.ToString("F2") + time.ToString("F2") + allowedTime.ToString("F2");
        
    }

    public void ScooterDestroyed()
    {
        streak = streak + 1;
        allowedTime = 10 - 0.7*streak;
    }
}
