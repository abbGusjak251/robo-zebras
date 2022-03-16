using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreCount : MonoBehaviour
{
    // The text component to write our findings too
    [SerializeField]
    public TextMeshProUGUI streakInfo;

    public int streak = 0; 
    private float time = 0;
    private float allowedTime = 30f;
    private float minimumAllowedTime = 5f;

    // Update is called once per frame
    void Update()
    {
        if (streak > 0) // check if streak is running
        {
            streakInfo.text = "Streak: " + streak.ToString("F2") + " Time: " + time.ToString("F2") + " Time Limit: " + allowedTime.ToString("F2");
            time = time + Time.deltaTime; // count time
            if (time > allowedTime) 
            {
                //Game over
                streak = -1;
            } else {
                
            }
        } else if(streak == -1) {
            GameObject[] scooters = GameObject.FindGameObjectsWithTag("voi-scooter");
            foreach(var scooter in scooters) {
                Destroy(scooter);
            } 
            GameObject[] crystals = GameObject.FindGameObjectsWithTag("crystal");
            foreach(var crystal in crystals) {
                Destroy(crystal);
            } 
            StartCoroutine(RestartScene());
            streakInfo.text = "Game Over";
            streakInfo.color = Color.red;
        }
        
    }

    public void ScooterDestroyed()
    {
        if(streak != -1) {
            streak += 1;
            time = 0;
            if(allowedTime > minimumAllowedTime) {
                allowedTime = 30f-streak;
            }
        }
    }

    IEnumerator RestartScene() {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
