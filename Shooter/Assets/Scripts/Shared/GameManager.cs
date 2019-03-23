﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager   {
    public event System.Action<Player> OnLocalPlayerJoined;

    private GameObject gameObject;
    private static GameManager m_Instance;

    public static GameManager Instance
    {
        get
        {
            if (m_Instance == null)
            {

                m_Instance = new GameManager();
                m_Instance.gameObject = new GameObject("_gameManager");
                m_Instance.gameObject.AddComponent<InputController>();
                m_Instance.gameObject.AddComponent<Timer>();
                m_Instance.gameObject.AddComponent<Respawner>();
                

            }
            return m_Instance;

        }
        set
        {
            m_Instance = value;
        }
    }

    private InputController m_InputeController;
    public InputController InputController
    {
        get
        {
            if (m_InputeController == null)
            {
                m_InputeController = gameObject.GetComponent<InputController>();
            }
            return m_InputeController;
        }
        set
        {
            m_InputeController = value;
        }
    }

    private Timer m_Timer;
    public Timer Timer
    {
        get
        {
            if (m_Timer == null)
                m_Timer = gameObject.GetComponent<Timer>();
            return m_Timer;
        }
    }
    private Respawner m_Respawner;
    public Respawner Respawner
    {
        get
        {
            if (m_Respawner == null)
                m_Respawner = gameObject.GetComponent<Respawner>();
            return m_Respawner;

        }
    }
    public static void FixIssue()
    {
        m_Instance = new GameManager();
        m_Instance.gameObject = new GameObject("_gameManager");
        m_Instance.gameObject.AddComponent<InputController>();
        m_Instance.gameObject.AddComponent<Timer>();
        m_Instance.gameObject.AddComponent<Respawner>();
    }
   

    private Player m_LocalPlayer;
    public Player LocalPlayer
    {
        get
        {
            return m_LocalPlayer;
        }
        set
        {
            m_LocalPlayer = value;
            if (OnLocalPlayerJoined != null)
                OnLocalPlayerJoined(m_LocalPlayer);
        }
    }

   


}
