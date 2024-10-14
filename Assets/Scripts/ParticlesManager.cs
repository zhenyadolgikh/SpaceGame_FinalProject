using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesManager : MonoBehaviour
{
    public GameObject[] particleEffects = new GameObject[7];
    public float spawnDistance = 3f;
    public Camera mainCamera;
    public Canvas canvas;

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
        }
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
    public void PlayParticleEffect(int index)
    {
        if (index >= 0 && index < particleEffects.Length && particleEffects[index] != null)
        {
            //spawn particles in front of the camera
            Vector3 spawnPosition = mainCamera.transform.position + mainCamera.transform.forward * spawnDistance;
            GameObject effect = Instantiate(particleEffects[index], spawnPosition, Quaternion.identity);

            // parent to follow the camera
            effect.transform.parent = mainCamera.transform;

            //so particles wont transform after parent
            effect.transform.localScale = Vector3.one;

        }
    }
    }