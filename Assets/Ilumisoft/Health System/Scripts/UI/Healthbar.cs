using UnityEngine;
using UnityEngine.UI;

namespace Ilumisoft.HealthSystem.UI
{
    [AddComponentMenu("Health System/UI/Healthbar")]
    [RequireComponent(typeof(Canvas))]
    public class Healthbar : MonoBehaviour
    {
        [field: SerializeField]
        public HealthComponent Health { get; set; }

        [SerializeField]
        Canvas canvas;

        [SerializeField]
        Image fillImage;

        [SerializeField, Tooltip("Whether the healthbar should be hidden when health is empty")]
        bool hideEmpty = true;

        [SerializeField, Tooltip("Makes the healthbar being aligned with the camera")]
        bool alignWithCamera = true;

        [SerializeField, Min(0.1f), Tooltip("Controls how fast changes will be animated in points/second")]
        float changeSpeed = 100f;

        float currentValue;
        Camera mainCamera;

        protected virtual void Reset()
        {
            // Automatically assign components
            canvas = GetComponent<Canvas>();
            fillImage = GetComponentInChildren<Image>();
            
            // Try to find HealthComponent in parent or children
            if (Health == null)
            {
                Health = GetComponentInParent<HealthComponent>();
                if (Health == null)
                {
                    Health = GetComponentInChildren<HealthComponent>();
                }
            }
        }

        private void Awake()
        {
            // Cache main camera
            mainCamera = Camera.main;

            // Validate components
            if (canvas == null)
            {
                canvas = GetComponent<Canvas>();
                if (canvas == null)
                {
                    Debug.LogError("Healthbar requires a Canvas component!", gameObject);
                    enabled = false;
                    return;
                }
            }

            if (fillImage == null)
            {
                Debug.LogError("Healthbar requires an Image component for the fill bar!", gameObject);
                enabled = false;
                return;
            }

            if (Health == null)
            {
                Debug.LogWarning("Healthbar is missing HealthComponent reference!", gameObject);
                enabled = false;
                return;
            }
        }

        private void Start()
        {
            if (Health != null)
            {
                currentValue = Health.CurrentHealth;
                UpdateFillbar();
                UpdateVisibility();
            }
        }

        private void OnEnable()
        {
            if (Health != null)
            {
                Health.OnHealthChanged += OnHealthChanged;
            }
        }

        private void OnDisable()
        {
            if (Health != null)
            {
                Health.OnHealthChanged -= OnHealthChanged;
            }
        }

        private void Update()
        {
            if (!enabled || Health == null) return;

            if (alignWithCamera && mainCamera != null)
            {
                AlignWithCamera();
            }

            currentValue = Mathf.MoveTowards(currentValue, Health.CurrentHealth, Time.deltaTime * changeSpeed);
            
            UpdateFillbar();
            UpdateVisibility();
        }

        private void AlignWithCamera()
        {
            transform.forward = mainCamera.transform.forward;
        }

        private void OnHealthChanged(float newHealth)
        {
            currentValue = newHealth;
            UpdateFillbar();
            UpdateVisibility();
        }

        private void UpdateFillbar()
        {
            if (fillImage == null || Health == null) return;

            float value = Mathf.InverseLerp(0, Health.MaxHealth, currentValue);
            fillImage.fillAmount = Mathf.Clamp01(value);
        }

        private void UpdateVisibility()
        {
            if (canvas == null) return;

            float value = fillImage != null ? fillImage.fillAmount : 0f;

            if (hideEmpty && Mathf.Approximately(value, 0f))
            {
                if (canvas.gameObject.activeSelf)
                {
                    canvas.gameObject.SetActive(false);
                }
            }
            else if (value > 0f && !canvas.gameObject.activeSelf)
            {
                canvas.gameObject.SetActive(true);
            }
        }
    }
}