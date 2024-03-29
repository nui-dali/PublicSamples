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

using System.Collections.Generic;
using System.Collections.ObjectModel;

using Tizen.NUI;
using Tizen.NUI.Binding;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Sensor.Pages
{
    /// <summary>
    /// Main Content Page with the supported sensor list on the current device.
    /// </summary>
    public partial class SensorMain : ContentPage
    {
        ISensorManager sensorManager = DependencyService.Get<ISensorManager>();

        public ObservableCollection<string> Items { get; set; }

        /// <summary>
        /// The constructor of SensorMain.
        /// </summary>
        public SensorMain()
        {
            InitializeComponent();

            Items = new ObservableCollection<string>();

            /* Add Sensor List */
            List<string> types = sensorManager.GetSensorTypeList();
            foreach (var type in types)
            {
                Items.Add(type);
            }

            MyListView.ItemsSource = Items;
        }

        /// <summary>
        /// This method will be called when a list item is selected.
        /// </summary>
        /// <param name="sender">Event sender</param>
        /// <param name="e">Event arguments</param>
        void OnItemSelected(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection == null)
            {
                return;
            }

            //Deselect Item
            ((CollectionView)sender).SelectedItem = null;

            SensorInfo info = sensorManager.GetSensorInfo((e.CurrentSelection as TextLabel).Text as string);
            OpenSensorPage(info);
        }

        /// <summary>
        /// Opens specific sensor page.
        /// </summary>
        /// <param name="info">Sensor information</param>
        public void OpenSensorPage(SensorInfo info)
        {
            if (info.Type == SensorTypes.AccelerometerType)
            {
                //await Navigation.PushAsync(new AccelerometerPage(info));
                Window.Instance.GetDefaultNavigator().Push(new AccelerometerPage(info));
            }

            if (info.Type == SensorTypes.FaceDownGestureDetectorType)
            {
                //await Navigation.PushAsync(new FaceDownGestureDetectorPage(info));
                Window.Instance.GetDefaultNavigator().Push(new FaceDownGestureDetectorPage(info));
            }

            if (info.Type == SensorTypes.GravitySensorType)
            {
                //await Navigation.PushAsync(new GravitySensorPage(info));
                Window.Instance.GetDefaultNavigator().Push(new GravitySensorPage(info));
            }

            if (info.Type == SensorTypes.GyroscopeType)
            {
                //await Navigation.PushAsync(new GyroscopePage(info));
                Window.Instance.GetDefaultNavigator().Push(new GyroscopePage(info));
            }

            if (info.Type == SensorTypes.GyroscopeRotationVectorType)
            {
                //await Navigation.PushAsync(new GyroscopeRotationVectorSensorPage(info));
                Window.Instance.GetDefaultNavigator().Push(new GyroscopeRotationVectorSensorPage(info));
            }

            if (info.Type == SensorTypes.HeartRateMonitorType)
            {
                //await Navigation.PushAsync(new HeartRateMonitorPage(info));
                Window.Instance.GetDefaultNavigator().Push(new HeartRateMonitorPage(info));
            }

            if (info.Type == SensorTypes.HumiditySensorType)
            {
                //await Navigation.PushAsync(new HumiditySensorPage(info));
                Window.Instance.GetDefaultNavigator().Push(new HumiditySensorPage(info));
            }

            if (info.Type == SensorTypes.InVehicleActivityDetectorType)
            {
                //await Navigation.PushAsync(new InVehicleActivityDetectorPage(info));
                Window.Instance.GetDefaultNavigator().Push(new InVehicleActivityDetectorPage(info));
            }

            if (info.Type == SensorTypes.LightSensorType)
            {
                //await Navigation.PushAsync(new LightSensorPage(info));
                Window.Instance.GetDefaultNavigator().Push(new LightSensorPage(info));
            }

            if (info.Type == SensorTypes.LinearAccelerationSensorType)
            {
                //await Navigation.PushAsync(new LinearAccelerationSensorPage(info));
                Window.Instance.GetDefaultNavigator().Push(new LinearAccelerationSensorPage(info));
            }

            if (info.Type == SensorTypes.MagnetometerType)
            {
                //await Navigation.PushAsync(new MagnetometerPage(info));
                Window.Instance.GetDefaultNavigator().Push(new MagnetometerPage(info));
            }

            if (info.Type == SensorTypes.MagnetometerRotationVectorType)
            {
                //await Navigation.PushAsync(new MagnetometerRotationVectorSensorPage(info));
                Window.Instance.GetDefaultNavigator().Push(new MagnetometerRotationVectorSensorPage(info));
            }

            if (info.Type == SensorTypes.OrientationSensorType)
            {
                //await Navigation.PushAsync(new OrientationSensorPage(info));
                Window.Instance.GetDefaultNavigator().Push(new OrientationSensorPage(info));
            }

            if (info.Type == SensorTypes.PedometerType)
            {
                //await Navigation.PushAsync(new PedometerPage(info));
                Window.Instance.GetDefaultNavigator().Push(new PedometerPage(info));
            }

            if (info.Type == SensorTypes.PickUpGestureDetectorType)
            {
                //await Navigation.PushAsync(new PickUpGestureDetectorPage(info));
                Window.Instance.GetDefaultNavigator().Push(new PickUpGestureDetectorPage(info));
            }

            if (info.Type == SensorTypes.PressureSensorType)
            {
                //await Navigation.PushAsync(new PressureSensorPage(info));
                Window.Instance.GetDefaultNavigator().Push(new PressureSensorPage(info));
            }

            if (info.Type == SensorTypes.ProximitySensorType)
            {
                //await Navigation.PushAsync(new ProximitySensorPage(info));
                Window.Instance.GetDefaultNavigator().Push(new ProximitySensorPage(info));
            }

            if (info.Type == SensorTypes.RotationVectorSensorType)
            {
                //await Navigation.PushAsync(new RotationVectorSensorPage(info));
                Window.Instance.GetDefaultNavigator().Push(new RotationVectorSensorPage(info));
            }

            if (info.Type == SensorTypes.RunningActivityDetectorType)
            {
                //await Navigation.PushAsync(new RunningActivityDetectorPage(info));
                Window.Instance.GetDefaultNavigator().Push(new RunningActivityDetectorPage(info));
            }

            if (info.Type == SensorTypes.SleepMonitorType)
            {
                //await Navigation.PushAsync(new SleepMonitorPage(info));
                Window.Instance.GetDefaultNavigator().Push(new SleepMonitorPage(info));
            }

            if (info.Type == SensorTypes.StationaryActivityDetectorType)
            {
                //await Navigation.PushAsync(new StationaryActivityDetectorPage(info));
                Window.Instance.GetDefaultNavigator().Push(new StationaryActivityDetectorPage(info));
            }

            if (info.Type == SensorTypes.TemperatureSensorType)
            {
                //await Navigation.PushAsync(new TemperatureSensorPage(info));
                Window.Instance.GetDefaultNavigator().Push(new TemperatureSensorPage(info));
            }

            if (info.Type == SensorTypes.UltravioletSensorType)
            {
                //await Navigation.PushAsync(new UltravioletSensorPage(info));
                Window.Instance.GetDefaultNavigator().Push(new UltravioletSensorPage(info));
            }

            if (info.Type == SensorTypes.UncalibratedGyroscopeType)
            {
                //await Navigation.PushAsync(new UncalibratedGyroscopePage(info));
                Window.Instance.GetDefaultNavigator().Push(new UncalibratedGyroscopePage(info));
            }

            if (info.Type == SensorTypes.UncalibratedMagnetometerType)
            {
                //await Navigation.PushAsync(new UncalibratedMagnetometerPage(info));
                Window.Instance.GetDefaultNavigator().Push(new UncalibratedMagnetometerPage(info));
            }

            if (info.Type == SensorTypes.WalkingActivityDetectorType)
            {
                //await Navigation.PushAsync(new WalkingActivityDetectorPage(info));
                Window.Instance.GetDefaultNavigator().Push(new WalkingActivityDetectorPage(info));
            }

            if (info.Type == SensorTypes.WristUpGestureDetectorType)
            {
                //await Navigation.PushAsync(new WristUpGestureDetectorPage(info));
                Window.Instance.GetDefaultNavigator().Push(new WristUpGestureDetectorPage(info));
            }
        }
    }
}
