using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsController : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(CompletedCredits());
       // AudioManager.Instance.PlayMusic(0);
    }

    void Update ()
    {
        transform.Translate(Vector3.up * 60 * Time.deltaTime);
    }

    IEnumerator CompletedCredits()
    {
        yield return new WaitForSeconds(45);
        UIManager.Instance.ChangeScene("Main Menu");
    }
}
