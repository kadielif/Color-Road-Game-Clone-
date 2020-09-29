using UnityEngine;

namespace PathCreation.Examples
{
    // Moves along a path at constant speed.
    // Depending on the end of path instruction, will either loop, reverse, or stop at the end of the path.
    public class PathFollower : MonoBehaviour
    {
        public PathCreator pathCreator;
        public EndOfPathInstruction endOfPathInstruction;
        public float speed = 5;
        public GameObject ball;
        float distanceTravelled;
        Vector3 pos;

        void Start()
        {
            ball.transform.position = new Vector3(ball.transform.position.x, 0.3f, ball.transform.position.y);
            if (pathCreator != null)
            {
                // Subscribed to the pathUpdated event so that we're notified if the path changes during the game
                pathCreator.pathUpdated += OnPathChanged;
            }
        }

        void FixedUpdate()
        {
            if (pathCreator != null && UIManager.instance.isStart==true)
            {
                distanceTravelled += speed * Time.fixedDeltaTime;
                pos = new Vector3(-0.3f, InputManager.instance.input.x, ball.transform.localPosition.z);
                ball.transform.localPosition = pos.normalized;
                //ball.transform.localPosition = new Vector3(-0.3f,InputManager.instance.input.x,transform.localPosition.z);
                transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
                transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
            }


        }
        // If the path changes during the game, update the distance travelled so that the follower's position on the new path
        // is as close as possible to its position on the old path
        void OnPathChanged()
        {
            distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
        }

    }
}