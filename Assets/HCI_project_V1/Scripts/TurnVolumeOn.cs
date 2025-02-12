﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TurnVolumeOn : MonoBehaviour
{
    public float totalTime = 3f;
    private bool isLookedAt;
    private float timeDuration = 0f;
    public GameObject[] audioSources;
    public Text notification;

    void Start()
    {
        SetGazedAt(false);
    }
    void Update()
    {
        if (isLookedAt)
        {
            timeDuration += Time.deltaTime;
            if (timeDuration > totalTime)
            {
                timeDuration = 0;
                foreach (GameObject g in audioSources)
                    g.GetComponent<AudioSource>().volume = 1;
                StartCoroutine(PrintText("Music turned on", 0f));
                StartCoroutine(PrintText("Please refer to Eliza for assisstance", 5f));
            }
        }
        else
        {
            timeDuration = 0;
        }

    }
    public void SetGazedAt(bool gazedAt)
    {
        isLookedAt = gazedAt;
        return;
    }
    void OnEnable()
    {
        SetGazedAt(false);
    }
    IEnumerator PrintText(string s, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        notification.text = s;
    }
}
