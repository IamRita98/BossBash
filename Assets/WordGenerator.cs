using System.Diagnostics.Tracing;
using UnityEngine;

public class WordGenerator : MonoBehaviour
{
    private static string[] wordList =
    { "aaa", "bbb", "ccc", "ddd" };

    public static string GetRandomWord()
    {
        string rand = wordList[Random.Range(0, wordList.Length - 1)];
        return rand;
    }
}
