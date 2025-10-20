using TMPro;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    float currentTime;
    public TMP_Text timerUI;
    void Start()
    {
        currentTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        timerUI.text = Mathf.RoundToInt(currentTime).ToString();
    }
}
