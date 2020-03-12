using FractalPainting.App.Fractals;

namespace FractalPainting.Infrastructure.Common
{
    public interface IDragonPainterFactory
    {
        DragonPainter Create(DragonSettings dragonSettings);
    }
}
