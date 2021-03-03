using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class CameraBorderBlock : MonoBehaviour
{
    [SerializeField] [Range(0, 100)] private float m_borderWidthX;
    [SerializeField] [Range(0, 100)] private float m_borderWidthY;

    private Vector3 m_wPos;
    
    private Camera m_gameCam;

    private PlayerMovements m_moveScript;
    // Start is called before the first frame update
    void Start()
    {
        m_gameCam = GameManagerSingleton.Instance.m_camera;

        m_moveScript = GetComponent<PlayerMovements>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
        
        Vector3 camPos = m_gameCam.WorldToViewportPoint(transform.position);

        float posY = transform.position.y;
        
        camPos.x = Mathf.Clamp01(camPos.x + (Mathf.Sign(camPos.x-0.5f)) * (m_borderWidthX/100)) - (Mathf.Sign(camPos.x-0.5f)) * (m_borderWidthX/100);
        camPos.y = Mathf.Clamp01(camPos.y + (Mathf.Sign(camPos.y-0.5f)) * (m_borderWidthY/100)) - (Mathf.Sign(camPos.y-0.5f)) *(m_borderWidthY/100);
        
        
        transform.position = m_gameCam.ViewportToWorldPoint(new Vector3(camPos.x,camPos.y,camPos.z));

        
        transform.position = new Vector3(transform.position.x,posY,transform.position.z);
    }
}
