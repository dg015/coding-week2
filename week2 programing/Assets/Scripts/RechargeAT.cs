using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace NodeCanvas.Tasks.Actions {

	public class RechargeAT : ActionTask {

        private Blackboard agentBlackboard;
		public float chargeGainRate = 20;
        public Transform target;
        private float speed;
        public float arrivalDistance;

        public BBParameter<float> charge;


        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {

            return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {

			
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
            


            Vector3 moveDiecion = (target.position - agent.transform.position).normalized;
            agent.transform.position += moveDiecion * speed * Time.deltaTime;

            float distanceToTarget = Vector3.Distance(target.position, agent.transform.position);
            if (distanceToTarget < arrivalDistance)
            {
                charge.value += chargeGainRate * Time.deltaTime;
                agentBlackboard.SetVariableValue("Charge", charge);
                if (charge.value >= 100)
                {
                    EndAction(true);
                    Debug.Log("done chargin");
                }
            }





        }

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}