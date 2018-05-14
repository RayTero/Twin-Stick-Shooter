using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private float fillAmount;

    [SerializeField] 
    private Image content;

    [SerializeField]
    private float lerpspeed;

    [SerializeField]
    private Color fullColor;

    [SerializeField]
    private Color lowColor;


    public float MaxValue { get; set; }

    public float Value
    {
        set
        {
            fillAmount = map(value, 0, MaxValue, 0, 1);
        }
    }

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        handleHealtBar();
	}

    // deze fuctie gaat de healthbar updaten
    private void handleHealtBar()
    { 
        if(fillAmount != content.fillAmount)
        {
            content.fillAmount = Mathf.Lerp(content.fillAmount, fillAmount, Time.deltaTime * lerpspeed);
        }
        if (content.fillAmount <= .4f)
        {
            content.color = Color.Lerp(lowColor, fullColor, fillAmount);
        }
       
    }

    private float map(float value, float inMin, float inMax, float outMin, float outMax) 
    {
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }
}
