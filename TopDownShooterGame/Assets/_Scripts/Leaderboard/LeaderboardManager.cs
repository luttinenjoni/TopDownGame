using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;
using TMPro;

[System.Serializable]
public class ScoreEntry
{
    public string playerName;
    public int score;
}

[System.Serializable]
public class Leaderboard
{
    public List<ScoreEntry> entries = new List<ScoreEntry>();
}

public class LeaderboardManager : MonoBehaviour
{
    public Transform leaderboardPanel;
    public GameObject scoreEntryTemplate;

    private string filePath;
    private const int MaxEntries = 10;
    private Leaderboard leaderboard;

    private void Awake()
    {
        filePath = Application.persistentDataPath + "/leaderboard.json";
        LoadLeaderboard();
    }

    public void AddScore(string name, int score)
    {
        ScoreEntry newEntry = new ScoreEntry { playerName = name, score = score };
        leaderboard.entries.Add(newEntry);

        leaderboard.entries.Sort((a, b) => b.score.CompareTo(a.score));
        if (leaderboard.entries.Count > MaxEntries)
            leaderboard.entries.RemoveRange(MaxEntries, leaderboard.entries.Count - MaxEntries);

        SaveLeaderboard();
    }

    public void ShowLeaderboardUI()
{
    Debug.Log("Entries count: " + leaderboard.entries.Count);

    // Clear previous entries
    foreach (Transform child in leaderboardPanel)
    {
        if (child != scoreEntryTemplate.transform)  // Don't destroy the template itself
            Destroy(child.gameObject);
    }

    // Instantiate and display leaderboard entries
    foreach (ScoreEntry entry in leaderboard.entries)
    {
        // Clone the score template
        GameObject entryGO = Instantiate(scoreEntryTemplate, leaderboardPanel);
        entryGO.SetActive(true);

        // Set the text of the cloned template
        TMP_Text textComponent = entryGO.GetComponent<TMP_Text>();
        if (textComponent != null)
        {
            textComponent.text = $"{entry.playerName} - {entry.score}";
        }
        else
        {
            Debug.LogError("TMP_Text component not found in template.");
        }
    }
}

    private void SaveLeaderboard()
    {
        string json = JsonUtility.ToJson(leaderboard, true);
        File.WriteAllText(filePath, json);
    }

    private void LoadLeaderboard()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            leaderboard = JsonUtility.FromJson<Leaderboard>(json);
        }
        else
        {
            leaderboard = new Leaderboard();
        }
    }

}
