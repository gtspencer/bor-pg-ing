using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FPSCounter : MonoBehaviour
{
    [SerializeField] private bool useAverage = true;
    private TextMeshProUGUI fpsText;
    private float fps;
    // Start is called before the first frame update
    void Start()
    {
        fpsText = this.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (useAverage)
            fps = Time.frameCount / Time.time;
        else
            fps = (int)(1f / Time.unscaledDeltaTime);

        fpsText.text = fps.ToString("n0");
    }
}
