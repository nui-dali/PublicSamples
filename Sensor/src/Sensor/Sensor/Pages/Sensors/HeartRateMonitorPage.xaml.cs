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

using Sensor.Pages.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tizen.NUI;
using Tizen.NUI.Xaml;
using Tizen.NUI.Binding;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Sensor.Pages
{
    /// <summary>
    /// HeartRateMonitor Information Page
    /// </summary>
    public partial class HeartRateMonitorPage : ContentPage
    {
        private Sensor.Models.HeartRateMonitorViewModel heartRateMonitor;
        private EventHandler<SensorEventArgs> listener;
        private SensorInfo info;

        /// <summary>
        /// Constructor of HeartRateMonitorPage
        /// </summary>
        /// <param name="info">Sensor Information</param>
        public HeartRateMonitorPage(SensorInfo info)
        {
            InitializeComponent();

            heartRateMonitor = new Sensor.Models.HeartRateMonitorViewModel();

            BindingContext = heartRateMonitor;
            this.FindByName<SensorInfoView>("SensorInfo").BindingContext = info;
            this.info = info;

            if (info.Status == "Permission Denied")
            {
                this.FindByName<TextLabel>("Status").Text = info.Status;
            }
        }

        /// <summary>
        /// Called when start button is clicked.
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="args">Event arguments</param>
        public void StartClicked(object sender, EventArgs args)
        {
            if (info.Status == "Permission Denied")
            {
                return;
            }

            listener = (s, e) =>
            {
                heartRateMonitor.HeartRate = e.Values[0];
            };

            try
            {
                DependencyService.Get<ISensorManager>().StartSensor(info.Type, listener);
            }
            catch (Exception e)
            {
                DependencyService.Get<ILog>().Error(e.Message.ToString());
            }

            DependencyService.Get<ILog>().Info("Sensor Start");
        }

        /// <summary>
        /// Called when stop button is clicked.
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="args">Event arguments</param>
        public void StopClicked(object sender, EventArgs args)
        {
            if (info.Status == "Permission Denied")
            {
                return;
            }

            try
            {
                DependencyService.Get<ISensorManager>().StopSensor(info.Type, listener);
            }
            catch (Exception e)
            {
                DependencyService.Get<ILog>().Error(e.Message.ToString());
            }


            DependencyService.Get<ILog>().Info("Sensor Stop");
        }
    }
}
