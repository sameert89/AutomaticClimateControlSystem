﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomaticClimateControlSystem
{
    public interface ISubscriber
    {
        public void OnEventHandler(object @event);
    }
}
