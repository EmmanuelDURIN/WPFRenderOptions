using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace DemoTextOptions
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            // Possible to use Software rendering.
            // See App.OnStartup
            //   RenderOptions.ProcessRenderMode = System.Windows.Interop.RenderMode.SoftwareOnly;
            // See
            // https://stackoverflow.com/questions/4951058/software-rendering-mode-wpf
            InitializeComponent();
            // Ajout d'une valuer par défaut en début de liste
            itemsControlRenderModes.ItemsSource = new List<RenderMode> { null }.Concat(
                ((Enum.GetValues(typeof(EdgeMode))) as IEnumerable<EdgeMode>)
                .SelectMany
                (
                    em => ((Enum.GetValues(typeof(BitmapScalingMode))) as IEnumerable<BitmapScalingMode>)
                        .Select
                        (
                            bsm => new RenderMode
                            {
                                BitmapScalingMode = bsm,
                                EdgeMode = em
                            }
                        )
                )
                .SelectMany
                (
                    tm => ((Enum.GetValues(typeof(ClearTypeHint))) as IEnumerable<ClearTypeHint>)
                           .Select
                           (
                                cht =>
                                   {
                                       tm.ClearTypeHint = cht;
                                       return tm;
                                   }
                           )
                )
                );
        }
    }
}
