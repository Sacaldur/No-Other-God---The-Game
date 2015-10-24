using UnityEngine;
using System.Collections;

public class LoadSceneButton : MonoBehaviour
{
    [SerializeField]
    private int sceneId = 1;


    public void Clicked()
    {
        Application.LoadLevel(this.sceneId);
    }
}
