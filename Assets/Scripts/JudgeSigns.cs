using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgeSigns : MonoBehaviour
{
    public float levelLength;
    TypingScenario currentScenario;
    int numberOfJudges = 5;
    public float timerForEachJudge;
    public float timer;
    [SerializeField] GameObject[] xJudges;
    [SerializeField] GameObject[] oJudges;
    int currentJudgeToCycle = 0;

    // Start is called before the first frame update
    void Awake()
    {
        levelLength = GameObject.Find("WordManager").GetComponent<WordManager>().currentScenario.timeLimit;
    }

    private void Start()
    {
        timerForEachJudge = levelLength / numberOfJudges - .6f;
        //Added the .6 to offset it from the last judge raising his sign as the level reaches 0 seconds
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timerForEachJudge)
        {
            timer = 0;
            CycleNextJudge();
        }
    }

    private void CycleNextJudge()
    {
        xJudges[currentJudgeToCycle].SetActive(false);
        oJudges[currentJudgeToCycle].SetActive(true);
        currentJudgeToCycle++;
    }
}
