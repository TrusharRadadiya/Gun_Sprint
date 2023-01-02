using UnityEngine;

public class RagdollToggle : MonoBehaviour
{
    public void TurnOnRagdoll()
    {
        GetComponent<Animator>().enabled = false;
    }
}
