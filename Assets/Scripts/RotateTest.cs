using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTest : MonoBehaviour
{
    public void RotateObject(GameObject mGameObject)
    {
        mGameObject.transform.eulerAngles += new Vector3(0f, 0f,10f);
    }
}
