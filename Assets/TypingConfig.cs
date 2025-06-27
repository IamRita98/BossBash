using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Consider extending TypingConfig to be an enum of multiple attributes, the actual word being just one element
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
            case "LevelTwo":
                return LevelTwoConfig;
            default:
                return new List<string> {  "No config for given scenario" };
        }
    }
}
