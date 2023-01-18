using Tizen.NUI;
using static Location.LocationServices;

namespace Location.Tizen.Mobile
{
    class Program : NUIApplication
    {
        /// <summary>
        /// This method called when the application created.
        /// </summary>
        protected override void OnCreate()
        {
            base.OnCreate();

            Window window = Window.Instance;
            window.BackgroundColor = Color.Cyan;
            window.KeyEvent += OnKeyEvent;

            InitializePage page = new InitializePage();
            page.PositionUsesPivotPoint = true;
            page.ParentOrigin = ParentOrigin.Center;
            page.PivotPoint = PivotPoint.Center;
            page.Size = new Size(window.WindowSize);
            window.Add(page);
        }

        public void OnKeyEvent(object sender, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Down && (e.Key.KeyPressedName == "XF86Back" || e.Key.KeyPressedName == "Escape"))
            {
                Exit();
            }
        }

        /// <summary>
        /// The main entrance of the application.
        /// </summary>
        /// <param name="args">The <see cref="string"/> arguments.</param>
        static void Main(string[] args)
        {
            var app = new Program();
            app.Run(args);
        }
    }
}
