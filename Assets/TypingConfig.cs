using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TypingConfig
{
    public static readonly List<string> LevelOneConfig = new List<string> { "random sentence fragment one" };
    public static readonly List<string> LevelTwoConfig = new List<string> { "random", "sentence", "fragment", "two" };

    public static List<string> GetTypingConfig(string scenario)
    {
        switch (scenario)
        {
            case "LevelOne":
                return LevelOneConfig;
            default:
                return new List<string> {  "No config for given scenario" };
        }
    }
}
