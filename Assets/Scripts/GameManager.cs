using System;
using System.IO ;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;

public class GameManager : MonoBehaviour
{
    public SpawnManager spawnManager;
    public ItemManager itemManager;
    public GameObject Cover;
    public Text BestScoreText;
    float EnemyScore = 3.0f;
    float CoinScore = 1.0f;
    UserData userData;

    int score = 0;
    public Text ScoreText;

    void Start()
    {
        EventManager.EnemyDieEvent += OnEnemyDie;
        LoadUserData();
        BestScoreText.text = String.Format("Bestscore>   {0}", userData.BestScore);
    }

    public void OnClickStartButton()
    {
        Cover.SetActive(false);
        StartCoroutine(spawnManager.SpawnRandom());
        itemManager.SpawnRandom();
    }

    public void OnEnemyDie()
    { 
        score += (int)EnemyScore;
        ScoreText.text = String.Format("Score {0}", score);

        ChangeBest();
    }

    public void OnCoin()
    {
        score += (int)CoinScore;
        ScoreText.text = String.Format("Score {0}", score);
        ChangeBest();
    }

    public void On5Coin()
    {
        score += (int)CoinScore*2;
        ScoreText.text = String.Format("Score {0}", score);
        ChangeBest();
    }

    public void ChangeBest()
    {
        if (userData.BestScore < score)
            {
                userData.BestScore = score;
                BestScoreText.text = String.Format("BestScore>   {0}", userData.BestScore);
                SaveUserData();
            }
    }   

    void SaveUserData()
    {
        FileStream file = new FileStream(Application.persistentDataPath + "/userdata.dat",
            FileMode.Create);
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file, userData);
        file.Close();
    }

    void LoadUserData()
    {
        FileStream file;

        try
        {
            file = new FileStream(Application.persistentDataPath + "/userdata.dat",
                FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            userData = (UserData)bf.Deserialize(file);
            file.Close();
        }
        catch (FileNotFoundException e)
        {
            Debug.Log(e.Message);
            userData = new UserData();
        }
    }
    
    [Serializable]
    class UserData
    {
        public int BestScore;
    }
}
