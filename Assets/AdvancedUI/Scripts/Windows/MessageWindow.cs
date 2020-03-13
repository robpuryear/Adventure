using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageWindow : GenericWindow
{
    private Text textInstance;
    public float closeDelay = 2f;
    private float delay;
    private bool closing;

    public string text
    {
        set
        {
            textInstance.text = value;
        }
    }

    protected override void Awake()
    {
        textInstance = GetComponentInChildren<Text>();

        base.Awake();
    }

    public override void Open()
    {
        base.Open();
        closing = true;
        delay = 0;
    }

    private void Update()
    {
        if (closing)
        {
            delay += Time.deltaTime;

            if(delay >= closeDelay)
            {
                Close();
                closing = false;
            }
        }
    }
}
