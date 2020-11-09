using System;
using System.Collections.Generic;

namespace OKHOSTING.UI.Animations
{
    /// <remarks>
    /// Based on a great project by Uwe Keim https://github.com/UweKeim/dot-net-transitions
    /// </remarks>
    internal class TransitionChain
    {
        #region Public methods

        public TransitionChain(params Transition[] transitions)
        {
            // We store the list of transitions...
            foreach (Transition transition in transitions)
            {
                ListTransitions.AddLast(transition);
            }

            // We start running them...
            RunNextTransition();
        }

        #endregion

        #region Private functions

        /// <summary>
        /// Runs the next transition in the list.
        /// </summary>
        private void RunNextTransition()
        {
            if (ListTransitions.Count == 0)
            {
                return;
            }

            // We find the next transition and run it. We also register
            // for its completed event, so that we can start the next transition
            // when this one completes...
            Transition nextTransition = ListTransitions.First.Value;
            nextTransition.TransitionCompleted += OnTransitionCompleted;
            nextTransition.Run();
        }

        /// <summary>
        /// Called when the transition we have just run has completed.
        /// </summary>
        private void OnTransitionCompleted(object sender, EventArgs e)
        {
            // We unregister from the completed event...
            Transition transition = (Transition)sender;
            transition.TransitionCompleted -= OnTransitionCompleted;

            // We remove the completed transition from our collection, and
            // run the next one...
            ListTransitions.RemoveFirst();
            RunNextTransition();
        }

        #endregion

        #region Private data

        // The list of transitions in the chain...
        private LinkedList<Transition> ListTransitions = new LinkedList<Transition>();

        #endregion
    }
}
