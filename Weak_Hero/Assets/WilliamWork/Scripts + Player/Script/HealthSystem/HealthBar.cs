using UnityEngine;

using Image = UnityEngine.UI.Image;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image HealthTotal;
    [SerializeField] private Image HealthCurrent;

    private void Start()
    {
        HealthCurrent.fillAmount = playerHealth.currentHealth / 18;
    }

    private void Update()
    {
        HealthCurrent.fillAmount = playerHealth.currentHealth / 18;
    }
}
