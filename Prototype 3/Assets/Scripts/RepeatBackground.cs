/*
* Create by William (c)
* https://github.com/Long18
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{

    #region Variables
    private Vector3 startPos;
    private float repeatWidth;
    #endregion

    #region Unity Mehods

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < startPos.x - repeatWidth)
		{
            transform.position = startPos;
		}
    }

    
    #endregion

    #region Class

    #endregion
}
