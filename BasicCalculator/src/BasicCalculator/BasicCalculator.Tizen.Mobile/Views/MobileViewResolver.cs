/*
 * Copyright (c) 2017 Samsung Electronics Co., Ltd. All rights reserved.
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

using BasicCalculator.Tizen.Mobile.Views;
using BasicCalculator.Views;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;

[assembly: Dependency(typeof(MobileViewResolver))]

namespace BasicCalculator.Tizen.Mobile.Views
{
    /// <summary>
    /// View resolver class to obtain views for selected device.
    /// </summary>
    public class MobileViewResolver : IViewResolver
    {
        #region fields

        /// <summary>
        /// Main page object reference used by <see cref="GetRootPage"/> method.
        /// </summary>
        private View _mainPage;

        #endregion fields

        #region methods

        /// <summary>
        /// Creates the MainPage on first execution and then returns it's reference.
        /// </summary>
        /// <returns>MainPage object.</returns>
        public View GetRootPage()
        {
            return _mainPage ?? (_mainPage = new MobileMainView());
        }

        #endregion methods
    }
}
