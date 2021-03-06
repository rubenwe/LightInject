﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LightInject.SampleLibraryWithCompositionRootTypeAttribute
{
    public class CompositionRoot : ICompositionRoot
    {
        [ThreadStatic]
        private static int callCount;

        public static int CallCount
        {
            get
            {
                return callCount;
            }
            set
            {
                callCount = value;
            }
        }

        void ICompositionRoot.Compose(IServiceRegistry serviceRegistry)
        {
            CallCount++;
            serviceRegistry.Register<IFoo,Foo>();

            serviceRegistry.RegisterFallback((type, s) => type == typeof(IBar), request => new Bar());
        }
    }
}
