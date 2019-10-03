namespace VRTK.Examples
{
    using UnityEngine;
    public class ObjectControllerEventHandler : MonoBehaviour
    {
        [HideInInspector]
        private ObjectController rcCarScript;
        private Vector2 touchAxis;
        private float triggerAxis;
        
        GameObject gameobjecRightController;
        GameObject gameobjecLeftController;
        private void Start()
        {
            RightControllerSetup();
            LeftControllerSetup();
        }
        void RightControllerSetup()
        {
            gameobjecRightController = GameObject.FindGameObjectWithTag("RightController");
            gameobjecRightController.GetComponent<VRTK_ControllerEvents>().TriggerAxisChanged += new ControllerInteractionEventHandler(DoTriggerAxisChanged);
            gameobjecRightController.GetComponent<VRTK_ControllerEvents>().TouchpadReleased += new ControllerInteractionEventHandler(DoTouchpadReleased);
            gameobjecRightController.GetComponent<VRTK_ControllerEvents>().TouchpadPressed += new ControllerInteractionEventHandler(DoTouchpadAxisChanged);
            gameobjecRightController.GetComponent<VRTK_ControllerEvents>().TriggerReleased += new ControllerInteractionEventHandler(DoTriggerReleased);
            gameobjecRightController.GetComponent<VRTK_ControllerEvents>().TouchpadTouchEnd += new ControllerInteractionEventHandler(DoTouchpadTouchEnd);
        }
        void LeftControllerSetup()
        {
            gameobjecLeftController = GameObject.FindGameObjectWithTag("LeftController");
            gameobjecLeftController.GetComponent<VRTK_ControllerEvents>().TriggerAxisChanged += new ControllerInteractionEventHandler(DoTriggerAxisChanged);
            gameobjecLeftController.GetComponent<VRTK_ControllerEvents>().TouchpadReleased += new ControllerInteractionEventHandler(DoTouchpadReleased);
            gameobjecLeftController.GetComponent<VRTK_ControllerEvents>().TouchpadPressed += new ControllerInteractionEventHandler(DoTouchpadAxisChanged);
            gameobjecLeftController.GetComponent<VRTK_ControllerEvents>().TriggerReleased += new ControllerInteractionEventHandler(DoTriggerReleased);
            gameobjecLeftController.GetComponent<VRTK_ControllerEvents>().TouchpadTouchEnd += new ControllerInteractionEventHandler(DoTouchpadTouchEnd);
        }

        private void Update()
        {
            if (GetComponent<VRTK_InteractableObject>().IsTouched())
            {
                Turn();
            }
        }
        private void DoTouchpadAxisChanged(object sender, ControllerInteractionEventArgs e)
        {
            touchAxis = e.touchpadAxis;

        }
        private void DoTouchpadReleased(object sender, ControllerInteractionEventArgs e)
        {
            touchAxis = new Vector2(500, 500);
        }

        private void DoTriggerAxisChanged(object sender, ControllerInteractionEventArgs e)
        {
            triggerAxis=e.buttonPressure;
        }

        private void DoTouchpadTouchEnd(object sender, ControllerInteractionEventArgs e)
        {
            touchAxis = Vector2.zero;
        }

        private void DoTriggerReleased(object sender, ControllerInteractionEventArgs e)
        {
            triggerAxis=0f;
        }


        private void Turn()
        {
            if (touchAxis != new Vector2(500, 500))
            {
                //rotation
                if (touchAxis.x < .5)
                {
                    gameObject.transform.eulerAngles += new Vector3(0, 10f, 0);
                }

                if (touchAxis.x > -.5)
                {
                    gameObject.transform.eulerAngles -= new Vector3(0, 10f, 0);
                }

                //scale
                if (touchAxis.y < .5)
                {
                    gameObject.transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
                }

                if (touchAxis.y > -.5)
                {
                    gameObject.transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
                }

            }
        }

    }
}