using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public int level;
    public Text levelText;
    #region Singleton
    public static GameManager instance = null;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer || level == -1)
            level = PlayerPrefs.GetInt("level", 1);

    }
    #endregion

    private void Start()
    {
        levelText.text = level.ToString();
    }
    public void LevelUp()
    {
        PlayerPrefs.SetInt("level",++level);
        Debug.Log("level: " + level);
        Restart();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
