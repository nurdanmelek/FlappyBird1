using System.Collections.Generic;
using UnityEngine;

public class WordsManager : MonoBehaviour
{
    public List<int> currentLevelKeys;
    
    public List<string> latinWords;
    public List<string> turkishWords;

    public void SetLevelKeys()
    {
        List<int> totalKeys = new List<int>();
        for (int i = 0; i < latinWords.Count; i++)
        {
            totalKeys.Add(i);
        }
        
        var selectedNo1 = totalKeys[Random.Range(0,totalKeys.Count)];
        totalKeys.Remove(selectedNo1);
        var selectedNo2 = totalKeys[Random.Range(0,totalKeys.Count)];
        totalKeys.Remove(selectedNo2);
        var selectedNo3 = totalKeys[Random.Range(0,totalKeys.Count)];
        totalKeys.Remove(selectedNo3);
        
        currentLevelKeys.Add(selectedNo1);
        currentLevelKeys.Add(selectedNo2);
        currentLevelKeys.Add(selectedNo3);
    }

    public List<string> ReturnLatinWords()
    {
        var newList = new List<string>();
        newList.Add(latinWords[currentLevelKeys[0]]);
        newList.Add(latinWords[currentLevelKeys[1]]);
        newList.Add(latinWords[currentLevelKeys[2]]);
        return newList;
    }

    public List<string> ReturnTurkishWords()
    {
        var newList = new List<string>();
        newList.Add(turkishWords[currentLevelKeys[0]]);
        newList.Add(turkishWords[currentLevelKeys[1]]);
        newList.Add(turkishWords[currentLevelKeys[2]]);
        return newList;
    }
}
