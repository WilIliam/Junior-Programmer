/*
* Create by William (c)
* https://github.com/Long18
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficuktyButton : MonoBehaviour
{

    #region Variables

    public int difficulty;

    private Button button;
    private GameManager gameManager;
    #endregion

    #region Unity Mehods

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        button.onClick.AddListener(SetDifficulty);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    #endregion

    #region Class

    void SetDifficulty()
	{
        gameManager.StartGame(difficulty);
	}
    #endregion
}
