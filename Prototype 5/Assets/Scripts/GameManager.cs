/*
* Create by William (c)
* https://github.com/Long18
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    #region Variables

    public List<GameObject> targets;

    private float spawnRate = 1.0f;
    #endregion

    #region Unity Mehods

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTarget());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    #endregion

    #region Class

    IEnumerator SpawnTarget()
	{
		while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.RandomRange(0, targets.Count);

            Instantiate(targets[index]);

        }
	}
    #endregion
}
