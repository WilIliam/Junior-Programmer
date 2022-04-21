/*
* Create by William (c)
* https://github.com/Long18
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{

    #region Variables

    public float rotaionSpeed = 50;
    #endregion

    #region Unity Mehods

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, horizontalInput * rotaionSpeed * Time.deltaTime);
    }

    
    #endregion

    #region Class

    #endregion
}
