using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomLightColor : MonoBehaviour
{
    #region Variables
    // Variables.
    [SerializeField] private Light windowLight;
    #endregion

    #region Unity Methods

    void Start()
    {
        var coroutine = RandomizeLight();
        StartCoroutine(coroutine);
    }

    void Update()
    {
        
    }

    #endregion

    #region Private Methods
    // Private Methods.
    IEnumerator RandomizeLight()
    {
        while (true)
        {
            var color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            gameObject.GetComponent<Renderer>().material.color = color;
            windowLight.color = color;

            yield return new WaitForSeconds(Random.Range(.1f, 3f));
        }
    }
    #endregion

    #region Public Methods
    // Public Methods.
    
    #endregion
}
