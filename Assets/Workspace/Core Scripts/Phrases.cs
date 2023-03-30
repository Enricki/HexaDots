using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public static class Phrases
{
    private static List<string> RandomPhrases = new List<string>()
    {
        "Monkeys does not grow on trees",
        "Cute animals are more likely to be squeezed",
        "King Tut owned a dagger from outer space",
        "There is a species of jellyfish that never cries",
        "Lemurs get high on bugs",
        "The original Back to the Future time machine was a fridge",
    };

    public static string GetRandomPhrase()
    {
        int randomIndex = Random.Range(0, RandomPhrases.Count);
        return RandomPhrases[randomIndex];
    }
}