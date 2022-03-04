using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardRefresh : MonoBehaviour
{
    [SerializeField]
    GameObject[] playerNames;

    [SerializeField]
    bool isAR;
    // Start is called before the first frame update
    void OnEnable()
    {
        if (isAR)
        {
            int arHighScore = GetHighAR();

            string[] nameList = {
                "NiKo - 100",
                "b1T - 90",
                "eletronic - 80",
                "ropz - 70",
                "Twistzz - 60",
                "mir - 50",
                "ax1le - 40",
                "EliGE - 30",
                "hunter - 20",
                "hobbit - 10"
            };

            List<string> newLeaderboard = new List<string>();
            foreach (var item in nameList)
            {
                string[] proScore = item.Split(' ');
                if (int.Parse(proScore[2]) < arHighScore)
                {
                    newLeaderboard.Add("YOU - " + arHighScore.ToString());
                }
                newLeaderboard.Add(item);
            }

            if (newLeaderboard.Count == nameList.Length)
            {
                newLeaderboard.Add("YOU - " + arHighScore.ToString());
            }

            int i = 0;
            foreach (GameObject item in playerNames)
            {
                
                item.GetComponent<Text>().text = newLeaderboard[i];
                if (newLeaderboard[i].Split(' ')[0] == "YOU")
                {
                    item.transform.parent.gameObject.GetComponent<Image>().color = new Color32(153,205,255,255);
                }
                i++;
            }
        }
        else
        {
            int awpHighScore = GetHighAWP();

            string[] nameList = {
                "simple - 50",
                "zywoo - 45",
                "device - 40",
                "kennyS - 35",
                "Jame - 30",
                "cadiaN - 25",
                "falleN - 20",
                "JW - 15",
                "mantuu - 10",
                "degster - 5"
            };
            List<string> newLeaderboard = new List<string>();
            foreach (var item in nameList)
            {
                string[] proScore = item.Split(' ');
                if (int.Parse(proScore[2]) < awpHighScore)
                {
                    newLeaderboard.Add("YOU - " + awpHighScore.ToString());
                }
                newLeaderboard.Add(item);
            }

            if (newLeaderboard.Count == nameList.Length)
            {
                newLeaderboard.Add("YOU - " + awpHighScore.ToString());
            }

            int i = 0;
            foreach (GameObject item in playerNames)
            {
                item.GetComponent<Text>().text = newLeaderboard[i];
                if (newLeaderboard[i].Split(' ')[0] == "YOU")
                {
                    item.transform.parent.gameObject.GetComponent<Image>().color = new Color32(153,205,255,255);
                }
                i++;
            }
        }
        this.transform.GetChild(0).gameObject.SetActive(false);
        this.transform.GetChild(0).gameObject.SetActive(true);
    }

    private static int GetHighAR()
    {
        int mirageAKScore = PlayerPrefs.GetInt("highScore" + "AK" + "1", 0);
        int infernoAKScore = PlayerPrefs.GetInt("highScore" + "AK" + "2", 0);
        int dustAKScore = PlayerPrefs.GetInt("highScore" + "AK" + "3", 0);
        int cacheAKScore = PlayerPrefs.GetInt("highScore" + "AK" + "4", 0);

        int mirageM4Score = PlayerPrefs.GetInt("highScore" + "M4" + "1", 0);
        int infernoM4Score = PlayerPrefs.GetInt("highScore" + "M4" + "2", 0);
        int dustM4Score = PlayerPrefs.GetInt("highScore" + "M4" + "3", 0);
        int cacheM4Score = PlayerPrefs.GetInt("highScore" + "M4" + "4", 0);

        int highscore = 0;

        if (infernoAKScore > highscore)
        {
            highscore = infernoAKScore;
        }
        if (dustAKScore > highscore)
        {
            highscore = dustAKScore;
        }
        if (mirageAKScore > highscore)
        {
            highscore = mirageAKScore;
        }
        if (cacheAKScore > highscore)
        {
            highscore = cacheAKScore;
        }
        if (infernoM4Score > highscore)
        {
            highscore = infernoM4Score;
        }
        if (dustM4Score > highscore)
        {
            highscore = dustM4Score;
        }
        if (mirageM4Score > highscore)
        {
            highscore = mirageM4Score;
        }
        if (cacheM4Score > highscore)
        {
            highscore = cacheM4Score;
        }
        return highscore;
    }
    private static int GetHighAWP()
    {
        int mirageAWPScore = PlayerPrefs.GetInt("highScore" + "AWP" + "1", 0);
        int infernoAWPScore = PlayerPrefs.GetInt("highScore" + "AWP" + "2", 0);
        int dustAWPScore = PlayerPrefs.GetInt("highScore" + "AWP" + "3", 0);
        int cacheAWPScore = PlayerPrefs.GetInt("highScore" + "AWP" + "4", 0);

        int highscore = 0;

        if (infernoAWPScore > highscore)
        {
            highscore = infernoAWPScore;
        }
        if (dustAWPScore > highscore)
        {
            highscore = dustAWPScore;
        }
        if (mirageAWPScore > highscore)
        {
            highscore = mirageAWPScore;
        }
        if (cacheAWPScore > highscore)
        {
            highscore = cacheAWPScore;
        }

        return highscore;
    }
}
