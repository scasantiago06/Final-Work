using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsController : MonoBehaviour
{
    /// <summary>
    /// I call the coroutine that is responsible for loading the main menu
    /// when the time is complete
    /// </summary>
    private void Start()
    {
        StartCoroutine(CompletedCredits());
    }

    /// <summary>
    /// This function move the gameobject constantly up
    /// </summary>
    void Update ()
    {
        transform.Translate(Vector3.up * 60 * Time.deltaTime);
    }

    /// <summary>
    /// This coroutine waits the seconds that the credits screen takes to finish 
    /// </summary>
    IEnumerator CompletedCredits()
    {
        yield return new WaitForSeconds(45);
        UIManager.Instance.ChangeScene("Main Menu");
    }
}
