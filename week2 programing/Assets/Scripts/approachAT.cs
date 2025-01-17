using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.EventSystems;


namespace NodeCanvas.Tasks.Actions {

	public class approachAT : ActionTask {

		public Transform target;
		private float speed;
		public float arrivalDistance;
		public float chargeUseRate;

		private Blackboard agentBlackboard;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			agentBlackboard = agent.GetComponent<Blackboard>();

			speed = agentBlackboard.GetVariableValue<float>("speed");


			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {



		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
            float charge = agentBlackboard.GetVariableValue<float>("Charge");
			charge -= chargeUseRate * Time.deltaTime;
			agentBlackboard.SetVariableValue("Charge", charge);

            Vector3 moveDiecion = (target.position - agent.transform.position).normalized;
            agent.transform.position += moveDiecion * speed * Time.deltaTime;

            float distanceToTarget = Vector3.Distance(target.position, agent.transform.position);
            if (distanceToTarget < arrivalDistance)
            {
                EndAction(true);
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