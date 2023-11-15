using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ExtensionFunc : MonoBehaviour
{
    public UnityEvent fatherFunctions;

    private void CallFunction()
    {
        fatherFunctions.Invoke();
    }
}
