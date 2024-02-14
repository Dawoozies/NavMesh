using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentManager : MonoBehaviour
{
    public List<NavMeshAgent> agents = new();
    public GameObject theSphere;
    Camera mainCamera;
    public LayerMask mouseCastLayerMask;
    void Start()
    {
        mainCamera = Camera.main;
        InputManager.RegisterMouseInputCallback(MouseInputHandler);
    }
    void Update()
    {
        foreach (NavMeshAgent agent in agents)
        {
            agent.SetDestination(theSphere.transform.position);
        }
    }
    void MouseInputHandler(Vector2 mouseScreenPos, Vector2 mouseWorldPos)
    {
        Ray mouseToWorldRay = mainCamera.ScreenPointToRay(mouseScreenPos);
        RaycastHit hit;
        if(Physics.Raycast(mouseToWorldRay, out hit, mainCamera.farClipPlane, mouseCastLayerMask))
        {
            theSphere.transform.position = hit.point;
        }
    }
}
