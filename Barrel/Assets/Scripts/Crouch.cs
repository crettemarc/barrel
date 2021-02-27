using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Crouch : MonoBehaviour
{

    public GameObject player;

    private CharacterController m_CharacterController;

    private bool m_Crouch = false;

    public KeyCode crouchKey = KeyCode.LeftControl;
    private FirstPersonController firstPersonController;

    private float m_OriginalHeight;

    [SerializeField] private float m_CrouchHeight = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        m_CharacterController = player.GetComponent<CharacterController>();
        m_OriginalHeight = m_CharacterController.height;
        firstPersonController = player.GetComponent<FirstPersonController>();
    }

    // Update is called once per frame
    void Update()
    {

        if(player.name == "FPSController"+firstPersonController.playerNumber)
        {

            if(Input.GetButtonDown("crouch"+firstPersonController.playerNumber))
            {
                m_Crouch = !m_Crouch;

                CheckCrouch();
            }
            
            if(Input.GetButtonUp("crouch"+firstPersonController.playerNumber))
            {
                m_Crouch = !m_Crouch;

                CheckCrouch();
            }
        }

    }

    void CheckCrouch()
    {
        if(m_Crouch == true)
        {
            m_CharacterController.height = m_CrouchHeight;
        }
        else
        {
            m_CharacterController.height = m_OriginalHeight;
        }
    }


}