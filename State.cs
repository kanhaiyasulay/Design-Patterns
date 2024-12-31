// DYNAMIC POLYMORPHISM    
/* a single object (LocomotionStatePattern) is dynamically changing its behavior by switching 
 between different state classes (GroundedState, InAirState, CrouchingState). */
using System;         
namespace  std
{
    public interface LocomotionContext
    {
        void SetState(LocomotionState newState);
    }

    public interface LocomotionState
    {
        void Jump(LocomotionContext context);
        void Fall(LocomotionContext context);
        void Land(LocomotionContext context);
        void Crouch(LocomotionContext context);
    }

    public class LocomotionStatePattern : LocomotionContext
    {
        private LocomotionState currentState;

        public LocomotionStatePattern()    // constructor
        {
            // Initial state is Grounded
            currentState = new GroundedState();
            Console.WriteLine("Initial State: Grounded");
        }

        public void SetState(LocomotionState newState)
        {
            currentState = newState;
        }

        public void Crouch()
        {
            currentState.Crouch(this);
        }

        public void Fall()
        {
            currentState.Fall(this);
        }

        public void Jump()
        {
            currentState.Jump(this);
        }

        public void Land()
        {
            currentState.Land(this);
        }
    }

    public class GroundedState : LocomotionState
    {
        public void Crouch(LocomotionContext context)
        {
            Console.WriteLine("Transitioning to Crouching State");
            context.SetState(new CrouchingState());
        }

        public void Fall(LocomotionContext context)
        {
            Console.WriteLine("Transitioning to In-Air State");
            context.SetState(new InAirState());
        }

        public void Jump(LocomotionContext context)
        {
            Console.WriteLine("Jumping and transitioning to In-Air State");
            context.SetState(new InAirState());
        }

        public void Land(LocomotionContext context)
        {
            Console.WriteLine("Already Grounded");
        }
    }

    public class InAirState : LocomotionState
    {
        public void Crouch(LocomotionContext context)
        {
            Console.WriteLine("Cannot crouch while in the air");
        }

        public void Fall(LocomotionContext context)
        {
            Console.WriteLine("Already in the air, falling");
        }

        public void Jump(LocomotionContext context)
        {
            Console.WriteLine("Already in the air, cannot jump again");
        }

        public void Land(LocomotionContext context)
        {
            Console.WriteLine("Landed and transitioning to Grounded State");
            context.SetState(new GroundedState());
        }
    }

    public class CrouchingState : LocomotionState
    {
        public void Crouch(LocomotionContext context)
        {
            Console.WriteLine("Already crouching");
        }

        public void Fall(LocomotionContext context)
        {
            Console.WriteLine("Falling from crouching and transitioning to In-Air State");
            context.SetState(new InAirState());
        }

        public void Jump(LocomotionContext context)
        {
            Console.WriteLine("Jumping from crouch and transitioning to Grounded State");
            context.SetState(new GroundedState());
        }

        public void Land(LocomotionContext context)
        {
            Console.WriteLine("Already crouching on the ground");
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            LocomotionStatePattern locomotion = new LocomotionStatePattern();

            locomotion.Jump();  // Transition to In-Air State
            locomotion.Land();  // Transition to Grounded State
            locomotion.Crouch(); // Transition to Crouching State
            locomotion.Fall();  // Transition to In-Air State
            locomotion.Land();  // Transition to Grounded State
        }
    }
}


    // public void Crouch() => currentState.Crouch(this);
    // public void Fall() => currentState.Fall(this);
    // public void Jump() => currentState.Jump(this);
    // public void Land() => currentState.Land(this);