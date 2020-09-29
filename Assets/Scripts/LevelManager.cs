using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Transform levelPos;
    [HideInInspector]public States state;
    #region Singleton
    public static LevelManager instance = null;
    private void Awake()
    {
        if (instance == null) instance = this;
    }
    #endregion

    public void Start()
    {
        //GetLevel();
        state = States.begin;
    }
  
    //public void GetLevel()
    //{
    //    I//nstantiate(Resources.Load<GameObject>("levels/level-" + GameManager.instance.level),levelPos.position,levelPos.rotation,levelPos);
    //}
}

public enum States
{
    begin,
    game,
    endSuccess,
    endFail
}
