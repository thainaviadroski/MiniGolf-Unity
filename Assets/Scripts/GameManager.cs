using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private string level;
    [SerializeField] private float time;

    public void callNextLevel()
    {
        StartCoroutine(nextLeve());
    }

    private IEnumerator nextLeve()
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(level);
    }
}
