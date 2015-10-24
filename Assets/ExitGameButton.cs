using UnityEngine;
using System.Collections;

public class ExitGameButton : MonoBehaviour
{
    public void Clicked()
    {
        Application.Quit();
        Debug.Log("ExitButtonClicked");
    }
}
