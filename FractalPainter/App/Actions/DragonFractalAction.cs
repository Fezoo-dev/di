using System;
using FractalPainting.App.Fractals;
using FractalPainting.Infrastructure.Common;
using FractalPainting.Infrastructure.UiActions;
using Ninject;

namespace FractalPainting.App.Actions
{
    // using DragonFactoryType = IDragonPainterFactory
    using DragonFactoryType = Func<DragonSettings, DragonPainter>;

    public class DragonFractalAction : IUiAction
    {
        //private DragonFactoryType dragonPainterFactory;
        private DragonFactoryType dragonPainterFactory;

        public DragonFractalAction(DragonFactoryType dragonPainterFactory)
        {
            this.dragonPainterFactory = dragonPainterFactory;
        }

        public string Category => "Фракталы";
        public string Name => "Дракон";
        public string Description => "Дракон Хартера-Хейтуэя";

        public void Perform()
        {
            var dragonSettings = CreateRandomSettings();
            SettingsForm.For(dragonSettings).ShowDialog();
            dragonPainterFactory(dragonSettings)
                .Paint();
        }

        private static DragonSettings CreateRandomSettings()
        {
            return new DragonSettingsGenerator(new Random()).Generate();
        }
    }
}