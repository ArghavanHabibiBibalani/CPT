using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StatePattern
{
    internal interface IAppStateMachine
    {
        public void TransitionTo(AppStateType targetStateType);
        public TestSettings testSettings { get; }
    }
}
