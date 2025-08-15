using UnityEngine;
using UnityEngine.AI;

namespace LlamAcademy.NavigationLS
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class ShowAgentPath : MonoBehaviour
    {
        [SerializeField] private Material LineMaterial;

        private NavMeshAgent Agent;
        private GameObject PathRenderer;
        private LineRenderer LineRenderer;

        private void Awake()
        {
            Agent = GetComponent<NavMeshAgent>();
            PathRenderer = new GameObject("Path Renderer");
            LineRenderer = PathRenderer.AddComponent<LineRenderer>();
            LineRenderer.useWorldSpace = true;
            LineRenderer.enabled = false;
            LineRenderer.startWidth = 0.2f;
            LineRenderer.endWidth = 0.2f;
        }

        private void Update()
        {
            if (Agent.enabled && Agent.hasPath)
            {
                LineRenderer.enabled = true;
                Vector3[] corners = Agent.path.corners;
                LineRenderer.positionCount = corners.Length;
                LineRenderer.SetPositions(corners);
            }
            else
            {
                LineRenderer.enabled = false;
            }
        }
    }

}
