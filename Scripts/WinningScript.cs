using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class WinningScript : MonoBehaviour
{
   [SerializeField] private Material winninMaterial;
   [SerializeField] private GameObject winningUi;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator WinningRoutine()
    {
        GetComponent<MeshRenderer>().material = winninMaterial;
        winningUi.SetActive(true);
        Time.timeScale = 0.1f;
        yield return new WaitForSeconds(3f);

        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(WinningRoutine());
    }
}
