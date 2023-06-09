using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LODManager : MonoBehaviour
{
    public GameObject[] LODs;
    public GameObject player;
    public GameObject model;
    public int lod = 0;
    public float[] distances;
    public bool useSlider = false;
    public Slider slider;
    public TextMeshProUGUI[] LODinfoText;
    public Toggle useSliderToggle;

    // Update is called once per frame
    void Update()
    {
        useSlider = useSliderToggle.isOn;
        if (!useSlider)
        {
            float distance = Vector3.Distance(player.transform.position, model.transform.position);
            int LOD_index = LODs.Length - 1;
            for (int i = 0; i < distances.Length; i++)
            {
                if (distance < distances[i])
                {
                    LOD_index = i;
                    break;
                }
            }
            for (int i = 0; i < LODs.Length; i++)
            {
                if (i == LOD_index)
                {
                    LODs[i].SetActive(true);
                    LODinfoText[i].color = Color.red;
                }
                else
                {
                    LODs[i].SetActive(false);
                    LODinfoText[i].color = Color.black;
                }
            }
        }
        else 
        {
            float val = slider.value;
            int LOD_index = (int)(val * LODs.Length) != LODs.Length ? (int)(val * LODs.Length) : LODs.Length - 1;
            for (int i = 0; i < LODs.Length; i++)
            {
                if (i == LOD_index)
                {
                    LODs[i].SetActive(true);
                    LODinfoText[i].color = Color.red;
                }
                else
                {
                    LODs[i].SetActive(false);
                    LODinfoText[i].color = Color.black;
                }
            }
        }
    }
}
