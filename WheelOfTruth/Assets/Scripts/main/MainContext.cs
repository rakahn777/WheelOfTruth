﻿using UnityEngine;
using System.Collections;
using strange.extensions.context.impl;
using strange.extensions.signal.impl;
using signals;
using cmds;

public class MainContext : SignalContext 
{
    public MainContext(MonoBehaviour contextView)
        : base(contextView)
    {

    }

    protected override void mapBindings()
    {
        base.mapBindings();

        #region Injection

        injectionBinder.Bind<SignalManager>().ToSingleton().CrossContext();

        #endregion

        commandBinder.Bind<StartSignal>().InSequence()
            .To<InitDataManagerCmd>();

        #region API Request

        commandBinder.Bind<SendAPILoginEmailSignal>().To<SendAPILoginEmailCmd>();
        commandBinder.Bind<SendAPIStartWheelSignal>().To<SendAPIStartWheelCmd>();

        #endregion

        #region API Respond
        
        commandBinder.Bind<OnAPIRegisterNewUserSignal>().To<OnAPIRegisterNewUserCmd>();
        commandBinder.Bind<OnAPILoginEmailSignal>().To<OnAPILoginEmailCmd>();
        commandBinder.Bind<OnAPILogoutSignal>().To<OnAPILogoutCmd>();
        commandBinder.Bind<OnAPIGetUserInfoSignal>().To<OnAPIGetUserInfoCmd>();
        commandBinder.Bind<OnAPIStartWheelSignal>().To<OnAPIStartWheelCmd>();
        
        #endregion
    }

    protected override void postBindings()
    {
        base.postBindings();
    }

    public override void Launch()
    {
        base.Launch();
    }
}