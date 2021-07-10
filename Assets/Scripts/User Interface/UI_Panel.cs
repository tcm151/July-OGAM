﻿using System;
using UnityEngine;
using UnityEngine.UI;


namespace OGAM
{

    public class UI_Panel : MonoBehaviour
    {
        new protected CanvasRenderer renderer;
        new protected RectTransform transform;

        virtual protected void Awake()
        {
            renderer = GetComponent<CanvasRenderer>();
            transform = GetComponent<RectTransform>();
        }
    }
}