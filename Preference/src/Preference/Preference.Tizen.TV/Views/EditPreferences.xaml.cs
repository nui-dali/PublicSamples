/*
 * Copyright (c) 2018 Samsung Electronics Co., Ltd. All rights reserved.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using Preference.ViewModels;
using Preference.Interfaces;
using Preference.TV.Views;
using System;
using Tizen.NUI;
using Tizen.NUI.Components;
using Tizen.NUI.Binding;
using Tizen.NUI.BaseComponents;

namespace Preference.TV.Views
{
    /// <summary>
    /// EditPreferences class.
    /// </summary>
    public partial class EditPreferences : IPage
    {
        #region properties

        /// <summary>
        /// EditPreferencesViewModel instance.
        /// </summary>
        public EditPreferencesViewModel ViewModel = new EditPreferencesViewModel();

        private Toast toast1;
        private Toast toast2;
        private Toast toast3;

        #endregion

        #region methods

        /// <summary>
        /// Class constructor.
        /// </summary>
        public EditPreferences()
        {
            ViewModel.NameValue = "abc";
            ViewModel.SurnameValue = "def";
            ViewModel.AgeValue = "29";
            ViewModel.HeightValue = "169";
            BindingContext = ViewModel;
            InitializeComponent();
            BindEvents();
        }

        /// <summary>
        /// Binds events.
        /// </summary>
        private void BindEvents()
        {
            ViewModel.OnSaveCompleteEvent += OnSaved;
            ViewModel.OnLoadCompleteEvent += OnLoaded;
            ViewModel.OnInvalidDataEvent += OnDataError;
        }

        /// <summary>
        /// Displays information about save success operation using Toast Message.
        /// </summary>
        /// <param name="sender">ViewModel instance. Not used.</param>
        /// <param name="arg">Event arguments. Not used.</param>
        public void OnSaved(object sender, EventArgs arg)
        {
            toast1 = Toast.FromText("Preferences saved.", 1000);
            toast1.Size = new Size(700, 132);
            toast1.Post(NUIApplication.GetDefaultWindow());
        }

        /// <summary>
        /// Displays information about load success operation using Toast Message.
        /// </summary>
        /// <param name="sender">ViewModel instance. Not used.</param>
        /// <param name="args">Event arguments. Not used.</param>
        public void OnLoaded(object sender, EventArgs args)
        {
            toast2 = Toast.FromText("Preferences loaded.", 1000);
            toast2.Size = new Size(700, 132);
            toast2.Post(NUIApplication.GetDefaultWindow());
        }

        /// <summary>
        /// Displays information about invalid data provided by user using Toast Message.
        /// </summary>
        /// <param name="sender">ViewModel instance. Not used.</param>
        /// <param name="args">Event arguments. Not used.</param>
        public void OnDataError(object sender, EventArgs args)
        {
            toast3 = Toast.FromText("Invalid data.", 1000);
            toast3.Size = new Size(700, 132);
            toast3.Post(NUIApplication.GetDefaultWindow());
        }

        #endregion
    }
}