using UnityEngine;

public class HighScoreActivator : MonoBehaviour
{
    [SerializeField] private GameObject objectToActivate;

    public void ActivateObject()
    {
        if (objectToActivate != null)
        {
            objectToActivate.SetActive(true);
            Invoke("DeactivateObject", 3f);
        }

    }

    private void DeactivateObject()
    {
        if (objectToActivate != null)
        {
            objectToActivate.SetActive(false);
        }
    }
}
