using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesManager : MonoBehaviour
{
    public GameObject[] particleEffects = new GameObject[7];
    //public float spawnDistance = 3f;
    public Camera mainCamera;
    public Canvas canvas; // Add reference to the UI canvas


    void Start()
    {
    
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            PlayParticleEffect(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            PlayParticleEffect(1);
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            PlayParticleEffect(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            PlayParticleEffect(3); 
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            PlayParticleEffect(4);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            PlayParticleEffect(5);
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            PlayParticleEffect(6);
        }
    }

    //void PlayParticleEffect(int index)
    //{
      //if (index >= 0 && index < particleEffects.Length && particleEffects[index] != null)
        //{
        
          //Vector3 spawnPosition = mainCamera.transform.position + mainCamera.transform.forward * spawnDistance;
          //GameObject effect = Instantiate(particleEffects[index], spawnPosition, Quaternion.identity);

        //}
    //}

    void PlayParticleEffect(int index)
    {
        if (index >= 0 && index < particleEffects.Length && particleEffects[index] != null)
        {
            // Spawn particle effect on canvas
            GameObject effect = Instantiate(particleEffects[index], canvas.transform);
            
            // Optional: Set the position to the center of the canvas (or where needed)
            RectTransform canvasRect = canvas.GetComponent<RectTransform>();
            effect.transform.localPosition = new Vector3(0, 0, 0); // Adjust as needed
        }
    }
}
}
