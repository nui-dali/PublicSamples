﻿/*
* Copyright (c) 2017 Samsung Electronics Co., Ltd All Rights Reserved
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
*     http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*/

using System;
using System.Collections.Generic;
using Tizen.Sensor;

namespace Sensor.Tizen.Mobile.Sensors
{
    /// <summary>
    /// Pedometer Adapter class
    /// </summary>
    class PedometerAdapter : ISensorAdapter
    {
        private Pedometer sensor = null;
        EventHandler<PedometerDataUpdatedEventArgs> handler = null;

        /// <summary>
        /// Constructor of PedometerAdapter.
        /// </summary>
        public PedometerAdapter()
        {
        }

        /// <summary>
        /// Destructor of PedometerAdapter.
        /// </summary>
        ~PedometerAdapter()
        {
            sensor?.Dispose();
        }

        /// <summary>
        /// Gets sensor information.
        /// </summary>
        /// <returns>Sensor information.</returns>
        public SensorInfo GetSensorInfo()
        {
            SensorInfo info = new SensorInfo();
            info.Type = SensorTypes.PedometerType;

            try
            {
                sensor = new Pedometer
                {
                    Interval = 100,
                    PausePolicy = SensorPausePolicy.None
                };

                info.Name = sensor.Name;
                info.Vendor = sensor.Vendor;
                info.MinRange = sensor.MinValue;
                info.MaxRange = sensor.MaxValue;
                info.Resolution = sensor.Resolution;
                info.MinInterval = sensor.MinInterval;
            }
            catch (Exception e)
            {
                global::Tizen.Log.Info(Log.LogTag, e.Message);
                info.Status = "Permission Denied";
            }

            return info;
        }

        /// <summary>
        /// Starts sensor and registers listener to a sensor
        /// </summary>
        /// <param name="listener">Event handler to listen sensor events</param>
        public void Start(EventHandler<SensorEventArgs> listener)
        {
            handler = (sender, e) =>
            {
                listener?.Invoke(this,
                    new SensorEventArgs(new List<float>()
                    {
                            e.StepCount,
                            e.WalkStepCount,
                            e.RunStepCount,
                            e.MovingDistance,
                            e.LastSpeed,
                            e.LastSteppingFrequency,
                            (int)e.LastStepStatus
                    }));
            };

            sensor.DataUpdated += handler;
            sensor.Start();
        }

        /// <summary>
        /// Stops sensor and unregisters the listener from a sensor
        /// </summary>
        /// <param name="listener">Event handler registered</param>
        public void Stop(EventHandler<SensorEventArgs> listener)
        {
            sensor.Stop();
            sensor.DataUpdated -= handler;
        }
    }
}
