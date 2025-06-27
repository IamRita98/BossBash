using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TypingScenario", menuName = "Game/Scenario", order = 1)]
public class TypingScenario : ScriptableObject
{
    public string scenarioName;
    public float timeLimit;
}
