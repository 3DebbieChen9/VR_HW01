using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.XR.Interaction.Toolkit.Inputs;

namespace UnityEngine.XR.Interaction.Toolkit
{
    /// <summary>
    /// A locomotion provider that allows the user to rotate their rig using a 2D axis input
    /// from an input system action.
    /// </summary>
    [AddComponentMenu("XR/Locomotion/Weapon Switch Provider (Action-based)")]
    [HelpURL(XRHelpURLConstants.k_ActionBasedSnapTurnProvider)]
    public class ActionBasedWeaponSwitchProvider : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("The Input System Action that will be used to read weapon switch data from the left hand controller. Must be a Value Vector2 Control.")]
        InputActionProperty m_LeftHandWeaponSwitchAction;
        /// <summary>
        /// The Input System Action that will be used to read Snap Turn data sent from the left hand controller. Must be a <see cref="InputActionType.Value"/> <see cref="Vector2Control"/> Control.
        /// </summary>
        public InputActionProperty leftHandWeaponSwitchAction
        {
            get => m_LeftHandWeaponSwitchAction;
            set => SetInputActionProperty(ref m_LeftHandWeaponSwitchAction, value);
        }


        /// <summary>
        /// See <see cref="MonoBehaviour"/>.
        /// </summary>
        protected void OnEnable()
        {
            m_LeftHandWeaponSwitchAction.EnableDirectAction();
        }

        /// <summary>
        /// See <see cref="MonoBehaviour"/>.
        /// </summary>
        protected void OnDisable()
        {
            m_LeftHandWeaponSwitchAction.DisableDirectAction();
        }

        /// <inheritdoc />
        public float ReadInput()
        {
            var leftHandValue = m_LeftHandWeaponSwitchAction.action?.ReadValue<float>() ?? 0.0f;
            return leftHandValue;
        }

        void SetInputActionProperty(ref InputActionProperty property, InputActionProperty value)
        {
            if (Application.isPlaying)
                property.DisableDirectAction();

            property = value;

            if (Application.isPlaying && isActiveAndEnabled)
                property.EnableDirectAction();
        }
    }
}
