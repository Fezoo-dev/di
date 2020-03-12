using System;
using System.Windows.Forms;
using FractalPainting.App.Actions;
using FractalPainting.App.Fractals;
using FractalPainting.Infrastructure.Common;
using FractalPainting.Infrastructure.UiActions;
using Ninject;
using Ninject.Extensions.Factory;

namespace FractalPainting.App
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            try
            {
                var container = new StandardKernel();

                // start here
                container.Bind<IImageHolder, PictureBoxImageHolder>()
                    .To<PictureBoxImageHolder>()
                    .InSingletonScope();
                container.Bind<Palette>().ToSelf().InSingletonScope();

                container.Bind<IUiAction>().To<SaveImageAction>().InSingletonScope();
                container.Bind<IUiAction>().To<DragonFractalAction>().InSingletonScope();
                container.Bind<IUiAction>().To<KochFractalAction>().InSingletonScope();
                container.Bind<IUiAction>().To<ImageSettingsAction>().InSingletonScope();
                container.Bind<IUiAction>().To<PaletteSettingsAction>().InSingletonScope();

                //container.Bind<IDragonPainterFactory>().ToFactory();

                //container.Bind<IImageHolder>().To<>();
                //container.Bind<Palette>().To();

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(container.Get<MainForm>());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}