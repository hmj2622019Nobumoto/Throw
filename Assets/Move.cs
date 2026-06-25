using UnityEngine;
using UnityEngine.InputSystem;

public class Move : MonoBehaviour
{ 
    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.aKey.wasPressedThisFrame)
        {
            transform.Translate(-1, 0 , 0);
        }
        if (Keyboard.current.dKey.wasPressedThisFrame)
        {
            transform.Translate(1, 0 , 0);
        }
    }
}
